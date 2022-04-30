using System.Collections.Generic;
using UsersAPI.Models;

namespace UsersAPI.Repository.UsersRep
{
    public interface IUsersRepository: IUsersCreate, IUsersUpdate, IUsersDelete, IUsersGet
    {
    }
}
