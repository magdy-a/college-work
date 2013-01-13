namespace NeuralNetwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using NNLibrary;
    using NNLibrary.MLPProblems;

    /// <summary>
    /// Neural Network Project
    /// </summary>
    public partial class NNProject : Form
    {
        #region Static Members

        /// <summary>
        /// Multilayer Perceptron Solver
        /// </summary>
        private static MultiLayerPerceptron solverMLP;

        #endregion Static Members

        #region Members

        /// <summary>
        /// Multilayer Perceptron Problem
        /// </summary>
        private MLPProblem problem;

        #endregion Members

        DateTime before;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NNProject class.
        /// </summary>
        public NNProject()
        {
            this.InitializeComponent();

            this.cmbProblem.Items.AddRange(Enum.GetNames(typeof(ProblemType)));
            this.cmbProblem.SelectedItem = ProblemType.OCR.ToString();

            //////this.problem = new XORProblem();
            //this.problem = new OCR("DIGITS.ASC", "digitsTarget.asc");

            //NNProject.solverMLP = new MultiLayerPerceptron(this.problem);

            //DateTime before;
            //TimeSpan durationTraining, durationTesting;

            //before = DateTime.Now;

            //int y = NNProject.solverMLP.RunTraining();

            //durationTraining = DateTime.Now - before;

            //before = DateTime.Now;

            //double x = NNProject.solverMLP.RunTesting();

            //durationTesting = DateTime.Now - before;

            //string message = "Epochs: " + y + "\n" + "Percentage: " + x.ToString() + "%\n";
            //message += durationTraining.TotalMinutes.ToString() + " : " + durationTraining.Seconds.ToString() + "\n";
            //////message += durationTesting.TotalMinutes.ToString() + " : " + durationTesting.Seconds;

            //MessageBox.Show(message);
        }

        #endregion Constructor

        private void cmbProblem_SelectedValueChanged(object sender, EventArgs e)
        {
            ProblemType tmpType = (ProblemType)Enum.Parse(typeof(ProblemType), this.cmbProblem.SelectedItem.ToString());

            if (tmpType == ProblemType.OCR)
            {
                this.btnOpenSamplesFile.Enabled = this.btnOpenResultsFile.Enabled = true;

                this.txtSamplesFile.Text = "DIGITS.ASC";
                this.txtResultsFile.Text = "digitsTarget.asc";

                this.txtEtaMin.Text = "0.1";
                this.txtEtaMax.Text = "0.9";

                this.txtMinError.Text = "0.0001";

                this.nudMaxEpochs.Value = 1000;

                this.nudSamplesNum.Value = 200;
                this.nudTestingNum.Value = 20;

                this.nudInputs.Value = OCR.defaultInputElements;
                this.nudOutputs.Value = OCR.defaultOutputElements;

                this.txtHiddenLayers.Text = string.Empty;
                OCR.defaultHiddenLayers.ForEach(myInt => this.txtHiddenLayers.Text += myInt.ToString() + ',');
                this.txtHiddenLayers.Text = this.txtHiddenLayers.Text.Remove(this.txtHiddenLayers.Text.Length - 1);
            }
            else if (tmpType == ProblemType.XOR)
            {
                this.btnOpenSamplesFile.Enabled = this.btnOpenResultsFile.Enabled = false;

                this.txtSamplesFile.Text = string.Empty;
                this.txtResultsFile.Text = string.Empty;

                this.txtEtaMin.Text = "0.1";
                this.txtEtaMax.Text = "0.9";

                this.txtMinError.Text = "0.000001";

                this.nudMaxEpochs.Value = 30000;

                this.nudSamplesNum.Value = 200;
                this.nudTestingNum.Value = 20;

                this.nudInputs.Value = XORProblem.defaultInputElements;
                this.nudOutputs.Value = XORProblem.defaultOutputElements;

                this.txtHiddenLayers.Text = string.Empty;
                XORProblem.defaultHiddenLayers.ForEach(myInt => this.txtHiddenLayers.Text += myInt.ToString() + ',');
                this.txtHiddenLayers.Text = this.txtHiddenLayers.Text.Remove(this.txtHiddenLayers.Text.Length - 1);
            }
        }

        private string OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return string.Empty;
            }
        }

        private void btnOpenSamplesFile_Click(object sender, EventArgs e)
        {
            this.txtSamplesFile.Text = this.OpenFile();
        }

        private void btnOpenResultsFile_Click(object sender, EventArgs e)
        {
            this.txtResultsFile.Text = this.OpenFile();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            switch ((ProblemType)Enum.Parse(typeof(ProblemType), this.cmbProblem.SelectedItem.ToString()))
            {
                case ProblemType.OCR:
                    this.problem = new OCR((int)this.nudSamplesNum.Value, this.txtSamplesFile.Text, this.txtResultsFile.Text);
                    break;
                case ProblemType.XOR:
                    this.problem = new XORProblem((int)this.nudSamplesNum.Value);
                    break;
            }

            this.problem.SetValues(this.txtEtaMin.Text, this.txtMinError.Text, this.nudMaxEpochs.Value, this.nudTestingNum.Value);

            solverMLP = new MultiLayerPerceptron(this.problem);

            before = DateTime.Now;

            solverMLP.RunTraining();

            //new Thread(solverMLP.RunTraining).Start();

            this.txtCurrentEpochNum.Text = solverMLP.EpochsUsed.ToString();
            this.txtCurrentError.Text = solverMLP.ErrorPerEpoch[solverMLP.EpochsUsed - 1].ToString();
            this.txtElapsedTime.Text = (DateTime.Now - before).ToString();
        }

        private void btnTestAll_Click(object sender, EventArgs e)
        {
            solverMLP.RunTesting();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.problem.TestingNum = (int)this.nudTestingNum.Value;
            this.txtTestResult.Text = solverMLP.RunTesting().ToString() + "%";
        }

        private void btnTestIndex_Click(object sender, EventArgs e)
        {
            solverMLP.ForwardPass((int)this.nudTestIndex.Value++);

            this.txtTestResult.Text = solverMLP.CheckCurrentOutput(int.Parse(this.nudTestIndex.Text)) ? "T" : "F";
        }

        private void btnChangeArchitecture_Click(object sender, EventArgs e)
        {
            switch ((ProblemType)Enum.Parse(typeof(ProblemType), this.cmbProblem.SelectedItem.ToString()))
            {
                case ProblemType.OCR:
                    OCR.defaultInputElements = (int)this.nudInputs.Value;
                    OCR.defaultOutputElements = (int)this.nudOutputs.Value;

                    OCR.defaultHiddenLayers = new List<int>();
                    this.txtHiddenLayers.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(hiddenLayer => OCR.defaultHiddenLayers.Add(int.Parse(hiddenLayer)));
                    break;
                case ProblemType.XOR:
                    XORProblem.defaultInputElements = (int)this.nudInputs.Value;
                    XORProblem.defaultOutputElements = (int)this.nudOutputs.Value;

                    XORProblem.defaultHiddenLayers = new List<int>();
                    this.txtHiddenLayers.Text.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(hiddenLayer => XORProblem.defaultHiddenLayers.Add(int.Parse(hiddenLayer)));
                    break;
            }
        }
    }
}