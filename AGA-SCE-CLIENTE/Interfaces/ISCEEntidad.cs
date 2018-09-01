using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGA_SCE_CLIENTE.Interfaces
{
    interface ISCEEntidad<T>
    {
        T Save(T entidad);
        T Update(T entidad);
        T GetById(int Id);
        void Delete(int Id);
        ICollection<T> Get();
        bool Exist(int Id);
    }
}
