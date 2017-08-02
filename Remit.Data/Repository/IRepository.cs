using System.Collections.Generic;

namespace Remit.Data.Repository
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        void Delete(object Id);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(T entityToDelete);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entityToUpdate"></param>
        void Update(T entityToUpdate);

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetByID(object id);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();
    }
}