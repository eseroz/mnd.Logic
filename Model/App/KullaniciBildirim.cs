using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public partial class KullaniciBildirim
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciId { get; set; }
        public DateTime GorusulmeyenMusteriSonBildirimTarihi { get; set; }
    }
}