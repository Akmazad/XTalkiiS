namespace Xtalkiz
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_loadData = new System.Windows.Forms.Button();
            this.btnBatchExclusion_B = new System.Windows.Forms.Button();
            this.btnSingleExclusion_B = new System.Windows.Forms.Button();
            this.btnBatchInclusion_B = new System.Windows.Forms.Button();
            this.btnSingleInclusion_B = new System.Windows.Forms.Button();
            this.lboxSelected_B = new System.Windows.Forms.ListBox();
            this.lblSelectedPathways_B = new System.Windows.Forms.Label();
            this.lbxAllB = new System.Windows.Forms.ListBox();
            this.lblChosePathwayFrom_B = new System.Windows.Forms.Label();
            this.comBoxOrganismB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnGetGenes = new System.Windows.Forms.Button();
            this.btnBatchExclusion_A = new System.Windows.Forms.Button();
            this.btnSingleExclusion_A = new System.Windows.Forms.Button();
            this.btnBatchInclusion_A = new System.Windows.Forms.Button();
            this.btnSingleInclusion_A = new System.Windows.Forms.Button();
            this.lboxSelected_A = new System.Windows.Forms.ListBox();
            this.lbxAllA = new System.Windows.Forms.ListBox();
            this.lblSelectedPathways_A = new System.Windows.Forms.Label();
            this.lblChosePathwayFrom_A = new System.Windows.Forms.Label();
            this.comBoxOrganismA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog_OutputDir = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Lbl_KeggPathwayGenes = new System.Windows.Forms.Label();
            this.Lbl_KeggPathwayCrosstalks = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2001, 1117);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Lbl_KeggPathwayCrosstalks);
            this.panel3.Controls.Add(this.Lbl_KeggPathwayGenes);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(870, 6);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1127, 1106);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Location = new System.Drawing.Point(0, 504);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1121, 596);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Location = new System.Drawing.Point(0, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1121, 441);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_loadData);
            this.panel2.Controls.Add(this.btnBatchExclusion_B);
            this.panel2.Controls.Add(this.btnSingleExclusion_B);
            this.panel2.Controls.Add(this.btnBatchInclusion_B);
            this.panel2.Controls.Add(this.btnSingleInclusion_B);
            this.panel2.Controls.Add(this.lboxSelected_B);
            this.panel2.Controls.Add(this.lblSelectedPathways_B);
            this.panel2.Controls.Add(this.lbxAllB);
            this.panel2.Controls.Add(this.lblChosePathwayFrom_B);
            this.panel2.Controls.Add(this.comBoxOrganismB);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnGetGenes);
            this.panel2.Controls.Add(this.btnBatchExclusion_A);
            this.panel2.Controls.Add(this.btnSingleExclusion_A);
            this.panel2.Controls.Add(this.btnBatchInclusion_A);
            this.panel2.Controls.Add(this.btnSingleInclusion_A);
            this.panel2.Controls.Add(this.lboxSelected_A);
            this.panel2.Controls.Add(this.lbxAllA);
            this.panel2.Controls.Add(this.lblSelectedPathways_A);
            this.panel2.Controls.Add(this.lblChosePathwayFrom_A);
            this.panel2.Controls.Add(this.comBoxOrganismA);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 1106);
            this.panel2.TabIndex = 0;
            // 
            // btn_loadData
            // 
            this.btn_loadData.Location = new System.Drawing.Point(273, 938);
            this.btn_loadData.Name = "btn_loadData";
            this.btn_loadData.Size = new System.Drawing.Size(298, 69);
            this.btn_loadData.TabIndex = 18;
            this.btn_loadData.Text = "Load gene dependency data";
            this.btn_loadData.UseVisualStyleBackColor = true;
            this.btn_loadData.Click += new System.EventHandler(this.Btn_loadData_Click);
            // 
            // btnBatchExclusion_B
            // 
            this.btnBatchExclusion_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchExclusion_B.Location = new System.Drawing.Point(743, 554);
            this.btnBatchExclusion_B.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatchExclusion_B.Name = "btnBatchExclusion_B";
            this.btnBatchExclusion_B.Size = new System.Drawing.Size(39, 60);
            this.btnBatchExclusion_B.TabIndex = 13;
            this.btnBatchExclusion_B.UseVisualStyleBackColor = true;
            this.btnBatchExclusion_B.Click += new System.EventHandler(this.btnBatchExclusion_B_Click);
            this.btnBatchExclusion_B.Paint += new System.Windows.Forms.PaintEventHandler(this.btnBatchExclusion_B_Paint);
            // 
            // btnSingleExclusion_B
            // 
            this.btnSingleExclusion_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleExclusion_B.Location = new System.Drawing.Point(668, 560);
            this.btnSingleExclusion_B.Margin = new System.Windows.Forms.Padding(4);
            this.btnSingleExclusion_B.Name = "btnSingleExclusion_B";
            this.btnSingleExclusion_B.Size = new System.Drawing.Size(39, 48);
            this.btnSingleExclusion_B.TabIndex = 14;
            this.btnSingleExclusion_B.UseVisualStyleBackColor = true;
            this.btnSingleExclusion_B.Click += new System.EventHandler(this.btnSingleExclusion_B_Click);
            this.btnSingleExclusion_B.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSingleExclusion_B_Paint);
            // 
            // btnBatchInclusion_B
            // 
            this.btnBatchInclusion_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchInclusion_B.Location = new System.Drawing.Point(593, 554);
            this.btnBatchInclusion_B.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatchInclusion_B.Name = "btnBatchInclusion_B";
            this.btnBatchInclusion_B.Size = new System.Drawing.Size(39, 60);
            this.btnBatchInclusion_B.TabIndex = 15;
            this.btnBatchInclusion_B.UseVisualStyleBackColor = true;
            this.btnBatchInclusion_B.Click += new System.EventHandler(this.btnBatchInclusion_B_Click);
            this.btnBatchInclusion_B.Paint += new System.Windows.Forms.PaintEventHandler(this.btnBatchInclusion_B_Paint);
            // 
            // btnSingleInclusion_B
            // 
            this.btnSingleInclusion_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleInclusion_B.Location = new System.Drawing.Point(518, 560);
            this.btnSingleInclusion_B.Margin = new System.Windows.Forms.Padding(4);
            this.btnSingleInclusion_B.Name = "btnSingleInclusion_B";
            this.btnSingleInclusion_B.Size = new System.Drawing.Size(39, 48);
            this.btnSingleInclusion_B.TabIndex = 16;
            this.btnSingleInclusion_B.UseVisualStyleBackColor = true;
            this.btnSingleInclusion_B.Click += new System.EventHandler(this.btnSingleInclusion_B_Click);
            this.btnSingleInclusion_B.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSingleInclusion_B_Paint);
            // 
            // lboxSelected_B
            // 
            this.lboxSelected_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxSelected_B.FormattingEnabled = true;
            this.lboxSelected_B.ItemHeight = 25;
            this.lboxSelected_B.Location = new System.Drawing.Point(480, 706);
            this.lboxSelected_B.Margin = new System.Windows.Forms.Padding(4);
            this.lboxSelected_B.Name = "lboxSelected_B";
            this.lboxSelected_B.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxSelected_B.Size = new System.Drawing.Size(348, 204);
            this.lboxSelected_B.TabIndex = 12;
            // 
            // lblSelectedPathways_B
            // 
            this.lblSelectedPathways_B.AutoSize = true;
            this.lblSelectedPathways_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPathways_B.Location = new System.Drawing.Point(471, 667);
            this.lblSelectedPathways_B.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedPathways_B.Name = "lblSelectedPathways_B";
            this.lblSelectedPathways_B.Size = new System.Drawing.Size(227, 25);
            this.lblSelectedPathways_B.TabIndex = 11;
            this.lblSelectedPathways_B.Text = "Selected Pathway(s): 0";
            // 
            // lbxAllB
            // 
            this.lbxAllB.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllB.FormattingEnabled = true;
            this.lbxAllB.ItemHeight = 25;
            this.lbxAllB.Location = new System.Drawing.Point(480, 198);
            this.lbxAllB.Margin = new System.Windows.Forms.Padding(4);
            this.lbxAllB.Name = "lbxAllB";
            this.lbxAllB.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxAllB.Size = new System.Drawing.Size(348, 329);
            this.lbxAllB.TabIndex = 10;
            // 
            // lblChosePathwayFrom_B
            // 
            this.lblChosePathwayFrom_B.AutoSize = true;
            this.lblChosePathwayFrom_B.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChosePathwayFrom_B.Location = new System.Drawing.Point(474, 154);
            this.lblChosePathwayFrom_B.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChosePathwayFrom_B.Name = "lblChosePathwayFrom_B";
            this.lblChosePathwayFrom_B.Size = new System.Drawing.Size(248, 25);
            this.lblChosePathwayFrom_B.TabIndex = 9;
            this.lblChosePathwayFrom_B.Text = "Chose from 0 pathway(s)";
            // 
            // comBoxOrganismB
            // 
            this.comBoxOrganismB.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxOrganismB.FormattingEnabled = true;
            this.comBoxOrganismB.Location = new System.Drawing.Point(481, 83);
            this.comBoxOrganismB.Margin = new System.Windows.Forms.Padding(4);
            this.comBoxOrganismB.Name = "comBoxOrganismB";
            this.comBoxOrganismB.Size = new System.Drawing.Size(348, 33);
            this.comBoxOrganismB.TabIndex = 8;
            this.comBoxOrganismB.SelectionChangeCommitted += new System.EventHandler(this.comBoxOrganism_B_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(475, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chose Organism B";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(546, 1025);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(282, 62);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Save outputs locally";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnGetGenes
            // 
            this.btnGetGenes.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetGenes.Location = new System.Drawing.Point(16, 1010);
            this.btnGetGenes.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetGenes.Name = "btnGetGenes";
            this.btnGetGenes.Size = new System.Drawing.Size(324, 77);
            this.btnGetGenes.TabIndex = 5;
            this.btnGetGenes.Text = "Get Pathway Cross-talks";
            this.btnGetGenes.UseVisualStyleBackColor = true;
            this.btnGetGenes.Click += new System.EventHandler(this.btnGetGenes_Click);
            // 
            // btnBatchExclusion_A
            // 
            this.btnBatchExclusion_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchExclusion_A.Location = new System.Drawing.Point(273, 560);
            this.btnBatchExclusion_A.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatchExclusion_A.Name = "btnBatchExclusion_A";
            this.btnBatchExclusion_A.Size = new System.Drawing.Size(39, 60);
            this.btnBatchExclusion_A.TabIndex = 4;
            this.btnBatchExclusion_A.UseVisualStyleBackColor = true;
            this.btnBatchExclusion_A.Click += new System.EventHandler(this.btnBatchExclusion_A_Click);
            this.btnBatchExclusion_A.Paint += new System.Windows.Forms.PaintEventHandler(this.btnBatchExclusion_A_Paint);
            // 
            // btnSingleExclusion_A
            // 
            this.btnSingleExclusion_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleExclusion_A.Location = new System.Drawing.Point(198, 566);
            this.btnSingleExclusion_A.Margin = new System.Windows.Forms.Padding(4);
            this.btnSingleExclusion_A.Name = "btnSingleExclusion_A";
            this.btnSingleExclusion_A.Size = new System.Drawing.Size(39, 48);
            this.btnSingleExclusion_A.TabIndex = 4;
            this.btnSingleExclusion_A.UseVisualStyleBackColor = true;
            this.btnSingleExclusion_A.Click += new System.EventHandler(this.btnSingleExclusion_A_Click);
            this.btnSingleExclusion_A.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSingleExclusion_A_Paint);
            // 
            // btnBatchInclusion_A
            // 
            this.btnBatchInclusion_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchInclusion_A.Location = new System.Drawing.Point(123, 560);
            this.btnBatchInclusion_A.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatchInclusion_A.Name = "btnBatchInclusion_A";
            this.btnBatchInclusion_A.Size = new System.Drawing.Size(39, 60);
            this.btnBatchInclusion_A.TabIndex = 4;
            this.btnBatchInclusion_A.UseVisualStyleBackColor = true;
            this.btnBatchInclusion_A.Click += new System.EventHandler(this.btnBatchInclusion_A_Click);
            this.btnBatchInclusion_A.Paint += new System.Windows.Forms.PaintEventHandler(this.btnBatchInclusion_A_Paint);
            // 
            // btnSingleInclusion_A
            // 
            this.btnSingleInclusion_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleInclusion_A.Location = new System.Drawing.Point(48, 566);
            this.btnSingleInclusion_A.Margin = new System.Windows.Forms.Padding(4);
            this.btnSingleInclusion_A.Name = "btnSingleInclusion_A";
            this.btnSingleInclusion_A.Size = new System.Drawing.Size(39, 48);
            this.btnSingleInclusion_A.TabIndex = 4;
            this.btnSingleInclusion_A.UseVisualStyleBackColor = true;
            this.btnSingleInclusion_A.Click += new System.EventHandler(this.btnSingleInclusion_A_Click);
            this.btnSingleInclusion_A.Paint += new System.Windows.Forms.PaintEventHandler(this.btnSingleInclusion_A_Paint);
            // 
            // lboxSelected_A
            // 
            this.lboxSelected_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lboxSelected_A.FormattingEnabled = true;
            this.lboxSelected_A.ItemHeight = 25;
            this.lboxSelected_A.Location = new System.Drawing.Point(16, 712);
            this.lboxSelected_A.Margin = new System.Windows.Forms.Padding(4);
            this.lboxSelected_A.Name = "lboxSelected_A";
            this.lboxSelected_A.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxSelected_A.Size = new System.Drawing.Size(348, 204);
            this.lboxSelected_A.TabIndex = 3;
            // 
            // lbxAllA
            // 
            this.lbxAllA.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllA.FormattingEnabled = true;
            this.lbxAllA.ItemHeight = 25;
            this.lbxAllA.Location = new System.Drawing.Point(16, 198);
            this.lbxAllA.Margin = new System.Windows.Forms.Padding(4);
            this.lbxAllA.Name = "lbxAllA";
            this.lbxAllA.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxAllA.Size = new System.Drawing.Size(348, 329);
            this.lbxAllA.TabIndex = 3;
            // 
            // lblSelectedPathways_A
            // 
            this.lblSelectedPathways_A.AutoSize = true;
            this.lblSelectedPathways_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedPathways_A.Location = new System.Drawing.Point(10, 673);
            this.lblSelectedPathways_A.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedPathways_A.Name = "lblSelectedPathways_A";
            this.lblSelectedPathways_A.Size = new System.Drawing.Size(227, 25);
            this.lblSelectedPathways_A.TabIndex = 2;
            this.lblSelectedPathways_A.Text = "Selected Pathway(s): 0";
            // 
            // lblChosePathwayFrom_A
            // 
            this.lblChosePathwayFrom_A.AutoSize = true;
            this.lblChosePathwayFrom_A.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChosePathwayFrom_A.Location = new System.Drawing.Point(10, 154);
            this.lblChosePathwayFrom_A.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChosePathwayFrom_A.Name = "lblChosePathwayFrom_A";
            this.lblChosePathwayFrom_A.Size = new System.Drawing.Size(248, 25);
            this.lblChosePathwayFrom_A.TabIndex = 2;
            this.lblChosePathwayFrom_A.Text = "Chose from 0 pathway(s)";
            // 
            // comBoxOrganismA
            // 
            this.comBoxOrganismA.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxOrganismA.FormattingEnabled = true;
            this.comBoxOrganismA.Location = new System.Drawing.Point(17, 83);
            this.comBoxOrganismA.Margin = new System.Windows.Forms.Padding(4);
            this.comBoxOrganismA.Name = "comBoxOrganismA";
            this.comBoxOrganismA.Size = new System.Drawing.Size(348, 33);
            this.comBoxOrganismA.TabIndex = 1;
            this.comBoxOrganismA.SelectionChangeCommitted += new System.EventHandler(this.comBoxOrganism_A_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chose Organism A";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(2011, 37);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1225);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2011, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Lbl_KeggPathwayGenes
            // 
            this.Lbl_KeggPathwayGenes.AutoSize = true;
            this.Lbl_KeggPathwayGenes.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_KeggPathwayGenes.Location = new System.Drawing.Point(454, 0);
            this.Lbl_KeggPathwayGenes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_KeggPathwayGenes.Name = "Lbl_KeggPathwayGenes";
            this.Lbl_KeggPathwayGenes.Size = new System.Drawing.Size(240, 25);
            this.Lbl_KeggPathwayGenes.TabIndex = 19;
            this.Lbl_KeggPathwayGenes.Text = "KEGG pathway Genes";
            this.Lbl_KeggPathwayGenes.Visible = false;
            // 
            // Lbl_KeggPathwayCrosstalks
            // 
            this.Lbl_KeggPathwayCrosstalks.AutoSize = true;
            this.Lbl_KeggPathwayCrosstalks.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_KeggPathwayCrosstalks.Location = new System.Drawing.Point(425, 475);
            this.Lbl_KeggPathwayCrosstalks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_KeggPathwayCrosstalks.Name = "Lbl_KeggPathwayCrosstalks";
            this.Lbl_KeggPathwayCrosstalks.Size = new System.Drawing.Size(295, 25);
            this.Lbl_KeggPathwayCrosstalks.TabIndex = 20;
            this.Lbl_KeggPathwayCrosstalks.Text = "KEGG pathway Cross-talks";
            this.Lbl_KeggPathwayCrosstalks.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(2011, 1247);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XTalkiiS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ComboBox comBoxOrganismA;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnBatchExclusion_A;
        private System.Windows.Forms.Button btnSingleExclusion_A;
        private System.Windows.Forms.Button btnBatchInclusion_A;
        private System.Windows.Forms.Button btnSingleInclusion_A;
        private System.Windows.Forms.ListBox lboxSelected_A;
        private System.Windows.Forms.ListBox lbxAllA;
        private System.Windows.Forms.Label lblSelectedPathways_A;
        private System.Windows.Forms.Label lblChosePathwayFrom_A;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_OutputDir;
        public System.Windows.Forms.Button btnGetGenes;
        private System.Windows.Forms.ListBox lbxAllB;
        private System.Windows.Forms.Label lblChosePathwayFrom_B;
        public System.Windows.Forms.ComboBox comBoxOrganismB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBatchExclusion_B;
        private System.Windows.Forms.Button btnSingleExclusion_B;
        private System.Windows.Forms.Button btnBatchInclusion_B;
        private System.Windows.Forms.Button btnSingleInclusion_B;
        private System.Windows.Forms.ListBox lboxSelected_B;
        private System.Windows.Forms.Label lblSelectedPathways_B;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_loadData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Lbl_KeggPathwayCrosstalks;
        private System.Windows.Forms.Label Lbl_KeggPathwayGenes;
    }
}

