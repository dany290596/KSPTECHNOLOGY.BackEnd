using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Models.Response.Common
{
    public class BaseEntityDTO
    {
        public Guid Id { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public DateTime? FechaBaja { get; set; }

        public DateTime? FechaReactivacion { get; set; }
    }
}