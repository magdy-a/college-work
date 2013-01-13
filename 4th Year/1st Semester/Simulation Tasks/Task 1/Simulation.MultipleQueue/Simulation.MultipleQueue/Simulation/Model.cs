namespace MultipleQueue.Simulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MultipleQueue.Entities;
    using MultipleQueue.Distributions;
    using System.Windows.Forms;

    public class Model
    {
        #region Attributes

        /// <summary>
        /// Number of servers
        /// </summary>
        private int serversCount;

        /// <summary>
        /// The server priority rule
        /// </summary>
        private ServerSelection serverSelection;

        /// <summary>
        /// Customers inter-arrival distribution
        /// </summary>
        private IDistribution customerInterArrivalDistribution;

        /// <summary>
        /// Number of customer at which to stop simulation.
        /// </summary>
        private int customerCountStoppingCondition;

        /// <summary>
        /// max clock at which to stop simulation.
        /// </summary>
        private int maxClockStoppingCondition;

        /// <summary>
        /// List of servers
        /// </summary>
        private List<Server> servers;

        /// <summary>
        /// The customers queue, the queue is changed with time according to the current number of customer waiting.
        /// </summary>
        private Queue<Customer> customerQueue;

        /// <summary>
        /// The list of customers who finished their service.
        /// </summary>
        private List<Customer> completedCustomers;

        /// <summary>
        /// Contains the future events sorted by time ASC
        /// </summary>
        private SortedList<Customer, EventType> eventsList;

        /// <summary>
        /// Gets or sets the probability that a customer will wait in the system.
        /// </summary>
        /// <value>
        /// The probability of wait.
        /// </value>
        private float probabilityOfWait = 0;

        /// <summary>
        /// The clock of the simulation, changes to the time of the next event with every cycle of the run loop
        /// </summary>
        private float clock;

        /// <summary>
        /// Carries the Last Event Happend in the System
        /// </summary>
        private EventType lastEvent;

        /// <summary>
        /// Carries the Customer Along with the Last Event Happend in the System
        /// </summary>
        private Customer lastCustomer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets Carries the Last Event Happend in the System
        /// </summary>
        internal EventType LastEvent
        {
            get { return this.lastEvent; }
        }

        /// <summary>
        /// Gets the Customer Along with the Last Event Happend in the System
        /// </summary>
        public Customer LastCustomer
        {
            get { return this.lastCustomer; }
        }

        /// <summary>
        /// Number of servers
        /// </summary>
        public int ServersCount
        {
            get { return serversCount; }
            set { serversCount = value; }
        }

        /// <summary>
        /// The server priority rule
        /// </summary>
        public ServerSelection ServerSelection
        {
            get { return serverSelection; }
            set { serverSelection = value; }
        }

        /// <summary>
        /// Number of customer at which to stop simulation.
        /// </summary>
        public int CustomerCountStoppingCondition
        {
            get { return customerCountStoppingCondition; }
            set { customerCountStoppingCondition = value; }
        }

        /// <summary>
        /// max clock at which to stop simulation.
        /// </summary>
        public int MaxClockStoppingCondition
        {
            get { return maxClockStoppingCondition; }
            set { maxClockStoppingCondition = value; }
        }

        /// <summary>
        /// The customers queue, the queue is changed with time according to the current number of customer waiting.
        /// </summary>
        public Queue<Customer> CustomerQueue
        {
            get { return customerQueue; }
            set { customerQueue = value; }
        }

        /// <summary>
        /// The list of customers who finished their service.
        /// </summary>
        public List<Customer> CompletedCustomers
        {
            get { return completedCustomers; }
            set { completedCustomers = value; }
        }

        /// <summary>
        /// Contains the future events sorted by time ASC
        /// </summary>
        internal SortedList<Customer, EventType> EventsList
        {
            get { return eventsList; }
            set { eventsList = value; }
        }

        /// <summary>
        /// The clock of the simulation, changes to the time of the next event with every cycle of the run loop
        /// </summary>
        public float Clock
        {
            get { return clock; }
            set { clock = value; }
        }

        /// <summary>
        /// Average waiting time of customers in the system
        /// </summary>
        private float averageWaitingTime = 0;

        /// <summary>
        /// Gets or sets the average waiting time of customers in the system.
        /// </summary>
        /// <value>
        /// The average waiting time.
        /// </value>
        public float AverageWaitingTime
        {
            get { return averageWaitingTime; }
            set { averageWaitingTime = value; }
        }

        /// <summary>
        /// Gets or sets the probability that a customer will wait in the system.
        /// </summary>
        /// <value>
        /// The probability of wait.
        /// </value>
        public float ProbabilityOfWait
        {
            get { return probabilityOfWait; }
            set { probabilityOfWait = value; }
        }

        /// <summary>
        /// Gets the servers.
        /// </summary>
        public List<Server> Servers
        {
            get { return servers; }
        }

        /// <summary>
        /// Gets a boolean that indicates if the Model is complete or not
        /// </summary>
        public bool IsComplete
        {
            get { return ((this.completedCustomers.Count >= this.customerCountStoppingCondition) || (this.clock >= this.maxClockStoppingCondition)) ? true : false; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="priorityType">Type of the priority.</param>
        /// <param name="customerInterArrivalDistribution">The customer inter arrival distribution.</param>
        /// <param name="servers">The servers.</param>
        /// <param name="customerCountStoppingCondition">The customer count stopping condition.</param>
        /// <param name="lcgRandomNumberGenerator">The LCG random number generator.</param>
        public Model(ServerSelection serverSelection,
            IDistribution customerInterArrivalDistribution,
            List<Server> servers, int customerCountStoppingCondition, int maxClockTime)
        {
            this.customerInterArrivalDistribution = customerInterArrivalDistribution;
            this.serverSelection = serverSelection;
            this.serversCount = servers.Count;
            this.customerCountStoppingCondition = customerCountStoppingCondition;
            this.maxClockStoppingCondition = maxClockTime;
            this.completedCustomers = new List<MultipleQueue.Entities.Customer>();
            this.customerQueue = new Queue<MultipleQueue.Entities.Customer>();
            this.eventsList = new SortedList<MultipleQueue.Entities.Customer, EventType>();
            this.servers = servers;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //initialize clock time
            clock = 0;

            //Generate initial arrival Time
            //1-generate the first event -> get next customer

            // use LCGRandomNumberGenerator to generate inter-arrival time for the customer
            float interArrivalTime = this.customerInterArrivalDistribution.GetValue(LCGRandomNumberGenerator.GetVariate());

            // return the new customer object
            Customer newCustomer = new Customer(interArrivalTime, clock, 1);

            //2-add arrival event in the events list
            eventsList.Add(newCustomer, EventType.Arrival);
        }

        /// <summary>
        /// Generates the customer.
        /// </summary>
        /// <returns></returns>
        private Customer GenerateCustomer(int lastCustmerNumber)
        {
            // use LCGRandomNumberGenerator to generate inter-arrival time for the customer
            float interArrivalTime = this.customerInterArrivalDistribution.GetValue(LCGRandomNumberGenerator.GetVariate());

            // return the new customer object
            return new Customer(interArrivalTime, clock + interArrivalTime, lastCustmerNumber + 1);
        }

        /// <summary>
        /// Arrives the customer.
        /// </summary>
        /// <param name="arrivingCustomer">The arriving customer.</param>
        private void ArriveCustomer(Customer arrivingCustomer)
        {
            // Tmp Server Index
            int tmpServerIndex;

            //set clock
            clock = arrivingCustomer.ArrivalTime;

            // Set IsArrived True
            arrivingCustomer.IsArrived = true;

            // Set LastEvent
            this.lastEvent = EventType.Arrival;

            // Set LastCustomer Along with the LastEvent
            this.lastCustomer = arrivingCustomer;

            // Remove First Event
            this.eventsList.RemoveAt(0);

            //select a server, if any are available
            tmpServerIndex = serverSelection.GetServerByPriority(servers, clock);

            //enter queue or assign to a server
            if (tmpServerIndex != -1)
            {
                // Assign to Server
                AssignCustomerToServer(arrivingCustomer, tmpServerIndex);
            }
            else
            {
                // Enter Queue
                this.customerQueue.Enqueue(arrivingCustomer);
            }

            //schedule arrival of next customer
            Customer newCustomer = GenerateCustomer(arrivingCustomer.CustomerNumber);
            //customerQueue.Enqueue(newCustomer);
            this.eventsList.Add(newCustomer, EventType.Arrival);
        }

        /// <summary>
        /// Departs the customer.
        /// </summary>
        /// <param name="departingCustomer">The departing customer.</param>
        private void DepartCustomer(Customer departingCustomer)
        {
            int tmpServerIndex;

            //Set the clock to the current event.
            this.clock = departingCustomer.DepartureTime;

            // Set LastEvent
            this.lastEvent = EventType.Departure;

            // Set LastCustomer Along with the LastEvent
            this.lastCustomer = departingCustomer;

            // Remove First Event
            this.eventsList.RemoveAt(0);
            
            //The server is no longer busy.
            this.servers[departingCustomer.ServerIndex].IsBusy = false;
            
            //Add the departed customer to the list of completed customers.
            this.completedCustomers.Add(departingCustomer);

            //enter another customer to the servers, 
            //but still by ServerSelection because maybe a more efficient server is idle too.
            tmpServerIndex = serverSelection.GetServerByPriority(this.servers, clock);

            // Enter a customer to server
            if (customerQueue.Count > 0)
            {
                AssignCustomerToServer(customerQueue.Dequeue(), tmpServerIndex);
            }

            //We know that serverIndex should not be -1 because a server just go IDLE.
            //But we are using server Selection cause maybe another server is IDLE too, and better
        }

        /// <summary>
        /// Assigns the customer to server.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="serverIndex">Index of the server.</param>
        private void AssignCustomerToServer(Customer customer, int serverIndex)
        {
            // update customer's data
            customer.ServerIndex = serverIndex;
            customer.ServiceTime = servers[serverIndex].GetNextServerTimeDistribution();
            customer.WaitTime = clock - customer.ArrivalTime;

            // Add new ServerBusyTime to ServerStatusList in the currentServer
            servers[serverIndex].ServerStatusList.Add(new ServerBusyTime(clock, clock + customer.ServiceTime));

            // schedule the departure of this customer

            // The Departure is the Arrival + Time UntilAssignedToServer + Service Time
            //customer.DepartureTime = customer.ArrivalTime + (clock - customer.ArrivalTime) + customer.ServiceTime;

            customer.DepartureTime = clock + customer.ServiceTime;
            this.eventsList.Add(customer, EventType.Departure);

            // update this server's statistics
            servers[serverIndex].TotalCustomerServed++;
            servers[serverIndex].IsBusy = true;
        }

        /// <summary>
        /// Move to the Next Event
        /// </summary>
        public bool Next()
        {
            if (IsComplete)
            {
                return false;
            }

            switch (eventsList.Values[0])
            {
                case EventType.Arrival:
                    ArriveCustomer(eventsList.Keys[0]);
                    break;
                case EventType.Departure:
                    DepartCustomer(eventsList.Keys[0]);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Calculates the system performance.
        /// </summary>
        public void CalculateSystemPerformance()
        {
            throw new NotImplementedException(@"Implement CalculateSystemPerformance in Simulation\Model.cs");

            //Calculate the value system performance measures
        }
    }
}
