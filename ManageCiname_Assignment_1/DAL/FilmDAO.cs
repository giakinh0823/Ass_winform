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
    public class FilmDAO: DAO
    {
        public static List<Film> List()
        {
            string sql = "SELECT [FilmID], [GenreID], [Title], [Year], [CountryCode] FROM [Films]";
            DataTable dataTable = GetDataBySql(sql);
            List<Film> list = new List<Film>();
            foreach (DataRow dr in dataTable.Rows)
            {
                list.Add(new Film()
                {
                    FilmId = (int)dr["FilmID"],
                    GenreId = (int)dr["GenreID"],
                    Year = (int)dr["Year"],
                    Title = (string)dr["Title"],
                    CountryCode = (string)dr["CountryCode"]
                });
            }
            return list;
        }

        public static Film? get(int Id)
        {
            string sql = "SELECT [FilmID], [GenreID], [Title], [Year], [CountryCode] FROM [Films] WHERE [FilmID] = @FilmId";
            SqlParameter parameter = new SqlParameter();
            parameter = new SqlParameter("@FilmId", DbType.Int32);
            parameter.Value = Id;
            DataTable dataTable = GetDataBySql(sql, parameter);
            if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                return new Film()
                {
                    FilmId = (int)dr["FilmID"],
                    GenreId = (int)dr["GenreID"],
                    Year = (int)dr["Year"],
                    Title = (string)dr["Title"],
                    CountryCode = (string)dr["CountryCode"]
                };
            }
            return null;
        }


        public static DataTable GetDataTable()
        {
            string sql = "SELECT [FilmID], [GenreID], [Title], [Year], [CountryCode] FROM [Films]";
            DataTable dataTable = GetDataBySql(sql);
            return dataTable;
        }
    }
}
