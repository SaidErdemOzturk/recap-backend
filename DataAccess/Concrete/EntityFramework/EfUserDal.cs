using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,RecapContext>, IUserDal
    {
       public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RecapContext())
            {
                var result = from operationClam in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClam.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.Id == user.Id
                             select new OperationClaim { Id = operationClam.Id, Name = operationClam.Name };
                return result.ToList();
            }
        }
    }
}
