using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class AppEntityLogRepository
    {
        PandapContext _dc = new PandapContext();
        public AppEntityLogRepository()
        {

        }

        public void EkleKaydet(EntityLog entityLog)
        {
            _dc.EntityLoglari.Add(entityLog);
            _dc.SaveChanges();
        }

        public ObservableCollection<EntityLog> GetEntityLogsFromGuidWithoutJsonStream(Guid rowGuid)
        {
            return Queryable.Where<EntityLog>(_dc.EntityLoglari, c => c.EntityRowGuid == rowGuid)
                .Select(c => new EntityLog { Id = c.Id, EntityJsonStream = null, KayitTarihi = c.KayitTarihi, KullaniciAdSoyad = c.KullaniciAdSoyad, EntityRowGuid = c.EntityRowGuid })
                .AsNoTracking()
                .ToObservableCollection();
        }

        public string GetEntityLogsFromGuidJsonStream(int id)
        {
            return Queryable.Where<EntityLog>(_dc.EntityLoglari, c => c.Id == id)
                .Select(c => c.EntityJsonStream)
                .FirstOrDefault();
        }
    }
}