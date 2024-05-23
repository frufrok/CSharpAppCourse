using Task1;

namespace Task0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FamilyMember mom = new FamilyMember("Мария", "Иванова", "Ивановна", Gender.Female, DateOnly.Parse("01.02.1975"));
            FamilyMember dad = new FamilyMember("Петр", "Иванов", "Петрович", Gender.Male, DateOnly.Parse("03.04.1967"));
            FamilyMember she = new FamilyMember("Екатерина", "Сидорова", "Петровна", Gender.Female, DateOnly.Parse("13.05.1998"));
            FamilyMember husband = new FamilyMember("Евгений", "Сидоров", "Валерьевич", Gender.Male, DateOnly.Parse("30.03.1992"));
            FamilyMember daughter = new FamilyMember("Мария", "Сидорова", "Евгеньевна", Gender.Female, DateOnly.Parse("15.10.2022"));
            FamilyMember son = new FamilyMember("Адам", "Сидоров", "Евгеньевич", Gender.Male, DateOnly.Parse("10.01.2024"));
            FamilyMember foster = new FamilyMember("Павел", "Сидоров", "Станиславович", Gender.Male, DateOnly.Parse("15.12.2018"));

            mom.SetPartner(dad);

            she.SetParent1(mom);
            she.SetParent2(dad);
            she.SetPartner(husband);
            daughter.SetParent1(she);
            son.SetParent1(she);
            foster.SetParent1(she);

            Console.WriteLine("Дерево человека:");
            Console.WriteLine(she.GetFamily());
            Console.WriteLine("Дерево её матери:");
            Console.WriteLine(mom.GetFamily());
            Console.WriteLine("Дерево её дочери:");
            Console.WriteLine(daughter.GetFamily());
        }
    }
}