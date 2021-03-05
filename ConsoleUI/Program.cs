using Business.Concrete;
using DataAccess.Concrete.EntityFremavork.DataAcessLayers;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            foreach (var user in result.Data)
            {
                if (result.Succcess)
                {
                    Console.WriteLine
                        (
                            "User Id :\t" + user.UserId + "\n" +
                            "User E-Mail :\t" + user.UserEmail + "\n" +
                            "User Password :\t" + user.UserPassword + "\n"

                        );
                }
            }
        }

        private static void RentManagerTest()
        {
            RentManager rentManager = new RentManager(new EfRentDal());

            RentDailyPriceTest(rentManager);
            RentDetailsList(rentManager);
        }

        private static void RentDetailsList(RentManager rentManager)
        {
            var result = rentManager.GetRentDetails();
            if (result.Succcess)
            {
                foreach (var rent in result.Data)
                {
                    TimeSpan resultDate = rent.ReturnDate - rent.RentDate;

                    decimal resultDay = Convert.ToDecimal(resultDate.Days);

                    decimal pay = rent.DailyPrce * resultDay;

                    Console.WriteLine
                        (
                            "Rentİd :\t" + rent.RentId + "\n" +
                            "Customer Name :\t" + rent.CustomerName + "\n" +
                            "Custoemr Surname :\t" + rent.CustomerLastName + "\n" +
                            "Car Name :\t" + rent.CarName + "\n" +
                            "Rent Date :\t" + rent.RentDate + "\n" +
                            "Return DAte :\t" + rent.ReturnDate + "\n" +
                            "Rent Time :\t" + resultDate.Days + " Day" + "\n" +
                            "Daily Price :\t" + rent.DailyPrce + "$" + "\n" +
                            "Money Payable :\t" + pay + "$" + "\n" +
                            "------------------------------------------------------"
                        );
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }

        }

        private static void RentDailyPriceTest(RentManager rentManager)
        {
            var result = rentManager.GetAll();
            if (result.Succcess)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine("günlük kiralama bedeli :\t" + rent.DailyPrice + " $");
                }
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }

        }

        private static void SaleManagerTest()
        {
            SaleManager saleManager = new SaleManager(new EfSaleDal());

            var result = saleManager.GetAll();

            if (result.Succcess)
            {
                foreach (var sale in result.Data)
                {
                    Console.WriteLine("Satış Fiyatı :\t" + sale.SalePrice + " $");
                }
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }
        }

        private static void PurshaseManagerTest()
        {
            PurchaseManager purchaseManager = new PurchaseManager(new EfPurchaseDal());
            PurchaseManagerList(purchaseManager);

        }

        private static void PurchaseManagerList(PurchaseManager purchaseManager)
        {
            var result = purchaseManager.GetAll();

            if (result.Succcess)
            {
                foreach (var purshase in result.Data)
                {
                    Console.WriteLine("Alış Fiyatı :\t" + purshase.PurchasePrice);
                }
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }
        }

        private static void CustomerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            CustomerListTest(customerManager);

            CustomerDetailsTest(customerManager);
        }

        private static void CustomerListTest(CustomerManager customerManager)
        {
            var result = customerManager.GetAll();

            if (result.Succcess)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("Customer Name :\t" + customer.CustomerName);
                }
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }

        }

        private static void CustomerDetailsTest(CustomerManager customerManager)
        {

            var result = customerManager.GetCustomerDetails();

            if (result.Succcess)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine
                        (
                            "Customer ID :\t" + customer.CustomerId + "\n" +
                            "CustomerName :\t" + customer.CustomerName + "\n" +
                            "Customer LastName :\t" + customer.CustomerLastname + "\n" +
                            "Customer Gender :\t" + customer.Gender + "\n" +
                            "Customer Nationality ID :\t" + customer.IdentityNumber + "\n" +
                            "Customer Date Of Borth :\t" + customer.DateOfBorth + "\n" +
                            "Customer Street :\t" + customer.Street + "\n" +
                            "Customer City :\t" + customer.City + "\n" +
                            "Customer Continental :\t" + customer.Region + "\n" +
                            "Customer Country :\t" + customer.Country + "\n" +
                            "Customer Address :\t" + customer.Address + "\n" +
                            "Customer Phone Number :\t" + customer.PhoneNumber + "\n" +
                            "Customer E-Mail Address :\t" + customer.SaveEmail + "\n" +
                            "Customer Zip Code :\t" + customer.ZipCode + "\n" +
                            "---------------------------------------------------"
                        );
                }
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }

        }

        private static void CommunicationManagerTest()
        {
            CommunicationManager communicationManager = new CommunicationManager(new EfCommunicationDal());
            ComminucationListTest(communicationManager);
        }

        private static void ComminucationListTest(CommunicationManager communicationManager)
        {
            var result = communicationManager.GetAll();
            if (result.Succcess)
            {
                foreach (var communication in result.Data)
                {
                    Console.WriteLine("Ülke :\t" + communication.Country);
                }
            }
            else
            {
                Console.WriteLine("Error Message :\t" + result.Message);
            }
        }
    }
}
