namespace MultipleQueue.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a server's serving time (busy time).
    /// </summary>
    public class ServerBusyTime
    {
        float fromTime;

        float toTime;

        /// <summary>
        /// Gets or sets from time.
        /// </summary>
        /// <value>
        /// From time.
        /// </value>
        public float FromTime
        {
            get { return fromTime; }
            set { fromTime = value; }
        }

        /// <summary>
        /// Gets or sets to time.
        /// </summary>
        /// <value>
        /// To time.
        /// </value>
        public float ToTime
        {
            get { return toTime; }
            set { toTime = value; }
        }

        //public float Duration
        //{
        //    get { return toTime - fromTime; }
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerBusyTime"/> class.
        /// </summary>
        /// <param name="fromTime">From time.</param>
        /// <param name="toTime">To time.</param>
        public ServerBusyTime(float fromTime, float toTime)
        {
            this.fromTime = fromTime;
            this.toTime = toTime;
        }

    }
}
