using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAAdmin.Service.Repo;

namespace UAAdmin.Service.Service.CRM
{
    public interface ICRMRepository : IGenericRepository<AdminCred>
    {
        bool Authenticate(string email, string password);
    }
}
