namespace Bearing_Machine
{
    using System.Collections.Generic;
    using Bearing_Machine.Distributions;

    /// <summary>
    /// Abstract Module Class
    /// </summary>
    public abstract class Module
    {
        #region Members

        /// <summary>
        /// The Table cantains the data of the current Module
        /// </summary>
        private List<List<BearingItem>> table;

        /// <summary>
        /// Number of Bearings changed through the whole simulation
        /// </summary>
        private int statNumOfBearings;

        /// <summary>
        /// Total delay time through the whole simulation
        /// </summary>
        private int statDelayTotal;

        /// <summary>
        /// Cost of Bearings bought
        /// </summary>
        private int statCostBearings;

        /// <summary>
        /// Cost of Delay time
        /// </summary>
        private int statCostDelayTime;

        /// <summary>
        /// Cost of Down time loss
        /// </summary>
        private int statCostDownTime;

        /// <summary>
        /// Cost of Repairperson pay
        /// </summary>
        private int statCostRepairpersons;

        /// <summary>
        /// The StatCostTotal Cost
        /// </summary>
        private int statCostTotal;

        #endregion

        #region Static Members

        /// <summary>
        /// Gets or sets Simulation Hours
        /// </summary>
        public static int SIMULATION_HOURS { get; set; }

        /// <summary>
        /// Gets or sets the number of bearings in the machine
        /// </summary>
        public static int NUM_OF_BEARINGS_IN_MACHINE { get; set; }

        /// <summary>
        /// Gets or sets Each Bearing Cost
        /// </summary>
        public static int COST_BEARING { get; set; }

        /// <summary>
        /// Gets or sets Downtime Cost/Min
        /// </summary>
        public static int COST_DOWNTIME_PER_MIN { get; set; }

        /// <summary>
        /// Gets or sets Direct on-site Cost for the Repairperson
        /// </summary>
        public static int COST_DIRECT_ONSITE_REPAIRPERSON_Per_Hour { get; set; }

        /// <summary>
        /// Gets or sets Time to change one Bearing
        /// </summary>
        public static int TIME_CHANGE_ONE_BEARING { get; set; }

        /// <summary>
        /// Gets or sets Time to change two Bearing
        /// </summary>
        public static int TIME_CHANGE_TWO_BEARINGS { get; set; }

        /// <summary>
        /// Gets or sets Time to change three Bearing
        /// </summary>
        public static int TIME_CHANGE_THREE_BEARINGS { get; set; }

        /// <summary>
        /// Gets or sets Bearing Lift Discrete Distribution
        /// </summary>
        public static DiscreteDistribution DIST_BEARING_LIFE { get; set; }

        /// <summary>
        /// Gets or sets Delay Time Discrete Distribution
        /// </summary>
        public static DiscreteDistribution DIST_DELAY_TIME { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets The Table cantains the data of the current Module
        /// </summary>
        public List<List<BearingItem>> Table
        {
            get { return this.table; }
            protected set { this.table = value; }
        }

        /// <summary>
        /// Gets Number of Bearings changed through the whole simulation
        /// </summary>
        public int StatNumOfBearings
        {
            get { return statNumOfBearings; }
            protected set { statNumOfBearings = value; }
        }

        /// <summary>
        /// Gets Total delay time through the whole simulation
        /// </summary>
        public int StatDelayTotal
        {
            get { return statDelayTotal; }
            protected set { statDelayTotal = value; }
        }

        /// <summary>
        /// Gets Cost of Bearings bought
        /// </summary>
        public int StatCostBearings
        {
            get { return this.statCostBearings; }
            protected set { this.statCostBearings = value; }
        }

        /// <summary>
        /// Gets Cost of Delay time
        /// </summary>
        public int StatCostDelayTime
        {
            get { return this.statCostDelayTime; }
            protected set { this.statCostDelayTime = value; }
        }

        /// <summary>
        /// Gets Cost of Down time loss
        /// </summary>
        public int StatCostDownTime
        {
            get { return this.statCostDownTime; }
            protected set { this.statCostDownTime = value; }
        }

        /// <summary>
        /// Gets Cost of Repairperson pay
        /// </summary>
        public int StatCostRepairpersons
        {
            get { return this.statCostRepairpersons; }
            protected set { this.statCostRepairpersons = value; }
        }

        /// <summary>
        /// Gets The StatCostTotal Cost
        /// </summary>
        public int StatCostTotal
        {
            get { return this.statCostTotal; }
            protected set { this.statCostTotal = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The Run Function of Module
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Creates the Statistics and the performance measure for the module
        /// </summary>
        protected abstract void CreateStatistics();

        #endregion
    }
}