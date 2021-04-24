using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_SatinAlmaYeni.Domain;
using mnd.Logic.Helper;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnd.Logic.BC_SatinAlmaYeni.Data
{
    public class DepoCikisFisDTO : MyBindableBase
    {
        private string fisNo;
        private int masrafMerkeziKod;
        private ObservableCollection<DepoCikisFisKalemDTO> kalemlerDTO;
        private string talepEdenKisi;
        private string teslimAlanKisi;
        private DateTime fisTarihi;

        [Key]
        public string FisNo { get => fisNo; set => SetProperty(ref fisNo, value); }

        public DateTime FisTarihi { get => fisTarihi; set => SetProperty(ref fisTarihi, value); }
        public string TalepEdenKisi { get => talepEdenKisi; set => SetProperty(ref talepEdenKisi, value); }
        public string TeslimAlanKisi { get => teslimAlanKisi; set => SetProperty(ref teslimAlanKisi, value); }
        public int MasrafMerkeziKod { get => masrafMerkeziKod; set => SetProperty(ref masrafMerkeziKod, value); }

        [NotMapped]
        public string IlgiliUniteVarsayilan { get; set; }
        public string MasrafMerkeziAd { get; set; }

        public int KalemSayisi => KalemlerDTO.Count;

        public DepoCikisFisDTO()
        {
            KalemlerDTO = new ObservableCollection<DepoCikisFisKalemDTO>();
        }

        public ObservableCollection<DepoCikisFisKalemDTO> KalemlerDTO { get => kalemlerDTO; set => SetProperty(ref kalemlerDTO, value); }
        public string CariKod { get; set; }
    }

    public class DepoCikisFisKalemDTO
    {
        [Key]
        public int Id { get; set; }

        public string StokKodu { get; set; }

        public string StokAd { get; set; }
        public decimal CikisMiktar { get; set; }

        public decimal GirisMiktar { get; set; }

        public string OlcuBirimAd { get; set; }
        public int MasrafMerkeziKod { get; set; }
        public decimal KdvOran { get; set; }
        public string MasrafMerkeziAd { get; set; }
        public decimal? BirimFiyat { get;  set; }
        public byte? DovizTip { get;  set; }
        public string IlgiliUnite { get;  set; }
    }

    public class DepoRepository
    {
        // netsiste uygun sutun bulunmadığı için alakasız sutunlara kayıt yapılıyor

        private SatinAlmaDbContextYeni dc = new SatinAlmaDbContextYeni();

        public void NetsisDepoCikisFisiEkle(DepoCikisFisDTO depoCikisFisi)
        {
            DEPO_FATUIRS depo_fatuirs = new DEPO_FATUIRS();

            depo_fatuirs.FATIRS_NO = depoCikisFisi.FisNo;
            depo_fatuirs.CARI_KODU = depoCikisFisi.MasrafMerkeziKod.ToString();
            depo_fatuirs.ACIKLAMA = depoCikisFisi.TalepEdenKisi.ToNetsisCollation();
            depo_fatuirs.S_YEDEK1 = depoCikisFisi.TeslimAlanKisi.ToNetsisCollation();

            depo_fatuirs.FTIRSIP = "8";

            depo_fatuirs.TIPI = 0;
            depo_fatuirs.KOD1 = "Y";
            depo_fatuirs.KOD2 = "G";

            depo_fatuirs.KDV_DAHILMI = "H";
            depo_fatuirs.ODEMETARIHI = DateTime.Now;
            depo_fatuirs.FATKALEM_ADEDI = 1;

            depo_fatuirs.YEDEK = "X";
            depo_fatuirs.YEDEK22 = "C";
            depo_fatuirs.C_YEDEK6 = "M";
            depo_fatuirs.KAYITYAPANKUL = "NETSIS";
            depo_fatuirs.KAYITTARIHI = DateTime.Now;
            depo_fatuirs.DUZELTMEYAPANKUL = "NETSIS";
            depo_fatuirs.DUZELTMETARIHI = DateTime.Now;
            depo_fatuirs.ONAYTIPI = "A";
            depo_fatuirs.ISLETME_KODU = 1;
            depo_fatuirs.TARIH = DateTime.Now;

            foreach (var kalemDto in depoCikisFisi.KalemlerDTO)
            {
                DEPO_STHAR depo_sthar = new DEPO_STHAR();

                depo_sthar.STOK_KODU = kalemDto.StokKodu;
                depo_sthar.STHAR_GCMIK = kalemDto.CikisMiktar;

                depo_sthar.STHAR_GCKOD = "C";
                depo_sthar.ONAYTIPI = "A";

                depo_sthar.DEPO_KODU = 10;
                depo_sthar.STHAR_ACIKLAMA = kalemDto.MasrafMerkeziKod.ToString();
                depo_sthar.STHAR_KDV = 0;
                depo_sthar.STHAR_HTUR = "C";
                depo_sthar.STHAR_FTIRSIP = "8";
                depo_sthar.STHAR_TARIH = DateTime.Now;

                depo_sthar.STHAR_BGTIP = "I";

                depo_sthar.STHAR_KOD1 = "Y";
                depo_sthar.STHAR_KOD2 = "G";

                depo_sthar.STHAR_CARIKOD = kalemDto.MasrafMerkeziKod.ToString();
                depo_sthar.S_YEDEK2 = kalemDto.IlgiliUnite.ToNetsisCollation();

                depo_sthar.STHAR_SIP_TURU = "M";
                depo_sthar.EKALAN = kalemDto.MasrafMerkeziKod.ToString();
                depo_sthar.C_YEDEK6 = "X";

                depo_sthar.LISTE_FIAT = 1;

                depo_fatuirs.FIS_KALEMLERI.Add(depo_sthar);
            }

            dc.DepoFatuIrsaliyeler.Add(depo_fatuirs);
        }

        public void NetsisDepoGirisFisiEkle(DepoCikisFisDTO depoGirisFisi)
        {
            DEPO_FATUIRS depo_fatuirs = new DEPO_FATUIRS();

            depo_fatuirs.FATIRS_NO = depoGirisFisi.FisNo;
            depo_fatuirs.TARIH = depoGirisFisi.FisTarihi;

            depo_fatuirs.CARI_KODU = depoGirisFisi.CariKod;
            depo_fatuirs.ACIKLAMA = depoGirisFisi.TalepEdenKisi;

            depo_fatuirs.FTIRSIP = "4";  //1,Alış Faturası 2,Satış İrsaliyesi 3,Alış İrsaliyesi 4,Müşteri Siparişi 6,Satıcı Siparişi 7,D.A.T Giriş 8 ,DAT Çıkış 9,Saklanmış İrsaliye A değerini alır

            depo_fatuirs.TIPI = 2; //Kapalı fatura 1,açık fatura 2,muhtelif fatura 3,iade fatura 4,zayi iade 5 ve ithalat/ihracat faturası için 6 değeri alır.
            depo_fatuirs.KOD1 = "Y";
            depo_fatuirs.KOD2 = "G";

            depo_fatuirs.KDV_DAHILMI = "H";
            depo_fatuirs.ODEMETARIHI = DateTime.Now;
            depo_fatuirs.FATKALEM_ADEDI = (short)depoGirisFisi.KalemlerDTO.Count;

            depo_fatuirs.YEDEK = "X";
            depo_fatuirs.YEDEK22 = "C";
            depo_fatuirs.C_YEDEK6 = "M";
            depo_fatuirs.KAYITYAPANKUL = "HAMMADDE-01";
            depo_fatuirs.KAYITTARIHI = DateTime.Now;
            depo_fatuirs.DUZELTMEYAPANKUL = "HAMMADDE-01";
            depo_fatuirs.DUZELTMETARIHI = DateTime.Now;
            depo_fatuirs.ONAYTIPI = "A";
            depo_fatuirs.ISLETME_KODU = 1;
            depo_fatuirs.TARIH = DateTime.Now;

            int satirSiraNo = 0;
            foreach (var kalemDto in depoGirisFisi.KalemlerDTO)
            {
                satirSiraNo = satirSiraNo + 1;

                DEPO_STHAR depo_sthar = new DEPO_STHAR();

                depo_sthar.SIRA = (short)satirSiraNo;
                depo_sthar.STOK_KODU = kalemDto.StokKodu;
                depo_sthar.STHAR_GCMIK = kalemDto.GirisMiktar;

                depo_sthar.STHAR_GCKOD = "G";
                depo_sthar.ONAYTIPI = "A";

                depo_sthar.DEPO_KODU = 10;
                depo_sthar.STHAR_ACIKLAMA = kalemDto.MasrafMerkeziAd;
                depo_sthar.STHAR_KDV = kalemDto.KdvOran;
                depo_sthar.STHAR_HTUR = "H";
                depo_sthar.STHAR_FTIRSIP = "4"; //Kapalı fatura 1,açık fatura 2,muhtelif fatura 3,iade fatura 4,zayi iade 5 ve ithalat/ ihracat faturası için 6 değeri alır.
                depo_sthar.STHAR_TARIH = DateTime.Now;

                depo_sthar.STHAR_BGTIP = "I";
                depo_sthar.STHAR_KOD1 = "Y";
                depo_sthar.STHAR_KOD2 = "G";

                depo_sthar.STHAR_CARIKOD = depo_fatuirs.CARI_KODU;

                //   depo_sthar.STHAR_SIP_TURU = "";
                depo_sthar.C_YEDEK6 = "X";

                depo_sthar.LISTE_FIAT = 1;

                depo_fatuirs.FIS_KALEMLERI.Add(depo_sthar);
            }

            dc.DepoFatuIrsaliyeler.Add(depo_fatuirs);
        }

    
        public DepoCikisFisDTO FisGetir(string fis_no)
        {
            var dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.DepoFatuIrsaliyeler
                        .Include(c => c.FIS_KALEMLERI)
                        .Include(c => c.FIS_KALEMLERI).ThenInclude(f => f.STSABIT_NAV)
                        .Where(c => c.FATIRS_NO == fis_no)
                        .Select(c => new DepoCikisFisDTO
                        {
                            FisNo = c.FATIRS_NO,
                            FisTarihi = c.TARIH,
                            TalepEdenKisi = c.ACIKLAMA.FromNetsisCollation(),
                            TeslimAlanKisi = c.S_YEDEK1.FromNetsisCollation(),
                           
                            MasrafMerkeziKod = int.Parse(c.CARI_KODU),


                            KalemlerDTO = c.FIS_KALEMLERI.Select(k => new DepoCikisFisKalemDTO
                            {
                                Id = k.INCKEYNO,
                                StokKodu = k.STOK_KODU,
                                StokAd = k.STSABIT_NAV.STOK_ADI_TR,
                                CikisMiktar = k.STHAR_GCMIK.GetValueOrDefault(),
                                OlcuBirimAd = k.STSABIT_NAV.OLCU_BR1,
                                BirimFiyat = k.STHAR_BF,
                                DovizTip = k.STHAR_DOVTIP,
                                IlgiliUnite = k.S_YEDEK2.FromNetsisCollation(),
                            }).ToList().ToObservableCollection()
                        })
                        .First();
            return sonuc;
        }

        public List<DepoCikisFisDTO> DepoFisListesiGetir()
        {
            var dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.DepoFatuIrsaliyeler
                        .Include(c => c.FIS_KALEMLERI)
                        .OrderByDescending(c => c.TARIH)
                        .Select(c => new DepoCikisFisDTO
                        {
                            FisNo = c.FATIRS_NO,
                            FisTarihi = c.TARIH,
                            TalepEdenKisi = c.ACIKLAMA.FromNetsisCollation(),
                            TeslimAlanKisi = c.S_YEDEK1.FromNetsisCollation(),
                            MasrafMerkeziKod =int.Parse(c.CARI_KODU),
                       


                            MasrafMerkeziAd = c.MASRAFMERKEZI_NAV.MASRAFMERKEZAD.FromNetsisCollation(),

                            KalemlerDTO = c.FIS_KALEMLERI.Select(k => new DepoCikisFisKalemDTO
                            {
                                Id = k.INCKEYNO,
                                StokKodu = k.STOK_KODU,
                                StokAd = k.STSABIT_NAV.STOK_ADI_TR.FromNetsisCollation(),
                                CikisMiktar = k.STHAR_GCMIK.GetValueOrDefault(),
                                OlcuBirimAd = k.STSABIT_NAV.OLCU_BR1,
                                BirimFiyat=k.STHAR_BF,
                                DovizTip=k.STHAR_DOVTIP,
                                IlgiliUnite = k.S_YEDEK2.FromNetsisCollation(),

                            }).ToList().ToObservableCollection()
                        })

                        .ToList();

            return sonuc;
        }

        public List<DepoCikisFisDTO> DepoFisListesiGetir2019()
        {
            var dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.DepoFatuIrsaliyeler2019
                        .Include(c => c.FIS_KALEMLERI)
                        .OrderByDescending(c => c.TARIH)
                        .Select(c => new DepoCikisFisDTO
                        {
                            FisNo = c.FATIRS_NO,
                            FisTarihi = c.TARIH,
                            TalepEdenKisi = c.ACIKLAMA.FromNetsisCollation(),
                            TeslimAlanKisi = c.S_YEDEK1.FromNetsisCollation(),
                            MasrafMerkeziKod = int.Parse(c.CARI_KODU),
                            MasrafMerkeziAd = c.MASRAFMERKEZI_NAV.MASRAFMERKEZAD.FromNetsisCollation(),

                            KalemlerDTO = c.FIS_KALEMLERI.Select(k => new DepoCikisFisKalemDTO
                            {
                                Id = k.INCKEYNO,
                                StokKodu = k.STOK_KODU,
                                StokAd = k.STSABIT_NAV.STOK_ADI_TR.FromNetsisCollation(),
                                CikisMiktar = k.STHAR_GCMIK.GetValueOrDefault(),
                                OlcuBirimAd = k.STSABIT_NAV.OLCU_BR1,
                             
                            }).ToList().ToObservableCollection()
                        })

                        .ToList();

            return sonuc;
        }

        public List<DepoCikisFisDTO> DepoFisListesiGetir2020()
        {
            var dc = new SatinAlmaDbContextYeni();

            var sonuc = dc.DepoFatuIrsaliyeler2020
                        .Include(c => c.FIS_KALEMLERI)
                        .OrderByDescending(c => c.TARIH)
                        .Select(c => new DepoCikisFisDTO
                        {
                            FisNo = c.FATIRS_NO,
                            FisTarihi = c.TARIH,
                            TalepEdenKisi = c.ACIKLAMA.FromNetsisCollation(),
                            TeslimAlanKisi = c.S_YEDEK1.FromNetsisCollation(),
                            MasrafMerkeziKod = int.Parse(c.CARI_KODU),
                            MasrafMerkeziAd = c.MASRAFMERKEZI_NAV.MASRAFMERKEZAD.FromNetsisCollation(),

                            KalemlerDTO = c.FIS_KALEMLERI.Select(k => new DepoCikisFisKalemDTO
                            {
                                Id = k.INCKEYNO,
                                StokKodu = k.STOK_KODU,
                                StokAd = k.STSABIT_NAV.STOK_ADI_TR.FromNetsisCollation(),
                                CikisMiktar = k.STHAR_GCMIK.GetValueOrDefault(),
                                OlcuBirimAd = k.STSABIT_NAV.OLCU_BR1,

                            }).ToList().ToObservableCollection()
                        })

                        .ToList();

            return sonuc;
        }


        public string SonKayitNoGetir()
        {
            var sonKayitNo = "";
            var dc_sonkayit = new SatinAlmaDbContextYeni();

            var sonKayit = dc_sonkayit
                            .DepoFatuIrsaliyeler
                            .Where(c => c.FATIRS_NO.StartsWith("HDBC"))
                            .Where(c=>!c.FATIRS_NO.Contains("X"))
                            .OrderByDescending(c => c.FATIRS_NO)
                            .FirstOrDefault();

            if (sonKayit == null) sonKayitNo = "HDBC00000000001";

            if (sonKayit != null)
            {
                sonKayitNo = (long.Parse(sonKayit.FATIRS_NO.Replace("HDBC", "")) + 1).ToString();
                sonKayitNo = "HDBC" + sonKayitNo.PadLeft(11, '0');
            }

            return sonKayitNo;
        }

        public List<string> StokDepoHucreGetir(string stokKodu)
        {
            var dc_stokDurum = new SatinAlmaDbContextYeni();
            var sonuc = dc.DepoDurumlari.Where(c => c.STOKKODU == stokKodu)
                .Select(c => c.HUCREKODU)
                .ToList();

            dc_stokDurum.Dispose();

            return sonuc;
        }

        public List<string> StokDepoHucreGetir()
        {
            var dc_stokDurum = new SatinAlmaDbContextYeni();
            var sonuc = dc.DepoDurumlari
                .Select(c => c.HUCREKODU)
                .ToList();

            dc_stokDurum.Dispose();

            return sonuc;
        }

    

        public void Kaydet()
        {
            try
            {
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}