namespace MultipleQueue.Simulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ServerSelection
    {
        /// <summary>
        /// Server Seclection Types
        /// </summary>
        public enum ServerSelectionTypes
        {
            HighestPriority,
            LowestUtilization,
            Random
        }

        private ServerSelectionTypes priorityType;

        public ServerSelection(ServerSelectionTypes priorityType)
        {
            this.priorityType = priorityType;
        }

        public int GetServerByPriority(List<Entities.Server> servers, float clock)
        {
            // List of Not Busy Servers
            List<Entities.Server> notBusyServers = new List<Entities.Server>();

            // I is the Index of the First Server To finish
            int i;

            // Check for Max Value in Not Busy List
            int tmpInt, tmpIndex = 0;
            float tmpFloat;

            // Get all not busy Servers
            for (i = 0; i < servers.Count; i++)
            {
                if (servers[i].IsBusy == false)
                {
                    notBusyServers.Add(servers[i]);
                }
            }

            // If at least one server no busy
            if (notBusyServers.Count > 0)
            {
                // switch (this.priorityType)
                    // HighestPriority
                    // Random
                    // LowestUtilization

                // If Not Busy Servers contains only one Server
                if (notBusyServers.Count == 1)
                {
                    // Return it's Index (In the Big List)
                    return servers.IndexOf(notBusyServers[0]);
                }

                switch (this.priorityType)
                {
                    case ServerSelectionTypes.HighestPriority:

                        tmpInt = (int)notBusyServers[0].Priority;
                        tmpIndex = 0;

                        for (i = 1; i < notBusyServers.Count; i++)
                        {
                            if (notBusyServers[i].Priority > tmpInt)
                            {
                                tmpInt = (int)notBusyServers[i].Priority;
                                tmpIndex = i;
                            }
                        }

                        break;

                    case ServerSelectionTypes.Random:

                        // Get random Index in Not Busy List
                        tmpIndex = new Random().Next(notBusyServers.Count);

                        break;

                    case ServerSelectionTypes.LowestUtilization:

                        tmpFloat = notBusyServers[0].TotalServiceTime;
                        tmpInt = 0;

                        for (i = 1; i < notBusyServers.Count; i++)
                        {
                            if (notBusyServers[i].TotalServiceTime > tmpFloat)
                            {
                                tmpFloat = notBusyServers[i].TotalServiceTime;
                                tmpInt = i;
                            }
                        }

                        tmpIndex = tmpInt;

                        break;
                }

                // Get the Same Index in the BigList
                return servers.IndexOf(notBusyServers[tmpIndex]);
            }
            else
            {
                // return an indicator that there is no server
                 return -1;
            }
        }
    }
}
