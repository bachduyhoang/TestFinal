using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyAssembly
{
    public class FacultyDAO
    {
        string connection = "server=se140692\\bachduyhoang;database=PE2021;uid=sa;pwd=123";

        public FacultyDAO()
        {
        }

        public List<Faculty> getListData(string name)
        {
            List<Faculty> list = new List<Faculty>();
            string sql = "select * from Faculty where [Full Name] like @Name ";
            SqlConnection cnn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
            try
            {
                Console.WriteLine("non");     
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }

            return list;
        }

        public bool Add(Faculty f)
        {
            string sql = "insert Faculty " +
                " values(@ID, @Name, @Age, @Address)";
            SqlConnection cnn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", f.Name);
            cmd.Parameters.AddWithValue("@ID", f.ID);
            cmd.Parameters.AddWithValue("@Age", f.Age);
            cmd.Parameters.AddWithValue("@Address", f.Address);

            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }

            return false;
        }

        public bool Update(Faculty f)
        {
            string sql = "update Faculty " +
                " set [Full Name] = @Name,[Age] = @Age, [Address] = @Address " +
                " where [FacultyID] = @ID";
            SqlConnection cnn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@Name", f.Name);
            cmd.Parameters.AddWithValue("@ID", f.ID);
            cmd.Parameters.AddWithValue("@Age", f.Age);
            cmd.Parameters.AddWithValue("@Address", f.Address);

            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }

            return false;
        }

        public bool Delete(int id)
        {
            string sql = "delete Faculty " +
                " where [FacultyID] = @ID";
            SqlConnection cnn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@ID", id);

            try
            {
                cnn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cnn.Close();
            }

            return false;
        }


    }
}
