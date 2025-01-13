using Microsoft.Data.SqlClient;
using System.Data;

namespace adoecommerce.DAL
{
    public partial class DBContext
    {
       
            SqlConnection con;
            SqlDataAdapter adapter;
            DataTable dt;
        public DBContext()
        {
            con = new SqlConnection("Server=MARIAMELGAZZAR;Database=WFTask;Trusted_connection=True;Encrypt=True;Trust Server Certificate=True");
            adapter = new SqlDataAdapter();
            dt = new DataTable();
        }
        //disconnected ->select

        public DataTable ExecuteQuery(string command)
        {
            SqlCommand selectCommand = new SqlCommand(command, con);

            adapter.SelectCommand = selectCommand;

            adapter.Fill(dt);
            return dt;
        }
        //connected ->update ,delete 
        //public int ExecuteNonQuery(string command) {
        //    SqlCommand cmd = new SqlCommand(command);

        //    con.Open();

        //    //execute commend
        //    int rowAffected = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return rowAffected;
        //}

        public int ExecuteNonQuery(string commandText)
        {
            // Ensure connection string is set
            if (con == null)
            {
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            int rowsAffected = 0;

            try
            {
                // Create command and associate with connection
                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    // Open connection
                    con.Open();

                    // Execute the command
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Re-throw exception if needed
            }
            finally
            {
                // Ensure the connection is closed
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return rowsAffected;
        }

    }
}
