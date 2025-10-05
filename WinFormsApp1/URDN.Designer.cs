namespace WindowsFormsApp1
{
    partial class URDN
    {
        private System.ComponentModel.IContainer components = null;

        // --- Existing Controls ---
        private System.Windows.Forms.Label lblISN;
        private System.Windows.Forms.TextBox txtISN;
        private System.Windows.Forms.Label lblNoOfChars;
        private System.Windows.Forms.TextBox txtNoOfChars;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSearchResult;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem loginUserMenu;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;

        // --- Added Controls ---
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancelBottom;
        private System.Windows.Forms.Panel pnlPagination; // Placeholder for pagination controls
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrugApi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentRoot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewRoot;
        private System.Windows.Forms.Button btnExportExcel; // 1. Add this line


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblISN = new Label();
            txtISN = new TextBox();
            lblNoOfChars = new Label();
            txtNoOfChars = new TextBox();
            btnSearch = new Button();
            btnCancel = new Button();
            lblSearchResult = new Label();
            dgvResults = new DataGridView();
            colSrNo = new DataGridViewTextBoxColumn();
            colSelect = new DataGridViewCheckBoxColumn();
            colISN = new DataGridViewTextBoxColumn();
            colSeqNo = new DataGridViewTextBoxColumn();
            colDrugApi = new DataGridViewTextBoxColumn();
            colSubOwner = new DataGridViewTextBoxColumn();
            colUUID = new DataGridViewTextBoxColumn();
            colCurrentRoot = new DataGridViewTextBoxColumn();
            colNewRoot = new DataGridViewTextBoxColumn();
            lblVersion = new Label();
            menuStrip = new MenuStrip();
            loginUserMenu = new ToolStripMenuItem();
            logoutMenuItem = new ToolStripMenuItem();
            btnSubmit = new Button();
            btnCancelBottom = new Button();
            pnlPagination = new Panel();
            btnExportExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblISN
            // 
            lblISN.AutoSize = true;
            lblISN.Location = new Point(28, 55);
            lblISN.Name = "lblISN";
            lblISN.Size = new Size(161, 15);
            lblISN.TabIndex = 0;
            lblISN.Text = "Internal Submission Number:";
            // 
            // txtISN
            // 
            txtISN.Location = new Point(175, 52);
            txtISN.Name = "txtISN";
            txtISN.Size = new Size(175, 23);
            txtISN.TabIndex = 1;
            // 
            // lblNoOfChars
            // 
            lblNoOfChars.AutoSize = true;
            lblNoOfChars.Location = new Point(28, 85);
            lblNoOfChars.Name = "lblNoOfChars";
            lblNoOfChars.Size = new Size(102, 15);
            lblNoOfChars.TabIndex = 2;
            lblNoOfChars.Text = "No. of Characters:";
            // 
            // txtNoOfChars
            // 
            txtNoOfChars.Location = new Point(175, 82);
            txtNoOfChars.MaxLength = 2;
            txtNoOfChars.Name = "txtNoOfChars";
            txtNoOfChars.Size = new Size(50, 23);
            txtNoOfChars.TabIndex = 3;
            txtNoOfChars.Text = "25";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(240, 78);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 28);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gold;
            btnCancel.Location = new Point(325, 78);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 28);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblSearchResult
            // 
            lblSearchResult.AutoSize = true;
            lblSearchResult.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearchResult.Location = new Point(28, 125);
            lblSearchResult.Name = "lblSearchResult";
            lblSearchResult.Size = new Size(91, 13);
            lblSearchResult.TabIndex = 6;
            lblSearchResult.Text = "Search Result:";
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResults.Columns.AddRange(new DataGridViewColumn[] { colSrNo, colSelect, colISN, colSeqNo, colDrugApi, colSubOwner, colUUID, colCurrentRoot, colNewRoot });
            dgvResults.Location = new Point(31, 150);
            dgvResults.Name = "dgvResults";
            dgvResults.Size = new Size(1124, 280);
            dgvResults.TabIndex = 7;
            // 
            // colSrNo
            // 
            colSrNo.HeaderText = "Sr. No.";
            colSrNo.Name = "colSrNo";
            colSrNo.ReadOnly = true;
            colSrNo.Width = 50;
            // 
            // colSelect
            // 
            colSelect.HeaderText = "Select";
            colSelect.Name = "colSelect";
            colSelect.Width = 50;
            // 
            // colISN
            // 
            colISN.HeaderText = "ISN";
            colISN.Name = "colISN";
            colISN.ReadOnly = true;
            colISN.Width = 70;
            // 
            // colSeqNo
            // 
            colSeqNo.HeaderText = "Seq No.";
            colSeqNo.Name = "colSeqNo";
            colSeqNo.ReadOnly = true;
            colSeqNo.Width = 60;
            // 
            // colDrugApi
            // 
            colDrugApi.HeaderText = "Drug/API";
            colDrugApi.Name = "colDrugApi";
            colDrugApi.ReadOnly = true;
            colDrugApi.Width = 80;
            // 
            // colSubOwner
            // 
            colSubOwner.HeaderText = "Sub Owner";
            colSubOwner.Name = "colSubOwner";
            colSubOwner.ReadOnly = true;
            // 
            // colUUID
            // 
            colUUID.HeaderText = "UUID";
            colUUID.Name = "colUUID";
            colUUID.ReadOnly = true;
            colUUID.Width = 220;
            // 
            // colCurrentRoot
            // 
            colCurrentRoot.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCurrentRoot.HeaderText = "Current Root Directory Name";
            colCurrentRoot.Name = "colCurrentRoot";
            colCurrentRoot.ReadOnly = true;
            // 
            // colNewRoot
            // 
            colNewRoot.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNewRoot.HeaderText = "New Root Directory Name";
            colNewRoot.Name = "colNewRoot";
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(1075, 30);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(83, 15);
            lblVersion.TabIndex = 8;
            lblVersion.Text = "Version: V1-1A";
            // 
            // menuStrip
            // 
            menuStrip.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuStrip.Dock = DockStyle.None;
            menuStrip.Items.AddRange(new ToolStripItem[] { loginUserMenu });
            menuStrip.Location = new Point(951, 27);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(108, 24);
            menuStrip.TabIndex = 9;
            menuStrip.Text = "menuStrip1";
            // 
            // loginUserMenu
            // 
            loginUserMenu.DropDownItems.AddRange(new ToolStripItem[] { logoutMenuItem });
            loginUserMenu.Name = "loginUserMenu";
            loginUserMenu.Size = new Size(100, 20);
            loginUserMenu.Text = "Login User: abc";
            loginUserMenu.Click += loginUserMenu_Click;
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Size = new Size(117, 22);
            logoutMenuItem.Text = "Log Out";
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSubmit.BackColor = Color.LightGreen;
            btnSubmit.Location = new Point(475, 480);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(90, 35);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCancelBottom
            // 
            btnCancelBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelBottom.BackColor = Color.Gold;
            btnCancelBottom.Location = new Point(585, 480);
            btnCancelBottom.Name = "btnCancelBottom";
            btnCancelBottom.Size = new Size(90, 35);
            btnCancelBottom.TabIndex = 12;
            btnCancelBottom.Text = "Cancel";
            btnCancelBottom.UseVisualStyleBackColor = false;
            // 
            // pnlPagination
            // 
            pnlPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPagination.Location = new Point(31, 436);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(1124, 30);
            pnlPagination.TabIndex = 10;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Location = new Point(815, 485);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(140, 30);
            btnExportExcel.TabIndex = 13;
            btnExportExcel.Text = "Export to Excel";
            btnExportExcel.UseVisualStyleBackColor = true;
            // 
            // URDN
            // 
            ClientSize = new Size(1184, 541);
            Controls.Add(btnCancelBottom);
            Controls.Add(btnSubmit);
            Controls.Add(pnlPagination);
            Controls.Add(lblVersion);
            Controls.Add(dgvResults);
            Controls.Add(lblSearchResult);
            Controls.Add(btnCancel);
            Controls.Add(btnSearch);
            Controls.Add(txtNoOfChars);
            Controls.Add(lblNoOfChars);
            Controls.Add(txtISN);
            Controls.Add(lblISN);
            Controls.Add(menuStrip);
            Controls.Add(btnExportExcel);
            MainMenuStrip = menuStrip;
            Name = "URDN";
            Text = "Update Root Directory Name";
            Load += URDN_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion
    }
}