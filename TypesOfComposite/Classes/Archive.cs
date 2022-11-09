using TypesOfComposite.Interfaces;

namespace TypesOfComposite.Classes
{
    public class Archive : ObjectBase
    {
        public string Name { get; set; } = string.Empty;
        public Archive(string name)
        {
            Name = name;
        }
        public Archive()
        {

        }

        public override void Add(ObjectBase objectToAdd)
        {
            throw new NotImplementedException("You shouldn't add a object inside an archive");
        }

        public override void GetHierarchy()
        {
            throw new NotImplementedException("There is not any hierarchy inside an archive");
        }

        public override string ToString()
        {
            return $"Name of the archive: {Name}";
        }
    }
}
