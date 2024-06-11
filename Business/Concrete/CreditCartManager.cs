using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCartManager : ICreditCartService
    {
        public CreditCartManager()
        {
            
        }
        [ValidationAspect(typeof(CreditCartValidator))]
        public IResult Pay(CreditCart creditCart)
        {
            return new SuccessResult("Ödeme başarılı");
        }
    }
}
