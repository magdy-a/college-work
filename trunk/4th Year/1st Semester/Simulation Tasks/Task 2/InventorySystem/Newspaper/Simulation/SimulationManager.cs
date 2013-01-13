namespace Newspaper.Simulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newspaper.Distributions;

    public class SimulationManager
    {
        private IDistribution NewsdaysDistribution;
        private List<IDistribution> DemandDistribution;

        private int start, end, range;

        private float purchasePrice, sellingPrice, scrapValue;

        private List<Model> modelList;

        public List<Model> Models
        {
            get { return this.modelList; }
        }

        public int Range
        {
            get { return this.range; }
        }

        public int End
        {
            get { return end; }
        }

        public int Start
        {
            get { return start; }
        }

        public SimulationManager(int simuStart, int simuEnd, float purPrice, float slPrice, float scrpValue, IDistribution daysDistribution, List<IDistribution> dmndDistribution)
        {
            this.start = simuStart;
            this.end = simuEnd;
            this.range = ((end - start) / 10) + 1;

            this.purchasePrice = purPrice;
            this.sellingPrice = slPrice;
            this.scrapValue = scrpValue;

            this.NewsdaysDistribution = daysDistribution;
            this.DemandDistribution = dmndDistribution;

            modelList = new List<Model>(this.range);
        }

        public void StartSimulation()
        {
            // Loop with the Range I have and send every range to the a new Model to run
            for (int i = 0; i < range; i++)
            {
                modelList.Add(new Model(this.purchasePrice, this.sellingPrice, this.scrapValue, start + (i * 10), this.NewsdaysDistribution, this.DemandDistribution));
                modelList[i].Run();
            }
        }
    }
}