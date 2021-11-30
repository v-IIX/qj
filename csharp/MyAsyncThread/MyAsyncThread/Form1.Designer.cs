
namespace MyAsyncThread
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnAnyncAdvanced = new System.Windows.Forms.Button();
      this.btnThreads = new System.Windows.Forms.Button();
      this.btnThreadPool = new System.Windows.Forms.Button();
      this.btnTask = new System.Windows.Forms.Button();
      this.btnParallel = new System.Windows.Forms.Button();
      this.btnThreadCore = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnAnyncAdvanced
      // 
      this.btnAnyncAdvanced.Location = new System.Drawing.Point(41, 38);
      this.btnAnyncAdvanced.Name = "btnAnyncAdvanced";
      this.btnAnyncAdvanced.Size = new System.Drawing.Size(146, 64);
      this.btnAnyncAdvanced.TabIndex = 0;
      this.btnAnyncAdvanced.Text = "AnyncAdvanced";
      this.btnAnyncAdvanced.UseVisualStyleBackColor = true;
      this.btnAnyncAdvanced.Click += new System.EventHandler(this.btnAnyncAdvanced_Click);
      // 
      // btnThreads
      // 
      this.btnThreads.Location = new System.Drawing.Point(41, 166);
      this.btnThreads.Name = "btnThreads";
      this.btnThreads.Size = new System.Drawing.Size(146, 50);
      this.btnThreads.TabIndex = 1;
      this.btnThreads.Text = "Threads";
      this.btnThreads.UseVisualStyleBackColor = true;
      this.btnThreads.Click += new System.EventHandler(this.btnThreads_Click);
      // 
      // btnThreadPool
      // 
      this.btnThreadPool.Location = new System.Drawing.Point(41, 260);
      this.btnThreadPool.Name = "btnThreadPool";
      this.btnThreadPool.Size = new System.Drawing.Size(146, 50);
      this.btnThreadPool.TabIndex = 2;
      this.btnThreadPool.Text = "ThreadPool";
      this.btnThreadPool.UseVisualStyleBackColor = true;
      this.btnThreadPool.Click += new System.EventHandler(this.btnThreadPool_Click);
      // 
      // btnTask
      // 
      this.btnTask.Location = new System.Drawing.Point(41, 369);
      this.btnTask.Name = "btnTask";
      this.btnTask.Size = new System.Drawing.Size(146, 50);
      this.btnTask.TabIndex = 3;
      this.btnTask.Text = "Task";
      this.btnTask.UseVisualStyleBackColor = true;
      this.btnTask.Click += new System.EventHandler(this.btnTask_Click);
      // 
      // btnParallel
      // 
      this.btnParallel.Location = new System.Drawing.Point(294, 45);
      this.btnParallel.Name = "btnParallel";
      this.btnParallel.Size = new System.Drawing.Size(146, 50);
      this.btnParallel.TabIndex = 4;
      this.btnParallel.Text = "Parallel";
      this.btnParallel.UseVisualStyleBackColor = true;
      this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
      // 
      // btnThreadCore
      // 
      this.btnThreadCore.Location = new System.Drawing.Point(294, 182);
      this.btnThreadCore.Name = "btnThreadCore";
      this.btnThreadCore.Size = new System.Drawing.Size(146, 50);
      this.btnThreadCore.TabIndex = 5;
      this.btnThreadCore.Text = "ThreadCore";
      this.btnThreadCore.UseVisualStyleBackColor = true;
      this.btnThreadCore.Click += new System.EventHandler(this.btnThreadCore_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.btnThreadCore);
      this.Controls.Add(this.btnParallel);
      this.Controls.Add(this.btnTask);
      this.Controls.Add(this.btnThreadPool);
      this.Controls.Add(this.btnThreads);
      this.Controls.Add(this.btnAnyncAdvanced);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnAnyncAdvanced;
    private System.Windows.Forms.Button btnThreads;
    private System.Windows.Forms.Button btnThreadPool;
    private System.Windows.Forms.Button btnTask;
    private System.Windows.Forms.Button btnParallel;
    private System.Windows.Forms.Button btnThreadCore;
  }
}