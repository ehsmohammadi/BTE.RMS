using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.Persistence.EF
{

    public class Repository<T>:IRepository<T>
    {
        public Repository()
        {
            
        }
        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetBy(long id)
        {
            throw new NotImplementedException();
        }

        public void Create(T t)
        {
            throw new NotImplementedException();
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }

        public void Delete(T t)
        {
            throw new NotImplementedException();
        }
    }
}
