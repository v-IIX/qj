using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerializer.IO
{
  public class Recurision
  {
    public static List<DirectoryInfo> GetAllDirectory(string rootPath)
    {
      if (!Directory.Exists(rootPath))
      {
        return new List<DirectoryInfo>();
      }

      List<DirectoryInfo> directoryList = new List<DirectoryInfo>();
      DirectoryInfo directory = new DirectoryInfo(rootPath);
      GetChildDirectory(directoryList, directory);
      return directoryList;
    }

    private static void GetChildDirectory(List<DirectoryInfo> directoryList, DirectoryInfo directoryParent)
    {
      DirectoryInfo[] directoryListChild = directoryParent.GetDirectories();
      if (directoryListChild.Length != 0)
      {
        directoryList.AddRange(directoryListChild);

        foreach (var item in directoryListChild)
        {
          GetChildDirectory(directoryList, item);
        }
      }
      else
      {
        return;
      }
    }
  }
}
