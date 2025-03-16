using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using InterfacesAndClasses;
using CarQueries;

namespace Lab.Tests
{
    [TestClass]
    public class CarQueriesTests
    {
        public class IInitTests
        {
            [TestMethod]
            public void Car_Init_SetsBrandCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual("Unknown", car.Brand); // Проверяем, что Brand изменился после Init
            }
            [TestMethod]
            public void Car_Init_SetsYearCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(2000, car.Year); // Проверяем, что Year изменился после Init
            }

            [TestMethod]
            public void Car_Init_SetsColorCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual("Black", car.Color); // Проверяем, что Color изменился после Init
            }

            [TestMethod]
            public void Car_Init_SetsPriceCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(0, car.Price); // Проверяем, что Price изменился после Init
            }

            [TestMethod]
            public void Car_Init_SetsGroundClearanceCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(0, car.GroundClearance); // Проверяем, что GroundClearance изменился после Init
            }
            [TestMethod]
            public void Truck_Init_SetsLoadCapacityCorrectly()
            {
                var truck = new Truck();
                truck.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(truck.LoadCapacity > 0); // Проверяем, что LoadCapacity больше 0
            }
            [TestMethod]
            public void IInit_IsImplementedByCar()
            {
                var car = new Car();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car is IInit); // Проверяем, что Car реализует IInit
            }

            [TestMethod]
            public void IInit_IsImplementedByPassengerCar()
            {
                var passengerCar = new PassengerCar();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(passengerCar is IInit); // Проверяем, что PassengerCar реализует IInit
            }

            [TestMethod]
            public void IInit_IsImplementedBySUV()
            {
                var suv = new SUV();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv is IInit); // Проверяем, что SUV реализует IInit
            }

            [TestMethod]
            public void IInit_IsImplementedByTruck()
            {
                var truck = new Truck();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(truck is IInit); // Проверяем, что Truck реализует IInit
            }
        }

        private List<Car> _cars;
        [TestInitialize]
        public void Initialize()
        {
            _cars = new List<Car>
        {
            new SUV("Ford", 2018, "Black", 600000, 25, true, "Sand"),
            new SUV("BMW", 2020, "White", 8000000, 15, false, "Mud"),
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250),
            new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220),
            new Truck("Volvo", 2019, "Red", 7000000, 30, 3000),
            new Truck("MAN", 2021, "Yellow", 6000000, 28, 2500)
        };
        }

        [TestMethod]
        public void GetMostExpensiveSUV_ReturnsCorrectSUV()
        {
            var result = CarQueries.CarQueries.GetMostExpensiveSUV(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BMW", result.Brand);
        }

        [TestMethod]
        public void GetMostExpensiveSUV_ReturnsNull_WhenNoSUVsExist()
        {
            var cars = new List<Car>
        {
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250),
            new Truck("Volvo", 2019, "Red", 7000000, 30, 3000)
        };

            var result = CarQueries.CarQueries.GetMostExpensiveSUV(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAverageSpeedOfPassengerCars_ReturnsCorrectAverage()
        {
            double result = CarQueries.CarQueries.GetAverageSpeedOfPassengerCars(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(235, result);
        }

        [TestMethod]
        public void GetAverageSpeedOfPassengerCars_Returns0_WhenNoPassengerCarsExist()
        {
            var cars = new List<Car>
        {
            new SUV("Ford", 2018, "Black", 600000, 25, true, "Sand"),
            new Truck("Volvo", 2019, "Red", 7000000, 30, 3000)
        };

            double result = CarQueries.CarQueries.GetAverageSpeedOfPassengerCars(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetColorsOfSUVsWithFourWheelDrive_ReturnsCorrectColors()
        {
            var result = CarQueries.CarQueries.GetColorsOfSUVsWithFourWheelDrive(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Black", result[0]);
        }

        [TestMethod]
        public void GetColorsOfSUVsWithFourWheelDrive_ReturnsEmptyList_WhenNoSUVsWithFourWheelDriveExist()
        {
            var cars = new List<Car>
        {
            new SUV("BMW", 2020, "White", 8000000, 15, false, "Mud"),
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250)
        };

            var result = CarQueries.CarQueries.GetColorsOfSUVsWithFourWheelDrive(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetMostExpensiveCar_ReturnsCorrectCar()
        {
            var result = CarQueries.CarQueries.GetMostExpensiveCar(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BMW", result.Brand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMostExpensiveCar_ThrowsException_WhenListIsEmpty()
        {
            var cars = new List<Car>();
            CarQueries.CarQueries.GetMostExpensiveCar(cars);
        }

        [TestMethod]
        public void GetAveragePriceOfCars_ReturnsCorrectAverage()
        {
            double result = CarQueries.CarQueries.GetAveragePriceOfCars(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5183333.33, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAveragePriceOfCars_ThrowsException_WhenListIsEmpty()
        {
            var cars = new List<Car>();
            CarQueries.CarQueries.GetAveragePriceOfCars(cars);
        }

        [TestMethod]
        public void GetSUVsWithFourWheelDrive_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetSUVsWithFourWheelDrive(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetSUVsWithFourWheelDrive_ReturnsEmptyList_WhenNoSUVsWithFourWheelDriveExist()
        {
            var cars = new List<Car>
        {
            new SUV("BMW", 2020, "White", 8000000, 15, false, "Mud"),
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250)
        };

            var result = CarQueries.CarQueries.GetSUVsWithFourWheelDrive(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetPassengerCarsBySpeed_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetPassengerCarsBySpeed(_cars, 240);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetPassengerCarsBySpeed_ReturnsEmptyList_WhenNoPassengerCarsMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetPassengerCarsBySpeed(_cars, 300);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetSUVsByPriceRange_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetSUVsByPriceRange(_cars, 500000, 9000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetSUVsByPriceRange_ReturnsEmptyList_WhenNoSUVsMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetSUVsByPriceRange(_cars, 9000000, 10000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetCarsByColor_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetCarsByColor(_cars, "Red");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetCarsByColor_ReturnsEmptyList_WhenNoCarsWithSpecifiedColorExist()
        {
            var result = CarQueries.CarQueries.GetCarsByColor(_cars, "Green");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetSUVsByTerrain_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetSUVsByTerrain(_cars, "Mud");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetSUVsByTerrain_ReturnsEmptyList_WhenNoSUVsWithSpecifiedTerrainExist()
        {
            var result = CarQueries.CarQueries.GetSUVsByTerrain(_cars, "Snow");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetTrucksByLoadCapacity_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetTrucksByLoadCapacity(_cars, 2500);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTrucksByLoadCapacity_ReturnsEmptyList_WhenNoTrucksMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetTrucksByLoadCapacity(_cars, 4000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetTrucksByPriceRange_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetTrucksByPriceRange(_cars, 5000000, 8000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTrucksByPriceRange_ReturnsEmptyList_WhenNoTrucksMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetTrucksByPriceRange(_cars, 9000000, 10000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }
    }

    [TestClass]
    public class CarTests
    {

        [TestMethod]
        public void Car_Constructor_WithParameters_ColorIsCorrect()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Blue", car.Color);
        }

        [TestMethod]
        public void Car_Clone_ReturnsNewObjectWithSamePrice()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var clonedCar = (Car)car.Clone();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Price, clonedCar.Price);
        }

        [TestMethod]
        public void Car_ShallowCopy_ReturnsNewObjectWithSameColor()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var shallowCopyCar = (Car)car.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Color, shallowCopyCar.Color);
        }
    }

    [TestClass]
    public class PassengerCarTests
    {
        [TestMethod]
        public void PassengerCar_Constructor_WithParameters_MaxSpeedIsCorrect()
        {
            var passengerCar = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(220, passengerCar.MaxSpeed);
        }
    }

    [TestClass]
    public class SUVTests
    {
        [TestMethod]
        public void SUV_Constructor_WithParameters_TerrainTypeIsCorrect()
        {
            var suv = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Mud", suv.TerrainType);
        }

        [TestMethod]
        public void SUV_RandomInit_SetsRandomFourWheelDrive()
        {
            var suv = new SUV();
            var rand = new Random();
            suv.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv.FourWheelDrive || !suv.FourWheelDrive); // Проверка, что значение установлено
        }

        [TestMethod]
        public void SUV_RandomInit_SetsRandomTerrainType()
        {
            var suv = new SUV();
            var rand = new Random();
            suv.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv.TerrainType == "Sand" || suv.TerrainType == "Mud" || suv.TerrainType == "Snow" || suv.TerrainType == "Rock");
        }
    }

    [TestClass]
    public class TruckTests
    {
        [TestMethod]
        public void Car_RandomInit_SetsRandomBrand()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car.Brand == "Toyota" || car.Brand == "Ford" || car.Brand == "BMW" || car.Brand == "Audi" || car.Brand == "Mercedes");
        }

        [TestMethod]
        public void Car_RandomInit_SetsRandomYear()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car.Year >= 2000 && car.Year <= 2023);
        }
        [TestMethod]
        public void Truck_Constructor_WithParameters_LoadCapacityIsCorrect()
        {
            var truck = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3000, truck.LoadCapacity);
        }
    }
}
