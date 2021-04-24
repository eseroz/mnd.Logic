using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.Operasyon
{
    public class HaftalikYuklemePlan
    {
        [Key]
        public int Id { get; set; }
        public int HaftaId { get; set; }
        public int Sirano { get; set; }
        public string Pazartesi { get; set; }
        public string Sali { get; set; }
        public string Carsamba { get; set; }
        public string Persembe { get; set; }
        public string Cuma { get; set; }
        public string Cumartesi { get; set; }
        public string Pazar { get; set; }
        public string RowId { get; set; }
        public int Yil { get; set; }

        public string UpdateUserId { get; set; }
    }
}
