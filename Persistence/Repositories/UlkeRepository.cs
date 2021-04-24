using Microsoft.EntityFrameworkCore;
using mnd.Common;
using mnd.Common.Helpers;
using mnd.Logic.BC_App.Data;
using mnd.Logic.BC_Satis._Seyahat;
using mnd.Logic.Helper;
using mnd.Logic.Model.Operasyon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace mnd.Logic.Persistence.Repositories
{

    public class UlkeRepository
    {
        private AppDataContext _dc;

        public UlkeRepository(AppDataContext context)
        {
            _dc = context;
        }



        public List<UlkeSabit> UlkeleriGetir()
        {
            var s = _dc.Ulkes.ToList();

            return s;
        }

        public string UlkeKoduVer(string _ulkeAdi)
        {
            var s = _dc.Ulkes.Where(p=>p.UlkeAdi == _ulkeAdi).Select(c=>c.UlkeKodu).FirstOrDefault();
      
            return s;
        }
    }
}