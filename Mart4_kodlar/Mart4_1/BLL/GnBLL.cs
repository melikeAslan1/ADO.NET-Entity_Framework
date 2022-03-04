using Mart4_1.DAL;
using Mart4_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mart4_1.DAL;

namespace Mart4_1.BLL
{
    public class GnBLL<T> where T : class, IEntity
    {
        //Dependency Injection Olmalı...
        GnFilmDB db;

        public GnBLL(GnFilmDB _db)
        {
            db = _db;
        }

        public void Ekle(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public List<T> Liste()
        {
            return db.Set<T>().ToList();
        }


    }
}
