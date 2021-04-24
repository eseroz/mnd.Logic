using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Uretim
{
    public partial class Recete : MyBindableBase
    {
        private string ekleyen;
        private DateTime? eklenmeTarihi;
        private string guncelleyen;
        private DateTime? guncellenmeTarihi;
        private Guid _rowGuid;
        private int ıd;

        [Key]
        public int Id { get => ıd; set => SetProperty(ref ıd ,value); }

        public string KullanimAlani { get; set; }
        public string RotaUrunKodlari { get; set; }
        public decimal? HedefKalinlik { get; set; }
        public string M_1 { get; set; }
        public decimal? GK_1 { get; set; }
        public decimal? CK_1 { get; set; }
        public string M_2 { get; set; }
        public decimal? GK_2 { get; set; }
        public decimal? CK_2 { get; set; }
        public string M_3 { get; set; }
        public decimal? GK_3 { get; set; }
        public decimal? CK_3 { get; set; }
        public string M_4 { get; set; }
        public decimal? GK_4 { get; set; }
        public decimal? CK_4 { get; set; }
        public string M_5 { get; set; }
        public decimal? GK_5 { get; set; }
        public decimal? CK_5 { get; set; }
        public string M_6 { get; set; }
        public string M_7 { get; set; }

        public string Ekleyen { get => ekleyen; set => SetProperty(ref ekleyen, value); }
        public DateTime? EklenmeTarihi { get => eklenmeTarihi; set => SetProperty(ref eklenmeTarihi, value); }

        public string Guncelleyen { get => guncelleyen; set => SetProperty(ref guncelleyen, value); }
        public DateTime? GuncellenmeTarihi { get => guncellenmeTarihi; set => SetProperty(ref guncellenmeTarihi, value); }

        public Guid RowGuid { get => _rowGuid; set => SetProperty(ref _rowGuid, value); }
    }
}