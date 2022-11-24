using KSPTECHNOLOGY.Data.Context;
using KSPTECHNOLOGY.Data.Implements.Empresa;
using KSPTECHNOLOGY.Data.Interfaces.Common;
using KSPTECHNOLOGY.Data.Interfaces.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Data.Implements.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KSPTECHNOLOGYContext _context;

        private readonly IEmpleadoRepository _empleadoRepository;
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public UnitOfWork(
            KSPTECHNOLOGYContext kSPTECHNOLOGYContext
            )
        {
            _context = kSPTECHNOLOGYContext;
        }

        public IEmpleadoRepository EmpleadoRepository => _empleadoRepository ?? new EmpleadoRepository(_context);

        public IBeneficiarioRepository BeneficiarioRepository => _beneficiarioRepository ?? new BeneficiarioRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}