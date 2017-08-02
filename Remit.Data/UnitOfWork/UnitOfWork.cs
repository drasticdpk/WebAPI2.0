using Remit.Data.Repository;
using System;
using System.Diagnostics;

namespace Remit.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Private

        private RemitEntities _context = null;
        private IRepository<Customer> _customerRepository;
        private IRepository<Transaction> _transactionRepository;

        #endregion Private

        public UnitOfWork()
        {
            _context = new RemitEntities();
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                    this._customerRepository = new Repository<Customer>(_context);
                return _customerRepository;
            }
        }

        public IRepository<Transaction> TransactionRepository
        {
            get
            {
                if (this._transactionRepository == null)
                    this._transactionRepository = new Repository<Transaction>(_context);
                return _transactionRepository;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Implementing IDiosposable...

        #region private dispose variable declaration...

        private bool disposed = false;

        #endregion private dispose variable declaration...

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Implementing IDiosposable...
    }
}