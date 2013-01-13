namespace Bearing_Machine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Current Module Class
    /// </summary>
    public class CurrentModule : Module
    {
        /// <summary>
        /// Initializes a new instance of the CurrentModule class
        /// </summary>
        public CurrentModule()
        {
        }

        /// <summary>
        /// Creates a table for the Current Module
        /// </summary>
        public override void Run()
        {
            // Create New Table
            Table = new List<List<BearingItem>>();

            // For the Number of Bearings, get a bearing life foreach
            for (int i = 0; i < Module.NUM_OF_BEARINGS_IN_MACHINE; i++)
            {
                // Create Life Bearing and add it
                Table.Add(BearingItem.CreateBearingLife());
            }

            CreateStatistics();
        }

        /// <summary>
        /// Creates the Statistics and the performance measure for the module
        /// </summary>
        protected override void CreateStatistics()
        {
            StatNumOfBearings = 0;
            StatDelayTotal = 0;

            foreach (List<BearingItem> bearing in Table)
            {
                StatNumOfBearings += bearing.Count;

                foreach (BearingItem t in bearing)
                {
                    StatDelayTotal += t.Delay;
                }
            }

            StatCostBearings = StatNumOfBearings * COST_BEARING;
            StatCostDelayTime = StatDelayTotal * COST_DOWNTIME_PER_MIN;
            StatCostDownTime = StatNumOfBearings * TIME_CHANGE_ONE_BEARING * COST_DOWNTIME_PER_MIN;
            StatCostRepairpersons = StatNumOfBearings * TIME_CHANGE_ONE_BEARING * COST_DIRECT_ONSITE_REPAIRPERSON_Per_Hour / 60;
            StatCostTotal = StatCostBearings + StatCostDelayTime + StatCostDownTime + StatCostRepairpersons;
        }
    }
}