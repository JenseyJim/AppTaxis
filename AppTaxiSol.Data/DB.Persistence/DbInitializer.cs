using AppTaxiSol.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.DB.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(AppTaxisContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
