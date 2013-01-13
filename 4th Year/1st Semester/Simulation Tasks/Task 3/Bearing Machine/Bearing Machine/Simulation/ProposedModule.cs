namespace Bearing_Machine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proposed Module Class
    /// </summary>
    public class ProposedModule : Module
    {
        /// <summary>
        /// First Failure for all the bearings
        /// </summary>
        private List<int> firstFailure;

        /// <summary>
        /// The Acc Life for all the Bearings
        /// </summary>
        private List<int> accLife;

        /// <summary>
        /// The Delay in the ProposedModule Item
        /// </summary>
        private List<int> delay;

        /// <summary>
        /// Initializes a new instance of the ProposedModule class
        /// </summary>
        /// <param name="currentModule">The Current Module to take the data from</param>
        public ProposedModule(CurrentModule currentModule)
        {
            Table = new List<List<BearingItem>>();

            for (int i = 0; i < currentModule.Table.Count; i++)
            {
                Table.Add(new List<BearingItem>());

                foreach (BearingItem t in currentModule.Table[i])
                {
                    Table[i].Add((BearingItem)t.Clone());
                }
            }

            this.firstFailure = new List<int>();
            this.accLife = new List<int>();
            this.delay = new List<int>();
        }

        /// <summary>
        /// Gets The Delay in the ProposedModule Item
        /// </summary>
        public List<int> Delay
        {
            get { return this.delay; }
        }

        /// <summary>
        /// Gets First Failure for all the bearings
        /// </summary>
        public List<int> FirstFailure
        {
            get { return this.firstFailure; }
        }

        /// <summary>
        /// Gets The Acc Life for all the Bearings
        /// </summary>
        public List<int> AccLife
        {
            get { return this.accLife; }
        }

        /// <summary>
        /// The Run Function of Module
        /// </summary>
        public override void Run()
        {
            int tmpFirstFailure, tmpAccLife;
            int index;

            // Initalize all with ZERO
            tmpFirstFailure = tmpAccLife = index = 0;

            // For the Simulation Hours
            while (tmpAccLife < Module.SIMULATION_HOURS)
            {
                // Foreach List of Bearings if index doesn't exist, create one
                foreach (List<BearingItem> list in Table)
                {
                    if (list.Count <= index)
                    {
                        list.Add(BearingItem.CreateBearingItem());
                    }
                }

                tmpFirstFailure = Math.Min(Table[0][index].LifeHours, Math.Min(Table[1][index].LifeHours, Table[2][index].LifeHours));
                tmpAccLife += tmpFirstFailure;

                this.firstFailure.Add(tmpFirstFailure);
                this.accLife.Add(tmpAccLife);
                this.delay.Add((int)Module.DIST_DELAY_TIME.GetValue(Simulation.LCGRandomNumberGenerator.GetVariate()));

                index++;
            }

            CreateStatistics();
        }

        /// <summary>
        /// Creates the Statistics and the performance measure for the module
        /// </summary>
        protected override void CreateStatistics()
        {
            StatNumOfBearings = this.firstFailure.Count * NUM_OF_BEARINGS_IN_MACHINE;
            StatDelayTotal = this.delay.Sum();

            StatCostBearings = StatNumOfBearings * COST_BEARING;
            StatCostDelayTime = StatDelayTotal * COST_DOWNTIME_PER_MIN;
            StatCostDownTime = StatNumOfBearings / NUM_OF_BEARINGS_IN_MACHINE * TIME_CHANGE_THREE_BEARINGS * COST_DOWNTIME_PER_MIN;
            StatCostRepairpersons = StatNumOfBearings / NUM_OF_BEARINGS_IN_MACHINE * TIME_CHANGE_THREE_BEARINGS * COST_DIRECT_ONSITE_REPAIRPERSON_Per_Hour / 60;
            StatCostTotal = StatCostBearings + StatCostDelayTime + StatCostDownTime + StatCostRepairpersons;
        }
    }
}