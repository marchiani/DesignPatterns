﻿// Паттерн Одиночка
//
// Назначение: Гарантирует, что у класса есть только один экземпляр, и
// предоставляет к нему глобальную точку доступа.

using System;

namespace Singleton
{
    // Класс Одиночка предоставляет метод `GetInstance`, который ведёт себя как
    // альтернативный конструктор и позволяет клиентам получать один и тот же
    // экземпляр класса при каждом вызове.
    internal class Singleton
    {
        // Объект одиночки храниться в статичном поле класса. Существует
        // несколько способов инициализировать это поле, и все они имеют разные
        // достоинства и недостатки. В этом примере мы рассмотрим простейший из
        // них, недостатком которого является полная неспособность правильно
        // работать в многопоточной среде.
        private static Singleton _instance;

        // Конструктор Одиночки всегда должен быть скрытым, чтобы предотвратить
        // создание объекта через оператор new.
        private Singleton()
        {
        }

        // Это статический метод, управляющий доступом к экземпляру одиночки.
        // При первом запуске, он создаёт экземпляр одиночки и помещает его в
        // статическое поле. При последующих запусках, он возвращает клиенту
        // объект, хранящийся в статическом поле.
        public static Singleton GetInstance()
        {
            if (_instance == null) _instance = new Singleton();
            return _instance;
        }

        // Наконец, любой одиночка должен содержать некоторую бизнес-логику,
        // которая может быть выполнена на его экземпляре.
        public static void someBusinessLogic()
        {
            // ...
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Клиентский код.
            var s1 = Singleton.GetInstance();
            var s2 = Singleton.GetInstance();

            if (s1 == s2)
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            else
                Console.WriteLine("Singleton failed, variables contain different instances.");
        }
    }
}