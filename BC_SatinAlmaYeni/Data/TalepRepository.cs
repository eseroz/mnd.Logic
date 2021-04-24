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

    public class SurecInfo
    {
        public string SurecAd { get; set; }

        public int SurecSayi { get; set; }
        public string Param1 { get; internal set; }
    }
    public class TalepRepository
    {
        SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();

     

        public ObservableCollection<Talep> TalepListesi(string tip=null, string surecAdimKod=null)
        {
            var sonuc = dc.Talepler
                .Where(c => c.Tip == tip || tip == null)
                .Where(c => c.TalepSurecKonum == surecAdimKod || surecAdimKod == null)
                .Include(c => c.TalepKalemler)
                .Include(c => c.TeklifIlgiliFirmalar)
                .Include(c => c.TalepKalemler).ThenInclude(p => p.TalepKalemTeklifler)
                .OrderByDescending(c => c.TalepId)
                .ToList();



            foreach (var item in sonuc)
            {


                item.StokAdlariBirlesik = String.Join(Environment.NewLine, item.TalepKalemler
                                            .Select(c => c.StokAd));

            }

            return sonuc.ToObservableCollection(); 
        }

        public ObservableCollection<TalepDTO> TalepDurumListesi()
        {
            var sonuc = dc.Talepler
                .Where(c => c.Tip == "Talep")
                .Include(c => c.TalepKalemler)
                .Include(c => c.TeklifIlgiliFirmalar)
                .Include(c => c.TalepKalemler).ThenInclude(p => p.TalepKalemTeklifler)
                .Select(c => new TalepDTO
                {
                    TalepId = c.TalepId,
                    TalepTarihi = c.TalepTarihi,
                    TalepEdenAdSoyad = c.TalepEdenAdSoyad,
                    IsMerkeziAd = c.IsMerkeziAd,
                    StokGrupAd = c.StokGrupAd,
                    MesajSayisi=c.MesajSayisi,
                    OkunmamisMesajSayisi=c.OkunmamisMesajSayisi,
                    RowGuid =c.RowGuid,
                    UrunAdlariBirlesik="",
                    ToplamTalepKalemSayisi=0,

                    TalepTip=c.Tip,


                    ToplamSiparisSayisi=0,
                    ToplamTeslimAlinanSiparisSayisi=0,
                    ToplamTeslimBekleyenSiparisSayisi=0,
                    SurecBilgi=c.TalepSurecKonum,
                    
                    TalepUrunListe =c.TalepKalemler.Select(u=> new TalepKalemDTO
                    {
                        UrunKod=u.StokKod,
                        UrunAd=u.StokAd,
                        Miktar=u.Miktar,
                        Birim=u.Birim,
                        TercihMarka=u.TercihMarkaModel
                    })
                    .ToList()
                })
                .AsNoTracking()
                .OrderByDescending(c=>c.TalepId)
                .ToList();


            foreach (var item in sonuc)
            {
                

                item.UrunAdlariBirlesik = String.Join(Environment.NewLine, item.TalepUrunListe
                                            .Select(c =>  c.UrunAd + 
                                                            (c.TercihMarka?.Length > 0 ? $" ({c.TercihMarka}) " : " ") + 
                                                            c.Miktar.ToString() + " " +
                                                            c.Birim));

                item.ToplamTalepKalemSayisi = item.TalepUrunListe.Count;
            }

            return sonuc.ToObservableCollection();
        }

        public ObservableCollection<Talep> CariSiparisListesi(string cariKod, string surecAdimKod = null)
        {
            var sonuc = dc.Talepler
                .Where(c => c.Tip == "Sipariş")
                .Where(c => c.TalepSurecKonum == surecAdimKod)
                .Where(c => c.OnaylananFirmaKod == cariKod)
                .Include(c => c.TalepKalemler);
               

            return sonuc.ToObservableCollection(); 
        }


        public List<StokGrupTanim> StokGruplariGetir()
        {
            var dcx =new SatinAlmaDbContextYeni();

            var result=dcx.StokGrupTanimlar
                .Where(c=> !String.IsNullOrEmpty(c.StokGrupKod))
                .Where(c=>c.StokGrupKod!="MM")
                .OrderBy(c=>c.StokGrupAd)
               
                .ToList();
            return result;
        }




        public ObservableCollection<Talep> Taleplerim(string kullaniciId)
        {
            var sonuc = dc.Talepler
                .Where(c => c.Ekleyen == kullaniciId)
                .Include(c => c.TalepKalemler)
                .Include(c=>c.TeklifIlgiliFirmalar)
                .Include(c => c.TalepKalemler).ThenInclude(p => p.TalepKalemTeklifler)
                .ToObservableCollection();
            return sonuc;
        }


        public int TalepEkle(Talep talep)
        {
            dc.Talepler.Add(talep);
            dc.SaveChanges();

            return talep.TalepId;
        }


        public int TalepSil(Talep talep)
        {
            dc.Talepler.Remove(talep);
            dc.SaveChanges();

            return 1;
        }

        public void SiparisTarihAta(int talepId, DateTime siparisTarihi)
        {
            var dcx = new SatinAlmaDbContextYeni();

            var sonuc = dcx.Talepler
                 .Where(c => c.TalepId == talepId)
                 .First();

            sonuc.SiparisTarih = siparisTarihi;
            dcx.SaveChanges();

        }

        public void SurecDegistir(int talepId, string yeniSurecKod)
        {
            var dcx = new SatinAlmaDbContextYeni();

            AppRepositorySA repoSurec = new AppRepositorySA();
            var yeniSurec = repoSurec.SurecListe("SatınAlma").FirstOrDefault(c=>c.SurecAdimKod==yeniSurecKod);

            var sonuc = dcx.Talepler
              .Where(c => c.TalepId == talepId)
              .First();


            if (yeniSurec!=null && yeniSurec.Param1!=null)
            {
                sonuc.Tip = yeniSurec.Param1;
            }

            sonuc.TalepSurecKonum = yeniSurecKod;
            dcx.SaveChanges();

        }

        public Talep TalepGetir(int talepId)
        {
            var sonuc = dc.Talepler
                .Include(c => c.TalepKalemler)
                .Include(c=>c.TeklifIlgiliFirmalar)
                .Include(c => c.TalepKalemler).ThenInclude(p => p.TalepKalemTeklifler)
                .Where(c => c.TalepId == talepId)
                .First();
            return sonuc;
        }

      

        public void Kaydet()
        {
            dc.SaveChanges();
        }


      




        public void TalepleriEkle(List<Talep> olusturulacakTalepler)
        {
            dc.Talepler.AddRange(olusturulacakTalepler);
            dc.SaveChanges();
        }

        public Guid? TalepRowGuidGetir(int talepId)
        {
            SatinAlmaDbContextYeni dcTalep = new SatinAlmaDbContextYeni();

            var talep=dc.Talepler.FirstOrDefault(c => c.TalepId == talepId);

          
            return talep?.RowGuid;
        }
    }
}
