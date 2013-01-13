namespace Bearing_Machine.Simulation
{
    using System.Collections.Generic;

    public class SimulationManager
    {
        public static int SIMULATION_RUNS { get; set; }

        private List<CurrentModule> currentModules;
        private List<ProposedModule> proposedModules;

        public List<CurrentModule> CurrentModules
        {
            get { return this.currentModules; }
        }

        public List<ProposedModule> ProposedModules
        {
            get { return proposedModules; }
        }

        public SimulationManager()
        {
            this.currentModules = new List<CurrentModule>();
            this.proposedModules = new List<ProposedModule>();
        }

        public void StartSimulation()
        {
            CurrentModule tmpCurrent;
            ProposedModule tmpProposed;

            // Loop with the Range I have and send every range to the a new Model to run
            for (int i = 0; i < SIMULATION_RUNS; i++)
            {
                tmpCurrent = new CurrentModule();
                tmpCurrent.Run();

                // TODO Don't send the Pointer of the tmpCurrent to the Proposed Method, cause I need to change in it
                tmpProposed = new ProposedModule(tmpCurrent);
                tmpProposed.Run();

                this.currentModules.Add(tmpCurrent);
                this.proposedModules.Add(tmpProposed);
            }
        }
    }
}