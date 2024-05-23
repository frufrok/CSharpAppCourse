using System.Text;

namespace Task1
{
    public class FamilyMember
    {
        public DateOnly DateOfBirth { get; init; }
        public Gender Gender { get; init; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? LastName { get; set; }
        public string FullName => LastName == null? $"{SecondName} {FirstName} {LastName}" : $"{SecondName} {FirstName}";
        public int Age => YearsBetween(DateOfBirth, DateOnly.FromDateTime(DateTime.Now));
        public FamilyMember? Parent1 { get; private set; }
        public FamilyMember? Parent2 { get; private set; }
        public FamilyMember? Partner { get; private set; }
        public List<FamilyMember> Children { get; init; } = [];
        public FamilyMember(string firstName, string secondName, string? lastName,  Gender gender, DateOnly dateOfBirth)
        {
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
        public void SetParent1(FamilyMember parent)
        {
            if (Parent1 != null) Parent1.Children.Remove(this);
            Parent1 = parent;
            parent.Children.Add(this);
        }
        public void SetParent2(FamilyMember parent)
        {
            if (Parent2 != null) Parent2.Children.Remove(this);
            Parent2 = parent;
            parent.Children.Add(this);
        }
        public void SetPartner(FamilyMember partner)
        {
            if (Partner != null) Partner.Partner = null;
            partner.Partner = this;
            Partner = partner;
        }
        public override string ToString()
        {
            return $"{FullName} {DateOfBirth}";
        }
        public string GetFamily()
        {
            StringBuilder result = new();
            List<FamilyMember> parents = new List<FamilyMember>();
            if (Parent1 != null) parents.Add(Parent1);
            if (Parent2 != null) parents.Add(Parent2);
            if (parents.Count == 2)
            {
                result.AppendLine(parents[0].ToString());
                result.Append("| ");
                result.AppendLine(parents[1].ToString());
                result.AppendLine("|/");
            }
            else if (parents.Count == 1)
            {
                result.AppendLine(parents[0].ToString());
                result.AppendLine("|");
            }
            result.Append(this.ToString());
            result.AppendLine(Partner == null ? "" : $" + {Partner.ToString()}");
            List<FamilyMember> childrenSorted = Children.OrderBy(x => x.DateOfBirth).ToList();
            int count = childrenSorted.Count;
            for (int i = 0; i < childrenSorted.Count; i++)
            {
                result.AppendLine(new string('|', count - i - 1) + "\\");
                result.AppendLine(new string('|', count - i - 1) + $" {childrenSorted[i].ToString()}");
            }
            return result.ToString();
        }
        private static int YearsBetween(DateOnly date1, DateOnly date2)
        {
            if (date2 > date1)
            {
                return date2.Year - date1.Year - (date1.DayOfYear >= date2.DayOfYear ? 0 : 0);
            }
            else
            {
                return -(date1.Year - date2.Year - (date2.DayOfYear >= date1.DayOfYear ? 0 : 0));
            }
        }
    }
}