using BusinessObject;
using DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CarRepo : ICarRepo
    {

        public CarRepo() { }

        private CarDAO carDAO = null;

        private CarDAO _carDAO() {
            if (this.carDAO == null) {
                this.carDAO = new CarDAO();
            }
            return this.carDAO; 
        }

        public void AddCar(Car car) {
            _carDAO().Add(car);
        }

        public void DeleteCarById(string id)
        {
            _carDAO().Delete(id);
        }

        public Car GetCarById(string id)
        {
            return _carDAO().GetByID(id);
        }

        public IEnumerable<Car> GetCarList()
        {
            return _carDAO().GetList();
        }

        public void UpdateCar(Car car)
        {
            _carDAO().Update(car);
        }
    }
}
