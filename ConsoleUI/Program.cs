using Business.Concrete;
using DataAccess.Concrete.EntityFremavork;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****************CUSTOMER DETAİLS******************");
            //CarManagerTest();
            //CommunicationManagerTest();
            CustomerManagerTest();
            Console.WriteLine("*****************RENT DETAİLS***********************");
            //PurshaseManagerTest();
            //SaleManagerTest();
            RentManagerTest();


        }

        private static void RentManagerTest()
        {
            RentManager rentManager = new RentManager(new EfRentDal());

            //foreach (var rent in rentManager.GetAll())
            //{
            //    Console.WriteLine("Günlük Kiralama Bedeli :\t" + rent.DailyPrice + " $");
            //}

            foreach (var rent in rentManager.GetRentDetails())
            {
                TimeSpan result = rent.ReturnDate - rent.RentDate ;

                decimal resultDay = Convert.ToDecimal(result.Days);

                decimal pay = rent.DailyPrce * resultDay ;

                Console.WriteLine
                    (
                        "Rentİd :\t" + rent.RentId + "\n" +
                        "Customer Name :\t" + rent.CustomerName + "\n" +
                        "Custoemr Surname :\t" + rent.CustomerLastName + "\n" +
                        "Car Name :\t" + rent.CarName + "\n" +
                        "Rent Date :\t" + rent.RentDate + "\n" +
                        "Return DAte :\t" + rent.ReturnDate  + "\n" +
                        "Rent Time :\t" + result.Days + " Day" +  "\n" +
                        "Daily Price :\t" + rent.DailyPrce + "$"+ "\n" + 
                        "Money Payable :\t" + pay + "$" + "\n" +
                        "------------------------------------------------------"
                    );
            }
        }

        private static void SaleManagerTest()
        {
            SaleManager saleManager = new SaleManager(new EfSaleDal());

            foreach (var sale in saleManager.GetAll())
            {
                Console.WriteLine("Satış Fiyatı :\t" + sale.SalePrice + " $");
            }
        }

        private static void PurshaseManagerTest()
        {
            PurchaseManager purchaseManager = new PurchaseManager(new EfPurchaseDal());
            foreach (var purshase in purchaseManager.GetAll())
            {
                Console.WriteLine("Alış Fiyatı :\t" + purshase.PurchasePrice);
            }

        }

        private static void CustomerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //foreach (var customer in customerManager.GetAll())
            //{
            //    Console.WriteLine("Müşteri Adı-Soyadı:\t" + customer.CustomerName +"  " + customer.CustomerLastname);
            //}

            foreach (var customer in customerManager.GetCustomerDetails())
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
                        "Customer Address :\t" +customer.Address + "\n" +
                        "Customer Phone Number :\t" + customer.PhoneNumber + "\n" +
                        "Customer E-Mail Address :\t" + customer.EmailAddress + "\n" +
                        "Customer Zip Code :\t" + customer.ZipCode +"\n" +
                        "---------------------------------------------------" 
                    );  
            }
        }

        private static void CommunicationManagerTest()
        {
            CommunicationManager communicationManager = new CommunicationManager(new EfCommunicationDal());
            foreach (var communication in communicationManager.GetAll())
            {
                Console.WriteLine("Ülke :\t" + communication.Country);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Name :\t" + car.CarName);
            }
        }
    }
}
