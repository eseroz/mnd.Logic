﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mnd.Logic.BC_Satis.Data_LookUp.Model
{
    public partial class OdemeTip
    {


        [Key]
        public string OdemeTipKod { get; set; }

        public string Aciklama { get; set; }
        public string Aciklama_EN { get; set; }

    }
}