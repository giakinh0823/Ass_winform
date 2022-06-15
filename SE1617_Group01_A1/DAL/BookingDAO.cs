using Ciname.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciname.DAL
{
    internal class BookingDAO : DAO
    {
        public static List<Booking> List()
        {
            string sql = "SELECT [BookingID], [ShowID], [Name], [SeatStatus], [Amount] FROM [Bookings]";
            DataTable dataTable = GetDataBySql(sql);
            List<Booking> list = new List<Booking>();
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Booking()
                {
                    BookingId = (int)dr["BookingID"],
                    ShowId = (int)dr["ShowID"],
                    Name = (string)dr["Name"],
                    SeatStatus = (string)dr["SeatStatus"],
                    Amount = (decimal)dr["Amount"]
                });
            }
            return list;
        }

        public static Booking? Get(int Id)
        {
            string sql = " SELECT [BookingID], [ShowID], [Name], [SeatStatus], [Amount] FROM [Bookings]" +
                          " WHERE [BookingID] = @BookingID";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@BookingID", DbType.Int32);
            parameter.Value = Id;
            DataTable dataTable = GetDataBySql(sql, parameter);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                return new Booking()
                {
                    BookingId = (int)dr["BookingID"],
                    ShowId = (int)dr["ShowID"],
                    Name = (string)dr["Name"],
                    SeatStatus = (string)dr["SeatStatus"],
                    Amount = (decimal)dr["Amount"]
                };
            }
            return null;
        }

        public static List<Booking>? findByShow(int Id)
        {
            string sql = " SELECT [BookingID], [ShowID], [Name], [SeatStatus], [Amount] FROM [Bookings]" +
                          " WHERE [ShowID] = @ShowID";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@ShowID", DbType.Int32);
            parameter.Value = Id;
            DataTable dataTable = GetDataBySql(sql, parameter);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                List<Booking> list = new List<Booking>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    list.Add(new Booking()
                    {
                        BookingId = (int)dr["BookingID"],
                        ShowId = (int)dr["ShowID"],
                        Name = (string)dr["Name"],
                        SeatStatus = (string)dr["SeatStatus"],
                        Amount = (decimal)dr["Amount"]
                    });
                }
                return list;
            }
            return null;
        }

        public static DataTable findByShowDataTable(int Id)
        {
            string sql = " SELECT [BookingID], [ShowID], [Name], [SeatStatus], [Amount] FROM [Bookings]" +
                          " WHERE [ShowID] = @ShowID";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@ShowID", DbType.Int32);
            parameter.Value = Id;
            DataTable dataTable = GetDataBySql(sql, parameter);
            return dataTable;
        }

        public static void Insert(Booking booking)
        {
            string sql = "INSERT INTO [Bookings] ([ShowID], [Name], [SeatStatus], [Amount])" +
                         " VALUES(@ShowID, @Name, @SeatStatus, @Amount)";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("ShowID", DbType.Int32);
            parameters[0].Value = booking.ShowId;
            parameters[1] = new SqlParameter("Name", DbType.String);
            parameters[1].Value = booking.Name;
            parameters[2] = new SqlParameter("SeatStatus", DbType.String);
            parameters[2].Value = booking.SeatStatus;
            parameters[3] = new SqlParameter("Amount", DbType.Decimal);
            parameters[3].Value = booking.Amount;
            UpdateDataSql(sql, parameters);
        }


        public static void Delete(int Id)
        {
            string sql = "DELETE FROM [Bookings]"
                        + "  WHERE [BookingID] = @BookingID";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("BookingID", DbType.Int32);
            parameter.Value = Id;
            UpdateDataSql(sql, parameter);
        }


        public static DataTable GetDataTable()
        {
            string sql = "SELECT [BookingID], [ShowID], [Name], [SeatStatus], [Amount] FROM [Bookings]";
            DataTable dataTable = GetDataBySql(sql);
            return dataTable;
        }
    }
}
