using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RecapContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RecapContext())
            {
                var result = from operationClam in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClam.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClam.Id, Name = operationClam.Name };
                return result.ToList();
            }
        }

        public UserDto GetUserDtoByEmail(string email)
        {
            using (var context = new RecapContext())
            {
                var result = (from user in context.Users
                              where user.Email == email
                              select new UserDto { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName }).FirstOrDefault();
                return result;
            }
        }
    }
}
