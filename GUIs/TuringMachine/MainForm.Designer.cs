namespace TuringMachine
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbMoveFun = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbCurState = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtCurBaenders = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbCurZeichen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbCurState = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pControl = new System.Windows.Forms.Panel();
            this.lStepCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numImageSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numSteps = new System.Windows.Forms.NumericUpDown();
            this.bFull = new System.Windows.Forms.Button();
            this.bStep = new System.Windows.Forms.Button();
            this.bCompile = new System.Windows.Forms.Button();
            this.tbError = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numBaender = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbInputBand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurState)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaender)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1002, 417);
            this.splitContainer2.SplitterDistance = 536;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbMoveFun);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 417);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Method (One method per line)";
            // 
            // tbMoveFun
            // 
            this.tbMoveFun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMoveFun.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMoveFun.Location = new System.Drawing.Point(3, 16);
            this.tbMoveFun.Multiline = true;
            this.tbMoveFun.Name = "tbMoveFun";
            this.tbMoveFun.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMoveFun.Size = new System.Drawing.Size(530, 398);
            this.tbMoveFun.TabIndex = 2;
            this.tbMoveFun.Text = resources.GetString("tbMoveFun.Text");
            this.tbMoveFun.TextChanged += new System.EventHandler(this.tbMoveFun_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbCurState);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.splitContainer3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 145);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output (Current State of the Machine)";
            // 
            // pbCurState
            // 
            this.pbCurState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCurState.Location = new System.Drawing.Point(3, 181);
            this.pbCurState.Name = "pbCurState";
            this.pbCurState.Size = new System.Drawing.Size(456, 0);
            this.pbCurState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurState.TabIndex = 1;
            this.pbCurState.TabStop = false;
            this.pbCurState.Click += new System.EventHandler(this.pbCurState_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtCurBaenders);
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(456, 165);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "The Bänders";
            // 
            // rtCurBaenders
            // 
            this.rtCurBaenders.CausesValidation = false;
            this.rtCurBaenders.DetectUrls = false;
            this.rtCurBaenders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtCurBaenders.Enabled = false;
            this.rtCurBaenders.Location = new System.Drawing.Point(3, 71);
            this.rtCurBaenders.Name = "rtCurBaenders";
            this.rtCurBaenders.ReadOnly = true;
            this.rtCurBaenders.Size = new System.Drawing.Size(450, 91);
            this.rtCurBaenders.TabIndex = 0;
            this.rtCurBaenders.Text = "";
            this.rtCurBaenders.WordWrap = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 55);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbCurZeichen);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(450, 26);
            this.panel6.TabIndex = 16;
            // 
            // tbCurZeichen
            // 
            this.tbCurZeichen.BackColor = System.Drawing.Color.White;
            this.tbCurZeichen.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbCurZeichen.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurZeichen.Location = new System.Drawing.Point(86, 0);
            this.tbCurZeichen.Name = "tbCurZeichen";
            this.tbCurZeichen.ReadOnly = true;
            this.tbCurZeichen.Size = new System.Drawing.Size(87, 22);
            this.tbCurZeichen.TabIndex = 4;
            this.tbCurZeichen.Text = "~";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Current Zeichen:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbCurState);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(450, 26);
            this.panel5.TabIndex = 15;
            // 
            // tbCurState
            // 
            this.tbCurState.BackColor = System.Drawing.Color.White;
            this.tbCurState.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbCurState.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurState.Location = new System.Drawing.Point(75, 0);
            this.tbCurState.Name = "tbCurState";
            this.tbCurState.ReadOnly = true;
            this.tbCurState.Size = new System.Drawing.Size(98, 22);
            this.tbCurState.TabIndex = 4;
            this.tbCurState.Text = "~";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Current State: ";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Size = new System.Drawing.Size(456, 126);
            this.splitContainer3.SplitterDistance = 149;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pControl);
            this.groupBox1.Controls.Add(this.tbError);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 272);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings and Errors";
            // 
            // pControl
            // 
            this.pControl.Controls.Add(this.lStepCount);
            this.pControl.Controls.Add(this.label8);
            this.pControl.Controls.Add(this.numImageSize);
            this.pControl.Controls.Add(this.label7);
            this.pControl.Controls.Add(this.numSteps);
            this.pControl.Controls.Add(this.bFull);
            this.pControl.Controls.Add(this.bStep);
            this.pControl.Controls.Add(this.bCompile);
            this.pControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pControl.Location = new System.Drawing.Point(3, 245);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(456, 23);
            this.pControl.TabIndex = 6;
            // 
            // lStepCount
            // 
            this.lStepCount.AutoSize = true;
            this.lStepCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.lStepCount.Location = new System.Drawing.Point(-43, 0);
            this.lStepCount.Name = "lStepCount";
            this.lStepCount.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.lStepCount.Size = new System.Drawing.Size(50, 16);
            this.lStepCount.TabIndex = 11;
            this.lStepCount.Text = "Steps: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(7, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Image size";
            // 
            // numImageSize
            // 
            this.numImageSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.numImageSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numImageSize.Location = new System.Drawing.Point(74, 0);
            this.numImageSize.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.numImageSize.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numImageSize.Name = "numImageSize";
            this.numImageSize.Size = new System.Drawing.Size(55, 20);
            this.numImageSize.TabIndex = 8;
            this.numImageSize.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(129, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "X:";
            // 
            // numSteps
            // 
            this.numSteps.Dock = System.Windows.Forms.DockStyle.Right;
            this.numSteps.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSteps.Location = new System.Drawing.Point(156, 0);
            this.numSteps.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSteps.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSteps.Name = "numSteps";
            this.numSteps.Size = new System.Drawing.Size(55, 20);
            this.numSteps.TabIndex = 6;
            this.numSteps.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // bFull
            // 
            this.bFull.Dock = System.Windows.Forms.DockStyle.Right;
            this.bFull.Location = new System.Drawing.Point(211, 0);
            this.bFull.Name = "bFull";
            this.bFull.Size = new System.Drawing.Size(85, 23);
            this.bFull.TabIndex = 5;
            this.bFull.Text = "Skip X steps";
            this.bFull.UseVisualStyleBackColor = true;
            this.bFull.Click += new System.EventHandler(this.bFull_Click);
            // 
            // bStep
            // 
            this.bStep.Dock = System.Windows.Forms.DockStyle.Right;
            this.bStep.Location = new System.Drawing.Point(296, 0);
            this.bStep.Name = "bStep";
            this.bStep.Size = new System.Drawing.Size(75, 23);
            this.bStep.TabIndex = 4;
            this.bStep.Text = "Next step";
            this.bStep.UseVisualStyleBackColor = true;
            this.bStep.Click += new System.EventHandler(this.bStep_Click);
            // 
            // bCompile
            // 
            this.bCompile.Dock = System.Windows.Forms.DockStyle.Right;
            this.bCompile.Location = new System.Drawing.Point(371, 0);
            this.bCompile.Name = "bCompile";
            this.bCompile.Size = new System.Drawing.Size(85, 23);
            this.bCompile.TabIndex = 10;
            this.bCompile.Text = "Compile";
            this.bCompile.UseVisualStyleBackColor = true;
            this.bCompile.Click += new System.EventHandler(this.bCompile_Click);
            // 
            // tbError
            // 
            this.tbError.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbError.Location = new System.Drawing.Point(3, 149);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.ReadOnly = true;
            this.tbError.Size = new System.Drawing.Size(456, 96);
            this.tbError.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 133);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label5.Size = new System.Drawing.Size(456, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Errors";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(456, 22);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numBaender);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(121, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(200, 22);
            this.panel1.TabIndex = 1;
            // 
            // numBaender
            // 
            this.numBaender.Dock = System.Windows.Forms.DockStyle.Left;
            this.numBaender.Location = new System.Drawing.Point(142, 0);
            this.numBaender.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBaender.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBaender.Name = "numBaender";
            this.numBaender.Size = new System.Drawing.Size(54, 20);
            this.numBaender.TabIndex = 0;
            this.numBaender.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBaender.ValueChanged += new System.EventHandler(this.numBaender_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount of Extra Bänders:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(101, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(20, 22);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(52, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(10, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Empty:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(32, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(20, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbInputBand);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 95);
            this.panel2.TabIndex = 2;
            // 
            // tbInputBand
            // 
            this.tbInputBand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInputBand.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInputBand.Location = new System.Drawing.Point(0, 16);
            this.tbInputBand.Multiline = true;
            this.tbInputBand.Name = "tbInputBand";
            this.tbInputBand.Size = new System.Drawing.Size(456, 79);
            this.tbInputBand.TabIndex = 2;
            this.tbInputBand.Text = "(~,1,1,0,1)";
            this.tbInputBand.TextChanged += new System.EventHandler(this.numBaender_ValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(456, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input Band";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 417);
            this.Controls.Add(this.splitContainer2);
            this.Name = "MainForm";
            this.Text = "Turing Machine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCurState)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pControl.ResumeLayout(false);
            this.pControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaender)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbMoveFun;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtCurBaenders;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbCurZeichen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbCurState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numImageSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numSteps;
        private System.Windows.Forms.Button bFull;
        private System.Windows.Forms.Button bStep;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numBaender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbInputBand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbCurState;
        private System.Windows.Forms.Button bCompile;
        private System.Windows.Forms.Label lStepCount;
    }
}