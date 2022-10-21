using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DB_to_CSV
{
    class DB
    {
        private string GetCSV()
        {
            using(SqlConnection cn=new SqlConnection(GetConnectionString()))
            {
                cn.Open();
                return CreateCSV(new SqlCommand("select * from").ExecuteReader());
            }
        }
        private string CreateCSV(IDataReader reader)
        {
            string soubor = "";
            List<string> radky = new List<string>();

            string hlavicka = "";
                if (reader.Read())
            {
                string[] sloupce = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sloupce[i] = reader.GetName(i);
                }
                hlavicka = string.Join(",", sloupce);
                radky.Add(hlavicka);
            }
                while(reader.Read()) //dostane data
                 {
                object[] hodnoty = new object[reader.FieldCount];
                reader.GetValues(hodnoty);
                radky.Add(string.Join(",", hodnoty));
                 }

            System.IO.File.WriteAllLines(soubor, radky);
            return soubor;
        }
           private string GetConnectionString()
        {
            return @"Server=;Database=; Integrated Security=true";
        }
    }

}
