using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAsyncThread.Common
{
  public class RandomHelper
  { 
    public int GetNumber(int min,int max) {
      Thread.Sleep(this.GetRandomNumber(100,200));
      return this.GetRandomNumber(min,max);
    }

    private int GetRandomNumber(int min, int max)
    {
      Guid guid = Guid.NewGuid();
      string sGuid = guid.ToString();
      int seed = DateTime.Now.Millisecond;
      for (int i = 0; i < sGuid.Length; i++)
      {
        switch (sGuid[i])
        {
          case 'a':
            seed += 1;
            break;
          case 'b':
            seed += 2;
            break;
          case 'c':
            seed += 3;
            break;
          case 'd':
            seed += 4;
            break;
          case 'e':
            seed += 5;
            break;
          case 'f':
            seed += 11;
            break;
          case 'g':
            seed += 12;
            break;
          case 'h':
            seed += 31;
            break;
          case 'i':
            seed += 55;
            break;
          case 'j':
            seed += 42;
            break;
          case 'k':
            seed += 87;
            break;
          case 'l':
            seed += 18;
            break;
          case 'm':
            seed += 1;
            break;
          case 'n':
            seed += 111;
            break;
          case 'o':
            seed += 11000;
            break;
          case 'p':
            seed += 113123;
            break;
          case 'q':
            seed += 125435;
            break;
          case 'r':
            seed += 1654;
            break;
          case 's':
            seed += 14121;
            break;
          case 't':
            seed += 45764;
            break;
          case 'u':
            seed += 1022;
            break;
          case 'v':
            seed += 1416;
            break;
          case 'w':
            seed += 187245;
            break;
          case 'x':
            seed += 18256;
            break;
          case 'y':
            seed += 116236;
            break;
          case 'z':
          default:
            seed += 1174566236;
            break;
        }
      }

      Random random = new Random(seed);
      return random.Next(min,max);
    }
  }
}
