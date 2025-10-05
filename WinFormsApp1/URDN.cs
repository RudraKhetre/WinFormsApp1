using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace WindowsFormsApp1
{
    public partial class URDN : Form
    {
        // A list to hold all the submission records.
        private List<SubmissionRecord> allRecords;
        private readonly string _loginUserId;

        public URDN(string loginUserId)
        {
            InitializeComponent();
            _loginUserId = loginUserId;
            loginUserMenu.Text = $"Login User: {_loginUserId}";
        }

        private void URDN_Load(object sender, EventArgs e)
        {
            // --- Setup Event Handlers ---
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancelBottom.Click += new System.EventHandler(this.BtnCancel_Click);
            this.logoutMenuItem.Click += new System.EventHandler(this.LogoutMenuItem_Click);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // --- Load Data from Database and Configure Grid ---
            allRecords = SubmissionRecord.LoadAll();
            ConfigureDataGridView();

            // Display all records initially
            dgvResults.DataSource = allRecords;
        }

        /// <summary>
        /// Configures the DataGridView columns to bind to the SubmissionRecord properties.
        /// </summary>
        private void ConfigureDataGridView()
        {
            dgvResults.AutoGenerateColumns = false;
            colSrNo.DataPropertyName = "SrNo";
            colSelect.DataPropertyName = "Select";
            colISN.DataPropertyName = "ISN";
            colSeqNo.DataPropertyName = "SeqNo";
            colDrugApi.DataPropertyName = "DrugAPI";
            colSubOwner.DataPropertyName = "SubOwner";
            colUUID.DataPropertyName = "UUID";
            colCurrentRoot.DataPropertyName = "CurrentRootDirName";
            colNewRoot.DataPropertyName = "NewRootDirName";
        }

        /// <summary>
        /// Handles the Search button click event.
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string submissionNumber = txtISN.Text.Trim(); // txtISN maps to rebmun_noissimbus
            if (string.IsNullOrEmpty(submissionNumber))
            {
                MessageBox.Show("Please enter a Submission Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT * FROM zespl_nalp_noissimbus WHERE rebmun_noissimbus = @SubmissionNumber", conn))
            {
                cmd.Parameters.AddWithValue("@SubmissionNumber", submissionNumber);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvResults.DataSource = dt;
                }
            }
        }

        /// <summary>
        /// Handles the Submit button click event.
        /// </summary>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Get all records where the 'Select' checkbox is checked.
            var selectedRecords = ((List<SubmissionRecord>)dgvResults.DataSource)
                                  .Where(r => r.Select)
                                  .ToList();

            if (selectedRecords.Any())
            {
                string message = $"You have selected {selectedRecords.Count} record(s) to update:\n\n";
                message += string.Join("\n", selectedRecords.Select(r => $"ISN: {r.ISN}, New Name: {r.NewRootDirName}"));

                MessageBox.Show(message, "Submission Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update database with new root directory names
                SubmissionRecord.UpdateNewRootDirName(selectedRecords);
            }
            else
            {
                MessageBox.Show("Please select at least one record to submit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handles clicks for both Cancel buttons.
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Clear inputs and reset the grid
            txtISN.Clear();
            txtNoOfChars.Text = "25";
            dgvResults.DataSource = allRecords;
        }

        /// <summary>
        /// Handles the Logout menu item click.
        /// </summary>
        private void LogoutMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //this.Close(); // In a real app, you would show the login form here.
                this.Hide();
                Login updateForm = new Login(); // Pass the actual loginId
                updateForm.Show();
            }
        }

        /// <summary>
        /// Handles the Export to Excel button click event.
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvResults.DataSource is not List<SubmissionRecord> records || records.Count == 0)
            {
                MessageBox.Show("No records to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"Update Root Directory Name-{timestamp}.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Export");
                        // Header
                        worksheet.Cell(1, 1).Value = "SrNo";
                        worksheet.Cell(1, 2).Value = "ISN";
                        worksheet.Cell(1, 3).Value = "SeqNo";
                        worksheet.Cell(1, 4).Value = "DrugAPI";
                        worksheet.Cell(1, 5).Value = "SubOwner";
                        worksheet.Cell(1, 6).Value = "UUID";
                        worksheet.Cell(1, 7).Value = "CurrentRootDirName";
                        worksheet.Cell(1, 8).Value = "NewRootDirName";

                        // Data
                        for (int i = 0; i < records.Count; i++)
                        {
                            var r = records[i];
                            worksheet.Cell(i + 2, 1).Value = r.SrNo;
                            worksheet.Cell(i + 2, 2).Value = r.ISN;
                            worksheet.Cell(i + 2, 3).Value = r.SeqNo;
                            worksheet.Cell(i + 2, 4).Value = r.DrugAPI;
                            worksheet.Cell(i + 2, 5).Value = r.SubOwner;
                            worksheet.Cell(i + 2, 6).Value = r.UUID;
                            worksheet.Cell(i + 2, 7).Value = r.CurrentRootDirName;
                            worksheet.Cell(i + 2, 8).Value = r.NewRootDirName;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Export successful.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void loginUserMenu_Click(object sender, EventArgs e)
        {

        }
    }
}