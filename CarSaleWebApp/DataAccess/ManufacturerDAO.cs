using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ManufacturerDAO
    {
        private static ManufacturerDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ManufacturerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ManufacturerDAO();
                    }
                }
                return instance;
            }
        }


        public IEnumerable<Manufacturer> GetList()
        {
            var manuList = new List<Manufacturer>();
            try
            {
                using var context = new CarSaleManagementDbContext();
                manuList = context.Manufacturers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return manuList;
        }

        public Manufacturer GetById(string manuId)
        {
            Manufacturer manu = null;
            try
            {
                using var context = new CarSaleManagementDbContext();
                manu = context.Manufacturers.SingleOrDefault(c => c.ManufacturerId == manuId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return manu;
        }

        public void Add(Manufacturer manu)
        {
            try
            {
                Manufacturer _manu = GetById(manu.ManufacturerId);
                if (_manu == null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Manufacturers.Add(manu);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Manufacturer is already existed.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Manufacturer manu)
        {
            try
            {
                Manufacturer _manu = GetById(manu.ManufacturerId);
                if (_manu != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Manufacturers.Update(manu);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Manufacturer does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(string manuId)
        {
            try
            {
                Manufacturer _manu = GetById(manuId);
                if (_manu != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Manufacturers.Remove(_manu);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Manufacturer does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
