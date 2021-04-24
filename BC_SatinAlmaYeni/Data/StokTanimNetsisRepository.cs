using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_SatinAlmaYeni.Domain;
using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class StokTanimNetsisRepository
    {

        public void StokHucreGuncelle(string stokKod, string hucrekod)
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();
            var sonuc = dc.StokTanimlarNetsis
                .Where(c => c.STOK_KODU == stokKod)
                .FirstOrDefault();

            sonuc.HucreKod = hucrekod;

            dc.SaveChanges();

        }

        public  void UpsertStokList()
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();
            // dc.Database.ExecuteSqlCommand("exec SatinAlma.Upsert_vwStokTanim");
            //dc.Dispose();

        }

        public ObservableCollection<vwStokTanim> NetsisStokTanimlariGetir()
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();
            var sonuc = dc.StokTanimlarNetsis
                .Where(c => c.GRUP_AD != null && c.GRUP_AD != "0" && c.GRUP_AD != "18")
                .ToObservableCollection();

            return sonuc;
        }

   

        public List<Vw_StokMiktarNetsis> StokMiktarlariGetir()
        {
            SatinAlmaDbContextYeni dcx = new SatinAlmaDbContextYeni();
            var result = dcx.StokMiktarlarNetsis
                        .AsNoTracking()
                        .ToList();

            return result;
        }

        public Vw_StokMiktarNetsis StokMiktariGetir(string stokKod)
        {
            SatinAlmaDbContextYeni dcx = new SatinAlmaDbContextYeni();
            var result = dcx.StokMiktarlarNetsis
                        .Where(c => c.StokKod == stokKod)

                        .FirstOrDefault();

            return result;
        }

        public Vw_StokAlimFiyatNetsis StokAlimSonFiyatGetir(string stokKod)
        {
            SatinAlmaDbContextYeni dcx = new SatinAlmaDbContextYeni();
            var result = dcx.StokAlimFiyatlarNetsis
                        .Where(c => c.StokKod == stokKod)
                        .OrderByDescending(c => c.IslemTarih).ToList()
                        .FirstOrDefault();

            return result;
        }

        public List<Vw_StokAlimFiyatNetsis> StokAlimFiyatlariGetirFromStokKod(string stokKod)
        {
            SatinAlmaDbContextYeni dcx = new SatinAlmaDbContextYeni();

            var result = dcx.StokAlimFiyatlarNetsis
                           .Where(c => c.StokKod == stokKod)
                           .AsNoTracking()
                            .OrderByDescending(c => c.IslemTarih).ToList()

                        .ToList();


            return result;
        }


        public List<Vw_StokAlimFiyatNetsis> StokAlimSonFiyatlariGetir()
        {
            var sql = "select * from(select c.*, ROW_NUMBER() OVER(PARTITION BY StokKod ORDER BY StokKod, IslemTarih desc) price_rank " +
                "from[SatinAlma].[Vw_StokAlimFiyatNetsis] c)  x where x.price_rank = 1";

            SatinAlmaDbContextYeni dcx = new SatinAlmaDbContextYeni();
            var result = dcx.StokAlimFiyatlarNetsis
                        .FromSql<Vw_StokAlimFiyatNetsis>(sql)
                        .AsNoTracking()
                        .ToList();
            return result;
        }

        public List<Vw_StokAlimFiyatNetsis> StokAlimFiyatlariGetir()
        {
            SatinAlmaDbContextYeni dcx = new SatinAlmaDbContextYeni();
            var result = dcx.StokAlimFiyatlarNetsis
                        .AsNoTracking()
                        .ToList();


            return result;
        }


        public vwStokTanim StokBul(string stokKodu)
        {
            SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();
            var sonuc = dc.StokTanimlarNetsis
                .Where(c => c.STOK_KODU == stokKodu)
                .FirstOrDefault();

            return sonuc;
        }
    }
      
}
