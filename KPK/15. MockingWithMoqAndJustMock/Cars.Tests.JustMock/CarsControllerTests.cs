namespace Cars.Tests
{
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;


    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(5, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        // Homework
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDetailsShouldRaiseExceptionIfCalledNull()
        {
            var carDetails = this.controller.Details(-1);
        }

        [TestMethod]
        public void TestSearchCarsAll()
        {
            var allCarsView = this.controller.Search(string.Empty);
            var count = ((IList<Car>)allCarsView.Model).Count;
            Assert.AreEqual(5, count, "Search methode return wrong count of all cars!");
        }

        [TestMethod]
        public void TestSortCarsByMake()
        {
            var carsView = this.controller.Sort("make");
            var car = ((IList<Car>)carsView.Model)[0];
            Assert.AreEqual(1, car.Id, "Car Controler sort by make not working!");
        }

        [TestMethod]
        public void TestSortCarsByYear()
        {
            var carsView = this.controller.Sort("year");
            var car = ((IList<Car>)carsView.Model)[0];
            Assert.AreEqual(1, car.Id, "Car Controler sort by year not working!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSortCarsUnknownSortCriteria()
        {
            var carsView = this.controller.Sort(string.Empty);
        }

        [TestMethod]
        public void TestCarsControllerCreationWithoutParameters()
        {
            CarsController carController = new CarsController();
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
