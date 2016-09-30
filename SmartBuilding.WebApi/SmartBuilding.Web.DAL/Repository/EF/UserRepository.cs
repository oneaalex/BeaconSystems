using System;
using System.Collections.Generic;
using System.Linq;
using SmartBuilding.Web.DAL.Interface;
using SmartBuilding.Web.EF;

namespace SmartBuilding.Web.DAL.Repository.EF
{
    public class UserRepository : IDisposable, IUserRepository
    {
        private BeaconSystemsEntities _db;


        public UserRepository()
        {
            _db = new BeaconSystemsEntities();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }   

        public IEnumerable<User> GetUsers()
        {
            return _db.Users;
        }

        public User GetById(int id)
        {
            return _db.Users.FirstOrDefault(p => p.UserID == id);
        }
        public bool Add(User user)
        {
            if (_db.Users.FirstOrDefault(u => u.Username == user.Username) == null )
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetByUserName(string userName)
        {
            return _db.Users.FirstOrDefault(p => p.Username == userName);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
