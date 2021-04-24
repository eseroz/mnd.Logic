using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class ExcelImportTanim
    {
        [Key]
        public int Id { get; set; }

        public string FormAdi { get; set; }
        public string DbTabloSutunBaslik { get; set; }
        public string ExcelBaslikHücreKonum { get; set; }

        public bool? IsExcelKey { get; set; }

        public bool? IsNumeric { get; set; }
        public bool? IsText { get; set; }
    }
}