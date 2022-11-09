namespace TypesOfComposite.Interfaces
{
    public abstract class ObjectBase
    {
        public int Level { get; set; }
        public List<ObjectBase> Objects { get; } = new();
        public abstract void Add(ObjectBase objectToAdd);
        public abstract void GetHierarchy();
    }
}
