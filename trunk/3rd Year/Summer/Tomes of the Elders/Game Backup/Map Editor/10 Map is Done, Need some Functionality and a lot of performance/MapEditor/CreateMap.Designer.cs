namespace MapEditor
{
    partial class CreateMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.TxtMapSizeWidth = new System.Windows.Forms.TextBox();
            this.txtNumOfFloors = new System.Windows.Forms.TextBox();
            this.txtMapSizeHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurrentFloor = new System.Windows.Forms.TextBox();
            this.txtLoadData = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Num Of Floors";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(140, 219);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(116, 42);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go Dude";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // TxtMapSizeWidth
            // 
            this.TxtMapSizeWidth.Location = new System.Drawing.Point(140, 24);
            this.TxtMapSizeWidth.Name = "TxtMapSizeWidth";
            this.TxtMapSizeWidth.Size = new System.Drawing.Size(55, 22);
            this.TxtMapSizeWidth.TabIndex = 3;
            this.TxtMapSizeWidth.Text = "1000";
            // 
            // txtNumOfFloors
            // 
            this.txtNumOfFloors.Location = new System.Drawing.Point(140, 74);
            this.txtNumOfFloors.Name = "txtNumOfFloors";
            this.txtNumOfFloors.Size = new System.Drawing.Size(116, 22);
            this.txtNumOfFloors.TabIndex = 3;
            this.txtNumOfFloors.Text = "16";
            // 
            // txtMapSizeHeight
            // 
            this.txtMapSizeHeight.Location = new System.Drawing.Point(201, 24);
            this.txtMapSizeHeight.Name = "txtMapSizeHeight";
            this.txtMapSizeHeight.Size = new System.Drawing.Size(55, 22);
            this.txtMapSizeHeight.TabIndex = 3;
            this.txtMapSizeHeight.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Current Floor";
            // 
            // txtCurrentFloor
            // 
            this.txtCurrentFloor.Location = new System.Drawing.Point(140, 127);
            this.txtCurrentFloor.Name = "txtCurrentFloor";
            this.txtCurrentFloor.Size = new System.Drawing.Size(116, 22);
            this.txtCurrentFloor.TabIndex = 3;
            this.txtCurrentFloor.Text = "7";
            // 
            // txtLoadData
            // 
            this.txtLoadData.Location = new System.Drawing.Point(140, 177);
            this.txtLoadData.Name = "txtLoadData";
            this.txtLoadData.Size = new System.Drawing.Size(116, 22);
            this.txtLoadData.TabIndex = 3;
            this.txtLoadData.Text = "Click To Open";
            this.txtLoadData.Click += new System.EventHandler(this.txtLoadData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Load Data";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CreateMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 273);
            this.Controls.Add(this.txtLoadData);
            this.Controls.Add(this.txtCurrentFloor);
            this.Controls.Add(this.txtNumOfFloors);
            this.Controls.Add(this.txtMapSizeHeight);
            this.Controls.Add(this.TxtMapSizeWidth);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "CreateMap";
            this.Text = "CreateMap";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CreateMap_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox TxtMapSizeWidth;
        internal System.Windows.Forms.TextBox txtNumOfFloors;
        internal System.Windows.Forms.TextBox txtMapSizeHeight;
        internal System.Windows.Forms.TextBox txtCurrentFloor;
        internal System.Windows.Forms.TextBox txtLoadData;
    }
}