using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace Carfleet
{
    public class Enterprise
    {
        #region private attributes
        private string _name;
        private string _street;
        private string _city;
        private string _phonenumber;
        private string _emailaddress;
        private List<Vehicle> _vehicles;
        #endregion private attributes

        #region public methods
        public Enterprise(string name, string street, string city, string phonenumber, string emailaddress)
        {
            _name = name;
            _street = street;
            _city = city;
            _phonenumber = phonenumber;
            _emailaddress = emailaddress;
        }

        public string Name { get => _name; set => _name = value; }
        public string Street { get => _street; set => _street = value; }
        public string City { get => _city; set => _city = value; }
        public string Phonenumber { get => _phonenumber; set => _phonenumber = value; }
        public string Emailaddress { get => _emailaddress; set => _emailaddress = value; }

        public void Add(Vehicle vehicleToAdd)
        {
            _vehicles.Add(vehicleToAdd);
        }

        public void Add(Driver driverToAdd)
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleByChassisNumber(string chassisNumber)
        {
            throw new NotImplementedException();
        }

        public Driver GetDriverByEmailaddress(string driverEmailaddress)
        {
            throw new NotImplementedException();
        }

        public void AssignVehicleToDriver(string chassisNumber, string driverEmailaddress)
        {
            var vehicle = GetVehicleByChassisNumber(chassisNumber);
            var driver = GetDriverByEmailaddress(driverEmailaddress);

            if (vehicle != null && driver != null)
            {
                driver.TakeAVehicle(vehicle);
            }
            else
            {
                throw new InvalidOperationException("Vehicle or driver not found.");
            }
        }
        #endregion public methods
    }
}
