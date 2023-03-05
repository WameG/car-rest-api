using CarLibary;

namespace car_rest_api.Repositories
{
    public class CarRepository
    {
        private int _nextId;
        private List<Car> _cars;

        public CarRepository()
        {
            _nextId = 1;
            _cars = new List<Car>()
            {
                new Car() { Id = _nextId++, Model = "C22D", LicensePlate = "DS45678", Price = 420000},
                new Car() { Id = _nextId++, Model = "A450", LicensePlate = "MD22335", Price = 720000},
                new Car() { Id = _nextId++, Model = "GT63", LicensePlate = "GPF", Price = 2720000},
                new Car() { Id = _nextId++, Model = "RSQ8", LicensePlate = "HJW92", Price = 2500000},
            };
        }

        public List<Car> GetAll()
        {
            return new List<Car>(_cars);
        }

        public Car? GetById(int Id)
        {
            return _cars.Find(car => car.Id == Id);
        }

        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextId++;
            _cars.Add(newCar);
            return newCar;
        }

        public Car? Delete(int Id)
        {
           Car? foundCar = GetById(Id);
           
            if (foundCar == null)
            {
                return null;
            }

            _cars.Remove(foundCar);
            return foundCar;
        }

        public Car? Update(int Id, Car updatedCar)
        {
            updatedCar.Validate();
            Car? carToBeUpdated = GetById(Id);
            if (carToBeUpdated == null)
            {
                return null;
            }


            carToBeUpdated.Model = updatedCar.Model;
            carToBeUpdated.LicensePlate = updatedCar.LicensePlate;
            carToBeUpdated.Price = updatedCar.Price;

            return carToBeUpdated;
        }
    }
}
