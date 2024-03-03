using BusinessObject;
using DataAccess;

namespace BusinessService
{
    public class CarService: ICarService
    {
        public CarService() { }

        private CarRepo carRepo = null;

        private CarRepo _carRepo()
        {
            if (this.carRepo == null)
            {
                this.carRepo = new CarRepo();
            }
            return this.carRepo;
        }

        public void AddCar(Car car)
        {
            _carRepo().AddCar(car);
        }
           

        public void DeleteCarById(string id)
        {
            _carRepo().DeleteCarById(id);
        }

        public Car GetCarById(string id)
        {
            return _carRepo().GetCarById(id);
        }

        public IEnumerable<Car> GetCarList()
        {
            return _carRepo().GetCarList();
        }

        public void UpdateCar(Car car)
        {
            _carRepo().UpdateCar(car);
        }
    }
}
