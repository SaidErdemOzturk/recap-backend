
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCartController : ControllerBase
    {
        ICreditCartService _creditCartService;
        public CreditCartController(ICreditCartService creditCartService)
        {
            _creditCartService = creditCartService;
        }

        [HttpPost("paywithcreditcart")]
        public IActionResult PayWithCreditCart(CreditCart creditCart)
        {
            var result = _creditCartService.Pay(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
