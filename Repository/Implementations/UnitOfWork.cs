using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private Cinema8SystemDBContext context = new Cinema8SystemDBContext();

        private GenericRepository<Film> filmRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Order> orderRepository;


        public GenericRepository<Film> FilmRepository
        {
            get
            {
                if (this.filmRepository == null)
                {
                    this.filmRepository = new GenericRepository<Film>(context);
                }
                return filmRepository;
            }
        }


        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }


        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }


        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
