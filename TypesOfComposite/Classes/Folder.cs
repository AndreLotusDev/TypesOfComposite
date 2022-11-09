using System.Text;
using TypesOfComposite.Interfaces;

namespace TypesOfComposite.Classes
{
    public class Folder : ObjectBase
    {
        private const string TAB = "\t";
        public string NameFolder { get; set; } = string.Empty;
        public Folder(int level, string nameFolder)
        {
            Level = level;
            NameFolder = nameFolder;
        }
        public Folder(string nameFolder)
        {
            NameFolder = nameFolder;
        }
        public Folder()
        {

        }
        public override void Add(ObjectBase objectToAdd)
        {
            objectToAdd.Level = Level + 1;
            Objects.Add(objectToAdd);
        }

        public override void GetHierarchy()
        {
            var actualLevel = Level;

            Console.ForegroundColor = ConsoleColor.Red;

            GenerateFolderTitle(actualLevel);

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            GenerateArchiveLeveledInfo(actualLevel);

            Console.ForegroundColor = ConsoleColor.White;

            foreach (var folder in Objects.Where(w => w is Folder))
            {
                GenerateFolderInsideFolderInfo(actualLevel, folder);

                folder.GetHierarchy();
            }
        }

        private static void GenerateFolderInsideFolderInfo(int actualLevel, ObjectBase folder)
        {
            StringBuilder newLevelStringBuilder = new();
            var folderCast = folder as Folder;
            for (int i = 0; i <= actualLevel; i++)
            {
                newLevelStringBuilder.Append(TAB);
            }
            newLevelStringBuilder.Append($"Folder -> {folderCast?.NameFolder}");
            newLevelStringBuilder.AppendLine();
            Console.WriteLine(newLevelStringBuilder.ToString());
        }

        private void GenerateArchiveLeveledInfo(int actualLevel)
        {
            StringBuilder archiveStringBuilder = new();
            foreach (var archive in Objects.Where(w => w is Archive))
            {
                for (int i = 0; i <= actualLevel; i++)
                {
                    archiveStringBuilder.Append(TAB);
                }

                archiveStringBuilder.Append(archive.ToString());
                archiveStringBuilder.AppendLine();
            }

            Console.WriteLine(archiveStringBuilder.ToString());
        }

        private void GenerateFolderTitle(int actualLevel)
        {
            if (Level > 1)
                return;

            StringBuilder folderStringBuilder = new();
            for (int i = 0; i <= actualLevel; i++)
            {
                folderStringBuilder.Append(TAB);
            }
            folderStringBuilder.Append(this.ToString());
            folderStringBuilder.AppendLine();

            Console.WriteLine(folderStringBuilder.ToString());
        }

        public override string ToString()
        {
            return $"Folder: {NameFolder}";
        }
    }
}
