using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Model.Operasyon;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence.Repositories
{
    public class OperasyonRepository : RepositoryAsync<NetsisRiskSon1>
    {
        public OperasyonRepository(PandapContext dc) : base(dc)
        {
        }

        public async Task<ObservableCollection<NetsisRiskSon1>> Netsis_CariRisk_Getir()
        {
            ObservableCollection<NetsisRiskSon1> sonuc = null;
            await Task.Run(() =>
            {
                sonuc = _dc.Netsis_CariRiskler.AsNoTracking().ToObservableCollection();
            });

            return sonuc;
        }

        public NetsisRiskSon1 Netsis_CariRisk_Getir_CariKoddan(string cariKod)
        {
            var sonuc = _dc.Netsis_CariRiskler.AsNoTracking().FirstOrDefault(c => c.CariKod == cariKod);
            return sonuc;
        }

        public void PandapNetsis_CariRisk_Guncelle(NetsisRiskSon1 netsis_cari_risk)
        {
            var cariRiskKontrol_db = _dc.CariRiskKontrols.FirstOrDefault(c => c.Id == netsis_cari_risk.P_Id);

            CariRiskKontrol cariRiskKontrol = null;

            if (cariRiskKontrol_db == null)
            {
                cariRiskKontrol_db = new CariRiskKontrol();

                MapNetsisCariRiskPandapCariRisk(netsis_cari_risk, cariRiskKontrol_db);

                _dc.CariRiskKontrols.Add(cariRiskKontrol);
            }
            else
            {
                MapNetsisCariRiskPandapCariRisk(netsis_cari_risk, cariRiskKontrol_db);
            }

            _dc.SaveChanges();
        }

        public void NetsisRiskLimitGuncelle(string cariKod, decimal? riskLimiti)
        {
            SqlConnection connection = (SqlConnection)_dc.Database.GetDbConnection();
            connection.Open();

            connection.ChangeDatabase("PANDA2018");

            var numericToText = riskLimiti.GetValueOrDefault();

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = $"Update dbo.TBLCARISK set " +
                                      $"RISKLIMITI={numericToText.ToString().Replace(",", ".")}" +
                                      $" where CARIKOD='{cariKod}'";

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static void MapNetsisCariRiskPandapCariRisk(NetsisRiskSon1 netsis_cari_risk, CariRiskKontrol cariRiskKontrol_db)
        {
            cariRiskKontrol_db.AliciKod = netsis_cari_risk.AliciKod;
            cariRiskKontrol_db.TicaretSicilNo = netsis_cari_risk.TicaretSicilNo;
            cariRiskKontrol_db.CariKod = netsis_cari_risk.CariKod;

            cariRiskKontrol_db.P_DBS_Limit = netsis_cari_risk.P_DBS_Limit;
            cariRiskKontrol_db.P_EximLimit = netsis_cari_risk.P_EximLimit;
            cariRiskKontrol_db.P_GarantiFactoring = netsis_cari_risk.P_GarantiFactoring;
            cariRiskKontrol_db.P_IngFactoring = netsis_cari_risk.P_IngFactoring;
            cariRiskKontrol_db.P_Ipotek = netsis_cari_risk.P_Ipotek;
            cariRiskKontrol_db.P_SeherliLimit = netsis_cari_risk.P_SeherliLimit;
            cariRiskKontrol_db.P_Teminat = netsis_cari_risk.P_Teminat;

            cariRiskKontrol_db.P_Yonetim = netsis_cari_risk.P_Yonetim;
        }
    }
}