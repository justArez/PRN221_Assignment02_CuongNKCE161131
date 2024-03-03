using BusinessObject;

namespace BusinessService
{
    public interface ICarService
    {
        public void AddCar(Car car);

        public void DeleteCarById(string id);

        public Car GetCarById(string id);

        public IEnumerable<Car> GetCarList();

        public void UpdateCar(Car car);
    }
}
