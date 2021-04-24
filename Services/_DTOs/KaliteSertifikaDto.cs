using mnd.Logic.Model.Uretim;
using System;
using System.Collections.Generic;

namespace mnd.Logic.Services._DTOs
{
    public class KaliteSertifikaDto
    {
        public DateTime SertifikaTarihi { get; set; }
        public string SertifikaNo { get; set; }

        public List<Bobin> Bobinler { get; set; }
    }
}