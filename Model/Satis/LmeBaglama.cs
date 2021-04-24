using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mnd.Logic.Model.Satis
{
    public class LmeBaglama : MyBindableBase
    {
        private bool? _kilitliMi;
        private int _bakiye;

        [Key]
        public string RefNo { get => _refNo; set => SetProperty(ref _refNo, value); }

        string musteriKod;
        private string _dovizTipKod;
        private string _hazirlayan;
        private string _refNo;
        private int _baglantiMiktari;
        private int _lmeDeger;
        private DateTime _baglantiTarihi;

        private int _okunmamisMesajSayisi1;
        private string _onaylayan;
        private bool? _onayliMi;
        private DateTime? _onayTarihi;
        private DateTime? _kilitlemeTarihi;
        private ObservableCollection<SiparisKalem> _siparisKalemleri;
        private bool _ısEditRow;
        private int? _faturalfx_kg;
        private int _siparisLfx;


        [NotMapped]
        //public string BagliSiparisKodlari => String.Join(";", SiparisKalemLmeDtoListe.Select(c => c.SiparisKod).Distinct().ToArray());

        public string MusteriKod
        {
            get => musteriKod;
            set => SetProperty(ref musteriKod, value);
        }

        [NotMapped]
        public string FirmaSiparisNumaralari { get; set; }


        [ForeignKey(nameof(MusteriKod))]
        public PandapCari PandapCari { get; set; }


        [Column("BaglantiMiktari")]
        public int BaglantiLfx_kg { get => _baglantiMiktari; set => SetProperty(ref _baglantiMiktari, value); }

        public LmeBaglama()
        {
            //SiparisKalemleri = new ObservableCollection<SiparisKalem>();
            //SiparisKalemLmeDtoListe = new List<SiparisKalemLmeDto>();

            BaglantiTarihi = DateTime.Now;
            KilitliMi = false;
        }

        //[NotMapped]
        //public int SiparisLfx_kg => SiparisKalemLmeDtoListe.Sum(c => c.Miktar_kg);

        //[NotMapped]
        //public int SiparisLfx_Bakiye_kg => BaglantiLfx_kg - SiparisLfx_kg;

        [NotMapped]
        public int FaturaBaglantiLfx_Bakiye_kg => BaglantiLfx_kg - FaturaLfx_kg.GetValueOrDefault();


        public string LmeKayitSurecDurum { get; set; }

        public string LmeKayitSurecDurumOnceki { get; set; }

        public DateTime? LmeKayitSurecDurumIslemTarih { get; set; }


        public DateTime BaglantiTarihi { get => _baglantiTarihi; set => SetProperty(ref _baglantiTarihi, value); }

        public int LmeDeger { get => _lmeDeger; set => SetProperty(ref _lmeDeger, value); }

        public string DovizTipKod { get => _dovizTipKod; set => SetProperty(ref _dovizTipKod, value); }


        public string Hazirlayan { get => _hazirlayan; set => SetProperty(ref _hazirlayan, value); }


        public string Onaylayan { get => _onaylayan; set => SetProperty(ref _onaylayan, value); }


        [NotMapped]
        public int? FaturaLfx_kg { get => _faturalfx_kg; set => SetProperty(ref _faturalfx_kg, value); }


        public decimal LmeGenelToplamTutar => LmeDeger * BaglantiLfx_kg / 1000;

        public bool? KilitliMi
        {
            get => _kilitliMi.GetValueOrDefault();
            set => SetProperty(ref _kilitliMi, value);
        }

        public bool? OnayliMi { get => _onayliMi; set => SetProperty(ref _onayliMi, value); }

        public DateTime? OnayTarihi { get => _onayTarihi; set => SetProperty(ref _onayTarihi, value); }

        public DateTime? KilitlemeTarihi { get => _kilitlemeTarihi; set => SetProperty(ref _kilitlemeTarihi, value); }



        public Guid RowGuid { get; set; }

        //public ObservableCollection<SiparisKalem> SiparisKalemleri { get => _siparisKalemleri; set => SetProperty(ref _siparisKalemleri, value); }


        //[NotMapped]
        //public List<SiparisKalemLmeDto> SiparisKalemLmeDtoListe { get; set; }


        public string SevkYilHafta { get; set; }

        public string SevkYilAy { get; set; }

        public decimal? DolarParite { get; set; }

        public decimal? DolarLme => DolarParite * LmeDeger;


        [NotMapped]
        public decimal ToplamLmeTutarTon => LmeDeger * BaglantiLfx_kg / 1000;


        [NotMapped]
        public bool IsEditRowMy { get => _ısEditRow; set => SetProperty(ref _ısEditRow, value); }




        [JsonIgnore]
        [NotMapped]
        public int MesajSayisi { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int OkunmamisMesajSayisi { get => _okunmamisMesajSayisi1; set => SetProperty(ref _okunmamisMesajSayisi1, value); }


        [NotMapped]
        public int LfxToplamPaketlenen { get; set; }

       

    }
}