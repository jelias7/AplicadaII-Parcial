using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase : IDisposable, IRepository<T> where T : class
    {
        internal Contexto contexto;

        public RepositorioBase()
        {
            contexto = new Contexto();
        }

        public virtual void Dispose()
        {
            contexto.Dispose();
        }
    }
}
