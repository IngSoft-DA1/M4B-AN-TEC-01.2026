// See https://aka.ms/new-console-template for more information

using ExerciseClasses;

Console.WriteLine("Hello, World!");

String name = Console.ReadLine();
DateTime birthdayDate = DateTime.Parse(Console.ReadLine());

Person myPersona = new Person(name, birthdayDate);