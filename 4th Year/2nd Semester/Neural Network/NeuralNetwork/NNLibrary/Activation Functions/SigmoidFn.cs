namespace NNLibrary.ActivationFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Sigmoid Function
    /// </summary>
    public class SigmoidFn : ActivationFunction
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the SigmoidFn class.
        /// </summary>
        public SigmoidFn()
        {
            this.V = this.Net = 0;
        }

        #endregion Constructor

        #region Overrided Functions

        /// <summary>
        /// Adds another value for the v parameter
        /// </summary>
        /// <param name="vk">value to be summed to the v parameter</param>
        public override void Add(double vk)
        {
            this.V += vk;
        }

        /// <summary>
        /// Calculate the result
        /// </summary>
        /// <returns>The Result of the Calculation</returns>
        public override double Calc_Normal()
        {
            double result;

            Net = V;

            result = 1 / (1 + Math.Exp((-1 * Alpha) * Net));

            result = (result < 0) ? 0 : (result > 1) ? 1 : result;

            // Clear V parameter for next calucation
            this.V = 0;

            return result;
        }

        /// <summary>
        /// Calculate the first derivative for the result
        /// </summary>
        /// <param name="result_Normal">Result of the Normal Calculation</param>
        /// <returns>The result of the FirstDerivative Calculation Process</returns>
        public override double Calc_FirstDerivative(double result_Normal)
        {
            return result_Normal = result_Normal * (1 - result_Normal);
        }

        #endregion Overrided Functions
    }
}