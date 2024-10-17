using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PersonCollection person_collection = new();
        Person per1 = new("ady elnatroon", 3);
        Person per2 = new("wady el gadeed", 3);
        person_collection.Add(per1);
        person_collection.Add(per2);
        foreach (var person in person_collection)
        {
            Console.WriteLine(person.name);
        }
    }
}

public class Person
{
    public string name { get; }
    public int age { get; }
    public Person(string new_name, int new_age)
    {
        name = new_name;
        age = new_age;
    }




}

public class PersonCollection : IEnumerable<Person>
{
    private List<Person> persons = new();

    public void Add(Person person)
    {
        persons.Add(person);
    }

    public IEnumerator<Person> GetEnumerator()
    {
        return new PersonEnumerator(persons);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class PersonEnumerator : IEnumerator<Person>
{
    private List<Person> persons;
    private int position = -1;

    public PersonEnumerator(List<Person> persons)
    {
        this.persons = persons;
    }

    public object Current => persons[position];

    // idk what is this, got generated automatically by vscode
    Person IEnumerator<Person>.Current => persons[position];

    public void Dispose()
    {

    }

    public bool MoveNext()
    {
        // rust habit
        position += 1;
        return position < persons.Count;
    }

    public void Reset()
    {
        position = -1;
    }
}