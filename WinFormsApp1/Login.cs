using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;
            cmbCountry.SelectedIndexChanged += CmbCountry_SelectedIndexChanged;

            txtCorporateId.ReadOnly = true;
        }

        // Auto-fill Corporate ID (actually you are now driving from CorporateId in combo)
        private void CmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCountry = cmbCountry.SelectedItem?.ToString(); // combo shows country names
            if (string.IsNullOrEmpty(selectedCountry)) return;

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT CorporateId FROM Users WHERE Country = @Country", conn))
            {
                cmd.Parameters.AddWithValue("@Country", selectedCountry);
                conn.Open();
                var result = cmd.ExecuteScalar();
                txtCorporateId.Text = result != null ? result.ToString() : string.Empty; // show CorporateId
            }
        }


        // Login button validation
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string loginId = txtLoginId.Text.Trim();
            string password = txtPassword.Text.Trim();
            string country = cmbCountry.SelectedItem?.ToString();
            string corporateId = txtCorporateId.Text.Trim();

            // 1. Mandatory fields validation
            if (string.IsNullOrEmpty(loginId))
            {
                MessageBox.Show("Login ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(country))
            {
                MessageBox.Show("Please select a country.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(corporateId))
            {
                MessageBox.Show("Corporate ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Check user in database
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string dbPassword = null, dbCountry = null, dbCorporateId = null;
            bool dbIsActive = false;
            bool userFound = false;

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand("SELECT Password, Country, CorporateId, IsActive FROM Users WHERE LoginId = @LoginId", conn))
            {
                cmd.Parameters.AddWithValue("@LoginId", loginId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dbPassword = reader.GetString(0);
                        dbCountry = reader.GetString(1);
                        dbCorporateId = reader.GetString(2);
                        dbIsActive = reader.GetBoolean(3);
                        userFound = true;
                    }
                }
            }

            if (!userFound)
            {
                MessageBox.Show("Invalid User ID.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Validate password
            if (dbPassword != password)
            {
                MessageBox.Show("Incorrect password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Validate country
            if (dbCountry != country)
            {
                MessageBox.Show("Selected country does not match user's country.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Validate corporate ID
            if (dbCorporateId != corporateId)
            {
                MessageBox.Show("Corporate ID does not match.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 6. Validate user active status
            if (!dbIsActive)
            {
                MessageBox.Show("User is not Active. Contact Administrator.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SUCCESS → Open Update Root Directory Name screen
            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            URDN updateForm = new URDN(loginId); // Pass the actual loginId
            updateForm.Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLoginId_Click(object sender, EventArgs e)
        {
            // Can be ignored
        }

        private void txtCorporateId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLoginId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
