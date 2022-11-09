using TypesOfComposite.Classes;

var firstFolder = FactoryObject.GenerateFirstFolder("DOCUMENTS") as Folder;

if(firstFolder is null)
{
    return;
}

firstFolder.GenerateArchiveToFolder("archive_one.pdf");
firstFolder.GenerateArchiveToFolder("archive_two.pdf");
firstFolder.GenerateArchiveToFolder("archive_three.pdf");

var secondLevelFolderOne = firstFolder.GenerateFolderToFolder("DOCUMENTS_OLD") as Folder;
var secondLevelFolderTwo = firstFolder.GenerateFolderToFolder("DOCUMENTS_OLD_TWO") as Folder;

if(secondLevelFolderOne is null)
{
    return;
}

secondLevelFolderOne.GenerateArchiveToFolder("archive_one_old_one.pdf");
secondLevelFolderOne.GenerateArchiveToFolder("archive_two_old_one.pdf");
secondLevelFolderOne.GenerateArchiveToFolder("archive_three_old_one.pdf");

if(secondLevelFolderTwo is null)
{
    return;
}

secondLevelFolderTwo.GenerateArchiveToFolder("archive_one_old_two.pdf");
secondLevelFolderTwo.GenerateArchiveToFolder("archive_two_old_two.pdf");
secondLevelFolderTwo.GenerateArchiveToFolder("archive_three_old_two.pdf");

firstFolder.GetHierarchy();
