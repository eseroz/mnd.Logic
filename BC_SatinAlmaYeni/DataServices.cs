using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_SatinAlmaYeni.Data;
using mnd.Logic.BC_SatinAlmaYeni.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni
{
    public class SatinAlmaDataServices
    {
        public static List<OlcuBirim> OlcuBirimleriGetir()
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.OlcuBirimleri.ToList();

            dc.Dispose();

            return sonuc;

        }


        public static void KalemTeklifeAktarilmaDurumGuncelle(List<TalepKalem> liste)
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();

            foreach (var item in liste)
            {
                var kalem=dc.TalepKalemler.First(c => c.TalepKalemId == item.TalepKalemId);
                kalem.TeklifeAktarilmaTarihi = item.TeklifeAktarilmaTarihi;
                kalem.SeciliMi = true;

            }

            dc.SaveChanges();
            dc.Dispose();
         
        }


        public static void StokTanimGuncelle()
        {
            SatinAlmaDbContextYeni _dc = new SatinAlmaDbContextYeni();
            _dc.Database.ExecuteSqlCommand($"SatinAlma.Upsert_vwStokTanim");
            _dc.Dispose();

            _dc.Dispose();
        }

    }
}
