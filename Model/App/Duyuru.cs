using System;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class Duyuru
    {
        [Key]
        public int Id { get; set; }

        public string DuyuruGrup { get; set; }
        public string DuyuruMetin { get; set; }
        public DateTime Tarih { get; set; }
        public Guid RowGuid { get; internal set; }

        public int MesajSayisi { get; set; }
    }
}