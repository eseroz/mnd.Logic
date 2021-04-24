using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.Model.App
{
    public class Layout
    {
        [Key]
        public int Id { get; set; }

        public string KullaniciId { get; set; }
        public string LayoutName { get; set; }
        public string LayoutXml { get; set; }
    }
}