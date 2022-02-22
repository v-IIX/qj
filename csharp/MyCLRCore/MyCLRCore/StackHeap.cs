using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
  /// <summary>
  /// 值类型：struct、枚举
  /// 引用类型：class、接口、委托
  /// 
  /// 线程栈：栈（stack）先进后出的数据结构
  /// 
  /// </summary>
  class StackHeap
  {
    internal static void Show()
    {
      {
        //栈
        //变量和值都在栈上
        ValuePoint valuePoint; //声明变量，没有初始化，但是可以正常赋值，和类不同
        valuePoint.x = 123;

        ValuePoint point = new ValuePoint();
        Console.WriteLine($"{valuePoint.x}");
      }

      {
        //堆
        //变量在栈上，值在堆上 
        ReferencePoint referencePoint = new ReferencePoint(123);
        Console.WriteLine(referencePoint.x);
      }

      {
        ReferenceTypeClass referenceTypeClass = new ReferenceTypeClass();
        referenceTypeClass.Method();
      }

      {
        //装拆箱
        int i = 3;
        object oI = i;
        i = (int)oI;
      }

      {
        //字符串内存分配
        //字符串的值是不可改变的，因为多个变量可能指向同一个字符串（享元）
        //还因为堆里面的内存是连续分配的，如果长度可变，会导致大量数据移动
        string str1 = "haha";
        string str2 = str1; //str2的值为haha
        str2 = "hehe";  //str1的值为haha，赋值相当于添加新的引用
      }

      {
        //享元模式
        //CLR分配内存时，会查找相同值，有重复值就会重用
        string str1 = "haha";
        string str2 = "haha";
        Console.WriteLine(object.ReferenceEquals(str1, str2)); //True
      }
    }
  }

  internal class ReferenceTypeClass
  {
    private int _value; //出现在堆里（对象在堆里，对象里面的属性、字段也在堆里）
    public ReferenceTypeClass()
    {
      _value = 0;
    }

    public void Method()
    {
      int localValue = 0; //出现在栈里
    }
  }

  internal class ReferencePoint
  {
    public int x;

    public ReferencePoint(int v)
    {
      this.x = v;
    }
  }

  internal struct ValuePoint
  {
    public int x;
    public ValuePoint(int x)
    {
      this.x = x;
    }
  }
}
