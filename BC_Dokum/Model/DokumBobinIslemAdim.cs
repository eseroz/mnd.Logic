using mnd.Logic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_Dokum.Model
{

    public class DokumBobinIslemAdim : MyBindableBase
    {
        private DateTime? baslamaTarihi;
        private DateTime? bitisTarihi;
        private bool? aktifMi;
        private string adimDurum;
        private bool calisiyorMu;
        private bool duruyorMu;

        [Key]
        public int Id { get; set; }
        public int BobinNo { get; set; }
        public string ShRotaKartKartNo { get; set; }
        public int? SiraNo { get; set; }
        public DateTime? BaslamaTarihi { get => baslamaTarihi; set => SetProperty(ref baslamaTarihi, value); }
        public DateTime? BitisTarihi { get => bitisTarihi; set => SetProperty(ref bitisTarihi, value); }
        public string MakinaIslem { get; set; }

        public string MakinaKisaKod => MakinaIslem.Split('/')[0];

        public decimal? EzmeYuzde { get; set; }
        public decimal? ProsesMax { get; set; }
        public decimal? ProsesMin { get; set; }
        public string ProsesMaxStr { get; set; }
        public string ProsesMinStr { get; set; }
        public string ProsesMetin { get; set; }


        [NotMapped]
        public bool CalisiyorMu { get => calisiyorMu; set => SetProperty(ref calisiyorMu, value); }

        [NotMapped]
        public bool DuruyorMu { get => duruyorMu; set => SetProperty(ref duruyorMu, value); }

        public string GecenSureStr
        {
            get
            {
                if (BaslamaTarihi == null) return "";
                return GetElapsedTimeString(DateTime.Now - BaslamaTarihi.GetValueOrDefault());

               
            }
        }

        public string ProsesMetin1 => ProsesMetin.Replace("-", "->");

        public string AdimDurum { get => adimDurum; set => SetProperty(ref adimDurum,value); }
        public string AlasimTipKod { get; set; }
        public bool? AktifMi { get => aktifMi.GetValueOrDefault(); set => SetProperty(ref aktifMi, value); }

        public string GetElapsedTimeString(TimeSpan result)
        {
            string elapsedTimeString = string.Format("{0}:{1}:{2}",
                                              result.Hours.ToString("00"),
                                              result.Minutes.ToString("00"),
                                              result.Seconds.ToString("00")
                                             );

            return elapsedTimeString;
        }



    }
}
