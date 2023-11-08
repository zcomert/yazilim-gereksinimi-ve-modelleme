namespace ErrorHandleApp.Models;

public abstract class Employee : IComparable
{
    public int Id { get; set; }
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public Double Salary { get; set; }

    protected Employee(int ıd,
    string? firstName,
    string? lastName,
    double salary)
    {
        Id = ıd;
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
    }

    public virtual int CompareTo(object? obj)
    {
        return this.Salary.CompareTo(((Employee)obj).Salary);
    }
}

