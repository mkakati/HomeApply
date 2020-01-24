using HomeApply.Entities.DataModels;
using HomeApply.Entities.DbContext;
using HomeApply.Entities.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApply.Entities
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HomeApplyContext context;

        private IGenericRepository<Users> _userRepository;
        private bool disposed = false;

        public IGenericRepository<Users> UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new GenericRepository<Users>(context);
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            //  Console.WriteLine("Objec is distroy");
            if (!this.disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("Context Object is Distroy");
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            //Console.WriteLine("Objec is distroy");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UnitOfWork(HomeApplyContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        public HomeApplyContext GetDbContext()
        {

            return this.context;
        }


    }
}
