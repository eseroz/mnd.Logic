using Newtonsoft.Json;
using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim
{
    public class Uretim_UretimTablo : MyBindableBase
    {
        public DateTime? başlangıçSaati;

        public DateTime? bitişSaati;

        private decimal? süreDk;
        private decimal? çıkışBobinAğırlığı;
        private decimal? çıkışKalınlık;
        private decimal? çıkışEni;
        private decimal? girişEni;
        private decimal? girişBobinAğırlığı;
        private string girişBobinNo;
        private string girişKafileNo;
        private string çıkışKafileNo;
        private int mesajSayisi;
        private int _okunmamisMesajSayisi1;
        private long ıd;
        private int siraNo;
        private string operatör;
        private string duruşKodu;
        private DateTime? tarih;
        private int? pasNo;
        private int? nihaiSonPas;
        private string alaşım;
        private string sonrakiİşlem;
        private int? çap;
        private int? ekSayısı;
        private string ekNedeni;
        private string çıkışBobinNo;
        private string kondüsyon;
        private decimal? girişKalınlık;
        private bool süreProblemliMi;
        private MakinaDurusTanim makinaDurus;
        private string kayitDurum;
        private string makinaDurusAd;
        private DateTime? kayitEklenmeTarihi;

        [Key]
        [Column("Id", Order = 1, TypeName = "bigint")]
        public long Id { get => ıd; set => SetProperty(ref ıd, value); }



        [NotMapped]
        public int SiraNo { get; set; }

        [NotMapped]
        public bool SüreProblemliMi => (Id != 0 && (SüreDk <= 0 || SüreDk > 1440));

        public int MakinaKod { get; set; }

        [NotMapped]
        public string MakinaAd { get; set; }

        public DateTime? Tarih { get => tarih; set => SetProperty(ref tarih, value); }

        public DateTime? BaşlangıçSaati
        {
            get => başlangıçSaati;
            set
            {
                SetProperty(ref başlangıçSaati, value);
                OnPropertyChanged(nameof(SüreDk));
            }
        }

        public DateTime? BitişSaati
        {
            get => bitişSaati;
            set
            {
                SetProperty(ref bitişSaati, value);
                OnPropertyChanged(nameof(SüreDk));
            }
        }

        public string Operatör { get => operatör; set => SetProperty(ref operatör, value); }

        public string OperatörYrd { get; set; }
        public string Vardiya { get; set; }

        public string Kondüsyon { get => kondüsyon; set => SetProperty(ref kondüsyon, value); }

        public string GirişKafileNo
        {
            get => girişKafileNo;
            set
            {
                SetProperty(ref girişKafileNo, value);
            }
        }

        public string GirişBobinNo
        {
            get => girişBobinNo;
            set
            {
                SetProperty(ref girişBobinNo, value);
            }
        }



        [Range(0, 8000)]
        public decimal? GirişBobinAğırlığı
        {
            get => girişBobinAğırlığı; set
            {
                SetProperty(ref girişBobinAğırlığı, value);
                OnPropertyChanged(nameof(KenarKesmeFiresi));
                OnPropertyChanged(nameof(İşletmeFiresi));

                OnPropertyChanged(nameof(Hurda));
            }
        }

        public string ÇıkışKafileNo
        {
            get => çıkışKafileNo;
            set => SetProperty(ref çıkışKafileNo, value);
        }

        public string ÇıkışBobinNo { get => çıkışBobinNo; set => SetProperty(ref çıkışBobinNo, value); }


        [Range(0, 8000)]
        public decimal? ÇıkışBobinAğırlığı
        {
            get => çıkışBobinAğırlığı; set
            {
                SetProperty(ref çıkışBobinAğırlığı, value);
                OnPropertyChanged(nameof(Ort_Kalınlık_Katsayısı));
                OnPropertyChanged(nameof(ÇıkışBobinAğırlığı));

                OnPropertyChanged(nameof(Hurda));
            }
        }

        public string DuruşKodu
        {
            get => duruşKodu;
            set
            {
                SetProperty(ref duruşKodu, value);
            }
        }

        [NotMapped]
        public string MakinaDuruşAd { get => makinaDurusAd; set => SetProperty(ref makinaDurusAd, value); }

        public decimal? GirişKalınlık { get => girişKalınlık; set => SetProperty(ref girişKalınlık, value); }

        public decimal? ÇıkışKalınlık
        {
            get => çıkışKalınlık; set
            {
                SetProperty(ref çıkışKalınlık, value);
                OnPropertyChanged(nameof(Ort_Kalınlık_Katsayısı));
            }
        }

        public decimal? GirişEni
        {
            get => girişEni; set
            {
                SetProperty(ref girişEni, value);
                OnPropertyChanged(nameof(Ort_EnKatsayısı));
                OnPropertyChanged(nameof(KenarKesmeFiresi));
            }
        }

        public decimal? ÇıkışEni
        {
            get => çıkışEni; set
            {
                SetProperty(ref çıkışEni, value);
                OnPropertyChanged(nameof(Ort_EnKatsayısı));

                OnPropertyChanged(nameof(KenarKesmeFiresi));
            }
        }

        public int? EkSayısı { get => ekSayısı; set => SetProperty(ref ekSayısı, value); }
        public string EkNedeni { get => ekNedeni; set => SetProperty(ref ekNedeni, value); }
        public int? PasNo { get => pasNo; set => SetProperty(ref pasNo, value); }
        public int? NihaiSonPas { get => nihaiSonPas; set => SetProperty(ref nihaiSonPas, value); }
        public string Alaşım { get => alaşım; set => SetProperty(ref alaşım, value); }
        public string Sonrakiİşlem { get => sonrakiİşlem; set => SetProperty(ref sonrakiİşlem, value); }

        public int? Çap { get => çap; set => SetProperty(ref çap, value); }

        public string Açıklama { get; set; }

        public decimal? SüreDk
        {
            get
            {
                if (başlangıçSaati == null || bitişSaati == null) return null;

                var sonuc = (decimal)(bitişSaati.Value - başlangıçSaati.Value).TotalMinutes;

                return sonuc;
            }
        }

        public decimal? Ort_Kalınlık_Katsayısı => ÇıkışBobinAğırlığı * ÇıkışKalınlık;
        public decimal? Ort_EnKatsayısı => ÇıkışBobinAğırlığı * ÇıkışEni;
        public decimal? KenarKesmeFiresi => ((GirişEni - ÇıkışEni) / GirişEni) * GirişBobinAğırlığı;
        public decimal? İşletmeFiresi => (girişBobinAğırlığı - çıkışBobinAğırlığı) - KenarKesmeFiresi;

        public decimal? Hurda
        {
            get
            {
                var sonuc = (girişBobinAğırlığı - çıkışBobinAğırlığı) / 1000;

                return sonuc;
            }
        }

        public string VeriTutarliMi()
        {
            var message = "";
            var newLine = Environment.NewLine;

            var durusKoduGiriliMi = !String.IsNullOrEmpty(DuruşKodu);

            if (BaşlangıçSaati == null) message += "BaşlangıçSaati boş geçilemez.";
            if (BitişSaati == null) message += newLine + "BitişSaati boş geçilemez.";
            if (BitişSaati < BaşlangıçSaati) message += newLine + "Bitiş saati başlangıç saatinden küçük olamaz. ";

            if (Operatör == null) message += newLine + "Operatör boş geçilemez.";
            if (Vardiya == null) message += newLine + "Vardiya boş geçilemez." + newLine;

            if (GirişBobinAğırlığı.GetValueOrDefault() == 0) message += "Giriş bobin ağırlığı boş geçilemez.";
            if (ÇıkışBobinAğırlığı.GetValueOrDefault() == 0) message += newLine + "Çıkış bobin ağırlığı boş geçilemez.";

            if (GirişEni == null) message += newLine + "GirişEni boş geçilemez.";
            if (ÇıkışEni == null) message += newLine + "ÇıkışEni boş geçilemez.";

            if (GirişKalınlık == null) message += newLine + "GirişKalınlık boş geçilemez.";
            if (ÇıkışKalınlık == null) message += newLine + "ÇıkışKalınlık boş geçilemez.";

            if (GirişKafileNo == null) message += newLine + "GirişKafileNo boş geçilemez.";
            if (ÇıkışKafileNo == null) message += newLine + "ÇıkışKafileNo boş geçilemez.";

            if (ÇıkışKalınlık > GirişKalınlık) message += newLine + "Çıkış kalınlık Giriş kalınlığından büyük olamaz. ";
            if (ÇıkışBobinAğırlığı > GirişBobinAğırlığı) message += newLine + "Çıkış bobin ağırlığı Giriş bobin ağırlığından büyük olamaz.";
            if (ÇıkışEni > GirişEni) message += newLine + "Çıkış eni giriş eninden büyük olamaz. ";

            var sonMesaj = message.Length > 0 ? Environment.NewLine + SiraNo.ToString() + ". kayıt için->>> " + message + Environment.NewLine : "";

            return sonMesaj;
        }

        [JsonIgnore]
        [NotMapped]
        public int MesajSayisi { get => mesajSayisi; set => SetProperty(ref mesajSayisi, value); }

        [JsonIgnore]
        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi1; set => SetProperty(ref _okunmamisMesajSayisi1, value); }

        [NotMapped]
        public decimal? NihaiSonPasTonaj
        {
            get
            {
                if (nihaiSonPas != null && nihaiSonPas == 1) return ÇıkışBobinAğırlığı.GetValueOrDefault();

                if (Sonrakiİşlem != null && (Sonrakiİşlem == "DL" || Sonrakiİşlem == "SP" || Sonrakiİşlem == "FTF")) return ÇıkışBobinAğırlığı.GetValueOrDefault();

                return 0;
            }

        }

        public Guid RowGuid { get; set; }

        public DateTime? KayitEklenmeTarihi { get => kayitEklenmeTarihi; set => SetProperty(ref kayitEklenmeTarihi, value); }

        [NotMapped]
        public string MakinaDurusGrupAd { get; set; }

        public string Uyari()
        {
            var uyari_message = "";

            if ((BitişSaati.GetValueOrDefault() - BaşlangıçSaati.GetValueOrDefault()).TotalMinutes < 5)
                uyari_message += "5 dakikadan daha az çalışıldı.";

            return uyari_message;
        }
    }
}