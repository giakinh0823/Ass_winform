using ManageCiname_Assignment_1.DTL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCiname_Assignment_1.DAL
{
    internal class RoomDAO : DAO
    {
        public static List<Room> List()
        {
            string sql = "SELECT [RoomID], [Name], [NumberRows] ,[NumberCols] FROM [Rooms]";
            DataTable dataTable = GetDataBySql(sql);
            List<Room> list = new List<Room>();
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Room()
                {
                    RoomId = (int)dr["ShowID"],
                    Name = (string)dr["FilmID"],
                    NumberRows = (int)dr["Slot"],
                    NumberCols = (int)dr["Slot"]
                });
            }
            return list;
        }

        public static Room? Get(int Id)
        {
            string sql = " SELECT [RoomID], [Name], [NumberRows] ,[NumberCols] FROM [Rooms]" +
                         " WHERE [RoomID] = @RoomId ";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@RoomId", DbType.Int32);
            parameter.Value = Id;
            DataTable dataTable = GetDataBySql(sql, parameter);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                return new Room()
                {
                    RoomId = (int)dr["ShowID"],
                    Name = (string)dr["FilmID"],
                    NumberRows = (int)dr["Slot"],
                    NumberCols = (int)dr["Slot"]
                };
            }
            return null;
        }

        public static DataTable GetDataTable()
        {
            string sql = "SELECT [RoomID], [Name], [NumberRows] ,[NumberCols] FROM [Rooms]";
            DataTable dataTable = GetDataBySql(sql);
            return dataTable;
        }

    }
}
