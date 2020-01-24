using HomeApply.Entities.DataModels;
using HomeApply.Entities.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApply.Entities
{
    public interface IUnitOfWork
    {
        IGenericRepository<Users> UserRepository { get; }

        
    }
}
