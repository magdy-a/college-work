namespace Newspaper.Simulation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newspaper.Distributions;
using ZedGraph;

    /// <summary>
    /// Model Class
    /// </summary>
    public class Model
    {
        // Distributions
        private IDistribution NewsdaysDistribution;
        private List<IDistribution> DemandDistribution;

        // Vars
        private float purchasePrice, sellingPrice, profitInOneItem, inventoryPurchasePrice;

        private float scrapValue;
        private int inventory;

        private int totalDaysWithExcessDemand, totalDaysWithUnsoldPapers;

        static private int testDays = 20;
        static private int frequencyValueRange = 4;

        // Lists
        private List<string> type;

        private List<int> demand;

        private List<float> revenue, lost, salvage, profit;

        // Simulation
        private PointPairList dailyProfitChart;
        private PointPairList frequencyProfitChart;

        #region Properties

        static public int TestDays
        {
            get { return testDays; }
        }

        public List<string> Type
        {
            get { return type; }
        }

        public List<int> Demand
        {
            get { return demand; }
        }

        public List<float> Profit
        {
            get { return profit; }
        }

        public List<float> Salvage
        {
            get { return salvage; }
        }

        public List<float> Lost
        {
            get { return lost; }
        }

        public List<float> Revenue
        {
            get { return revenue; }
        }

        public int Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public float InventoryPurchasePrice
        {
            get { return inventoryPurchasePrice; }
        }

        public PointPairList DailyProfitChart
        {
            get { return dailyProfitChart; }
        }

        public PointPairList FrequencyProfitChart
        {
            get { return frequencyProfitChart; }
        }

        public int TotalDaysWithUnsoldPapers
        {
            get { return totalDaysWithUnsoldPapers; }
        }

        public int TotalDaysWithExcessDemand
        {
            get { return totalDaysWithExcessDemand; }
        }

        #endregion

        public Model(float purPrice, float slPrice, float scrpValue, int dmnd, IDistribution daysDistribution, List<IDistribution> dmndDistribution)
        {
            // Take Values
            this.purchasePrice = purPrice;
            this.sellingPrice = slPrice;
            this.profitInOneItem = this.sellingPrice - this.purchasePrice;

            this.scrapValue = scrpValue;

            this.inventory = dmnd;
            this.inventoryPurchasePrice = this.inventory * this.purchasePrice;

            this.NewsdaysDistribution = daysDistribution;
            this.DemandDistribution = dmndDistribution;

            this.totalDaysWithExcessDemand = 0;
            this.totalDaysWithUnsoldPapers = 0;

            // Create Lists
            type = new List<string>();
            demand = new List<int>();
            revenue = new List<float>();
            lost = new List<float>();
            salvage = new List<float>();
            profit = new List<float>();
        }

        public void Run()
        {
            int tmpType, tmpDemand;
            float tmpRevenue, tmplost, tmpsalvage, tmpProfit;

            for (int i = 0; i < testDays; i++)
            {
                // Type of Newsday
                tmpType = (int)NewsdaysDistribution.GetValue(LCGRandomNumberGenerator.GetVariate());

                // Demand
                tmpDemand = (int)DemandDistribution[tmpType].GetValue(LCGRandomNumberGenerator.GetVariate());

                // Revenue from Sales
                tmpRevenue = Math.Min(this.inventory, tmpDemand) * sellingPrice;

                // Lost Profit from excess demand && Salvage from Sales of Scrap
                if (tmpDemand >= inventory)// Excess Demand
                {
                    // Lost Profit
                    tmplost = (tmpDemand - inventory) * profitInOneItem;

                    // Salvage
                    tmpsalvage = 0;

                    this.totalDaysWithExcessDemand++;
                }
                else// Unsold Papers
                {
                    // Salvage
                    tmpsalvage = (inventory - tmpDemand) * scrapValue;

                    // Lost Profit
                    tmplost = 0;

                    this.totalDaysWithUnsoldPapers++;
                }

                // Daily Profit
                tmpProfit = tmpRevenue - inventoryPurchasePrice - tmplost + tmpsalvage;

                // Add Values to Lists
                type.Add(((NewsdayType)tmpType).ToString());
                demand.Add(tmpDemand);

                revenue.Add(tmpRevenue);

                lost.Add(tmplost);

                salvage.Add(tmpsalvage);

                profit.Add(tmpProfit);
            }

            // Statistics

            // Totals

            // Add Sums
            revenue.Add(revenue.Sum());
            lost.Add(lost.Sum());
            salvage.Add(salvage.Sum());
            profit.Add(profit.Sum());

            // Charts

            // Create Pane Axises
            double[] tmpDoubleX;
            double[] tmpDoubleY;

            // Daily Profit Chart
            // Set X Values, just once
            tmpDoubleX = new double[Model.testDays];
            for (int i = 0; i < Model.testDays; i++)
            {
                tmpDoubleX[i] = i + 1;
            }

            // Set Y Values, Daily Profit
            tmpDoubleY = Array.ConvertAll<float, double>(this.profit.Take(Model.testDays).ToArray(), new Converter<float, double>(Convert.ToDouble));

            dailyProfitChart = new PointPairList(tmpDoubleX, tmpDoubleY);

            // Frequncy Profit Chart
            // Get MinOnChart & MaxOnChart & RangeOnChart
            int minOnChart = GetFirstNumberDivisableByVar(profit.GetRange(0, Model.testDays).Min(), Model.frequencyValueRange);
            int maxOnChart = GetFirstNumberDivisableByVar(profit.GetRange(0, Model.testDays).Max(), Model.frequencyValueRange);
            int rangeOnChart = (maxOnChart - minOnChart) / Model.frequencyValueRange + 1;

            // Values On X Axis
            tmpDoubleX = new double[rangeOnChart];
            for (int i = 0; i < rangeOnChart; i++)
            {
                tmpDoubleX[i] = minOnChart + (i * Model.frequencyValueRange);
            }

            // Values On Y Axis
            tmpDoubleY = new double[rangeOnChart];
            for (int i = 0; i < rangeOnChart; i++)
            {
                tmpDoubleY[i] = GetCountOfOccurencesBetweenTwoVars(profit, (float)tmpDoubleX[i], (float)tmpDoubleX[i] + Model.frequencyValueRange);
            }

            frequencyProfitChart = new PointPairList(tmpDoubleX, tmpDoubleY);
        }

        private int GetFirstNumberDivisableByVar(float value, int origin)
        {
            bool isNegative = (value < 0) ? true : false;

            value = Math.Abs(value);
            value = (float)Math.Ceiling(value);

            while (true)
            {
                if (value % origin == 0)
                {
                    break;
                }

                value++;
            }

            return (isNegative) ? (-1 * (int)value) : (int)value;
        }

        private float GetCountOfOccurencesBetweenTwoVars(List<float> list, float min, float max)
        {
            float occurences = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= min && list[i] <= max)
                {
                    occurences++;
                }
            }

            return occurences;
        }
    }
}
