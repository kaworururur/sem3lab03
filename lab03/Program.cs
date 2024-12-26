//using System;

//public struct Vector
//{
//    public double x;
//    public double y;
//    public double z;

//    public Vector(double x, double y, double z)
//    {
//        this.x = x;
//        this.y = y;
//        this.z = z;
//    }

//    // Переопределение оператора сложения векторов
//    public static Vector operator +(Vector a, Vector b)
//    {
//        return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
//    }

//    // Переопределение оператора умножения векторов (векторное произведение)
//    public static Vector operator *(Vector a, Vector b)
//    {
//        return new Vector(
//            a.y * b.z - a.z * b.y,
//            a.z * b.x - a.x * b.z,
//            a.x * b.y - a.y * b.x
//        );
//    }

//    // Переопределение оператора умножения вектора на число
//    public static Vector operator *(Vector a, double scalar)
//    {
//        return new Vector(a.x * scalar, a.y * scalar, a.z * scalar);
//    }

//    // Переопределение оператора сравнения по длине векторов
//    public static bool operator ==(Vector a, Vector b)
//    {
//        return a.Length() == b.Length();
//    }

//    public static bool operator !=(Vector a, Vector b)
//    {
//        return !(a == b);
//    }

//    // Метод для вычисления длины вектора
//    public double Length()
//    {
//        return Math.Sqrt(x * x + y * y + z * z);
//    }

//    // Переопределение методов Equals и GetHashCode
//    public override bool Equals(object obj)
//    {
//        if (obj is Vector)
//        {
//            Vector other = (Vector)obj;
//            return this == other;
//        }
//        return false;
//    }

//    public override int GetHashCode()
//    {
//        return HashCode.Combine(x, y, z);
//    }

//    public override string ToString()
//    {
//        return $"Vector({x}, {y}, {z})";
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Vector vec1 = new Vector(1, 2, 3);
//        Vector vec2 = new Vector(4, 5, 6);

//        // Сложение векторов
//        Vector sum = vec1 + vec2;
//        Console.WriteLine($"Сумма: {sum}");

//        // Умножение векторов (векторное произведение)
//        Vector crossProduct = vec1 * vec2;
//        Console.WriteLine($"Векторное произведение: {crossProduct}");

//        // Умножение вектора на число
//        Vector scaledVec = vec1 * 2.0;
//        Console.WriteLine($"Умножение вектора на число: {scaledVec}");

//        // Сравнение векторов по длине
//        bool areEqual = vec1 == vec2;
//        Console.WriteLine($"Векторы равны по длине: {areEqual}");
//    }
//}

//using System;
//using System.Collections.Generic;

//public class Car : IEquatable<Car>
//{
//    public string Name { get; set; }
//    public string Engine { get; set; }
//    public int MaxSpeed { get; set; } // Макс. скорость в км/ч

//    public Car(string name, string engine, int maxSpeed)
//    {
//        Name = name;
//        Engine = engine;
//        MaxSpeed = maxSpeed;
//    }

//    // Переопределение метода ToString
//    public override string ToString()
//    {
//        return Name;
//    }

//    // Реализация интерфейса IEquatable
//    public bool Equals(Car other)
//    {
//        if (other == null) return false;
//        return this.Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
//    }

//    public override bool Equals(object obj)
//    {
//        return Equals(obj as Car);
//    }

//    public override int GetHashCode()
//    {
//        return Name.ToLower().GetHashCode();
//    }
//}

//public class CarsCatalog
//{
//    private List<Car> _cars = new List<Car>();

//    // Индексатор, который возвращает строку с названием машины и типом двигателя
//    public string this[int index]
//    {
//        get
//        {
//            if (index < 0 || index >= _cars.Count)
//            {
//                throw new ArgumentOutOfRangeException("index", "Индекс вне диапазона.");
//            }
//            return $"{_cars[index].Name} - {_cars[index].Engine}";
//        }
//    }

//    public void AddCar(Car car)
//    {
//        _cars.Add(car);
//    }

