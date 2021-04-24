using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_SatinAlmaYeni.Domain
{
    public class KulceKontratDonem
    {
        [Key]
        public int Id { get; set; }
        public int KulceKontratId { get; set; }
        public int Yil { get; set; }
        public int Ay { get; set; }
        public int MiktarTon { get; set; }

        public KulceKontratDonem()
        {
            KulceProformalar = new ObservableCollection<KulceProforma>();
        }
        public ObservableCollection<KulceProforma> KulceProformalar { get; set; }
    }
}
