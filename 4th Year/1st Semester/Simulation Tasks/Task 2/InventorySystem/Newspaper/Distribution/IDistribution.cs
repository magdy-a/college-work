namespace Newspaper.Distributions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains supported distributions
    /// </summary>
    public enum DistributionTypes
    {
        /// <summary>
        /// Uniform Distribution
        /// </summary>
        Uniform,
        /// <summary>
        /// Discrete Distribution
        /// </summary>
        Discrete,
        /// <summary>
        /// Exponential Distribution
        /// </summary>
        Exponential
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDistribution
    {
        DistributionTypes GetMyType();

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="randomVariable">The random variable.</param>
        /// <returns></returns>
        float GetValue(float randomVariable);
    }
}
