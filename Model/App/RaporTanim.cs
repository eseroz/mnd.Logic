using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class RaporTanim
    {
        [Key]
        public int Id { get; set; }

        public string RaporAd { get; set; }
        public string RaporXmlStream { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public double ZoomFaktor { get; set; }

        public string SubReportJson { get; set; }

        public string ParentDatasetProp { get; set; }

    }
}