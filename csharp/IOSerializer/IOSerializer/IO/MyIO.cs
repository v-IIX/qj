using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOSerializer.IO
{
  public class MyIO
  {
    private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;

    public static void Show()
    {
      {//check 

        if (!Directory.Exists(Canstant.LogPath))
        {

        }
        DirectoryInfo directory = new DirectoryInfo(Canstant.LogPath); //路径不存在不会报错，小心使用
        Console.WriteLine("{0} {1} {2}", directory.FullName, directory.CreationTime, directory.Name);

        if (!File.Exists(Path.Combine(Canstant.LogPath, "info.txt")))
        { }
        FileInfo fileInfo = new FileInfo(Path.Combine(Canstant.LogPath, "info.txt"));
        Console.WriteLine("{0} {1} {2}", fileInfo.FullName, fileInfo.CreationTime, fileInfo.Name);
      }

      {
        if (!Directory.Exists(Canstant.LogPath))
        {
          DirectoryInfo directoryInfo = Directory.CreateDirectory(Canstant.LogPath);
          Directory.Move(Canstant.LogPath, Canstant.LogMovePath);
          Directory.Delete(Canstant.LogMovePath);
        }
      }

      {
        string fileName = Path.Combine(Canstant.LogPath, "log.txt");
        string fileNameCopy = Path.Combine(Canstant.LogPath, "logCopy.txt");
        string fileNameMove = Path.Combine(Canstant.LogPath, "logMove.txt");
        bool isExists = File.Exists(fileName);

        if (!isExists)
        {
          Directory.CreateDirectory(Canstant.LogPath); ;
          using (FileStream stream = File.Create(fileName))
          {
            string name = "test";
            byte[] bytes = Encoding.Default.GetBytes(name);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
          }

          using (FileStream stream = File.Create(fileName))
          {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("test content");
            sw.Flush();
          }

          using (StreamWriter sw = File.AppendText(fileName))
          {
            string msg = "test message";
            sw.WriteLine(msg);
            sw.Flush();
          }

          using (StreamWriter sw = File.AppendText(fileName))
          {
            string name = "some text";
            byte[] bytes = Encoding.Default.GetBytes(name);
            sw.BaseStream.Write(bytes, 0, bytes.Length);
            sw.Flush();
          }

          using (FileStream stream = File.OpenRead(fileName))
          {
            int length = 5;
            int result = 0;
            do
            {
              byte[] bytes = new byte[length];
              result = stream.Read(bytes, 0, 5);
              for (int i = 0; i < result; i++)
              {
                Console.WriteLine(bytes[i].ToString());
              }
            } while (length == result);
          }

          File.Create(fileName);
          File.Copy(fileName,fileNameCopy);
          File.Copy(fileName,fileNameMove);
        }
      }
    }
  }
}
