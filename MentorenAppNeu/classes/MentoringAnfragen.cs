using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Mentoren_App.classes
{
    internal class MentoringAnfragen : DbConnection
    {
        public int AnfrageID { get; set; }
        public int SchuelerID { get; set; }
        public int MentorID { get; set; }
        public int FachID { get; set; }
        public string Status { get; set; }
        public string Nachricht { get; set; }

        public MentoringAnfragen(int anfrageID, int schuelerID, int mentorID, int fachID, string status, string nachrichten)
        {
            this.AnfrageID = anfrageID;
            this.SchuelerID = schuelerID;
            this.MentorID = mentorID;
            this.FachID = fachID;
            this.Status = status;
            this.Nachricht = nachrichten;
        }
        /*
        public static void CreateMentoringAnfrage(int schuelerID, int mentorID, int fachID, string nachricht)
        {
            string query = "INSERT INTO MentoringAnfragen (SchuelerID, MentorID, FachID, Status, Nachricht) VALUES (@SchuelerID, @MentorID, @FachID, @Status, @Nachricht)";
            SqlParameter[] parameters = {
                new SqlParameter("@SchuelerID", schuelerID),
                new SqlParameter("@MentorID", mentorID),
                new SqlParameter("@FachID", fachID),
                new SqlParameter("@Status", "Offen"), // Standardmäßig als "Offen" markieren
                new SqlParameter("@Nachricht", nachricht)
            };
            new MentoringAnfragen(0, 0, 0, 0, "", "").CreateData(query, parameters);
        }

        public static List<MentoringAnfragen> ReadAllMentoringAnfragen()
        {
            List<MentoringAnfragen> result = new List<MentoringAnfragen>();
            string query = "SELECT * FROM MentoringAnfragen";
            using (SqlDataReader reader = new MentoringAnfragen(0, 0, 0, 0, "", "").ReadData(query, null))
            {
                while (reader.Read())
                {
                    int anfrageID = Convert.ToInt32(reader["AnfragenID"]);
                    int schuelerID = Convert.ToInt32(reader["SchuelerID"]);
                    int mentorID = Convert.ToInt32(reader["MentorID"]);
                    int fachID = Convert.ToInt32(reader["FachID"]);
                    string status = Convert.ToString(reader["Status"]);
                    string nachricht = Convert.ToString(reader["Nachricht"]);
                    result.Add(new MentoringAnfragen(anfrageID, schuelerID, mentorID, fachID, status, nachricht));
                }
            }
            return result;
        }

        public void UpdateMentoringAnfrageStatus(string neuerStatus)
        {
            string query = "UPDATE MentoringAnfragen SET Status = @NeuerStatus WHERE AnfragenID = @AnfrageID";
            SqlParameter[] parameters = { new SqlParameter("@NeuerStatus", neuerStatus), new SqlParameter("@AnfrageID", this.AnfrageID) };
            new MentoringAnfragen(0, 0, 0, 0, "", "").UpdateData(query, parameters);
        }

        public void DeleteMentoringAnfrage()
        {
            string query = "DELETE FROM MentoringAnfragen WHERE AnfragenID = @AnfrageID";
            SqlParameter[] parameters = { new SqlParameter("@AnfrageID", this.AnfrageID) };
            new MentoringAnfragen(0, 0, 0, 0, "", "").DeleteData(query, parameters);
        }*/
    }
}
