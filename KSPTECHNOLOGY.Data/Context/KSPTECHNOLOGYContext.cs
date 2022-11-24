using KSPTECHNOLOGY.Domain.Entities.Empresa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Context
{
    public class KSPTECHNOLOGYContext : DbContext
    {
        public KSPTECHNOLOGYContext()
        {
        }

        public KSPTECHNOLOGYContext(DbContextOptions<KSPTECHNOLOGYContext> options) : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleado { get; set; } = null!;

        public virtual DbSet<Beneficiario> Beneficiario { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}