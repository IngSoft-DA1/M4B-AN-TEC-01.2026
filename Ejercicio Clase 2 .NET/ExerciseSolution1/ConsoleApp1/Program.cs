using ExerciseClasses;

Console.WriteLine("Escriba su nombre: ");
string name = Console.ReadLine() ;

Console.WriteLine("Escriba su fecha de nacimiento en el formato dd/mm/yyyy: ");
DateTime birthdayDate = DateTime.Parse(Console.ReadLine()) ;

Person myPerson = new Person(name, birthdayDate);

Console.WriteLine("Su nombre es: " + myPerson.Name );
Console.WriteLine("Su fecha de nacimiento es: " + myPerson.BirthdayDate);
Console.WriteLine("Su edad es: " + myPerson.CalculatedAge());
Console.WriteLine("Su dia de nacimiento es: " + myPerson.DayOfWeekBirthday() );