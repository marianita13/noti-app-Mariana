using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IFormato : IGenericRepository<Formatos>
    {
        Task<List<ModuloNoficaciones>> GetModuloNotificaciones(int formatoId);
    }
}