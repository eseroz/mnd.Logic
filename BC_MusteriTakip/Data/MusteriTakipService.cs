using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_MusteriTakip.Domain;
using mnd.Logic.BC_MusteriTakip.DTOs;
using mnd.Logic.Helper;
using mnd.Logic.Model.Netsis;
using mnd.Logic.Persistence;
using mnd.Logic.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.BC_MusteriTakip.Data
{
    public class Result
    {
        public int ResultCode { get; set; }
    }

    public class MusteriTakipService
    {

        public int PandaCariGuncelle(PandapCariDto musteri)
        {
            PandapContext dc = new PandapContext();

            var cari = dc.PandapCaris.Where(c => c.CariKod == musteri.CariKod).FirstOrDefault();
            cari.PandaSahaSorumlusu = musteri.PandaSahaSorumlusu;
            cari.KontratDonemTip = musteri.KontratDonemTip;
            cari.KontratDonemDeger = musteri.KontratDonemDeger;
            cari.FirmaGrupTip = musteri.FirmaGrupTip;
            cari.MusteriKullanimAlanTipKod = musteri.KullanimAlanTipKod;
            cari.MusteriPotansiyelDurum = musteri.Durumu;

            cari.CariSevkAdres = musteri.SevkAdres;

            cari.Web = musteri.Web;
            cari.Email = musteri.Email;
            cari.CariTel = musteri.Tel;

            dc.SaveChanges();

            return 0;
        }


        public int NetsisMusteriBilgileriGuncelle(string cariKod, string tel, string adres,
            string kullanimAlanTipKod, int? yillikTonaj, string plasiyerKod, string agent, string sektorKod, string musteriPotansiyelDurum)
        {
            //3 iş merkezi
            //4FirmaGrupTip,
            //5AktifPasifDurum

            MusteriTakipDbContext dc = new MusteriTakipDbContext();

            var yil = DateTime.Now.Year;

            var str = $"UPDATE MND{yil}.dbo.TBLCASABIT SET  " +
                      "CARI_TEL = @tel, " +
                      "RAPOR_KODU3 = @musteriPotansiyelDurum," +
                      "PLASIYER_KODU=@plasiyerKod, " +
                      "CARI_ADRES = @adres " +
                      "WHERE(CARI_KOD = @cariKod)";

            SqlConnection cnn = new SqlConnection(dc.Database.GetDbConnection().ConnectionString);

            cnn.Open();
            SqlCommand cmd = new SqlCommand(str, cnn);


            cmd.Parameters.AddWithValue(nameof(tel), tel);
            //cmd.Parameters.AddWithValue(nameof(kullanimAlanTipKod), kullanimAlanTipKod);
            //cmd.Parameters.AddWithValue(nameof(yillikTonaj), yillikTonaj);
            //cmd.Parameters.AddWithValue(nameof(agent), agent);
            cmd.Parameters.AddWithValue(nameof(musteriPotansiyelDurum), musteriPotansiyelDurum);
            //cmd.Parameters.AddWithValue(nameof(sektorKod), sektorKod);
            cmd.Parameters.AddWithValue(nameof(plasiyerKod), plasiyerKod);
            cmd.Parameters.AddWithValue(nameof(adres), adres);
            cmd.Parameters.AddWithValue(nameof(cariKod), cariKod);


            int count = cmd.ExecuteNonQuery();
            cnn.Close();

            dc.Database.ExecuteSqlCommandAsync("exec Satis.Upsert_PandapCari");

            return 0;
        }

        public static ObservableCollection<FirmaTemsilci> FirmaTemsilcileriniGetir(string musteriCariKod)
        {
            MusteriTakipNetsisDbContext dc = new MusteriTakipNetsisDbContext();
            var sonuc = dc.NetsisCariEmails
                .Where(c => c.CARI_KOD == musteriCariKod && c.AKTIF == true)
                .Select(c => new FirmaTemsilci
                {
                    Id = c.RECID,
                    AdSoyad = c.YETKILIKISI.FromNetsisCollation(),
                    Email = c.EMAIL,
                    Tel = c.TEL,
                    Unvan = c.UNVAN
                })
                .ToObservableCollection();

            return sonuc;
        }


        public static void KaydetYadaEkle(FirmaTemsilci ft)
        {
            MusteriTakipNetsisDbContext dc = new MusteriTakipNetsisDbContext();

            if (ft.Id == 0)
            {
                var netsisKisi = new NetsisCariEmail();

                netsisKisi.YETKILIKISI = ft.AdSoyad.ToNetsisCollation();
                netsisKisi.OZELEMAIL = ft.Email;
                netsisKisi.TEL = ft.Tel;
                netsisKisi.UNVAN = ft.Unvan;
                netsisKisi.AKTIF = true;
                netsisKisi.KAYITTARIHI = DateTime.Now.Date;
                netsisKisi.DUZELTMETARIHI = DateTime.Now.Date;
                netsisKisi.CARI_KOD = ft.CariKod;

                netsisKisi.EKBILGI = ft.Birim;


                dc.NetsisCariEmails.Add(netsisKisi);
                dc.SaveChanges();

                ft.Id = netsisKisi.RECID;

            }
            else
            {
                var nkisi = dc.NetsisCariEmails.Where(u => u.RECID == ft.Id).FirstOrDefault();

                nkisi.YETKILIKISI = ft.AdSoyad.ToNetsisCollation();
                nkisi.OZELEMAIL = ft.Email;
                nkisi.TEL = ft.Tel;
                nkisi.UNVAN = ft.Unvan;
                nkisi.AKTIF = true;
                nkisi.EKBILGI = ft.Birim;
                nkisi.DUZELTMETARIHI = DateTime.Now.Date;
                dc.SaveChanges();

            }

        }

        public static void CariEmailKaydetYadaEkle(CariEmailYeni ft)
        {
            MusteriTakipNetsisDbContext dc = new MusteriTakipNetsisDbContext();

            if (ft.Id == 0)
            {
                var cariEmail = new NetsisCariEmail();

                cariEmail.YETKILIKISI = ft.YetkiliKisi.ToNetsisCollation();
                cariEmail.OZELEMAIL = ft.Email;
                cariEmail.TEL = ft.Tel;
                cariEmail.UNVAN = ft.Unvan;
                cariEmail.AKTIF = true;
                cariEmail.KAYITTARIHI = DateTime.Now.Date;
                cariEmail.DUZELTMETARIHI = DateTime.Now.Date;
                cariEmail.CARI_KOD = ft.CariKod;

                cariEmail.EKBILGI = ft.Birim;
                cariEmail.ISLEMTIPI = ft.Durum;


                dc.NetsisCariEmails.Add(cariEmail);
                dc.SaveChanges();

                ft.Id = cariEmail.RECID;

            }
            else
            {
                var nkisi = dc.NetsisCariEmails.Where(u => u.RECID == ft.Id).FirstOrDefault();

                nkisi.YETKILIKISI = ft.YetkiliKisi.ToNetsisCollation();
                nkisi.OZELEMAIL = ft.Email;
                nkisi.TEL = ft.Tel;
                nkisi.UNVAN = ft.Unvan;
                nkisi.AKTIF = true;
                nkisi.EKBILGI = ft.Birim;
                nkisi.DUZELTMETARIHI = DateTime.Now.Date;

                nkisi.ISLEMTIPI = ft.Durum;


                dc.SaveChanges();

            }

        }


        public async Task<List<GorusmeDTO>> GorusmeleriPlasiyereGoreGetir(string[] bagliPlasiyerKodlari)
        {
            MusteriTakipDbContext db = new MusteriTakipDbContext();
            var sonuc =await db.Gorusmeler
                .Include(c => c.GorusmeKonuTip)
                .Include(c => c.GorusmeTip)
               .Select(c=>new GorusmeDTO
               {
                  Id=c.Id,
                  GorusmeTarih=c.GorusmeTarih,
                 
                  CariIsim=c.CariIsim,
                  GorusulenKisi=c.GorusulenKisi,
                  GorusmeKonuTipAd=c.GorusmeKonuTip.Ad,
                  GorusmeTipAd=c.GorusmeTip.Ad,
                  GorusmeDetay=c.GorusmeDetay.Substring(1,30) + "...",
                  RowGuid=c.RowGuid,
                  PlasiyerKod=c.PlasiyerKod,
                  UlkeKod=c.UlkeKod,
                  Ekleyen=c.Ekleyen,
                  KullanimAlanTipKod = c.KullanimAlanTipKod


               })
                .Where(c => bagliPlasiyerKodlari.Any(x => x.ToString() == c.PlasiyerKod.ToString()))
                .AsNoTracking()
                .ToListAsync();

            return sonuc;
        }



    }
}
