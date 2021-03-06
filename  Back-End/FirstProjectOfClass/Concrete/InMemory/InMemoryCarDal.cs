﻿using DataAccess.Abstruct.DataAcessLayers;
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
        List<Car> cars;

        public InMemoryProductDal()
        {
            this.cars = new List<Car>
            {
                new Car
                {
                    Id=1,
                    Marque="Ford",
                    CarName="Mustang",
                    BrandDate=1976,
                    Color="Red",
                    Description="Type :\t2 Door \nBody Styles :\tCoupe, Fastback \nEngines :\t140ci 2V 4 cyl, 171ci 2V V6, 302ci 2V V8",
                    Plaque="07FF546",
                    Price=3791
                },
                new Car
                {
                    Id=2,
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

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = cars.SingleOrDefault
                (
                    c => c.Id == car.Id
                );
            cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault
                (
                    c => c.Id == car.Id
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
