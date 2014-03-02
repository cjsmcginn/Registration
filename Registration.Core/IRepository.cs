using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Core
{
    /// <summary>
    /// The IRepository represents a an interface common to the Repository Pattern.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="http://martinfowler.com/eaaCatalog/repository.html"/>
    public partial interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }

    }
}
