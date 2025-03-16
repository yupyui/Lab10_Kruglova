using InterfacesAndClasses;
using System.Linq;
using System.Collections.Generic;
using System;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Random rand = new Random(); // Создаем один экземпляр Random

            Console.WriteLine("Выберите способ создания объектов:");
            Console.WriteLine("1. Вручную (с клавиатуры)");
            Console.WriteLine("2. Автоматически (случайные значения)");
            Console.Write("Ваш выбор: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // Создание объектов с вводом данных с клавиатуры
                Console.WriteLine("\nВведите данные для легкового автомобиля:");
                PassengerCar passengerCar = new PassengerCar();
                passengerCar.Init();
                cars.Add(passengerCar);

                Console.WriteLine("\nВведите данные для внедорожника:");
                SUV suv = new SUV();
                suv.Init();
                cars.Add(suv);

                Console.WriteLine("\nВведите данные для грузовика:");
                Truck truck = new Truck();
                truck.Init();
                cars.Add(truck);
            }
            else if (choice == 2)
            {
                // Создание массива из 20 объектов с использованием RandomInit()
                for (int i = 0; i < 20; i++)
                {
                    Car car;
                    switch (i % 3)
                    {
                        case 0:
                            car = new PassengerCar();
                            break;
                        case 1:
                            car = new SUV();
                            break;
                        case 2:
                            car = new Truck();
                            break;
                        default:
                            car = new Car();
                            break;
                    }
                    car.RandomInit(rand); // Передаем один экземпляр Random
                    cars.Add(car);
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор. Программа завершена.");
                return;
            }

            // Вывод информации о всех автомобилях
            Console.WriteLine("\nИнформация о всех автомобилях:");
            foreach (var car in cars)
            {
                car.Show();
                Console.WriteLine();
            }

            // Выполнение запросов
            Console.WriteLine("\nВыполнение запросов:");

            // 1. Самый дорогой внедорожник
            SUV mostExpensiveSUV = CarQueries.CarQueries.GetMostExpensiveSUV(cars);
            if (mostExpensiveSUV != null)
            {
                Console.WriteLine("Самый дорогой внедорожник:");
                mostExpensiveSUV.Show();
            }
            else
            {
                Console.WriteLine("Внедорожники не найдены.");
            }

            // 2. Средняя скорость легковых автомобилей
            double averageSpeed = CarQueries.CarQueries.GetAverageSpeedOfPassengerCars(cars);
            Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeed} км/ч");

            // 3. Грузовики с грузоподъёмностью, превышающей заданную
            Console.Write("Введите минимальную грузоподъёмность для поиска грузовиков: ");
            double minLoadCapacity = double.Parse(Console.ReadLine());
            List<Truck> trucksWithHighLoadCapacity = CarQueries.CarQueries.GetTrucksByLoadCapacity(cars, minLoadCapacity);
            if (trucksWithHighLoadCapacity.Any())
            {
                Console.WriteLine($"Грузовики с грузоподъёмностью выше {minLoadCapacity} кг:");
                foreach (var truck in trucksWithHighLoadCapacity)
                {
                    truck.Show();
                }
            }
            else
            {
                Console.WriteLine("Грузовики с указанной грузоподъёмностью не найдены.");
            }
        }
    }
}