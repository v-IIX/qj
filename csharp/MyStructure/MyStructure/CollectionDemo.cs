using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyStructure
{
  internal class CollectionDemo
  {
    public static void Show()
    {
      #region Array
      //在内存上连续分配
      //读取快，按索引访问
      //增删慢

      {
        //Array:在内存上连续分配，元素类型是一致的，长度固定

        int[] intArray = new int[3];
        string[] stringArray = new string[] { "a", "b" };
      }

      {
        //ArrayList:不定长度，在内存上连续分配
        //没有类型限制，任何元素都是当成object处理，如果是值类型，会有拆装箱操作

        ArrayList arrayList = new ArrayList();
        arrayList.Add("abc");
        arrayList.Add(123);
        //arrayList[2] = 12; //索引赋值，不会增加长度
        arrayList.RemoveAt(0); //按索引删除
        arrayList.Remove("abc"); ////按值删除第一个匹配项
      }

      {
        //List：不定长度，也是Array，内存上也是连续存放
        //有类型限制
        //泛型：保证数据安全，避免拆装箱

        List<int> intList = new List<int>() { 1, 2, 3, 4 };
      }
      #endregion

      #region 链表

      {
        //LinkedList:泛型特点
        //元素不连续分配，每个元素都有记录前后节点的信息
        //不能通过下标访问，查找元素只能遍历，查找不方便
        //增删方便
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddFirst(123);
        linkedList.AddLast(456);

        bool isContain = linkedList.Contains(123);
        LinkedListNode<int> node123 = linkedList.Find(123);
        linkedList.AddBefore(node123, 0);
        linkedList.AddAfter(node123, 4);

        linkedList.Remove(456);
        linkedList.Remove(node123);
        linkedList.RemoveFirst();
        linkedList.RemoveLast();

        linkedList.Clear();

      }

      #region 队列
      {
        //Queue 就是链表的应用
        //先进先出
        //可以用于存放任何，延迟执行（A不断写入任务，B不断获取去执行）
        Queue<string> strings = new Queue<string>();
        strings.Enqueue("one");
        strings.Enqueue("two");
        strings.Enqueue("three");
        strings.Enqueue("four");

        foreach (var item in strings)
        {
          Console.WriteLine(item);
        }

        Console.WriteLine($"{strings.Dequeue()}"); //获取值,获取一个移除一个
        Console.WriteLine($"{strings.Peek()}"); //获取值,但不移除
        Console.WriteLine($"{strings.Dequeue()}");

        Queue<string> queueCopy = new Queue<string>(strings.ToArray());
        foreach (var item in queueCopy)
        {
          Console.WriteLine(item);
        }

        Console.WriteLine($"{queueCopy.Contains("one")}");
        queueCopy.Clear();

      }

      #endregion

      #region 栈
      {
        //Stack 就是栈，也是链表的应用
        //先进后出

        Stack<string> strings = new Stack<string>();
        strings.Push("one");
        strings.Push("two");
        strings.Push("three");
        strings.Push("four");

        foreach (var item in strings)
        {
          Console.WriteLine(item);
        }

        Console.WriteLine($"{strings.Pop()}");  //获取值,获取一个移除一个
        Console.WriteLine($"{strings.Peek()}"); //获取值,但不移除
        Console.WriteLine($"{strings.Pop()}");
      }

      #endregion

      #endregion

      #region 集合（Set）

      {
        //前后元素呈hash分布
        //动态增加元素容量，会自动去重（统计用户、IP投票）
        HashSet<string> hashSet = new HashSet<string>();
        hashSet.Add("1");
        hashSet.Add("2");
        hashSet.Add("3");
        hashSet.Add("4");
        hashSet.Add("5");
        hashSet.Add("5");

        foreach (var item in hashSet)
        {
          Console.WriteLine(item);
        }

        Console.WriteLine(hashSet.Count);
        Console.WriteLine(hashSet.Contains("123"));


        HashSet<string> hashSet2 = new HashSet<string>();
        hashSet2.Add("1");
        hashSet2.Add("2");
        hashSet2.Add("5");
        hashSet2.Add("6");
        hashSet2.Add("7");

        hashSet2.SymmetricExceptWith(hashSet);  //补
        //hashSet2.UnionWith(hashSet);  //并
        //hashSet2.ExceptWith(hashSet); //差
        //hashSet2.IntersectWith(hashSet);  //交

        hashSet.Clear();
      }

      {
        //去重且排序集合
        //也可以交差并补
        SortedSet<string> sortedSet = new SortedSet<string>();
        sortedSet.Add("1");
        sortedSet.Add("6");
        sortedSet.Add("4");
        sortedSet.Add("3");
        sortedSet.Add("9");

        foreach (var item in sortedSet)
        {
          Console.WriteLine(item);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(sortedSet.Contains("1"));
      }

      #endregion

      #region Key-Value

      #region HashTable

      //HashTable key-value 容量可以动态添加
      //用key进行hash计算等到一个地址，然后放入key-value。如果两个不同key计算后的地址相同，第二个key的地址会在第一个key的地址基础上加1。需要单独的数据结构来维护地址，因此浪费空间
      //value为object类型
      //增删查改都快

      {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("123", "456"); //key-value形式添加数据··
        hashtable[12] = 123;  //方括号中的内容是key
        hashtable[121] = 123;
        hashtable[2] = 123;
        hashtable["abc"] = 123;

        foreach (DictionaryEntry item in hashtable)
        {
          Console.WriteLine(item.Key.ToString());
          Console.WriteLine(item.Value.ToString());
        }
      }

      #endregion

      #region 字典
      //泛型、增删查改快、有序
      {
        Dictionary<int, string> dic = new Dictionary<int, string>();
        dic.Add(1, "1");
        dic.Add(5, "5");
        dic.Add(3, "3");
        dic.Add(2, "2");
        dic[9] = "9";
        foreach (var item in dic)
        {
          Console.WriteLine($"key:{item.Key},value:{item.Value}");
        }

      }

      {
        //SortedDictionary，排序字典
      }

      #endregion

      #endregion

      #region 线程安全版本

      //ConcurrentQueue 线程安全版本Queue
      //ConcurrentStack 线程安全版本Stack
      //ConcurrentDictionary  线程安全版本Dictionary
      //ConcurrentBag 线程安全版本对象集合

      {
        List<string> fruit = new List<string>() { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "stawberry" };
        IEnumerable<string> query = fruit.Where(x => x.Length < 6);

        foreach (var item in query) //IEnumerable:延迟加载，只有遍历时才会获取数据，使用迭代器yield
        {
          Console.WriteLine(item);
        }

        IQueryable<string> queryable = fruit.AsQueryable<string>().Where(x => x.Length < 6);

        foreach (var item in queryable) ////IQueryable:表达式目录树解析，延迟到遍历的时候才去执行
        {
          Console.WriteLine(item);
        }

      }


      #endregion

    }
  }
}