using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Uretim.SH_RotaModel
{
    [Table("SH_Recete",Schema ="Uretim")]
    public class ShRecete
    {
        [Key]
        public int Id { get; set; }
        public string RotaKartId { get; set; }
        public string Faz1 { get; set; }
        public string Faz1_a { get; set; }
        public string Faz1_b { get; set; }
        public string Faz2 { get; set; }
        public string Faz2_a { get; set; }
        public string Faz2_b { get; set; }
        public string Faz3 { get; set; }
        public string Faz3_a { get; set; }
        public string Faz3_b { get; set; }
        public string Faz4 { get; set; }
        public string Faz4_a { get; set; }
        public string Faz4_b { get; set; }
        public string Faz5 { get; set; }
        public string Faz5_a { get; set; }
        public string Faz5_b { get; set; }
        public string Faz6 { get; set; }
        public string Faz6_a { get; set; }
        public string Faz6_b { get; set; }
        public string Faz7 { get; set; }
        public string Faz7_a { get; set; }
        public string Faz7_b { get; set; }
    }
}
