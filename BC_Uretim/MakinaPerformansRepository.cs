using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{

    public class MakinaPerformansDTO
    {
        public int MakinaKod { get; set; }
        public string MakinaAd { get; set; }
        public int Giren_kg { get; set; }

        public int Cikan_kg { get; set; }

        public int Hurda_kg { get; set; }
        public string Alasim { get; set; }

        public int Elektrik_kwh { get; set; }

      
        public int Gaz_kwh { get; set; }
        public decimal Run_hr { get;  set; }
        public decimal BakimDurus_hr { get;  set; }
        public decimal IsletmeDurus_hr { get;  set; }
        public decimal IdariDurus_hr { get;  set; }

        [NotMapped]
        public decimal ToplamDurus_hr { get;  set; }

        [NotMapped]
        public decimal HurdaYuzde { get;  set; }
    }

    public class MakinaPerformansRepository
    {
        private UretimDbContext dc = new UretimDbContext();


        public List<MakinaPerformansDTO> PerformansTabloGetir(DateTime baslamatarih, DateTime bitisTarih, string alasim="tumu")
        {

            IsMerkeziRepository repoIsMerkezi = new IsMerkeziRepository();
            MakinaParcaRepository repoMakinaParca = new MakinaParcaRepository();

            var makinaDuruslari = UretimDataService.MakinaDuruslariGetir();


            var uretimMakinalari = repoIsMerkezi.UretimMakinalariGetir();

            var makinaParcalariMotorGucleri = repoMakinaParca.MakinaParcalarigetir()
                            .GroupBy(c => new { c.MakinaKod })
                            .Select(g => new { MakinaKod = g.Key.MakinaKod, ToplamKwh = g.Sum(t => t.MotorGucuKw * ((decimal)t.HatHiziYuzde/100))})
                            .ToList();

            foreach (var item in uretimMakinalari)
            {
                item.MakinaToplamKwh = makinaParcalariMotorGucleri.Find(c => c.MakinaKod == item.Kod).ToplamKwh.GetValueOrDefault();
            }


            var bakimGrup=makinaDuruslari.Where(c => c.DurusGrup == "BAKIM").ToList();
            var isletmeGrup=makinaDuruslari.Where(c => c.DurusGrup == "ISLETME").ToList();
            var idariGrup=makinaDuruslari.Where(c => c.DurusGrup == "IDARI").ToList();


            var result = dc.UretimTablo
                .Where(c => c.Tarih >= baslamatarih && c.Tarih <= bitisTarih)
                .Where(c => c.Alaşım == alasim || alasim == "")
                .AsNoTracking()
                .ToList()
                .GroupBy(c => new { c.MakinaKod })
                .Select(g => new MakinaPerformansDTO
                {
                    MakinaKod = g.Key.MakinaKod,
                    Giren_kg = g.Sum(c => (int)c.GirişBobinAğırlığı.GetValueOrDefault()),
                    Cikan_kg = g.Sum(c => (int)c.ÇıkışBobinAğırlığı.GetValueOrDefault()),

                    Hurda_kg = g.Sum(c => (int)(c.Hurda.GetValueOrDefault() * 1000)),
                    Run_hr = g.Where(c => c.DuruşKodu == "1000").Sum(c => c.SüreDk).GetValueOrDefault() / 60,
                    BakimDurus_hr = g.Where(c => bakimGrup.Any(b=>b.DurusKod==c.DuruşKodu)).Sum(c => c.SüreDk).GetValueOrDefault() / 60,
                    IsletmeDurus_hr = g.Where(c => isletmeGrup.Any(b => b.DurusKod == c.DuruşKodu)).Sum(c => c.SüreDk).GetValueOrDefault() / 60,
                    IdariDurus_hr = g.Where(c => idariGrup.Any(b => b.DurusKod == c.DuruşKodu)).Sum(c=>c.SüreDk).GetValueOrDefault()/60

                })
                .ToList();



            foreach (var item in result)
            {
                var makina = uretimMakinalari.Find(c => c.Kod == item.MakinaKod);

                item.MakinaAd = makina.Tanim;
                item.Elektrik_kwh = (int)(makina.MakinaToplamKwh * item.Run_hr);
                item.HurdaYuzde = item.Giren_kg==0?0:  ((decimal)item.Hurda_kg / item.Giren_kg)*100;
                item.ToplamDurus_hr = item.Run_hr + item.BakimDurus_hr + item.IsletmeDurus_hr + item.IdariDurus_hr;
                
            }


            return result;
        }


    }
}
