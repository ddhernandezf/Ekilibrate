using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.Data.EntityModel.Abstract;
using System.Data;
using System.Data.SqlClient;
using Autofac;

namespace Ekilibrate.Data.Access.Common
{
    public abstract class clsDataAccess<T, Tkey> : clsBaseAutofacContainer where T : IEntityPOCO<Tkey>, new() 
    {        
        private const string GetAllColumns = "*";

        public clsDataAccess(ILifetimeScope lifetimeScope) : base(lifetimeScope) {}
    }

    public abstract class clsBaseAutofacContainer
    {
        protected ILifetimeScope _lifetimescope;

        public clsBaseAutofacContainer(ILifetimeScope lifetimeScope)
       {
            _lifetimescope = lifetimeScope;
        }

    }
}
