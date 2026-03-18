namespace ExerciseClasses;

public class Person
{
    public String Name { get; set; }
    public DateTime BirthdayDate { get; set; }

    public Person(String name, DateTime birthdayDate)
    {
        Name = name;
        BirthdayDate = birthdayDate;
    }

    public int CalculatedAge()
    {
        int age = DateTime.Now.Year - BirthdayDate.Year;
        
        if (BirthdayDate.Date > DateTime.Now.Date)
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