//    public int Count => _cars.Count;
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        CarsCatalog catalog = new CarsCatalog();
//        catalog.AddCar(new Car("Toyota Camry", "V6", 240));
//        catalog.AddCar(new Car("Honda Accord", "I4", 220));

//        // Печать всех машин в каталоге
//        for (int i = 0; i < catalog.Count; i++)
//        {
//            Console.WriteLine(catalog[i]);
//        }

//        // Пример сравнения
//        Car car1 = new Car("Toyota Camry", "V6", 240);
//        Car car2 = new Car("Toyota Camry", "V4", 200);

//        Console.WriteLine($"car1.Equals(car2): {car1.Equals(car2)}"); // Должно вернуть true
//    }
//}

//using System;

//public class Currency
//{
//    public double Value { get; set; }

//    public Currency(double value)
//    {
//        Value = value;
//    }
//}

//public class CurrencyUSD : Currency
//{
//    public CurrencyUSD(double value) : base(value) { }

//    // Явное преобразование из USD в EUR
//    public static explicit operator CurrencyEUR(CurrencyUSD usd)
//    {
//        Console.Write("Введите текущий курс USD к EUR: ");
//        double exchangeRate = double.Parse(Console.ReadLine());
//        return new CurrencyEUR(usd.Value * exchangeRate);
//    }

//    // Явное преобразование из USD в RUB
//    public static explicit operator CurrencyRUB(CurrencyUSD usd)
//    {
//        Console.Write("Введите текущий курс USD к RUB: ");
//        double exchangeRate = double.Parse(Console.ReadLine());
//        return new CurrencyRUB(usd.Value * exchangeRate);
//    }
//}

//public class CurrencyEUR : Currency
//{
//    public CurrencyEUR(double value) : base(value) { }

//    // Явное преобразование из EUR в USD
//    public static explicit operator CurrencyUSD(CurrencyEUR eur)
//    {
//        Console.Write("Введите текущий курс EUR к USD: ");
//        double exchangeRate = double.Parse(Console.ReadLine());
//        return new CurrencyUSD(eur.Value * exchangeRate);
//    }

//    // Явное преобразование из EUR в RUB
//    public static explicit operator CurrencyRUB(CurrencyEUR eur)
//    {
//        Console.Write("Введите текущий курс EUR к RUB: ");
//        double exchangeRate = double.Parse(Console.ReadLine());
//        return new CurrencyRUB(eur.Value * exchangeRate);
//    }
//}

//public class CurrencyRUB : Currency
//{
//    public CurrencyRUB(double value) : base(value) { }

//    // Явное преобразование из RUB в USD
//    public static explicit operator CurrencyUSD(CurrencyRUB rub)
//    {
//        Console.Write("Введите текущий курс RUB к USD: ");
//        double exchangeRate = double.Parse(Console.ReadLine());
//        return new CurrencyUSD(rub.Value * exchangeRate);
//    }

//    // Явное преобразование из RUB в EUR
//    public static explicit operator CurrencyEUR(CurrencyRUB rub)
//    {
//        Console.Write("Введите текущий курс RUB к EUR: ");
//        double exchangeRate = double.Parse(Console.ReadLine());
//        return new CurrencyEUR(rub.Value * exchangeRate);
//    }
//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        // Пример использования
//        Console.Write("Введите сумму в USD: ");
//        double amountUSD = double.Parse(Console.ReadLine());
//        CurrencyUSD usd = new CurrencyUSD(amountUSD);

//        CurrencyEUR eur = (CurrencyEUR)usd; // Преобразование из USD в EUR
//        Console.WriteLine($"{amountUSD} USD => {eur.Value} EUR");

//        CurrencyRUB rub = (CurrencyRUB)usd; // Преобразование из USD в RUB
//        Console.WriteLine($"{amountUSD} USD => {rub.Value} RUB");

//        // Преобразование обратно из EUR в USD
//        CurrencyUSD convertedBackUSD = (CurrencyUSD)eur;
//        Console.WriteLine($"{eur.Value} EUR => {convertedBackUSD.Value} USD");
//    }
//}
