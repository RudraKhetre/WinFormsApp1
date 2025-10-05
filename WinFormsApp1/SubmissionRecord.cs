using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class SubmissionRecord
    {
        public int SrNo { get; set; }
        public bool Select { get; set; }
        public string ISN { get; set; }                   // on_bus_lanretni
        public string SeqNo { get; set; }                 // noisrev_noissimbus
        public string DrugAPI { get; set; }               // rebmun_noissimbus (current root dir)
        public string SubOwner { get; set; }              // renwo_bus
        public string UUID { get; set; }                  // optional
        public string CurrentRootDirName { get; set; }    // rebmun_noissimbus_old
        public string NewRootDirName { get; set; }        // rebmun_noissimbus_new

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        /// <summary>
        /// Loads all records from zespl_nalp_noissimbus.
        /// </summary>
        public static List<SubmissionRecord> LoadAll()
        {
            var list = new List<SubmissionRecord>();

            string sql = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY on_bus_lanretni) AS SrNo,
                    on_bus_lanretni,      -- ISN
                    noisrev_noissimbus,   -- Sequence No
                    rebmun_noissimbus,    -- Current Root Directory Name
                    renwo_bus,            -- Submission Owner
                    di_etaroproc          -- UUID/Procedure ID (optional)
                FROM zespl_nalp_noissimbus;";

            using (var conn = new SqlConnection(GetConnectionString()))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SubmissionRecord
                        {
                            SrNo = Convert.ToInt32(reader.GetValue(0)),
                            ISN = reader.GetString(1),
                            SeqNo = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            CurrentRootDirName = reader.IsDBNull(3) ? "" : reader.GetString(3),
                            SubOwner = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            UUID = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            NewRootDirName = "", // blank initially
                            Select = false
                        });
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Updates all related tables with new Root Directory Name as per the EU logic.
        /// </summary>
        public static void UpdateNewRootDirName(List<SubmissionRecord> selectedRecords)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                foreach (var rec in selectedRecords)
                {
                    if (string.IsNullOrWhiteSpace(rec.NewRootDirName))
                        continue;

                    // 1️⃣ — Check if ISN + OldName exists in main table
                    string checkSql = @"SELECT COUNT(*) FROM zespl_nalp_noissimbus 
                                        WHERE on_bus_lanretni = @ISN AND rebmun_noissimbus = @OldName";
                    using (var checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ISN", rec.ISN);
                        checkCmd.Parameters.AddWithValue("@OldName", rec.CurrentRootDirName);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // 2️⃣ — Update all five tables like your SQL script
                            ExecuteUpdate(conn, "zespl_nalp_noissimbus", rec);
                            ExecuteUpdate(conn, "zespl_noissimbus_gnikrow_resu", rec);
                            ExecuteUpdate(conn, "zespl_redaeh_bus_tropmi", rec);
                            ExecuteUpdate(conn, "zespl_redaeh_bus_tsed_tirehni", rec);
                            ExecuteUpdateEU(conn, rec);

                            // 3️⃣ — Insert into audit tables
                            InsertAudit(conn, rec);
                        }
                    }
                }

                MessageBox.Show("Root Directory Names updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void ExecuteUpdate(SqlConnection conn, string tableName, SubmissionRecord rec)
        {
            string sql = $@"UPDATE {tableName} 
                            SET rebmun_noissimbus = @NewName 
                            WHERE on_bus_lanretni = @ISN;";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ISN", rec.ISN);
                cmd.Parameters.AddWithValue("@NewName", rec.NewRootDirName);
                cmd.ExecuteNonQuery();
            }
        }

        private static void ExecuteUpdateEU(SqlConnection conn, SubmissionRecord rec)
        {
            string sql = @"UPDATE zespl_redaeh_noissimbus_evitalumuc 
                           SET rebmun_noissimbus = @NewName 
                           WHERE on_bus_lanretni = @ISN AND edoc_yrtnuoc_ger = 'EU';";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ISN", rec.ISN);
                cmd.Parameters.AddWithValue("@NewName", rec.NewRootDirName);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertAudit(SqlConnection conn, SubmissionRecord rec)
        {
            // Replicates the INSERT logic for audit tables
            string auditBusSql = @"
                INSERT INTO zespl_redaeh_tidua_bus
                (ppa_ecruos, epyt_ytivitca, ytivitca, di_etaroproc, di_resu, etad, emit, on_bus_lanretni, noisrev_noissimbus, rebmun_noissimbus, on_fer_gurd, txet_tidua)
                VALUES ('Web','SubmissionPlan','Edit', @UUID, @SubOwner, CONVERT(DATE, GETDATE()), CONVERT(TIME, GETDATE()), 
                        @ISN, @SeqNo, @NewName, NULL, 'Submission Plan information is Edited');

                DECLARE @key_id NUMERIC(18,0) = SCOPE_IDENTITY();

                INSERT INTO zespl_liated_tidua_ecnereffid (yek_etagorrus_rdh, on_rs, eman_dleif, eulav_dlo, eulav_wen, etad, emit)
                VALUES (@key_id, 1, 'Root Directory Name', @OldName, @NewName, CONVERT(DATE, GETDATE()), CONVERT(TIME, GETDATE()));";

            using (var cmd = new SqlCommand(auditBusSql, conn))
            {
                cmd.Parameters.AddWithValue("@ISN", rec.ISN);
                cmd.Parameters.AddWithValue("@SeqNo", rec.SeqNo ?? "");
                cmd.Parameters.AddWithValue("@UUID", rec.UUID ?? "");
                cmd.Parameters.AddWithValue("@SubOwner", rec.SubOwner ?? "");
                cmd.Parameters.AddWithValue("@OldName", rec.CurrentRootDirName);
                cmd.Parameters.AddWithValue("@NewName", rec.NewRootDirName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
