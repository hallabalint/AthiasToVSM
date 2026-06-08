namespace AthiasToVSM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lbIP = new Label();
            lbPort = new Label();
            lbDescription = new Label();
            label6 = new Label();
            dgPages = new DataGridView();
            SetActive = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgPages).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 22);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "Ember+ port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 47);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Anthias IP:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 102);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 2;
            label3.Text = "State:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Lime;
            label4.Location = new Point(127, 102);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Running";
            // 
            // lbIP
            // 
            lbIP.AutoSize = true;
            lbIP.ForeColor = SystemColors.ControlText;
            lbIP.Location = new Point(127, 47);
            lbIP.Name = "lbIP";
            lbIP.Size = new Size(52, 15);
            lbIP.TabIndex = 4;
            lbIP.Text = "Running";
            // 
            // lbPort
            // 
            lbPort.AutoSize = true;
            lbPort.ForeColor = SystemColors.ControlText;
            lbPort.Location = new Point(127, 22);
            lbPort.Name = "lbPort";
            lbPort.Size = new Size(52, 15);
            lbPort.TabIndex = 5;
            lbPort.Text = "Running";
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.ForeColor = SystemColors.ControlText;
            lbDescription.Location = new Point(127, 71);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(52, 15);
            lbDescription.TabIndex = 6;
            lbDescription.Text = "Running";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 71);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 7;
            label6.Text = "Description";
            // 
            // dgPages
            // 
            dgPages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgPages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgPages.Columns.AddRange(new DataGridViewColumn[] { SetActive });
            dgPages.Location = new Point(23, 138);
            dgPages.Name = "dgPages";
            dgPages.Size = new Size(765, 300);
            dgPages.TabIndex = 8;
            dgPages.CellContentClick += dgPages_CellContentClick;
            // 
            // SetActive
            // 
            SetActive.HeaderText = "Activate";
            SetActive.Name = "SetActive";
            SetActive.Text = "Set Active";
            SetActive.UseColumnTextForButtonValue = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgPages);
            Controls.Add(label6);
            Controls.Add(lbDescription);
            Controls.Add(lbPort);
            Controls.Add(lbIP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "AnthiasToVSM";
            ((System.ComponentModel.ISupportInitialize)dgPages).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbIP;
        private Label lbPort;
        private Label lbDescription;
        private Label label6;
        private DataGridView dgPages;
        private DataGridViewButtonColumn SetActive;
    }
}
