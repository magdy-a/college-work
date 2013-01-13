namespace Bearing_Machine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Bearing_Machine.Simulation;

    /// <summary>
    /// Bearing Class
    /// </summary>
    public class BearingItem : ICloneable
    {
        /// <summary>
        /// The Life Hours of the Bearing
        /// </summary>
        private int lifeHours;

        /// <summary>
        /// The Accumulated Life Hours of the Bearing
        /// </summary>
        private int accLifeHours;

        /// <summary>
        /// The Delay the Repairperson arrival
        /// </summary>
        private int delay;

        /// <summary>
        /// Initializes a new instance of the BearingItem class
        /// </summary>
        public BearingItem()
        {
            this.lifeHours = 0;
            this.accLifeHours = 0;
        }

        /// <summary>
        /// Gets The Life Hours of the Bearing
        /// </summary>
        public int LifeHours
        {
            get { return this.lifeHours; }
        }

        /// <summary>
        /// Gets The Accumulated Life Hours of the Bearing
        /// </summary>
        public int AccLifeHours
        {
            get { return this.accLifeHours; }
        }

        /// <summary>
        /// Gets The Delay the Repairperson arrival
        /// </summary>
        public int Delay
        {
            get { return this.delay; }
        }

        /// <summary>
        /// Creates a new Life for a Bearing
        /// </summary>
        /// <returns>List of BearingItem Object</returns>
        public static List<BearingItem> CreateBearingLife()
        {
            List<BearingItem> life = new List<BearingItem>();

            int tmpAccLife;

            BearingItem tmpBearingItem;

            tmpAccLife = 0;

            while (tmpAccLife < Module.SIMULATION_HOURS)
            {
                // Create New Object
                tmpBearingItem = new BearingItem();

                // Life Hours
                tmpBearingItem.lifeHours = (int)Module.DIST_BEARING_LIFE.GetValue(LCGRandomNumberGenerator.GetVariate());

                // Acc Life Hours
                tmpAccLife += tmpBearingItem.lifeHours;

                tmpBearingItem.accLifeHours = tmpAccLife;

                // Delay
                tmpBearingItem.delay = (int)Module.DIST_DELAY_TIME.GetValue(LCGRandomNumberGenerator.GetVariate());

                // Add to List
                life.Add(tmpBearingItem);
            }

            return life;
        }

        /// <summary>
        /// Creates a new stand alone Bering Item, mostly for the Proposed Module
        /// </summary>
        /// <returns>Bearing Item</returns>
        public static BearingItem CreateBearingItem()
        {
            BearingItem tmp = new BearingItem();

            tmp.lifeHours = (int)Module.DIST_BEARING_LIFE.GetValue(Simulation.LCGRandomNumberGenerator.GetVariate());
            tmp.accLifeHours = tmp.lifeHours;
            tmp.delay = (int)Module.DIST_DELAY_TIME.GetValue(Simulation.LCGRandomNumberGenerator.GetVariate());

            return tmp;
        }

        /// <summary>
        /// Creates a Shallow Copy of this Bearing Item Object
        /// </summary>
        /// <returns>Shallow Copy of this Object</returns>
        public object Clone()
        {
            BearingItem tmp = new BearingItem();

            tmp.lifeHours = this.lifeHours;
            tmp.accLifeHours = this.accLifeHours;
            tmp.delay = this.delay;

            return tmp;
        }
    }
}