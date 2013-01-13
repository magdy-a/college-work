using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultipleQueue.Distributions;
using MultipleQueue.Simulation;

namespace MultipleQueue.Entities
{
    /// <summary>
    /// Represents a single server instance.
    /// </summary>
    public class Server
    {
        #region Attributes

        /// <summary>
        /// The service time distribution
        /// </summary>
        private IDistribution serviceTimeDistribution;

        /// <summary>
        /// The busy flag
        /// </summary>
        private bool isBusy;

        /// <summary>
        /// The server pirority
        /// </summary>
        private int? priority;

        /// <summary>
        /// Server busy time list
        /// </summary>
        private List<ServerBusyTime> serverStatusList;

        /// <summary>
        /// Total service time for all customers served at this server
        /// </summary>
        private float totalServiceTime;

        private float utilization;

        private int totalCustomerServed = 0;

        ///// <summary>
        ///// This server's Idle line
        ///// </summary>
        //private float idle_ZGraph_Line;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the server status list.
        /// </summary>
        /// <value>
        /// The server status list.
        /// </value>
        public List<ServerBusyTime> ServerStatusList
        {
            get { return serverStatusList; }
            set { serverStatusList = value; }
        }

        /// <summary>
        /// Gets Service Time Distribution
        /// </summary>
        public IDistribution ServiceTimeDistribution
        {
            get { return this.serviceTimeDistribution; }
        }

        /// <summary>
        /// Gets or sets the total customer served.
        /// </summary>
        /// <value>
        /// The total customer served.
        /// </value>
        public int TotalCustomerServed
        {
            get { return totalCustomerServed; }
            set { totalCustomerServed = value; }
        }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority.
        /// </value>
        public int? Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        /// <summary>
        /// Gets or sets the utilization of the server.
        /// </summary>
        /// <value>
        /// The utilization.
        /// </value>
        public float Utilization
        {
            get { return utilization; }
            set { utilization = value; }
        }

        /// <summary>
        /// Gets the average service time.
        /// </summary>
        public float AverageServiceTime
        {
            get { return this.TotalServiceTime / this.TotalCustomerServed; }
        }

        /// <summary>
        /// Gets the total service time for all customers served at this server.
        /// </summary>
        public float TotalServiceTime
        {
            get { return totalServiceTime; }
        }

        ///// <summary>
        ///// Gets this server's idle line
        ///// </summary>
        //public float idle_ZGraph_Line
        //{
        //    get { return idle_ZGraph_Line; }
        //}

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="serviceTimeDistribution">The service time distribution.</param>
        /// <param name="priority">The priority.</param>
        public Server(IDistribution serviceTimeDistribution, int? priority)
        {
            this.serviceTimeDistribution = serviceTimeDistribution;
            this.isBusy = false;
            this.priority = priority;
            this.totalServiceTime = 0;
            this.ServerStatusList = new List<ServerBusyTime>();
        }

        /// <summary>
        /// Gets the next server time distribution.
        /// </summary>
        /// <returns></returns>
        public float GetNextServerTimeDistribution()
        {
            float randomVariable = LCGRandomNumberGenerator.GetVariate();
            float serviceTime = this.serviceTimeDistribution.GetValue(randomVariable);
            this.totalServiceTime += serviceTime;
            return serviceTime;
        }
    }
}
