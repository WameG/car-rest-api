using Microsoft.VisualStudio.TestTools.UnitTesting;
using car_rest_api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibary;

namespace car_rest_api.Repositories.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {

        [TestMethod()]
        public void GetAllTest()
        {
            CarRepository repository = new CarRepository();

            List<Car> cars = repository.GetAll();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            CarRepository repository = new CarRepository();

            Car? car = repository.GetById(1);

            Assert.IsNotNull(car);
            Assert.AreEqual(car.Id, 1);
            Assert.AreEqual(car.LicensePlate, "DS45678");
            Assert.AreEqual(car.Model, "C22D");
            Assert.AreEqual(car.Price, 420000);
        }

        [TestMethod()]
        public void AddTest()
        {
            Car newCar = new Car() { Id = 78734, Model = "E630", LicensePlate = "Hjkjjk", Price = 650000 };

            CarRepository repository = new CarRepository();

            Car car = repository.Add(newCar);

            Assert.IsNotNull(car);
            Assert.AreEqual(car.Id, 5);
            Assert.IsTrue(car.Model.Length > 3);
            Assert.IsTrue(car.LicensePlate.Length > 2 || car.LicensePlate.Length < 7);
            Assert.IsTrue(car.Price > 0);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            CarRepository repository = new CarRepository();

            Car? car = repository.Delete(1);

            Assert.IsNotNull(car);
            Assert.AreEqual(car.Id, 1);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            CarRepository repository = new CarRepository();


            Car updatedCar = new Car() { Id = 78734, Model = "E630", LicensePlate = "Hjkjjk", Price = 650000 };

            Car? car = repository.Update(1, updatedCar);

            Car? carToBeUpdated = repository.GetById(1);

            Assert.IsNotNull(car);
            Assert.IsTrue(car.Model.Length > 3);
            Assert.IsTrue(car.LicensePlate.Length > 2 || car.LicensePlate.Length < 7);
            Assert.IsTrue(car.Price > 0);
            Assert.AreEqual(car.Id, carToBeUpdated?.Id);
            Assert.IsNotNull(carToBeUpdated);
            Assert.AreEqual(carToBeUpdated?.LicensePlate, car.LicensePlate);
            Assert.AreEqual(carToBeUpdated?.Model, car.Model);
            Assert.AreEqual(carToBeUpdated?.Price, car.Price);
        }
    }
}