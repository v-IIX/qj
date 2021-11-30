using MyAsyncThread.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsyncThread
{
  public partial class FormSSQ : Form
  {
    public FormSSQ()
    {
      InitializeComponent();
      this.btnStart.Enabled = true;
      this.btnStop.Enabled = false;
    }

    private void FormSSQ_Load(object sender, EventArgs e)
    {

    }

    #region 字段

    private static readonly object btnStart_Click_Lock = new object();
    private bool IsGoOn = true;
    private List<Task> tasks = new List<Task>();

    #endregion

    private void btnStart_Click(object sender, EventArgs e)
    {
      try
      {
        this.IsGoOn = true; //停止一次之后，才能再次开始。
        this.tasks = new List<Task>(); //清空之前的结果
        this.btnStart.Text = "运行中。。。";
        this.btnStart.Enabled = false;
        this.red1.Text = "00";
        this.red2.Text = "00";
        this.red3.Text = "00";
        this.red4.Text = "00";
        this.red5.Text = "00";
        this.red6.Text = "00";
        this.blue.Text = "0";
        Thread.Sleep(1000);

        TaskFactory taskFactory = new TaskFactory();

        foreach (var control in this.gbo.Controls)
        {
          if (control is Label)
          {
            Label lbl = (Label)control;
            if (lbl.Name.Contains("blue"))
            {
              tasks.Add(taskFactory.StartNew(() =>
              {
                while (this.IsGoOn)
                {
                  RandomHelper randomHelper = new RandomHelper();
                  int numberIndex = randomHelper.GetNumber(0, this.BlueNumbers.Length);
                  this.UpdateLabel(lbl, this.BlueNumbers[numberIndex]);
                }
              }));
            }
            else
            {
              tasks.Add(taskFactory.StartNew(() =>
              {
                while (this.IsGoOn)
                {
                  RandomHelper randomHelper = new RandomHelper();
                  int numberIndex = randomHelper.GetNumber(0, this.RedNumbers.Length);
                  lock (btnStart_Click_Lock)
                  {
                    if (this.IsExist(this.RedNumbers[numberIndex]))
                    {
                      break;
                    }
                    this.UpdateLabel(lbl, this.RedNumbers[numberIndex]);
                  }
                }
              }));
            }
          }
        }

        Task.Run(() =>
        {
          while (true)
          {
            Thread.Sleep(100);
            if (!this.IsExist("00") && !this.blue.Text.Equals("00"))
            {
              this.Invoke(new Action(() =>
              {
                this.btnStop.Enabled = true;
              }));
              break;
            }
          }
        });

        taskFactory.ContinueWhenAll(this.tasks.ToArray(), (x) => { this.ShowResult(); });
      }
      catch (Exception ex)
      {
        Console.WriteLine("双色球启动出现异常：{0}", ex.Message);
      }
    }



    private void btnStop_Click(object sender, EventArgs e)
    {
      this.btnStart.Enabled = true;
      this.btnStop.Enabled = false;
      this.IsGoOn = false;
    }

    #region 初始数据
    private string[] RedNumbers =
      {
        "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
        "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
        "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
        "31", "32","33"
      };

    private string[] BlueNumbers =
      {
        "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
        "11", "12", "13", "14", "15", "16"
      };
    #endregion


    #region PrivateMethod

    private bool IsExist(string sNumber)
    {
      foreach (var item in gbo.Controls)
      {
        if (item is Label)
        {
          Label lbl = (Label)item;
          if (lbl.Name.Contains("Red") && lbl.Text.Equals(sNumber))
          {
            return true;
          }
        }
      }
      return false;
    }

    private void UpdateLabel(Label lbl, string text)
    {
      if (lbl.InvokeRequired)
      {
        this.Invoke(new Action(() =>
        {
          lbl.Text = text;
        }));
      }
      else
      {
        lbl.Text = text;
      }
    }

    private void ShowResult()
    {
      MessageBox.Show(string.Format("红球：{0} {1} {2} {3} {4} {5} 篮球：{6}",
        this.red1.Text,
        this.red2.Text,
        this.red3.Text,
        this.red4.Text,
        this.red5.Text,
        this.red6.Text,
        this.blue.Text
        ));
    }

    #endregion


    ////#region 作业
    ////作业 1
    ////超级大乐透：
    ////01-35中选5个号码为前区
    ////01-12中选2个号码为后区
    ////

    ///作业2
    ///基本版：
    ///   天龙八部开始，三条人物线
    ///     乔峰：丐帮帮主 契丹人 南院大王 挂印离开
    ///     虚竹：小和尚  逍遥掌门  灵鹫宫宫主 西夏驸马
    ///     段誉：钟灵儿  木婉清 王语嫣 大理国王
    ///
    ///   以上是三个线程，需要并发执行：
    ///     1 每个线程都需要按时间顺序完成上述4件事
    ///     2 每件事都需要写文本日志并输出到控制台，每件事需要随机等待一定时间，保证节目的缓慢输出
    ///     3 任何一个人完成第一件事后，需要执行一件事时“天龙八部就此拉开序幕。。。”，且全场仅执行一次。（严格要求任何人物的第一件事完成后必须先执行拉开序幕）
    ///     4 以上的任何一个任务完成了，需要执行一件事“某某已经做好准备。。。”，且全场仅执行一次。（非严格要求，某某需要识别出来）
    ///     5 等人物线全部完成后，执行一件事“中原群雄大战辽兵，忠义两难一死谢天”
    ///     6 等这些事全部都完成了，系统需要统计出整个天龙八部故事花了多长时间
    ///     7 在人物线之外增加一个监控线程，间隔时间new Random().Next(0,10000)，如果值刚好等于当前年份，则打印“天降雷霆灭世，天龙八部的故事到此结束。。。。”，然后其他的任务都结束掉
    ///   
    /// 进阶版：
    ///   每个人的故事内容做成可配置
    ////#endregion
  }
}
