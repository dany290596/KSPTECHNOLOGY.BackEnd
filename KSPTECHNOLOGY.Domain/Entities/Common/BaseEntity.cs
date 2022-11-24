using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public DateTime? FechaBaja { get; set; }

        public DateTime? FechaReactivacion { get; set; }
    }
}