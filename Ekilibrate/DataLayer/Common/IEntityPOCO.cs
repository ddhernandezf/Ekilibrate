using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.Data.EntityModel.Abstract
{
    public interface IEntityPOCO<T>
    {
        T Key { get; set; }
    }
}
