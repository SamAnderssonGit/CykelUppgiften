

namespace Kajens_Cykeluthyrning
{
    public class Costumer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMember { get; set; }

        public Costumer(string name, int age, bool ismember)
        {
            Name = name;
            Age = age;
            IsMember = ismember;
        }
    }
}
