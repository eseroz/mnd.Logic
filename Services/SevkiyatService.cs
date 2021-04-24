using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class SevkiyatService
    {
        public static void Paletlerin_KonumDegistir(List<int> paletIds, string paletKonum)
        {
            PandapContext dc = new PandapContext();

            foreach (var paletId in paletIds)
            {
                var palet=dc.UretimPaletler.Find(paletId);
                palet.PaletKonum = paletKonum;
            }

            dc.SaveChanges();
            
        }

        public static void SevkiyatEmri_Paletlerin_KonumDegistir(int sevkiyatEmriId, string paletKonum)
        {
            PandapContext dc = new PandapContext();

            var paletler = dc.UretimPaletler.Where(c=>c.SevkiyatEmriId== sevkiyatEmriId);

            paletler
                .ToList()
                .Select(c=> { c.PaletKonum = paletKonum; return c; })
                .ToList();

            dc.SaveChanges();

        }


        public static void PaletAktifSevkEmriToDepo(string carikod)
        {
            PandapContext dc = new PandapContext();

            var palets = dc.UretimPaletler
                .Include(u=>u.UretimEmriKodNav)
                 .ThenInclude(u => u.SiparisKalemKodNav)
                  .ThenInclude(u => u.SiparisNav)
                .Where(c=>c.CariKod==carikod)
                .Where(c => c.PaletKonum == PALETKONUM.AKTIFSEVKEMRI)
                .Select(c=>c)
                .ToList();

            foreach (var palet in palets)
            {
                palet.PaletKonum = PALETKONUM.DEPO;
            }

            dc.SaveChanges();

        }

        public static List<CariSevkPaletDto> CariBazliSevkMiktarlariGetir()
        {
            PandapContext dc = new PandapContext();

            var aktifYil = DateTime.Now.Year;

            var query = dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Include(c => c.UretimEmriKodNav)
                    .Include(c => c.UretimEmriKodNav).ThenInclude(c => c.SiparisKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
                    .Where(c => c.FiyatKalemKod != null)   // palet oluşturma sırasında null olabiliyor
                    .AsQueryable();



            var query1 = dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Include(c => c.UretimEmriKodNav)
                    .Include(c => c.UretimEmriKodNav).ThenInclude(c => c.SiparisKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
                    .Where(c => c.FiyatKalemKod != null)
                    .Select(c => new
                    {
                        CariKod = c.FiyatKalemKodNav.SiparisNav.CariKod,
                        PaletNet_Kg = c.Bobinler.Sum(b => b.Agirlik_kg.GetValueOrDefault()),
                        PaletKonum = c.PaletKonum,
                        SevkiyatTarihi = c.SevkiyatTarihi

                    })
                    .Where(c => c.PaletKonum == PALETKONUM.SEVKEDILDI && c.SevkiyatTarihi.GetValueOrDefault().Year == aktifYil)
                    .AsNoTracking()
                    .ToList();


            var palets = query1
             .GroupBy(c => c.CariKod)
             .Select(c => new CariSevkPaletDto { CariKod = c.Key, PaletMiktarTon = c.Sum(p => p.PaletNet_Kg) }
             )
             .ToList();

            dc.Dispose();

            return palets;

        }

        public static List<CariSevkPaletDto> SevkEdilenMiktarlariGetir()
        {
            PandapContext dc = new PandapContext();

            var aktifYil = DateTime.Now.Year;

            var query = dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Include(c => c.UretimEmriKodNav)
                    .Include(c => c.UretimEmriKodNav).ThenInclude(c => c.SiparisKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
                    .Where(c => c.FiyatKalemKod != null)   // palet oluşturma sırasında null olabiliyor
                    .AsQueryable();



            var query1 = dc.UretimPaletler
                    .Include(c => c.Bobinler)
                    .Include(c => c.UretimEmriKodNav)
                    .Include(c => c.UretimEmriKodNav).ThenInclude(c => c.SiparisKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav)
                    .Include(c => c.FiyatKalemKodNav).ThenInclude(c => c.SiparisNav).ThenInclude(c => c.CariKartNavigation)
                    .Where(c => c.FiyatKalemKod != null)
                    .Select(c => new
                    {
                        CariKod = c.FiyatKalemKodNav.SiparisNav.CariKod,
                        PaletNet_Kg = c.Bobinler.Sum(b=>b.Agirlik_kg.GetValueOrDefault()),
                        PaletKonum = c.PaletKonum,
                        SevkiyatTarihi = c.SevkiyatTarihi

                    })
                    .Where(c => c.PaletKonum == PALETKONUM.SEVKEDILDI && c.SevkiyatTarihi.GetValueOrDefault().Year == aktifYil)
                    .AsNoTracking()
                    .ToList();


               var palets = query1
                .GroupBy(c => c.CariKod)
                .Select(c => new CariSevkPaletDto { CariKod = c.Key, PaletMiktarTon = c.Sum(p => p.PaletNet_Kg) }
                )
                .ToList();

            dc.Dispose();

            return palets;

        }



        public static void Paletler_SevkEmriId_Ata(List<int> paletIds, int sevkiyatEmriId, string paletKonum)
        {
            PandapContext dc = new PandapContext();

            foreach (var paletId in paletIds)
            {
                var palet = dc.UretimPaletler.Find(paletId);
                palet.SevkiyatEmriId = sevkiyatEmriId;
                palet.PaletKonum = paletKonum;
            }

            dc.SaveChanges();
        }
    }
}
