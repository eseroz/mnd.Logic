using mnd.Logic.BC_App.Data;
using mnd.Logic.BC_App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnd.Logic.BC_App
{
    public class MailServiceRepository
    {
        AppDataContext dc = new AppDataContext();
       
        public bool GunlukMailGittiMi(string mailAdi,DateTime tarih)
        {
            var cevap = dc.MailLogs.Any(c => c.MailAdi==mailAdi && c.MailGonderimTarihi.Date == tarih.Date);

            return cevap;
        }

        public List<MailTanim> MailTanimlariGetir()
        {
            var liste = dc.MailTanims.ToList();
            return liste;
        }

        public void MailDbLogEkle(string mailAdi)
        {
            MailLog satir = new MailLog();
            satir.MailAdi = mailAdi;
            satir.MailGonderimTarihi = DateTime.Now;

            dc.Add(satir);

            dc.SaveChanges();
        }

    }
}
