using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace VeriTabaniKatmani
{
    class Baglanti
    {
        public static OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=KutuphaneOtomasyonu.mdb");
        public static void ConntectionKontrol(OleDbCommand komut)
        {
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
        }
    }
}
