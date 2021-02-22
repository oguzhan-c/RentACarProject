using DataAccess.Abstruct;
using Entities.Concrute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Cars> cars;

        public InMemoryProductDal()
        {
            this.cars = new List<Cars>
            {
                new Cars
                {
                    CarId=1,
                    Marque="Ford",
                    CarName="Mustang",
                    BrandDate=1976,
                    Color="Red",
                    Description="Type :\t2 Door \nBody Styles :\tCoupe, Fastback \nEngines :\t140ci 2V 4 cyl, 171ci 2V V6, 302ci 2V V8",
                    Plaque="07FF546",
                    Price=3791
                },
                new Cars
                {
                    CarId=2,
                    Marque="Ford",
                    CarName="Mustang",
                    BrandDate=1976,
                    Color="Red",
                    Description="Type :\t2 Door \nBody Styles :\tCoupe, Fastback \nEngines :\t140ci 2V 4 cyl, 171ci 2V V6, 302ci 2V V8",
                    Plaque="07FF546",
                    Price=3791
                }
            };
        }

        public void Add(Cars car)
        {
            cars.Add(car);
        }

        public void Delete(Cars car)
        {
            Cars carToDelete = cars.SingleOrDefault
                (
                    c => c.CarId == car.CarId
                );
            cars.Remove(carToDelete);
        }

        public Cars Get(Expression<Func<Cars, bool>> filter)
        {
            return null;
        }

        public List<Cars> GetAll(Expression<Func<Cars, bool>> filter = null)
        {
            return cars;
        }

        public void Update(Cars car)
        {
            Cars carToUpdate = cars.SingleOrDefault
                (
                    c => c.CarId == car.CarId
                );
            carToUpdate.CarName = car.CarName;
            carToUpdate.Color = car.Color;
            carToUpdate.BrandDate = car.BrandDate;
            carToUpdate.Description = car.Description;
            carToUpdate.Marque = car.Marque;
            carToUpdate.Plaque = car.Plaque;
            carToUpdate.Price = carToUpdate.Price;
        }
    }
}
