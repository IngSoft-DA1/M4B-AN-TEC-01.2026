namespace ExerciseClasses;

public class Person
{
    public string Name { get; set; }
    public DateTime BirthdayDate { get; set; }

    public Person(string name, DateTime birthdayDate)
    {
        Name = name;
        BirthdayDate = birthdayDate;
    }

    public int CalculatedAge()
    {
        int age = DateTime.Now.Year - BirthdayDate.Year;
        
        if (BirthdayDate.AddYears(age) > DateTime.Now)
        {
            age--;
        }
        return age;
    }
    
    public string DayOfWeekBirthday()
    {
        return BirthdayDate.DayOfWeek.ToString();
    }

}