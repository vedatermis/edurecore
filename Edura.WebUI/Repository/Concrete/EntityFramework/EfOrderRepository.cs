using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Edura.WebUI.Entity;
using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository: EfGenericRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(EduraContext context) : base(context)
        {
        }
    }
}
