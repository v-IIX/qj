
namespace MyAsyncThread
{
  partial class FormSSQ
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
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      this.gbo = new System.Windows.Forms.GroupBox();
      this.red6 = new System.Windows.Forms.Label();
      this.red5 = new System.Windows.Forms.Label();
      this.blue = new System.Windows.Forms.Label();
      this.red3 = new System.Windows.Forms.Label();
      this.red4 = new System.Windows.Forms.Label();
      this.red2 = new System.Windows.Forms.Label();
      this.red1 = new System.Windows.Forms.Label();
      this.gbo.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(99, 270);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(117, 41);
      this.btnStart.TabIndex = 0;
      this.btnStart.Text = "start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(514, 270);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(117, 41);
      this.btnStop.TabIndex = 0;
      this.btnStop.Text = "stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // gbo
      // 
      this.gbo.Controls.Add(this.red6);
      this.gbo.Controls.Add(this.red5);
      this.gbo.Controls.Add(this.blue);
      this.gbo.Controls.Add(this.red3);
      this.gbo.Controls.Add(this.red4);
      this.gbo.Controls.Add(this.red2);
      this.gbo.Controls.Add(this.red1);
      this.gbo.Location = new System.Drawing.Point(99, 76);
      this.gbo.Name = "gbo";
      this.gbo.Size = new System.Drawing.Size(532, 123);
      this.gbo.TabIndex = 1;
      this.gbo.TabStop = false;
      this.gbo.Text = "双色球结果区";
      // 
      // red6
      // 
      this.red6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.red6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.red6.ForeColor = System.Drawing.Color.Red;
      this.red6.Location = new System.Drawing.Point(369, 54);
      this.red6.Name = "red6";
      this.red6.Size = new System.Drawing.Size(46, 26);
      this.red6.TabIndex = 6;
      this.red6.Text = "00";
      this.red6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // red5
      // 
      this.red5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.red5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.red5.ForeColor = System.Drawing.Color.Red;
      this.red5.Location = new System.Drawing.Point(298, 54);
      this.red5.Name = "red5";
      this.red5.Size = new System.Drawing.Size(46, 26);
      this.red5.TabIndex = 5;
      this.red5.Text = "00";
      this.red5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // blue
      // 
      this.blue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.blue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.blue.ForeColor = System.Drawing.Color.Blue;
      this.blue.Location = new System.Drawing.Point(479, 54);
      this.blue.Name = "blue";
      this.blue.Size = new System.Drawing.Size(46, 26);
      this.blue.TabIndex = 4;
      this.blue.Text = "00";
      this.blue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // red3
      // 
      this.red3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.red3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.red3.ForeColor = System.Drawing.Color.Red;
      this.red3.Location = new System.Drawing.Point(156, 54);
      this.red3.Name = "red3";
      this.red3.Size = new System.Drawing.Size(46, 26);
      this.red3.TabIndex = 3;
      this.red3.Text = "00";
      this.red3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // red4
      // 
      this.red4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.red4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.red4.ForeColor = System.Drawing.Color.Red;
      this.red4.Location = new System.Drawing.Point(227, 54);
      this.red4.Name = "red4";
      this.red4.Size = new System.Drawing.Size(46, 26);
      this.red4.TabIndex = 2;
      this.red4.Text = "00";
      this.red4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // red2
      // 
      this.red2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.red2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.red2.ForeColor = System.Drawing.Color.Red;
      this.red2.Location = new System.Drawing.Point(85, 54);
      this.red2.Name = "red2";
      this.red2.Size = new System.Drawing.Size(46, 26);
      this.red2.TabIndex = 1;
      this.red2.Text = "00";
      this.red2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // red1
      // 
      this.red1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.red1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.red1.ForeColor = System.Drawing.Color.Red;
      this.red1.Location = new System.Drawing.Point(14, 54);
      this.red1.Name = "red1";
      this.red1.Size = new System.Drawing.Size(46, 26);
      this.red1.TabIndex = 0;
      this.red1.Text = "00";
      this.red1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // FormSSQ
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.gbo);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Name = "FormSSQ";
      this.Text = "FormSSQ";
      this.Load += new System.EventHandler(this.FormSSQ_Load);
      this.gbo.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.GroupBox gbo;
    private System.Windows.Forms.Label red1;
    private System.Windows.Forms.Label red6;
    private System.Windows.Forms.Label red5;
    private System.Windows.Forms.Label blue;
    private System.Windows.Forms.Label red3;
    private System.Windows.Forms.Label red4;
    private System.Windows.Forms.Label red2;
  }
}