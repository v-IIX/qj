using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace IOSerializer
{
  /// <summary>
  /// 1 .net framework中进行的所有输入和输出都要用到流。
  /// 2 File类和FileInfo类很相似，只不过File类是静态类，不用先实例化。
  /// 3 创建FileStream实例的方法：
  ///   1 使用FileStream自身的构造函数，FileStream fs = new FileStream(filename,FileMode[, FileAccess]);
  ///   2 使用File类和FileInfo类的相关方法（如Open、OpenRead）创建;
  /// 4 FileStream类操作的是字节，更底层,简单的文件读写没有必要使用。推荐使用更快捷的StreamWrite和StreamRead,这两个类可以通过FileStream对象来创建。
  /// 5 StreamWrite对象的创建（StreamRead创建方法类似）：
  ///   1 使用自身构造函数，StreamWrite sw = new StreamWrite(filename,true);
  ///   2 结合FileStream对象创建：
  ///     FileStream fs = new FileStream(filename,FileMode[, FileAccess]);
  ///     StreamWrite sw = new StreamWrite(fs); 
  /// 6 压缩解压缩文件：DeflateStream类和GZipStream类。创建方法：使用已有的流初始化它们，对于文件，流就是FileStream，创建好后就可以用于StreamWrite和StreamRead了。
  ///   FileStream fs = new FileStream(filename,FileMode[, FileAccess]);
  ///   GzipStream gs = new GzipStream(fs,CompressionMode.Compress);
  ///   StreamWrite sw = new StreamWrite(gs);
  /// </summary>
  public class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //MyIO.Show();
        //Console.WriteLine(Recurision.GetAllDirectory(@"C:\Users\entme\source").Count());
        User user = new User()
        {
          Name = "马老师",
          Account = "user",
          Password = "e123",
          Email = "abcd@sina.com",
          Mobile = "134088",
          CompanyId = 1,
          CompanyName = "阿里巴巴",
          Status = 2,
          UserType = 2,
          LastLoginTime = DateTime.Now,
          CreateTime = DateTime.Now,
          CreateId = 1,
          LastModifierId = 1,
          LastModifyTime = DateTime.Now,
        };

        List<User> users = new List<User>() {
        new User()
        {
          Name = "马老师",
          Account = "user",
          Password = "e123",
          Email = "abcd@sina.com",
          Mobile = "134088",
          CompanyId = 1,
          CompanyName = "阿里巴巴",
          Status = 2,
          UserType = 2,
          LastLoginTime = DateTime.Now,
          CreateTime = DateTime.Now,
          CreateId = 1,
          LastModifierId = 1,
          LastModifyTime = DateTime.Now,
        },
        new User()
        {
          Name = "马老师",
          Account = "user",
          Password = "e123",
          Email = "abcd@sina.com",
          Mobile = "134088",
          CompanyId = 1,
          CompanyName = "阿里巴巴",
          Status = 2,
          UserType = 2,
          LastLoginTime = DateTime.Now,
          CreateTime = DateTime.Now,
          CreateId = 1,
          LastModifierId = 1,
          LastModifyTime = DateTime.Now,
        }
      };

        {
          string file = Path.Combine(Canstant.LogPath, "xml_serializ.xml");
          using (Stream stream = new FileStream(file, FileMode.Append, FileAccess.Write))
          {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            xmlSerializer.Serialize(stream, users);
          }
        }

        {
          string jsonString = JsonConvert.SerializeObject(users);

          string file = Path.Combine(Canstant.LogPath, "json_serializ.json");
          FileStream fileStream = new FileStream(file,FileMode.Append);
          StreamWriter streamWriter = new StreamWriter(fileStream);
          streamWriter.Write(jsonString);
          streamWriter.Flush();
          streamWriter.Close();
        }

        {
          string jsonString = JsonConvert.SerializeObject(users);

          string file = Path.Combine(Canstant.LogPath, "gzip.txt");
          FileStream fileStream = new FileStream(file,FileMode.Append);
          GZipStream gZipStream = new GZipStream(fileStream,CompressionLevel.Optimal);
          StreamWriter streamWriter = new StreamWriter(gZipStream);
          streamWriter.Write(jsonString);
          streamWriter.Flush();
          streamWriter.Close();
        }

      }
      catch (Exception)
      {

        throw;
      }
      Console.ReadKey();
    }
  }
}
