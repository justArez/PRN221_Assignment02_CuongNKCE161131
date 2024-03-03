
using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class ManufacturerService: IManufacturerService
    {
        public ManufacturerService() { }

        private ManufacturerRepo manufacturerRepo = null;

        private ManufacturerRepo _manufacturerRepo()
        {
            if (manufacturerRepo == null)
            {
                this.manufacturerRepo = new ManufacturerRepo();
            }
            return this.manufacturerRepo;
        }

        public void AddManufacturer(Manufacturer manufacturer) {
            _manufacturerRepo().AddManufacturer(manufacturer);
        }

        public void DeleteManufacturerById(string id)
        {
            _manufacturerRepo().DeleteManufacturerById(id);
        }

        public Manufacturer GetManufacturerById(string id)
        {
            return _manufacturerRepo().GetManufacturerById(id);
        }
        public IEnumerable<Manufacturer> GetManufacturerList()
        {
            return _manufacturerRepo().GetManufacturerList();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
           _manufacturerRepo().UpdateManufacturer(manufacturer);
        }
    }
}
