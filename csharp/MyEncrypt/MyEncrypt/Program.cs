using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MyEncrypt
{
  /// <summary>
  /// 1 MD5 不可逆加密
  /// 2 DES 对称可逆加密
  /// 3 RSA 非对称可逆加密
  /// 4 hash散列算法产生散列值，MD5是其中一种hash算法
  /// 5 签名：用私钥加密散列值得到签名。签名目的不是加密，而是证明签名来自发送者（用A的公钥打开的签名一定来自A）
  /// 6 CA（Certificate Authority）证书颁发机构，审核服务方，生成CA证书，颁发给服务方
  /// 7 http + ssl = https
  /// 
  /// 
  /// 浏览器与服务器使用SSL认证过程（单边认证），以百度为例。
  /// 1 操作系统中内置了公认的可信的CA的公钥，浏览器会从操作系统中获取CA公钥，部分浏览器内部自带CA公钥。
  /// 2 百度提供
  ///   a 持有者姓名
  ///   b 发证机关
  ///   c 有效日期
  ///   d 自己的公钥
  ///   e 扩展信息
  ///  给CA，申请证书。
  /// 3 CA对abcde信息进行MD5运算产生散列值，并用自己的私钥加密散列值形成签名，加上abcde项明文信息生成证书颁发给百度。
  /// 4 百度服务器上安装CA证书。
  /// 5 浏览器访问服务器时，服务器将自己的CA证书传送给浏览器，浏览器查看b项信息，能找到b发证机关的公钥，说明CA可信，并用CA的公钥解密签名，如果能解开，
  ///   证明签名确实来自CA，解密后得到一个散列值。
  /// 6 浏览器对abcde项信息进行MD5运算得到散列值，和签名中的散列值比对，如果一致，证明abcde项没有被篡改，确认服务器确实是百度服务器。
  /// 7 浏览器发送自己支持的对称加密算法给服务器，服务器选出最安全的算法发给浏览器。
  /// 8 浏览器使用约定的算法并产生随机密码做为对称加密算法的私钥，用服务器公钥加密后发送给服务器，服务器收到后用自己的私钥解密得到对称加密算法的私钥。之后双方这个私钥加密通信。
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        #region MD5
        // 1 防止看到明文
        // 2 防篡改
        // 3 防止抵赖

        Console.WriteLine();
        #endregion
      }
      catch (Exception)
      {

        throw;
      }

      Console.ReadKey();
    }
  }
}
