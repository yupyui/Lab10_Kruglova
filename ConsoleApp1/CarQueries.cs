using System;
using System.Collections.Generic;
using System.Linq;
using InterfacesAndClasses;

namespace CarQueries
{
    public static class CarQueries
    {
        public static SUV GetMostExpensiveSUV(List<Car> cars)
        {
            return cars.OfType<SUV>().OrderByDescending(suv => suv.Price).FirstOrDefault();
        }

        public static double GetAverageSpeedOfPassengerCars(List<Car> cars)
        {
            var passengerCars = cars.OfType<PassengerCar>();
            return passengerCars.Any() ? passengerCars.Average(pc => pc.MaxSpeed) : 0;
        }

        public static List<string> GetColorsOfSUVsWithFourWheelDrive(List<Car> cars)
        {
            return cars.OfType<SUV>()
                        .Where(suv => suv.FourWheelDrive)
                        .Select(suv => suv.Color)
                        .Distinct()
                        .ToList();
        }

        public static Car GetMostExpensiveCar(List<Car> cars)
        {
            if (cars == null || !cars.Any())
                throw new ArgumentException("Список автомобилей не может быть пустым.");

            return cars.OrderByDescending(car => car.Price).FirstOrDefault();
        }

        public static double GetAveragePriceOfCars(List<Car> cars)
        {
            if (cars == null || !cars.Any())
                throw new ArgumentException("Список автомобилей не может быть пустым.");

            return cars.Average(car => car.Price);
        }

        public static List<SUV> GetSUVsWithFourWheelDrive(List<Car> cars)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            return cars.OfType<SUV>()
                       .Where(suv => suv.FourWheelDrive)
                       .ToList();
        }

        public static List<PassengerCar> GetPassengerCarsBySpeed(List<Car> cars, int minSpeed)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            return cars.OfType<PassengerCar>()
                       .Where(pc => pc.MaxSpeed >= minSpeed)
                       .ToList();
        }

        public static List<SUV> GetSUVsByPriceRange(List<Car> cars, double minPrice, double maxPrice)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            if (minPrice > maxPrice)
                throw new ArgumentException("Минимальная цена не может быть больше максимальной.");

            return cars.OfType<SUV>()
                       .Where(suv => suv.Price >= minPrice && suv.Price <= maxPrice)
                       .ToList();
        }

        public static List<Car> GetCarsByColor(List<Car> cars, string color)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            if (string.IsNullOrEmpty(color))
                throw new ArgumentException("Цвет не может быть пустым или null.", nameof(color));

            return cars.Where(car => car.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                       .ToList();
        }

        public static List<SUV> GetSUVsByTerrain(List<Car> cars, string terrainType)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            if (string.IsNullOrEmpty(terrainType))
                throw new ArgumentException("Тип местности не может быть пустым или null.", nameof(terrainType));

            return cars.OfType<SUV>()
                       .Where(suv => suv.TerrainType.Equals(terrainType, StringComparison.OrdinalIgnoreCase))
                       .ToList();
        }

        public static List<Truck> GetTrucksByLoadCapacity(List<Car> cars, double minLoadCapacity)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            if (minLoadCapacity < 0)
                throw new ArgumentException("Грузоподъемность не может быть отрицательной.", nameof(minLoadCapacity));

            return cars.OfType<Truck>()
                       .Where(truck => truck.LoadCapacity >= minLoadCapacity)
                       .ToList();
        }

        public static List<Truck> GetTrucksByPriceRange(List<Car> cars, double minPrice, double maxPrice)
        {
            if (cars == null)
                throw new ArgumentNullException(nameof(cars), "Список автомобилей не может быть null.");

            if (minPrice > maxPrice)
                throw new ArgumentException("Минимальная цена не может быть больше максимальной.");

            return cars.OfType<Truck>()
                       .Where(truck => truck.Price >= minPrice && truck.Price <= maxPrice)
                       .ToList();
        }
    }
}