using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Net.Http.Headers;
using System.Threading.Channels;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager( new EfCarDal());

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach(var item in result.Data)
                {
                    Console.WriteLine(item.Description);
                }
            }


            Console.WriteLine("-------------------------dto test-------------------");


            var getDto = carManager.GetCarsByBrandDto();

            if (getDto.Success)
            {
                foreach (var item in getDto.Data)
                {
                    Console.WriteLine(item.BrandName + " -- " + item.ColorName);
                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            UserManager userManager = new UserManager( new EfUserDal());
            //userManager.Add(new User() { FirstName = "Erdem", LastName = "Öztürk", Email = "erdem@erdem.com", Password = "erdem" });
            //userManager.Add(new User() { FirstName = "Nihal", LastName = "Öztürk", Email = "nihal@nihal.com", Password = "nihal" });
            //userManager.Add(new User() { FirstName = "Faruk", LastName = "Öztürk", Email = "faruk@faruk.com", Password = "faruk" });

            var resultUser = userManager.GetAll();
            if (result.Success) 
            {
                foreach (var item in resultUser.Data)
                {
                    Console.WriteLine(item.Email);
                }
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            CustomerManager customerManager = new CustomerManager( new EfCustomerDal());

            //customerManager.Add( new Customer() { UserId=1,CompanyName="Erdemin şirketi"});

            var resultCustomer = customerManager.GetAll();
            if (resultCustomer.Success)
            {
                foreach(var item in resultCustomer.Data)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
            Console.WriteLine("--------------------------------------------");


            RentalManager rentalManager = new RentalManager( new EfRentalDal());
            var resultAdded = rentalManager.Add(new Rental() { CarId = 1002, CustomerId = 1, RentDate = DateTime.Now });
            Console.WriteLine(resultAdded.Message);
            var resultRental = rentalManager.GetAll();
            if (resultRental.Success)
            {
                foreach (var item in resultRental.Data)
                {
                    Console.WriteLine(item.RentDate);
                }
            }

        }
    }
}
