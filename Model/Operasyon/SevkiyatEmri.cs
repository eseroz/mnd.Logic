using mnd.Logic.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Operasyon
{
    [NotMapped]
    public class UlkeIsimVeIsoKod
    {
        public string UlkeIsim { get; set; }
        public string UlkeKodIso { get; set; }
        public string CariAd { get; set; }
    }


    [NotMapped]
    public class IrsaliyePaletDto : MyBindableBase
    {
        private int _masuraSayisi;

        [Key]
        public int PaletId { get; set; }
        public int SevkiyatEmriId { get; set; }
        public int IrsaliyeId { get; set; }
        public string CariAd { get; set; }
        public decimal? Kalinlik { get; set; }
        public decimal? En { get; set; }
        public int PaletNet_Kg { get; set; }
        public int PaletBrut_Kg { get; set; }
        public int PaletDara_Kg { get; set; }
        public string PaletEbat { get; set; }
        public string UrunKod { get; set; }



        public int MasuraSayisi { get => _masuraSayisi; set => SetProperty(ref _masuraSayisi, value); }
        public bool YuklendiMi { get; set; }
    }


    [Table(nameof(SevkiyatEmri), Schema = "Operasyon")]
    public class SevkiyatEmri : MyBindableBase
    {

        public SevkiyatEmri()
        {
            CariIrsaliyeler = new ObservableCollection<Irsaliye>();

        }

        public string NakliyeciFaturaNo { get => nakliyeciFaturaNo; set => SetProperty(ref nakliyeciFaturaNo, value); }


        [Key]
        public int SevkiyatEmriId { get; set; }


        public bool? RiskVarMi { get => riskVarMi.GetValueOrDefault(); set => riskVarMi = value; }

        public void PaletYuklemeVerileriniEkle()
        {
            TumPaletler = TumPaletleriGetir();
            YuklenenPaletler = TumPaletler.Where(c => c.YuklendiMi == true).ToObservableCollection();
            KalanPaletler = TumPaletler.Where(c => c.YuklendiMi == false).ToObservableCollection();
        }

        public DateTime? TeslimTarihi { get => teslimTarihi; set => SetProperty(ref teslimTarihi, value); }

        public Guid RowGuid { get; set; }

        [NotMapped]
        public int MesajSayisi { get => _mesajSayisi; set => SetProperty(ref _mesajSayisi, value); }

        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi; set => SetProperty(ref _okunmamisMesajSayisi, value); }


        public DateTime? SevkiyatTarihi { get; set; }


        public void AlanlariYenidenHesapla()
        {
            OnPropertyChanged(nameof(PaletBrut_TKg));
            OnPropertyChanged(nameof(PaletDara_TKg));
            OnPropertyChanged(nameof(PaletNet_TKg));
            OnPropertyChanged(nameof(KantarFark));
        }

        private string sevkSurecDurum;

        private string _kontainerNo;
        private string _muhurNo;
        private string _soforTel;
        private int? _kantarDara;
        private int? _kantarBrut;
        private string _plaka;
        private string _dorse;
        private string _aracSoforAd;
        private string _nakliyeci;
        private decimal? _nakliyeFiyati;
        private string _ambarSorumlusu;
        private string _lojistik;
        private string _muhasebe;
        private string _guvenlik;
        private string _ulasimTip;
        private int _mesajSayisi;
        private int _okunmamisMesajSayisi;
        private ObservableCollection<IrsaliyePaletDto> _yuklenenPaletler;
        private ObservableCollection<IrsaliyePaletDto> _kalanPaletler;
        private ObservableCollection<IrsaliyePaletDto> _tumPaletler;
        private int _paletNet_TKg_Yuklenen;
        private ObservableCollection<Irsaliye> _cariIrsaliyeler;
        private bool? riskVarMi;
        private string faturaKesimCariKod;
        private string nakliyeciFaturaNo;
        private DateTime? teslimTarihi;

        public string SevkSurecDurum
        {
            get => sevkSurecDurum;
            set => SetProperty(ref sevkSurecDurum, value);
        }

        [NotMapped]
        public string CariIsimlerBirlesik
        {
            get
            {
                if (CariIrsaliyeler.Count == 0) return "";
                return CariIrsaliyeler?.Select(c => c.CariKod + "-" + c.CariAd)
                   .Distinct().ToList().Aggregate((current, next) => current + Environment.NewLine + next);
            }
        }

        [NotMapped]
        public List<UlkeIsimVeIsoKod> CariIsimVeIsoList
        {
            get
            {
                if (CariIrsaliyeler.Count == 0) return null;
                return CariIrsaliyeler?.Select(c => new UlkeIsimVeIsoKod
                { UlkeIsim = c.CariKodNav?.UlkeAd, UlkeKodIso = c.CariKodNav?.UlkeKod, CariAd = c.CariKodNav?.CariIsim })
                .ToList();
            }
        }


        [NotMapped]
        public string CariKodBirlesik
        {
            get
            {
                return String.Join(",", CariIrsaliyeler.Select(c => c.CariKod));
            }
        }


        public string AmbarSorumlusu { get => _ambarSorumlusu; set => SetProperty(ref _ambarSorumlusu, value); }
        public string Lojistik { get => _lojistik; set => SetProperty(ref _lojistik, value); }
        public string Muhasebe { get => _muhasebe; set => SetProperty(ref _muhasebe, value); }
        public string Guvenlik { get => _guvenlik; set => SetProperty(ref _guvenlik, value); }


        [NotMapped]
        public int? PaletNet_TKg => CariIrsaliyeler.Sum(c => c.IrsaliyePaletler.Sum(p => p.PaletBrut_Kg - p.PaletDara_Kg));

        [NotMapped]
        public int? PaletDara_TKg => CariIrsaliyeler.Sum(c => c.IrsaliyePaletler.Sum(p => p.PaletDara_Kg));


        [NotMapped]
        public int? PaletBrut_TKg => CariIrsaliyeler.Sum(c => c.IrsaliyePaletler.Sum(p => p.PaletBrut_Kg));


        public string FaturaKesimCariKod { get => faturaKesimCariKod; set => SetProperty(ref faturaKesimCariKod, value); }

        public int? KantarDara
        {
            get => _kantarDara.GetValueOrDefault();
            set
            {
                SetProperty(ref _kantarDara, value);
                OnPropertyChanged(nameof(KantarFark));
                OnPropertyChanged(nameof(KantarNet));
            }
        }

        public int? KantarBrut
        {
            get => _kantarBrut.GetValueOrDefault();
            set
            {
                SetProperty(ref _kantarBrut, value);
                OnPropertyChanged(nameof(KantarFark));
                OnPropertyChanged(nameof(KantarNet));
            }
        }

        [NotMapped]
        public int? KantarNet
        {
            get => _kantarBrut.GetValueOrDefault() - _kantarDara.GetValueOrDefault();
        }

        [NotMapped]
        public int? KantarFark { get => KantarBrut.GetValueOrDefault() - KantarDara.GetValueOrDefault() - PaletBrut_TKg.GetValueOrDefault(); }



        public string Nakliyeci { get => _nakliyeci; set => SetProperty(ref _nakliyeci, value); }
        public decimal? NakliyeFiyati { get => _nakliyeFiyati; set => SetProperty(ref _nakliyeFiyati, value); }


        public string NakliyeDovizCinsi { get; set; }

        public string Plaka { get => _plaka; set => SetProperty(ref _plaka, value); }
        public string Dorse { get => _dorse; set => SetProperty(ref _dorse, value); }
        public string AracSoforAd { get => _aracSoforAd; set => SetProperty(ref _aracSoforAd, value); }
        public string SoforTel { get => _soforTel; set => SetProperty(ref _soforTel, value); }

        public string KontainerNo { get => _kontainerNo; set => SetProperty(ref _kontainerNo, value); }
        public string MuhurNo { get => _muhurNo; set => SetProperty(ref _muhurNo, value); }

        public string UlasimTip { get => _ulasimTip; set => SetProperty(ref _ulasimTip, value); }

        public ObservableCollection<Irsaliye> CariIrsaliyeler
        {
            get => _cariIrsaliyeler;
            set
            {
                _cariIrsaliyeler = value;


            }
        }




        [NotMapped]
        public int PaletNet_TKg_Yuklenen { get => _paletNet_TKg_Yuklenen; set => SetProperty(ref _paletNet_TKg_Yuklenen, value); }



        public ObservableCollection<IrsaliyePaletDto> TumPaletler { get => _tumPaletler; set => SetProperty(ref _tumPaletler, value); }


        public void PaletYukle(IrsaliyePaletDto irsPalet)
        {
            YuklenenPaletler.Add(irsPalet);
            KalanPaletler.Remove(irsPalet);

            OnPropertyChanged(nameof(SevkiyatYuklenmeOran));
            OnPropertyChanged(nameof(SevkiyatYuklemeMetin));

            OnPropertyChanged(nameof(YuklemeBittiMi));


        }

        public void PaletCikar(IrsaliyePaletDto irsPalet)
        {
            YuklenenPaletler.Remove(irsPalet);
            KalanPaletler.Add(irsPalet);

            OnPropertyChanged(nameof(SevkiyatYuklenmeOran));
            OnPropertyChanged(nameof(SevkiyatYuklemeMetin));

            OnPropertyChanged(nameof(YuklemeBittiMi));
        }


        [NotMapped]
        public ObservableCollection<IrsaliyePaletDto> YuklenenPaletler { get => _yuklenenPaletler; private set => SetProperty(ref _yuklenenPaletler, value); }

        [NotMapped]
        public ObservableCollection<IrsaliyePaletDto> KalanPaletler { get => _kalanPaletler; private set => SetProperty(ref _kalanPaletler, value); }


        public decimal SevkiyatTumPaletSayisi => _tumPaletler.Count;
        public decimal SevkiyatYuklenenPaletSayisi => _yuklenenPaletler.Count;
        public decimal SevkiyatYuklenmeOran => (SevkiyatYuklenenPaletSayisi / SevkiyatTumPaletSayisi) * 100;
        public string SevkiyatYuklemeMetin => $"{_yuklenenPaletler.Count} / {_tumPaletler.Count}";
        public bool YuklemeBittiMi => _yuklenenPaletler.Count == _tumPaletler.Count;


        public DateTime? YuklemeBaslamaTarih { get; set; }
        public DateTime? YuklemeBitisTarih { get; set; }

        public ObservableCollection<IrsaliyePaletDto> TumPaletleriGetir()
        {

            var u = CariIrsaliyeler.SelectMany(i_p => i_p.IrsaliyePaletler, (i, i_p) => new { i, i_p })
                .Select(c => new IrsaliyePaletDto
                {
                    PaletId = c.i_p.PaletId,
                    SevkiyatEmriId = c.i.SevkiyatEmriId,
                    IrsaliyeId = c.i.IrsaliyeId,
                    CariAd = c.i.CariAd,
                    Kalinlik = c.i_p.Kalinlik,
                    En = c.i_p.En,
                    PaletNet_Kg = c.i_p.PaletNet_Kg,
                    PaletBrut_Kg = c.i_p.PaletBrut_Kg,
                    PaletDara_Kg = c.i_p.PaletDara_Kg,
                    PaletEbat = c.i_p.PaletEbat,
                    UrunKod = c.i_p.UrunKod,
                    YuklendiMi = c.i_p.YuklendiMi.GetValueOrDefault()
                });
            return u.ToObservableCollection();
        }



    }



}