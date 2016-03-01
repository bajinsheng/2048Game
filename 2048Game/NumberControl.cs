// -------------------------------------------------------------
// <copyright file="NumberControl.cs" company="SuperSight">
//     ©2014 SuperSight Corporation. All rights reserved.	
// </copyright> 
// -------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

/* ==============================================================
* 
* 作者：Mr.K 
* 时间：2014/5/13 9:47:20
* 版本：V1.0.1
*
* 修改作者： 
* 修改时间： 
* 修改说明：
* ===============================================================
*/
namespace _2048Game
{
    /// <summary>
    /// 数字小方块控件
    /// </summary>
    public partial class NumberControl : UserControl
    {
        public NumberControl() {
            InitializeComponent();
        }

        /// <summary>
        /// 当前方块所承载的分数值
        /// </summary>
        private int value = 0;

        /// <summary>
        /// 当前分数值
        /// </summary>
        [Description("设置当前值")] // 显示在属性设计图示中的描述
        [DefaultValue(typeof(int), "0")]
        public int Value {
            get {
                return this.value;
            }
            set {
                this.value = value;
            }
        }

        /// <summary>
        /// 在控件需要重绘时反生
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            this.Invoke((MethodInvoker)delegate
            {
                using (Graphics g = this.CreateGraphics()) {
                    bool flag = true;
                    SolidBrush sb = new SolidBrush(Color.White); // 画笔的颜色
                    Color back = Color.Yellow;// 方块的背景色
                    PointF pf = new PointF(); // 画的位置
                    Font f = new Font("微软雅黑", 42, FontStyle.Bold);
                    switch (this.value) {
                        case 2:
                            back = Color.FromArgb(238, 228, 218);
                            sb = new SolidBrush(Color.FromArgb(121, 111, 101));
                            pf = new PointF(14, 2);
                            break;
                        case 4:
                            back = Color.FromArgb(236, 224, 200);
                            sb = new SolidBrush(Color.FromArgb(121, 111, 101));
                            pf = new PointF(14, 2);
                            break;
                        case 8:
                            back = Color.FromArgb(242, 177, 121);
                            sb = new SolidBrush(Color.White);
                            pf = new PointF(14, 2);
                            break;
                        case 16:
                            back = Color.FromArgb(245, 149, 99);
                            sb = new SolidBrush(Color.White);
                            f = new Font("微软雅黑", 32, FontStyle.Bold);
                            pf = new PointF(6, 12);
                            break;
                        case 32:
                            back = Color.FromArgb(243, 124, 94);
                            sb = new SolidBrush(Color.White);
                            pf = new PointF(6, 12);
                            f = new Font("微软雅黑", 32, FontStyle.Bold);
                            break;
                        case 64:
                            back = Color.FromArgb(246, 93, 59);
                            sb = new SolidBrush(Color.White);
                            pf = new PointF(6, 12);
                            f = new Font("微软雅黑", 32, FontStyle.Bold);
                            break;
                        case 128:
                        case 256:
                        case 512:
                            back = Color.FromArgb(237, 204, 97);
                            sb = new SolidBrush(Color.White);
                            pf = new PointF(1, 16);
                            f = new Font("微软雅黑", 26, FontStyle.Bold);
                            break;
                        case 1024:
                        case 2048:
                            back = Color.FromArgb(237, 204, 97);
                            sb = new SolidBrush(Color.White);
                            f = new Font("微软雅黑", 22, FontStyle.Bold);
                            pf = new PointF(0, 20);
                            break;
                        case 4096:
                            back = Color.FromArgb(237, 204, 97);
                            sb = new SolidBrush(Color.FromArgb(121, 111, 101));
                            pf = new PointF(0, 20);
                            f = new Font("微软雅黑", 22, FontStyle.Bold);
                            break;
                        default:
                            // TODO:
                            g.Clear(Color.FromArgb(204, 192, 178));
                            flag = false;
                            break;
                    }
                    if (flag) {
                        g.Clear(back);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.DrawString(this.value.ToString(), f, sb, pf);
                    }
                }
            });
        }
    }
}
