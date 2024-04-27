using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAAdmin.Service.Repo;

namespace UAAdmin.Service.Service.CRM
{
    public class CRMRepository : GenericRepository<AdminCred>, ICRMRepository
    {
        private readonly UrbanAutoMasterContext _dbContext;

        public CRMRepository(UrbanAutoMasterContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool Authenticate(string email, string password)
        {
            bool result = false;

            var getUser = _dbContext.AdminCreds.Where(x => x.UserName.ToLower() == email.ToLower() &&
            x.Password == password).FirstOrDefault();

            if (getUser != null)
            {
                result = true;
            }

            return result;
        }
    }
}
