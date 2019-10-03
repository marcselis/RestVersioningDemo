namespace VersioningDemo.Domain
{
    public class Concern
    {
        internal Concern()
        {
        }

        internal Concern(string number, string name)
        {
            Number = number;
            Name = name;
        }

        public string Number { get; private set; }
        public string Name { get; private set; }
    }
}
