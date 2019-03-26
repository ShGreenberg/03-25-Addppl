using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace People
{
    public class DbManger
    {
        private string _connString;
        public DbManger(string connString)
        {
            _connString = connString;
        }

        public void AddPeople(List<Person> ppl)
        {
            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO PEOPLE VALUES";
            int count = 0;
            foreach(Person p in ppl)
            {
                count++;
                cmd.CommandText += count == 1 ? "" : ",";
                cmd.CommandText += $" (@firstname{count}, @lastname{count}, @age{count})";
                cmd.Parameters.AddWithValue($"@firstname{count}", p.FirstName);
                cmd.Parameters.AddWithValue($"@lastname{count}", p.LastName);
                cmd.Parameters.AddWithValue($"@age{count}", p.Age);
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public List<Person> GetPeople()
        {
            SqlConnection conn = new SqlConnection(_connString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            conn.Open();
            List<Person> ppl = new List<Person>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ppl.Add(new Person
                {
                    FirstName = (string)reader["firstname"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            conn.Close();
            conn.Dispose();
            return ppl;
        }

        
    }
}
