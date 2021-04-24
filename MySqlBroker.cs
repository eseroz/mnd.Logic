using mnd.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic
{
    public enum SurecAd
    {
        SatinAlma,
        SatisSiparis
    }

    public class SurecEventArgs
    {
        public SurecEventArgs(string s) { Text = s; }
        public String Text { get; } 
    }

    public class SurecSqlBroker
    {
        public delegate void SurecEventHandler(object sender, SurecEventArgs e);

        public event SurecEventHandler SurecEvent;

        public string SqlPath { get; set; }

        public string CommandText { get; set; }


        public SurecSqlBroker(SurecAd surecAd)
        {
            SqlPath = GlobalSettings.Default.SqlCnnString;
            SqlDependency.Start(SqlPath);


            if (surecAd == SurecAd.SatinAlma) CommandText = "select TalepSurecKonum from SatinAlma.Talep";
            if (surecAd == SurecAd.SatisSiparis) CommandText = "select SiparisSurecDurum from Satis.Siparis";


            VeriYukle();

        }
       
        public void Durdur()
        {
            SqlDependency.Stop(SqlPath);
        }

        public void VeriYukle()
        {
            var con = new SqlConnection(SqlPath);
            con.Open();

            var command = new SqlCommand(CommandText , con);

            var dependency = new SqlDependency(command);

            dependency.OnChange -= new OnChangeEventHandler(OnDependencyChange);
            dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);

            command.ExecuteReader();

            con.Close();
        }

        private void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            var sonuc = e.Source.ToString() + " " + e.Info.ToString() + " ";

            SurecEvent?.Invoke(this, new SurecEventArgs(sonuc));

            VeriYukle();

        }
    }

   

}
