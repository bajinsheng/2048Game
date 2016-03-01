namespace _2048Game
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pb_main = new System.Windows.Forms.PictureBox();
            this.pb_close = new System.Windows.Forms.PictureBox();
            this.pb_start = new System.Windows.Forms.PictureBox();
            this.tt_msg = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_start)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_main
            // 
            this.pb_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.pb_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_main.Location = new System.Drawing.Point(5, 24);
            this.pb_main.Name = "pb_main";
            this.pb_main.Size = new System.Drawing.Size(400, 400);
            this.pb_main.TabIndex = 0;
            this.pb_main.TabStop = false;
            this.pb_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
            this.pb_main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);
            // 
            // pb_close
            // 
            this.pb_close.Image = global::_2048Game.Resource.close1;
            this.pb_close.Location = new System.Drawing.Point(383, 0);
            this.pb_close.Name = "pb_close";
            this.pb_close.Size = new System.Drawing.Size(20, 20);
            this.pb_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_close.TabIndex = 2;
            this.pb_close.TabStop = false;
            this.pb_close.Click += new System.EventHandler(this.pb_Click);
            this.pb_close.MouseLeave += new System.EventHandler(this.pb_MouseLeave);
            this.pb_close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
            // 
            // pb_start
            // 
            this.pb_start.Image = global::_2048Game.Resource.start1;
            this.pb_start.Location = new System.Drawing.Point(357, 0);
            this.pb_start.Name = "pb_start";
            this.pb_start.Size = new System.Drawing.Size(20, 20);
            this.pb_start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_start.TabIndex = 2;
            this.pb_start.TabStop = false;
            this.pb_start.Click += new System.EventHandler(this.pb_Click);
            this.pb_start.MouseLeave += new System.EventHandler(this.pb_MouseLeave);
            this.pb_start.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
            // 
            // tt_msg
            // 
            this.tt_msg.AutoPopDelay = 5000;
            this.tt_msg.BackColor = System.Drawing.Color.Transparent;
            this.tt_msg.InitialDelay = 500;
            this.tt_msg.ReshowDelay = 100;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(410, 434);
            this.ControlBox = false;
            this.Controls.Add(this.pb_start);
            this.Controls.Add(this.pb_close);
            this.Controls.Add(this.pb_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_start)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_main;
        private System.Windows.Forms.PictureBox pb_close;
        private System.Windows.Forms.PictureBox pb_start;
        private System.Windows.Forms.ToolTip tt_msg;
    }
}

