using System;
using System.Collections.Generic;

namespace BTE.Core
{
    public interface IRepository
    {

    }

    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetBy(long id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
    }

    public interface ISyncRepository<T> : IRepository<T>, IRepository
    {
        T GetBy(Guid syncId);

    }





}
