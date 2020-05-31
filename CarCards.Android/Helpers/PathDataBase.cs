using CarCards.Droid.Helpers;
using CarCards.Helpers;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathDataBase))]
namespace CarCards.Droid.Helpers
{
    public class PathDataBase : IPathDataBase
    {
       public string FilePath(string fileName)
        {
            string pathDataBase = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(pathDataBase, fileName);
        }
    }
}