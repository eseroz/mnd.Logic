using Microsoft.EntityFrameworkCore;
using mnd.Logic.BC_PandapForms.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_PandapForms
{
    public class PandapFormRepository
    {
        private PandapFormsDbContext dc = new PandapFormsDbContext();

        public List<FormGunluk> GunlukFormlariGetir()
        {
            var sonuc=dc.FormGunluks.ToList();

            return sonuc;
        }

        public List<FormYatayData> FormYanitlariGetir(int id)
        {
            var sonuc = dc.YatayDatas.Where(c => c.FormGunlukId == id).AsNoTracking().ToList();

            return sonuc;
        }

        public List<FormYatayData> FormYanitlariGetir(string formKisaAd)
        {
            var sonuc = dc.YatayDatas.Where(c => c.FormAdi==formKisaAd).ToList();

            return sonuc;
        }

        public List<FormSoru> FormSorulariGetir(string formKisaAd)
        {
            var sonuc = dc.FormSorus.Where(c => c.FormAdi == formKisaAd).ToList();

            return sonuc;
        }
    }
}
