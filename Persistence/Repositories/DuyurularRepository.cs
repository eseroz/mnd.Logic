using Microsoft.EntityFrameworkCore;
using mnd.Logic.Helper;
using mnd.Logic.Model.App;
using mnd.Logic.Model.Satis;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace mnd.Logic.Persistence.Repositories
{
    public class DuyurularRepository : RepositoryAsync<Siparis>
    {
        public DuyurularRepository(PandapContext dc) : base(dc)
        {
        }

        public ObservableCollection<Duyuru> DuyuruVeSayilariGetir()
        {
            var sonuc = Queryable.OrderByDescending<Duyuru, DateTime>(_dc.Duyurular.FromSql(
                    @"SELECT  a.Id, a.DuyuruGrup, a.DuyuruMetin, a.Tarih, a.RowGuid, COUNT(b.Id) AS MesajSayisi
                            FROM   App.Duyuru AS a LEFT OUTER JOIN
                            App.Mesaj AS b ON a.RowGuid = b.RefEntityGuid
                            GROUP BY a.Id, a.DuyuruGrup, a.DuyuruMetin, a.Tarih, a.RowGuid"

                ), c => c.Tarih).ToObservableCollection();

            return sonuc;
        }
    }
}