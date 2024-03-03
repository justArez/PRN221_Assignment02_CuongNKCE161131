using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface ICarRepo
    {
        IEnumerable<Car> GetCarList();
        Car GetCarById(string id);
        void AddCar(Car car);
        void DeleteCarById(string id);
        void UpdateCar(Car car);
    }
}
