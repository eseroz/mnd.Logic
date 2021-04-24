using mnd.Logic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.Services
{
    public class SiparisFiyatHesapService
    {
        public static SatirFiyatSonucDto FiyatSonucDTO_Getir(string cariKod, decimal? lmeBF, decimal? kulceBF, decimal? iscilikBF,
                                                    decimal? iscilikVadeFarkiOran, decimal? kdvOran, int miktarKg, string IlgiId, string dovizTipKod)
        {
            var satirFiyatDto = new SatirFiyatSonucDto();

            satirFiyatDto.CariKod = cariKod;
            satirFiyatDto.IlgiliId = IlgiId;
            satirFiyatDto.MiktarKg = miktarKg;
            satirFiyatDto.DovizTipKod = dovizTipKod;

            var varsayilanBirimFiyatKg = (decimal)(lmeBF.GetValueOrDefault() + kulceBF.GetValueOrDefault() + iscilikBF.GetValueOrDefault()) / 1000;

            satirFiyatDto.IscilikVadeFarkiTutar = varsayilanBirimFiyatKg * iscilikVadeFarkiOran.GetValueOrDefault() / 100;

            satirFiyatDto.BirimFiyat = varsayilanBirimFiyatKg + satirFiyatDto.IscilikVadeFarkiTutar;

            satirFiyatDto.BirimFiyat = Math.Round(satirFiyatDto.BirimFiyat, 3);

            satirFiyatDto.ToplamTutar = satirFiyatDto.BirimFiyat * miktarKg;

            satirFiyatDto.KdvTutar = satirFiyatDto.ToplamTutar * kdvOran.GetValueOrDefault() / (decimal)100.0;

            satirFiyatDto.GenelToplamTutar = (satirFiyatDto.ToplamTutar + satirFiyatDto.KdvTutar);

            return satirFiyatDto;
        }

        public static decimal FiyatHesapla(int Miktar_kg, decimal? LmeTutar, decimal? KulceTutar, decimal? IscilikTutar, 
                                    decimal? kdvOran, decimal? IscilikVadeFarkiOran )
        {
            var varsayilanBirimFiyat = (decimal)(LmeTutar + KulceTutar + IscilikTutar) / 1000;

            var IscilikVadeFarkiTutar = varsayilanBirimFiyat * IscilikVadeFarkiOran / 100;

            var BirimFiyat = varsayilanBirimFiyat + IscilikVadeFarkiTutar;

            BirimFiyat = Math.Round(BirimFiyat.GetValueOrDefault(), 3);

            var ToplamTutar = BirimFiyat * Miktar_kg;

            var KdvTutar = ToplamTutar * kdvOran / (decimal)100.0;

            var GenelToplamTutar = (ToplamTutar + KdvTutar);

            return GenelToplamTutar.GetValueOrDefault();
        }

    }
}
