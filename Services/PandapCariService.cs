using Microsoft.EntityFrameworkCore;
using mnd.Logic.Model.Satis;
using mnd.Logic.Persistence;
using mnd.Logic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class PandapCariService
    {
        public static void CariListeRiskBilgileriniYukle(ObservableCollection<PandapCari> PandapCariler)
        {
            var yeniSatisFiyatlar = CariRiskService.SatisYeniKayitFiyatlariGetir();
            var depoMiktarFiyatlar = CariRiskService.DepoPaletFiyatGetir();
            var uretimEmriFiyatlar = CariRiskService.UretimEmriIsYuku_FiyatGetir();
            var sevkEmriFiyatlar = CariRiskService.SevkiyatEmirleriFiyatGetir();

            foreach (var pCari in PandapCariler)
            {

                pCari.SatisYeniKayitRiski = yeniSatisFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.GenelToplamTutar??0;
                pCari.UretimRiski = uretimEmriFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.GenelToplamTutar??0;
                pCari.MusteriDepoRiski = depoMiktarFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.GenelToplamTutar??0;
                pCari.MusteriSevkEmirleriRiski = sevkEmriFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.GenelToplamTutar??0;


                pCari.UretimdekiMiktar = uretimEmriFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.Miktar_Kg??0;
                pCari.DepodakiUrunMiktarKg = depoMiktarFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.Miktar_Kg??0;
                pCari.SevkEmrindekiMiktar = sevkEmriFiyatlar.Where(c => c.CariKod == pCari.CariKod).FirstOrDefault()?.Miktar_Kg ?? 0;

                pCari.OnPropertyChanged(nameof(pCari.KullanilabilirLimit));

            };

        }

        public static List<PandapCari> VergiNumarasindanCariGetir(string vergiNo)
        {
            PandapCariRepository rep = new PandapCariRepository();

            return rep.VergiNodanPandapCariGetir(vergiNo);
           

        }

        public static List<PandapCari>EximKodundanCariGetir(decimal eximkod)
        {
            PandapCariRepository rep = new PandapCariRepository();

            return rep.EximKodundanGetir(eximkod);


        }


        public static PandapCari CariGetir(string cariKod)
        {
            PandapCariRepository rep = new PandapCariRepository();

            var sonuc= rep.PandapCariGetir(cariKod);
            return sonuc;

        }



        public static void NetsistenAlarakCariGuncelle(string cariKod)
        {
            PandapContext _dc = new PandapContext();
            _dc.Database.ExecuteSqlCommand($"Satis.Upsert_PandapCari @p0", parameters: new[] { cariKod });
            _dc.Dispose();
        }

    }
}
