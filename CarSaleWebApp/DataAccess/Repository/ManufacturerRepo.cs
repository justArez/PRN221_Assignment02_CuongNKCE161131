using BusinessObject;
using DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ManufacturerRepo: IManufacturerRepo
    {
        public ManufacturerRepo() { }   

        private ManufacturerDAO manufacturerDAO = null;

        private ManufacturerDAO _manufacturerDAO()
        {
            if (this.manufacturerDAO == null)
            {
                this.manufacturerDAO = new ManufacturerDAO();
            }
            return this.manufacturerDAO;
        }

        public void AddManufacturer(Manufacturer manufacturer) {
            _manufacturerDAO().Add(manufacturer);
        }

        public void DeleteManufacturerById(string id)
        {
            _manufacturerDAO().Delete(id);
        }

        public Manufacturer GetManufacturerById(string id)
        {
            return _manufacturerDAO().GetById(id);
        }

        public IEnumerable<Manufacturer> GetManufacturerList()
        {
            return _manufacturerDAO().GetList();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _manufacturerDAO().Update(manufacturer);
        }
    }
}
