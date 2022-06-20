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
    internal class ShowDAO : DAO
    {
        public static List<Show> List()
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         "FROM [Shows]";
            DataTable dataTable = GetDataBySql(sql);
            List<Show> list = new List<Show>();
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Show()
                {
                    ShowId = (int)dr["ShowID"],
                    RoomId = (int)dr["RoomID"],
                    FilmId = (int)dr["FilmID"],
                    ShowDate = (DateTime)dr["ShowDate"],
                    Price = (decimal)dr["Price"],
                    Status = (bool)dr["status"],
                    Slot = (int)dr["Slot"]
                });
            }
            return list;
        }

        public static Show? get(int Id)
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         "FROM [Shows]" +
                         " WHERE [ShowID] = @ShowID";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@ShowID", DbType.Int32);
            parameter.Value = Id;
            DataTable dataTable = GetDataBySql(sql, parameter);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                bool status = false;
                bool.TryParse(dr["status"].ToString(), out status);
                return new Show()
                {
                    ShowId = (int)dr["ShowID"],
                    RoomId = (int)dr["RoomID"],
                    FilmId = (int)dr["FilmID"],
                    ShowDate = (DateTime)dr["ShowDate"],
                    Price = (decimal)dr["Price"],
                    Status = status,
                    Slot = (int)dr["Slot"]
                };
            }
            return null;
        }

        public static Show? GetItemByDateAndSlotAndRoom(DateTime Date, int Slot, int Room)
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         " FROM [Shows]" +
                         " WHERE YEAR([ShowDate]) = YEAR(@ShowDate) " +
                         "  AND MONTH([ShowDate]) = MONTH(@ShowDate)" +
                         "  AND DAY([ShowDate]) = DAY(@ShowDate)" +
                         "  AND [Slot] = @Slot " +
                         "  AND [RoomID] = @RoomID";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ShowDate", DbType.Date);
            parameters[0].Value = Date;
            parameters[1] = new SqlParameter("@Slot", DbType.Int32);
            parameters[1].Value = Slot;
            parameters[2] = new SqlParameter("@RoomID", DbType.Int32);
            parameters[2].Value = Room;
            DataTable dataTable = GetDataBySql(sql, parameters);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                bool status = false;
                bool.TryParse(dr["status"].ToString(), out status);
                return new Show()
                {
                    ShowId = (int)dr["ShowID"],
                    RoomId = (int)dr["RoomID"],
                    FilmId = (int)dr["FilmID"],
                    ShowDate = (DateTime)dr["ShowDate"],
                    Price = (decimal)dr["Price"],
                    Status = status,
                    Slot = (int)dr["Slot"]
                };
            }
            return null;
        }


        public static List<Show>? GetItemByDate(DateTime Date)
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         " FROM [Shows]" +
                         " WHERE YEAR([ShowDate]) = YEAR(@ShowDate) " +
                         "  AND MONTH([ShowDate]) = MONTH(@ShowDate)" +
                         "  AND DAY([ShowDate]) = DAY(@ShowDate)";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ShowDate", DbType.Date);
            parameters[0].Value = Date;
            DataTable dataTable = GetDataBySql(sql, parameters);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                List<Show> list = new List<Show>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    bool status = false;
                    bool.TryParse(dr["status"].ToString(), out status);
                    list.Add(new Show()
                    {
                        ShowId = (int)dr["ShowID"],
                        RoomId = (int)dr["RoomID"],
                        FilmId = (int)dr["FilmID"],
                        ShowDate = (DateTime)dr["ShowDate"],
                        Price = (decimal)dr["Price"],
                        Status = status,
                        Slot = (int)dr["Slot"]
                    });
                }
                return list;
            }
            return null;
        }

        public static List<Show>? GetItemByDate(DateTime Date, int roomId)
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         " FROM [Shows]" +
                         " WHERE YEAR([ShowDate]) = YEAR(@ShowDate) " +
                         "  AND MONTH([ShowDate]) = MONTH(@ShowDate)" +
                         "  AND DAY([ShowDate]) = DAY(@ShowDate) " +
                         "  AND [RoomID] = @RoomID";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ShowDate", DbType.Date);
            parameters[0].Value = Date;
            parameters[1] = new SqlParameter("@RoomID", DbType.Int32);
            parameters[1].Value = roomId;
            DataTable dataTable = GetDataBySql(sql, parameters);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                List<Show> list = new List<Show>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    bool status = false;
                    bool.TryParse(dr["status"].ToString(), out status);
                    list.Add(new Show()
                    {
                        ShowId = (int)dr["ShowID"],
                        RoomId = (int)dr["RoomID"],
                        FilmId = (int)dr["FilmID"],
                        ShowDate = (DateTime)dr["ShowDate"],
                        Price = (decimal)dr["Price"],
                        Status = status,
                        Slot = (int)dr["Slot"]
                    });
                }
                return list;
            }
            return null;
        }

        public static List<Show>? FindByRoomAndFilmAndDate(DateTime Date, int film, int Room)
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         " FROM [Shows] " +
                         " WHERE YEAR([ShowDate]) = YEAR(@ShowDate) " +
                         "  AND MONTH([ShowDate]) = MONTH(@ShowDate)" +
                         "  AND DAY([ShowDate]) = DAY(@ShowDate)" +
                         "  AND [FilmID] = @FilmID " +
                         "  AND [RoomID] = @RoomID ";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ShowDate", DbType.Date);
            parameters[0].Value = Date;
            parameters[1] = new SqlParameter("@FilmID", DbType.Int32);
            parameters[1].Value = film;
            parameters[2] = new SqlParameter("@RoomID", DbType.Int32);
            parameters[2].Value = Room;
            DataTable dataTable = GetDataBySql(sql, parameters);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                List<Show> list = new List<Show>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    bool status = false;
                    bool.TryParse(dr["status"].ToString(), out status);
                    list.Add(new Show()
                    {
                        ShowId = (int)dr["ShowID"],
                        RoomId = (int)dr["RoomID"],
                        FilmId = (int)dr["FilmID"],
                        ShowDate = (DateTime)dr["ShowDate"],
                        Price = (decimal)dr["Price"],
                        Status = status,
                        Slot = (int)dr["Slot"]
                    });
                }
                return list;
            }
            return null;
        }

        public static DataTable FindByRoomAndFilmAndDateDataTable(DateTime Date, int film, int Room)
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         " FROM [Shows] " +
                         " WHERE YEAR([ShowDate]) = YEAR(@ShowDate) " +
                         "  AND MONTH([ShowDate]) = MONTH(@ShowDate)" +
                         "  AND DAY([ShowDate]) = DAY(@ShowDate)" +
                         "  AND [FilmID] = @FilmID " +
                         "  AND [RoomID] = @RoomID ";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@ShowDate", DbType.Date);
            parameters[0].Value = Date;
            parameters[1] = new SqlParameter("@FilmID", DbType.Int32);
            parameters[1].Value = film;
            parameters[2] = new SqlParameter("@RoomID", DbType.Int32);
            parameters[2].Value = Room;
            DataTable dataTable = GetDataBySql(sql, parameters);
            return dataTable;
        }


        public static void Insert(Show show)
        {
            string sql = "INSERT INTO [Shows]([RoomID], [FilmID], [ShowDate], [Price], [Status], [Slot])" +
                    "VALUES(@RoomID, @FilmID, @ShowDate, @Price, @Status, @Slot)";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("RoomID", DbType.Int32);
            parameters[0].Value = show.RoomId;
            parameters[1] = new SqlParameter("FilmID", DbType.Int32);
            parameters[1].Value = show.FilmId;
            parameters[2] = new SqlParameter("ShowDate", DbType.Date);
            parameters[2].Value = show.ShowDate;
            parameters[3] = new SqlParameter("Price", DbType.Decimal);
            parameters[3].Value = show.Price;
            parameters[4] = new SqlParameter("Status", DbType.Boolean);
            parameters[4].Value = show.Status;
            parameters[5] = new SqlParameter("Slot", DbType.Int32);
            parameters[5].Value = show.Slot;
            UpdateDataSql(sql, parameters);
        }

        public static void Update(Show show)
        {
            string sql = "UPDATE [Shows]" +
                         " SET  [RoomID] = @RoomID" +
                         "    , [FilmID] = @FilmID" +
                         "    , [ShowDate] = @ShowDate" +
                         "    , [Price] = @Price" +
                         "    , [Status] = @Status" +
                         "    , [Slot] = @Slot" +
                         "  WHERE [ShowID] = @ShowId";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("RoomID", DbType.Int32);
            parameters[0].Value = show.RoomId;
            parameters[1] = new SqlParameter("FilmID", DbType.Int32);
            parameters[1].Value = show.FilmId;
            parameters[2] = new SqlParameter("ShowDate", DbType.Date);
            parameters[2].Value = show.ShowDate;
            parameters[3] = new SqlParameter("Price", DbType.Decimal);
            parameters[3].Value = show.Price;
            parameters[4] = new SqlParameter("Status", DbType.Boolean);
            parameters[4].Value = show.Status;
            parameters[5] = new SqlParameter("Slot", DbType.Int32);
            parameters[5].Value = show.Slot;
            parameters[6] = new SqlParameter("ShowId", DbType.Int32);
            parameters[6].Value = show.ShowId;
            UpdateDataSql(sql, parameters);
        }


        public static void Delete(int ShowId)
        {
            string sql = "DELETE FROM [Shows]" 
                        + "  WHERE [ShowID] = @ShowId";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("ShowId", DbType.Int32);
            parameter.Value = ShowId;
            UpdateDataSql(sql, parameter);
        }

        public static DataTable GetDataTable()
        {
            string sql = "SELECT [ShowID] ,[RoomID] ,[FilmID] ,[ShowDate] ,[Price] ,[Status] ,[Slot] " +
                         "FROM [Shows]" +
                         " ORDER BY [ShowID] DESC";
            DataTable dataTable = GetDataBySql(sql);
            return dataTable;
        }
    }
}
