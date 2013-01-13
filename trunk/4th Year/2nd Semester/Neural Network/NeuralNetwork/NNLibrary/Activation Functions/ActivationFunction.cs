namespace NNLibrary.ActivationFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    #region Enumerators

    /// <summary>
    /// ActivationFunction Type, define wether normal function or it's FirstDerivative
    /// </summary>
    public enum ActivationFunctoinType
    {
        /// <summary>
        /// Noraml Activation Function for the forward pass
        /// </summary>
        Normal,

        /// <summary>
        /// The FirstDerivative of the Activation Function for the backward pass
        /// </summary>
        FirstDerivative
    }

    #endregion Enumerators

    /// <summary>
    /// Activation Function, an abstract class
    /// </summary>
    public abstract class ActivationFunction
    {
        #region Static Members

        /// <summary>
        /// Alpha is the slope parameter for the sigmoid Function
        /// </summary>
        private static double alpha = 1;

        #endregion Const Members

        #region Members

        /// <summary>
        /// The Parameter of the Function
        /// </summary>
        private double v;

        /// <summary>
        /// net Value for all summations
        /// </summary>
        private double net;

        #endregion Members

        #region Properites

        /// <summary>
        /// Gets or sets Alpha is the slope parameter for the sigmoid Function
        /// </summary>
        public static double Alpha
        {
            get { return ActivationFunction.alpha; }
            protected set { ActivationFunction.alpha = value; }
        }

        /// <summary>
        /// Gets or sets The Parameter of the Function
        /// </summary>
        public double V
        {
            get { return this.v; }
            protected set { this.v = value; }
        }

        /// <summary>
        /// Gets or sets net Value for all summations
        /// </summary>
        public double Net
        {
            get { return this.net; }
            protected set { this.net = value; }
        }

        #endregion Properites

        #region Abstract Functions

        /// <summary>
        /// Adds another value for the v parameter
        /// </summary>
        /// <param name="vk">value to be summed to the v parameter</param>
        public abstract void Add(double vk);

        /// <summary>
        /// Calculate the result
        /// </summary>
        /// <returns>The result of the Normal Calculation Process</returns>
        public abstract double Calc_Normal();

        /// <summary>
        /// Calculate the first derivative for the result
        /// </summary>
        /// <param name="result_Normal">Result of the Normal Calculation</param>
        /// <returns>The result of the FirstDerivative Calculation Process</returns>
        public abstract double Calc_FirstDerivative(double result_Normal);

        #endregion Functions
    }
}