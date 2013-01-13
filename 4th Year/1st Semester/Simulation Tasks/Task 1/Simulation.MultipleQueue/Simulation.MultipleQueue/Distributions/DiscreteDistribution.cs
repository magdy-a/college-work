namespace MultipleQueue.Distributions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DiscreteDistribution : IDistribution
    {
        /// <summary>
        /// List of Probabilities
        /// </summary>
        private List<float> probabilities;

        /// <summary>
        /// List of Values
        /// </summary>
        private List<float> values;

        /// <summary>
        /// List of CumulativeProbabilities
        /// </summary>
        private List<float> cumulativeProbabilities;

        /// <summary>
        /// Gets the Probabilities of this Distribution
        /// </summary>
        public List<float> Probabilities
        {
            get { return this.probabilities; }
        }

        /// <summary>
        /// Gets the Values of this Distribution
        /// </summary>
        public List<float> Values
        {
            get { return this.values; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscreteDistribution"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="probabilities">The probabilities.</param>
        public DiscreteDistribution(List<float> values, List<float> probabilities)
        {
            this.probabilities = probabilities;

            this.values = values;

            this.cumulativeProbabilities = new List<float>();

            float sum = 0;

            for (int i = 0; i < this.probabilities.Count; i++)
            {
                sum += this.probabilities[i];
                this.cumulativeProbabilities.Add(sum);
            }
        }

        /// <summary>
        /// Gets the val.
        /// </summary>
        /// <param name="randomVariable">The random variable.</param>
        /// <returns></returns>
        public float GetValue(float randomVariable)
        {
            int i;
            for (i = 0; randomVariable > this.cumulativeProbabilities[i]; i++)
                ;//Empty loop
            return this.values[i];
        }

        public DistributionTypes GetMyType()
        {
            return DistributionTypes.Discrete;
        }
    }
}
