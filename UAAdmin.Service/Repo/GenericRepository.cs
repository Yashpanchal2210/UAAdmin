using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAAdmin.Service.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //protected readonly UrbanAutoMasterContext _masterContext;

        public GenericRepository() { }
    }
}
