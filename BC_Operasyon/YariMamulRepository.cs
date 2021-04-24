using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Operasyon
{
    public class YariMamulRepository
    {
        OperasyonIstatistikDbContext dc = new OperasyonIstatistikDbContext();

        public ObservableCollection<YariMamulHatData> YariMamulDataGetir(DateTime tarih, List<string> hatListesi)
        {
            var result = dc.YariMamulHatVeriler.Where(c => c.Tarih == tarih.Date).ToObservableCollection();

            if (result.Count == 0)
            {

                for (int i =0; i <= hatListesi.Count-1; i++)
                {
                    var yariMamul = new YariMamulHatData();
                    yariMamul.Hat = hatListesi[i];
                    yariMamul.Tarih = tarih;
                    yariMamul.Sirano = i+1;
                    dc.YariMamulHatVeriler.Add(yariMamul);
                    dc.SaveChanges();
                }


                var yeniData= dc.YariMamulHatVeriler.Where(c => c.Tarih == tarih.Date).ToObservableCollection();

                return yeniData;
            }

            return result;

        }


        public ObservableCollection<YariMamulHatData> YariMamulSonDataGetir()
        {
            var sonData= dc.YariMamulHatVeriler
                                .Where(c => c.SonKayitTarihi != null)
                                .LastOrDefault();

            if (sonData == null) return null;
                               

            var result = dc.YariMamulHatVeriler
                            .Where(c=>c.SonKayitTarihi== sonData.SonKayitTarihi)
                            .ToObservableCollection();

            return result;

        }



        public YariMamulBirimFiyat YariMamulSonFiyatlariGetir()
        {
           var sonFiyat= dc.YariMamulBirimFiyatlari.Last();

            return sonFiyat;
        }


        public void Kaydet()
        {
            dc.SaveChanges();
        }
    }
}
