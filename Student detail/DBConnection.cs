using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Student_detail
{
	class DBConnection
	{
		public static SqlConnection DbConnect()
		{
			var conn = new SqlConnection();
			conn.ConnectionString = "Data Source=ANISH;Initial Catalog=SMS;Integrated Security=True";
			if (conn.State != ConnectionState.Open)
			{
				conn.Open();
			}
			return conn;
		}
		public static DataTable GetTableByQuery(string SqlQuery)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				command.Connection = DbConnect();
				command.CommandText = SqlQuery;
				command.CommandType = CommandType.Text;
				SqlDataAdapter adapter = new SqlDataAdapter(command);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				return dt;
			}
			catch
			{
				throw;
			}
		}

		internal static void ExecuteNonQuery(object insertstudent_table)
		{
			throw new NotImplementedException();
		}

		public static void ExecuteNonQuery(string SqlQuery)
		{
			try
			{
				SqlCommand command = new SqlCommand();
				command.Connection = DbConnect();
				command.CommandText = SqlQuery;
				command.CommandType = CommandType.Text;
				command.ExecuteNonQuery();
			}
			catch
			{
				throw;
			}
		}

	}
}
