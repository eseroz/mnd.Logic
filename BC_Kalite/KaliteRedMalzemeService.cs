using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_Kalite.QueryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Kalite
{
    public class KaliteRedMalzemeService
    {
        public Task<List<RedMalzemeDto>> RedMalzemeListesi()
        {
            KaliteDbContext dc = new KaliteDbContext();

            var sonuc=dc.KalteRedMalzemeler.Select(c => new RedMalzemeDto
            {
                Id = c.Id,
                UretimEmriKod = c.UretimEmriKod,
                Tarih = c.Tarih,
                KafileNo = c.KafileNo,
                Vardiya = c.Vardiya,
                Operator = c.Operator,
                BobinNo = c.BobinNo,
                MalzemeNo = c.MalzemeNo,
                Alasim = c.Alasim,
                Kondusyon = c.Kondusyon,
                En = c.En,
                Kalinlik = c.Kalinlik,
                RedYeri = c.RedYeri,
                RedMiktarKg = c.RedMiktarKg,
                Musteri = c.Musteri,
                RedNedeni = c.RedNedeni,
                KaliteTeknisyeni = c.KaliteTeknisyeni,
                RowGuid=c.RowGuid,
            })
            .AsNoTracking()
            .ToListAsync();

            return sonuc;
        }
    }
}
