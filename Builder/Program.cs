using System;
using System.Collections.Generic;

public class Dog
{
    private string _name;
    private string _breed;
    private int _age;
    private List<string> _toys;

    // Конструктор приватный, чтобы предотвратить создание объектов Dog напрямую
    private Dog(string name, string breed, int age, List<string> toys)
    {
        _name = name;
        _breed = breed;
        _age = age;
        _toys = toys;
    }

    // Методы-аксессоры (геттеры)
    public string GetName() => _name;
    public string GetBreed() => _breed;
    public int GetAge() => _age;
    public List<string> GetToys() => new List<string>(_toys); // Возвращаем копию списка

    // Методы-мутаторы (сеттеры)
    public void SetName(string name) => _name = name;
    public void SetBreed(string breed) => _breed = breed;
    public void SetAge(int age) => _age = age;
    public void SetToys(List<string> toys) => _toys = new List<string>(toys); // Сохраняем копию списка

    // Класс-строитель
    public class Builder
    {
        private string _name;
        private string _breed;
        private int _age;
        private List<string> _toys = new List<string>();

        // Методы для установки значений, возвращающие текущий объект строителя для цепочки вызовов
        public Builder SetName(string name)
        {
            _name = name;
            return this;
        }

        public Builder SetBreed(string breed)
        {
            _breed = breed;
            return this;
        }

        public Builder SetAge(int age)
        {
            _age = age;
            return this;
        }

        public Builder SetToys(List<string> toys)
        {
            _toys = new List<string>(toys);
            return this;
        }

        // Метод для создания объекта Dog
        public Dog Build()
        {
            return new Dog(_name, _breed, _age, _toys);
        }
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        Dog dog = new Dog.Builder()
                        .SetName("Buddy")
                        .SetBreed("Golden Retriever")
                        .SetAge(3)
                        .SetToys(new List<string> { "Ball", "Bone" })
                        .Build();

        Console.WriteLine($"Name: {dog.GetName()}");
        Console.WriteLine($"Breed: {dog.GetBreed()}");
        Console.WriteLine($"Age: {dog.GetAge()}");
        Console.WriteLine($"Toys: {string.Join(", ", dog.GetToys())}");
    }
}
