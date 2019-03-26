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
            cmd.CommandText = "INSERT INTO PEOPLE VALUES  (@firstname, @lastname, @age)";
            conn.Open();
            foreach(Person p in ppl)
            {
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue($"@firstname", p.FirstName);
                cmd.Parameters.AddWithValue($"@lastname", p.LastName);
                cmd.Parameters.AddWithValue($"@age", p.Age);
                cmd.ExecuteNonQuery();
            }
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
