using NUnit.Framework;
using System.Collections.Generic;

namespace Carfleet
{
    public class TestIntegrationEnterprise
    {
        #region private attributes
        #region vehicle
        private string _registration = "VD 123 567";
        private string _brand = "Mercedes-Benz";
        private string _model = "Vito";
        private string _chassisNumber = "SV30-0169266";
        private Vehicle _vehicule;
        #endregion

        #region driver
        private string _driverName = "Kiss";
        private string _firstname = "Norbert";
        private string _driverPhonenumber = "+4398567985093";
        private string _driverEmailaddress = "kiss.norbert@fia.com";
        private List<string> _languages = new List<string>();
        private string _workZone = "Spain";
        private Driver _driver;
        #endregion private driver

        #region enterprise
        private string _enterpriseName = "Friderici";
        private string _street = "Av. de Genève 12";
        private string _city = "1200 Lausanne";
        private string _enterprisePhonenumber = "+41 21 456 78 90";
        private string _enterpriseEmailaddress = "info@friderici.ch";
        private Enterprise _enterprise;
        #endregion entreprise
        #endregion private attributes

        [SetUp]
        public void Setup()
        {
            _vehicule = new Vehicle(_registration, _brand, _model, _chassisNumber);
            _driver = new Driver(_driverName,_firstname, _driverPhonenumber, _driverEmailaddress, _workZone);
            _enterprise = new Enterprise(_enterpriseName, _street, _city, _enterprisePhonenumber, _enterpriseEmailaddress);
        }

        [Test]
        public void GetVehicleByRegistration_NewVehicle_VehicleAddedAndGet()
        {
            //given

            //when
            _enterprise.Add(_vehicule);

            //then
            Assert.AreEqual(_registration, _enterprise.GetVehicleByChassisNumber(_chassisNumber).Registration);
        }

        [Test]
        public void GetDriverByEmailaddress_NewDriver_DriverAddedAndGet()
        {
            //given

            //when
            _enterprise.Add(_driver);

            //then
            Assert.AreEqual(_driverName, _enterprise.GetDriverByEmailaddress(_driverEmailaddress).Name);
        }

        [Test]
        public void AssignVehicleToDriver_NominalCase_AssignationSuccessfull()
        {
            //given
            _enterprise.Add(_vehicule);
            _enterprise.Add(_driver);

            //when
            _enterprise.AssignVehicleToDriver(_chassisNumber, _driverEmailaddress);

            //then
            Assert.AreEqual(_registration, _enterprise.GetDriverByEmailaddress(_driverEmailaddress).Vehicle.Registration);
        }
    }
}
