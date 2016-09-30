using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBuilding.Web.DAL;
using SmartBuilding.Web.EF;

namespace SmartBuilding.Web.DAL.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetById(int id);
        User GetByUserName(string userName);
        bool Add(User user);
    }
}
