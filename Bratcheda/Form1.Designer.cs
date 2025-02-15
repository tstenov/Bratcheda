namespace Bratcheda
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
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            bntClaculate = new Button();
            label3 = new Label();
            bntClear = new Button();
            label4 = new Label();
            comboBox1 = new ComboBox();
            bntList = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(12, 62);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(182, 629);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(198, 188);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1202, 503);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(288, 62);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(326, 87);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // bntClaculate
            // 
            bntClaculate.Location = new Point(198, 148);
            bntClaculate.Name = "bntClaculate";
            bntClaculate.Size = new Size(112, 34);
            bntClaculate.TabIndex = 4;
            bntClaculate.Text = "Calculate";
            bntClaculate.UseVisualStyleBackColor = true;
            bntClaculate.Click += bntClaculate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(198, 62);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 5;
            label3.Text = "Selected";
            // 
            // bntClear
            // 
            bntClear.Location = new Point(316, 148);
            bntClear.Name = "bntClear";
            bntClear.Size = new Size(270, 34);
            bntClear.TabIndex = 6;
            bntClear.Text = "Clear selected in the list";
            bntClear.UseVisualStyleBackColor = true;
            bntClear.Click += bntClear_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(198, 87);
            label4.Name = "label4";
            label4.Size = new Size(131, 25);
            label4.TabIndex = 7;
            label4.Text = "Selected Count";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(898, 33);
            comboBox1.TabIndex = 8;
            // 
            // bntList
            // 
            bntList.Location = new Point(930, 12);
            bntList.Name = "bntList";
            bntList.Size = new Size(46, 33);
            bntList.TabIndex = 9;
            bntList.Text = "Go";
            bntList.UseVisualStyleBackColor = true;
            bntList.Click += bntList_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.DarkOliveGreen;
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(881, 159);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 10;
            label5.Text = "min value";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Red;
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(975, 159);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 11;
            label6.Text = "max value";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(881, 102);
            label7.Name = "label7";
            label7.Size = new Size(519, 25);
            label7.TabIndex = 12;
            label7.Text = "Note1 - 'SelectedNo' on power of two is less than max in the list";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(881, 127);
            label8.Name = "label8";
            label8.Size = new Size(379, 25);
            label8.TabIndex = 13;
            label8.Text = "Note2 - 'SelectedNo' square root  is an integer";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1414, 723);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(bntList);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(bntClear);
            Controls.Add(label3);
            Controls.Add(bntClaculate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private ListBox listBox1;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Button bntClaculate;
        private Label label3;
        private Button bntClear;
        private Label label4;
        private ComboBox comboBox1;
        private Button bntList;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
