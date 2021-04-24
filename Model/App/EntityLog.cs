using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public partial class EntityLog
    {
        [Key]
        public int Id { get; set; }

        public Guid EntityRowGuid { get; set; }
        public string EntityJsonStream { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public DateTime? KayitTarihi { get; set; }
    }
}