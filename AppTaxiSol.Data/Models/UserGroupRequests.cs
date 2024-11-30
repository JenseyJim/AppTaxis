using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTaxiSol.Data.Models
{
    public class UserGroupRequests
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }
        public string Estado { get; set; }
    }
}
