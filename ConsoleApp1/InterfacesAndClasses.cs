using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndClasses
{
    public interface IInit
    {
        void Init(); // Метод для ввода данных с клавиатуры
        void RandomInit(Random rand); // Метод для инициализации случайными значениями
    }
    public class Car : IInit, IComparable<Car>, ICloneable
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public double GroundClearance { get; set; }

        public Car()
        {
            Brand = "Unknown";
            Year = 2000;
            Color = "Black";
            Price = 0;
            GroundClearance = 0;
        }

        public Car(string brand, int year, string color, double price, double groundClearance)
        {
            Brand = brand;
            Year = year;
            Color = color;
            Price = price;
            GroundClearance = groundClearance;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price}, Дорожный просвет: {GroundClearance}");
        }

        public virtual void Init()
        {
            try
            {
                Console.Write("Введите бренд: ");
                Brand = Console.ReadLine();
                Console.Write("Введите год выпуска: ");
                Year = int.Parse(Console.ReadLine());
                Console.Write("Введите цвет: ");
                Color = Console.ReadLine();
                Console.Write("Введите стоимость: ");
                Price = double.Parse(Console.ReadLine());
                Console.Write("Введите дорожный просвет: ");
                GroundClearance = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректные данные.");
                Init(); // Повторный вызов метода для повторного ввода
            }
        }

        //public virtual void RandomInit()
        //{
        //Random rand = new Random();
        //string[] brands = { "Toyota", "Ford", "BMW", "Audi", "Mercedes" };
        //string[] colors = { "Red", "Blue", "Black", "White", "Green" };

        //Brand = brands[rand.Next(brands.Length)];
        //    Year = rand.Next(2000, 2023);
        //    Color = colors[rand.Next(colors.Length)];
        //    Price = rand.Next(500000, 10000000);
        //    GroundClearance = rand.Next(10, 30);
        //}

        public virtual void RandomInit(Random rand)
        {
            string[] brands = { "Toyota", "Ford", "BMW", "Audi", "Mercedes" };
            string[] colors = { "Red", "Blue", "Black", "White", "Green" };

            Brand = brands[rand.Next(brands.Length)];
            Year = rand.Next(2000, 2023);
            Color = colors[rand.Next(colors.Length)];
            Price = rand.Next(500000, 10000000);
            GroundClearance = rand.Next(10, 30);
        }

        public override bool Equals(object obj)
        {
            if (obj is Car car)
            {
                return Brand == car.Brand && Year == car.Year && Color == car.Color && Price == car.Price && GroundClearance == car.GroundClearance;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price}, Дорожный просвет: {GroundClearance}";
        }

        public int CompareTo(Car other) => Price.CompareTo(other.Price);

        public object Clone()
        {
            return new Car(Brand, Year, Color, Price, GroundClearance);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }

    public class PassengerCar : Car
    {
        public int DoorsCount { get; set; }
        public double MaxSpeed { get; set; }

        public PassengerCar() : base()
        {
            DoorsCount = 4;
            MaxSpeed = 200;
        }

        public PassengerCar(string brand, int year, string color, double price, double groundClearance, int doorsCount, double maxSpeed)
            : base(brand, year, color, price, groundClearance)
        {
            DoorsCount = doorsCount;
            MaxSpeed = maxSpeed;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество дверей: {DoorsCount}, Максимальная скорость: {MaxSpeed} км/ч");
        }

        public override void Init()
        {
            // Вызов метода Init() из базового класса
            base.Init();

            // Ввод данных для производного класса
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    Console.Write("Введите количество дверей: ");
                    DoorsCount = int.Parse(Console.ReadLine());

                    Console.Write("Введите максимальную скорость: ");
                    MaxSpeed = double.Parse(Console.ReadLine());

                    isValidInput = true; // Если ввод корректен, выходим из цикла
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректные данные.");
                }
            }
        }

        public override void RandomInit(Random rand)
        {
            base.RandomInit(rand);
            DoorsCount = rand.Next(2, 5);
            MaxSpeed = rand.Next(150, 250);
        }

        public override string ToString()
        {
            return base.ToString() + $", Количество дверей: {DoorsCount}, Максимальная скорость: {MaxSpeed} км/ч";
        }
    }

    public class SUV : Car
    {
        public bool FourWheelDrive { get; set; }
        public string TerrainType { get; set; }

        public SUV() : base()
        {
            FourWheelDrive = false;
            TerrainType = "Unknown";
        }

        public SUV(string brand, int year, string color, double price, double groundClearance, bool fourWheelDrive, string terrainType)
            : base(brand, year, color, price, groundClearance)
        {
            FourWheelDrive = fourWheelDrive;
            TerrainType = terrainType;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Полный привод: {FourWheelDrive}, Тип местности: {TerrainType}");
        }

        public override void Init()
        {
            base.Init(); // Вызов метода Init() из базового класса
            try
            {
                Console.Write("Есть полный привод (true/false): ");
                FourWheelDrive = bool.Parse(Console.ReadLine());
                Console.Write("Введите тип местности: ");
                TerrainType = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректные данные.");
                Init(); // Повторный вызов метода для повторного ввода
            }
        }
        public override void RandomInit(Random rand)
        {
            base.RandomInit(rand);
            FourWheelDrive = rand.Next(2) == 1; // Случайное true/false
            string[] terrains = { "Sand", "Mud", "Snow", "Rock" };
            TerrainType = terrains[rand.Next(terrains.Length)];
        }

        public override string ToString()
        {
            return base.ToString() + $", Полный привод: {FourWheelDrive}, Тип местности: {TerrainType}";
        }
    }

    public class Truck : Car
    {
        public double LoadCapacity { get; set; }

        public Truck() : base()
        {
            LoadCapacity = 0;
        }

        public Truck(string brand, int year, string color, double price, double groundClearance, double loadCapacity)
            : base(brand, year, color, price, groundClearance)
        {
            LoadCapacity = loadCapacity;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Грузоподъёмность: {LoadCapacity} кг");
        }

        public override void Init()
        {
            base.Init(); // Вызов метода Init() из базового класса
            try
            {
                Console.Write("Введите грузоподъёмность: ");
                LoadCapacity = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите корректные данные.");
                Init(); // Повторный вызов метода для повторного ввода
            }
        }
        public override void RandomInit(Random rand)
        {
            base.RandomInit(rand);
            LoadCapacity = rand.Next(1000, 5000);
        }

        public override string ToString()
        {
            return base.ToString() + $", Грузоподъёмность: {LoadCapacity} кг";
        }
    }
}