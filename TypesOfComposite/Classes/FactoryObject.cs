using TypesOfComposite.Interfaces;

namespace TypesOfComposite.Classes
{
    public static class FactoryObject
    {
        public static ObjectBase GenerateFirstFolder(string nameFolder)
        {
            const int FIRST_LEVEL = 1;

            return new Folder(FIRST_LEVEL, nameFolder);
        }
        public static ObjectBase GenerateArchiveToFolder(this Folder folder, string name)
        {
            var archive = new Archive(name);
            folder.Add(archive);

            return archive;
        }

        public static ObjectBase GenerateFolderToFolder(this Folder folder, string name)
        {
            var folderToAdd = new Folder(name);
            folder.Add(folderToAdd);

            return folderToAdd;
        }
    }
}
