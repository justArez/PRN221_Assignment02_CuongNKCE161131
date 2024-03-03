using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CarDAO
    {
        private static CarDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CarDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Car> GetList()
        {
            var carList = new List<Car>();
            try
            {
                using var context = new CarSaleManagementDbContext();
                carList = context.Cars.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return carList;
        }

        public Car GetByID(string carId)
        {
            Car car = null;
            try
            {
                using var context = new CarSaleManagementDbContext();
                car = context.Cars.SingleOrDefault(c => c.Carid == carId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return car;
        }

        public void Add(Car car)
        {
            try
            {
                Car _car = GetByID(car.Carid);
                if (_car == null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Cars.Add(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Car is already existed.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Car car)
        {
            try
            {
                Car _car = GetByID(car.Carid);
                if (_car != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Cars.Update(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Car does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(string carId)
        {
            try
            {
                Car _car = GetByID(carId);
                if (_car != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Cars.Remove(_car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Car does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}

