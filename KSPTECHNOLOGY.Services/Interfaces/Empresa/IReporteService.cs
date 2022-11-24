using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPTECHNOLOGY.Services.Interfaces.Empresa
{
    public interface IReporteService
    {
        Task<MemoryStream> ExportToExcelTheReport();
    }
}