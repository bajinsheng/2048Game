// -------------------------------------------------------------
// <copyright file="MainForm.cs" company="SuperSight">
//     ©2014 SuperSight Corporation. All rights reserved.	
// </copyright> 
// -------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NC = _2048Game.NumberControl;

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
    public partial class MainForm : Form
    {
        private readonly NumberControl[] NCS = new NumberControl[16];
        private readonly int NumberHeight = 80;
        private readonly int NumberWidth = 80;
        private bool isOver = false;

        /// <summary>
        /// 属性的起始坐标
        /// </summary>
        private int x1, y1;

        /// <summary>
        /// 分数
        /// </summary>
        private int Score;

        public MainForm() {
            InitializeComponent();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            this.Invoke((MethodInvoker)delegate
            {

                int IntervalX = (400 - NumberWidth * 4) / 5;
                int IntervalY = (400 - NumberHeight * 4) / 5;

                int index = 0;
                for (int i = 0; i < 4; i++) { // 横向
                    for (int j = 0; j < 4; j++) { // 纵向
                        int x = IntervalX * (j + 1) + NumberWidth * j; // x 坐标
                        int y = IntervalX * (i + 1) + NumberWidth * i; // y 坐标
                        NumberControl nc = new NumberControl();
                        nc.Value = 0;
                        nc.Size = new Size(this.NumberWidth, this.NumberHeight);
                        nc.Location = new Point(x, y);
                        nc.Name = "NumberControl" + (i + 1) + (j + 1);
                        nc.Tag = index;
                        nc.MouseDown -= this.pb_MouseDown;
                        nc.MouseDown += this.pb_MouseDown;
                        nc.MouseUp -= this.pb_MouseUp;
                        nc.MouseUp += this.pb_MouseUp;
                        this.NCS[index] = nc;
                        index++;
                        this.pb_main.Controls.Add(nc);
                    }
                }
            });
            this.Start();
        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        public void Start() {
            if (this.pb_main.Controls.Count < 16) {
                MessageBox.Show("程序加载异常");
                return;
            }
            this.isOver = false;
            this.Score = 0;
            this.Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < 16; i++)
                    NCS[i].Value = 0;
                // 产生两个随机方块显示2个随机值
                Random rd = new Random();
                int nc1 = 0;
                int nc2 = 0;
                do {
                    nc1 = rd.Next(0, 15);
                    nc2 = rd.Next(0, 15);
                } while (nc1 == nc2);
                this.NCS[nc1].Value = rd.Next(1, 3) * 2;// 产生 2 和 4的随机值
                this.NCS[nc2].Value = rd.Next(1, 3) * 2;// 产生 2 和 4的随机值
                this.pb_main.Refresh();
            });
        }

        /// <summary>
        /// 鼠标按下 记住当前坐标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_MouseDown(object sender, MouseEventArgs e) {
            this.x1 = e.X;
            this.y1 = e.Y;
        }

        /// <summary>
        /// 鼠标释放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_MouseUp(object sender, MouseEventArgs e) {
            if (this.x1.Equals(e.X) && this.y1.Equals(e.Y)) {
                // 坐标无变化，不动
                return;
            }
            MoveBox(this.GetDirection(e.X - this.x1, e.Y - this.y1));
        }

        /// <summary>
        /// 上一次的方向
        /// </summary>
        private Direction lastDir = Direction.Nil;


        /// <summary>
        /// 同一方向的次数
        /// </summary>
        private int dirCount = 0;

        /// <summary>
        /// 移动方块
        /// </summary>
        /// <param name="d"></param>
        private void MoveBox(Direction d) {
            if (this.isOver) {
                return;
            }
            if (lastDir == d) { // 和上一次的方向相同
                this.dirCount++;
            } else {
                this.dirCount = 0;
            }
            if(this.dirCount >3){
                return;
            }
            int s = 0;
            switch (d) {
                case Direction.Up: // 上移
                    s = this.MoveRowOrColumn(NCS[12], NCS[8], NCS[4], NCS[0]) +
                               this.MoveRowOrColumn(NCS[13], NCS[9], NCS[5], NCS[1]) +
                               this.MoveRowOrColumn(NCS[14], NCS[10], NCS[6], NCS[2]) +
                               this.MoveRowOrColumn(NCS[15], NCS[11], NCS[7], NCS[3]);
                    break;
                case Direction.Down: // 下移
                    s = this.MoveRowOrColumn(NCS[0], NCS[4], NCS[8], NCS[12]) +
                                  this.MoveRowOrColumn(NCS[1], NCS[5], NCS[9], NCS[13]) +
                                  this.MoveRowOrColumn(NCS[2], NCS[6], NCS[10], NCS[14]) +
                                  this.MoveRowOrColumn(NCS[3], NCS[7], NCS[11], NCS[15]);
                    break;
                case Direction.Left: // 左移
                    s = this.MoveRowOrColumn(NCS[3], NCS[2], NCS[1], NCS[0]) +
                                 this.MoveRowOrColumn(NCS[7], NCS[6], NCS[5], NCS[4]) +
                                 this.MoveRowOrColumn(NCS[11], NCS[10], NCS[9], NCS[8]) +
                                 this.MoveRowOrColumn(NCS[15], NCS[14], NCS[13], NCS[12]);
                    break;
                case Direction.Right:// 右移
                    s = this.MoveRowOrColumn(NCS[0], NCS[1], NCS[2], NCS[3]) +
                                this.MoveRowOrColumn(NCS[4], NCS[5], NCS[6], NCS[7]) +
                                this.MoveRowOrColumn(NCS[8], NCS[9], NCS[10], NCS[11]) +
                                this.MoveRowOrColumn(NCS[12], NCS[13], NCS[14], NCS[15]);

                    break;

            }
            this.Score += s;
            if (!this.isGetNextBox() || s != 0) { // 不能移动的时候才取一个方块
                getNextBox();//取下一个方块
            }
            this.pb_main.Refresh();
        }

        /// <summary>
        /// 移动一行或者一列
        /// </summary>
        /// <returns>总分数</returns>
        private int MoveRowOrColumn(NC nc1, NC nc2, NC nc3, NC nc4) {
            int total = 0;
            if (nc1.Value == 0 && nc2.Value == 0 && nc3.Value == 0 && nc4.Value == 0) {
                return 0;
            }

            NC[] ncs = new NC[] { nc1, nc2, nc3, nc4 };
            IList nclist = new ArrayList(); // 不为0的方块
            for (int i = 0; i < ncs.Length; i++) {
                if (!ncs[i].Value.Equals(0)) {
                    nclist.Add(ncs[i].Value);
                }
            }
            for (int i = 0; i < ncs.Length - nclist.Count; i++) { // 把ncs前面几个的值设置为0
                ncs[i].Value = 0;
            }

            for (int i = 0; i < nclist.Count; i++) { // 把nclist里面的值赋给ncs的后面
                ncs[ncs.Length - nclist.Count + i].Value = (int)nclist[i];
            }

            if (ncs[2].Value != 0) { // ncs中，如果第三个也是0，那么正一条线就只有一个数不为0
                if (ncs[2].Value == ncs[3].Value) {
                    ncs[3].Value = 2 * ncs[3].Value;
                    total += ncs[3].Value;
                    if (ncs[1].Value == ncs[0].Value) {
                        total += 2 * ncs[1].Value;
                        ncs[2].Value = 2 * ncs[1].Value;
                        ncs[1].Value = 0;
                        ncs[0].Value = 0;
                    } else {
                        ncs[2].Value = ncs[1].Value;
                        ncs[1].Value = ncs[0].Value;
                        ncs[0].Value = 0;
                    }
                } else {
                    if (ncs[2].Value == ncs[1].Value) {
                        total += 2 * ncs[1].Value;
                        ncs[2].Value = 2 * ncs[1].Value;
                        ncs[1].Value = ncs[0].Value;
                        ncs[0].Value = 0;
                    } else {
                        if (ncs[1].Value == ncs[0].Value) {
                            total += 2 * ncs[1].Value;
                            ncs[1].Value = 2 * ncs[0].Value;
                            ncs[0].Value = 0;
                        }
                    }
                }
            }
            return total;
        }

        /// <summary>
        /// 获取一个方块
        /// </summary>
        private void getNextBox() {
            ArrayList nclist = new ArrayList();
            for (int i = 0; i < 16; i++) {
                if (NCS[i].Value == 0) {
                    nclist.Add(i);
                }
            }
            if (nclist.Count > 0) {
                System.Random r = new Random();
                int val =  (r.Next(1, 100) < 80 ? 2 : 4);
                NCS[(int)nclist[r.Next(1, nclist.Count) - 1]].Value = val;
            } else {
                if (!this.iSCanMove()) {
                    using (OverForm ov = new OverForm(this.Score)) {
                        if (ov.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                            // 再来
                            this.Start();
                        } else {
                            this.isOver = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 全部方格已填满，是否还能移动
        /// </summary>
        /// <returns></returns>
        private bool iSCanMove() {
            //能左右移动吗？
            if (NCS[0].Value == NCS[1].Value || NCS[1].Value == NCS[2].Value || NCS[2].Value == NCS[3].Value ||
               NCS[4].Value == NCS[5].Value || NCS[5].Value == NCS[6].Value || NCS[6].Value == NCS[7].Value ||
               NCS[8].Value == NCS[9].Value || NCS[9].Value == NCS[10].Value || NCS[10].Value == NCS[11].Value ||
               NCS[12].Value == NCS[13].Value || NCS[13].Value == NCS[14].Value || NCS[14].Value == NCS[15].Value
                )
                return true;
            //能上下移动吗？
            if (NCS[0].Value == NCS[4].Value || NCS[4].Value == NCS[8].Value || NCS[8].Value == NCS[12].Value ||
               NCS[1].Value == NCS[5].Value || NCS[5].Value == NCS[9].Value || NCS[9].Value == NCS[13].Value ||
               NCS[2].Value == NCS[6].Value || NCS[6].Value == NCS[10].Value || NCS[10].Value == NCS[14].Value ||
               NCS[3].Value == NCS[7].Value || NCS[7].Value == NCS[11].Value || NCS[11].Value == NCS[15].Value
                )
                return true;
            return false;
        }

        /// <summary>
        /// 是否需要取出下一个
        /// </summary>
        /// <returns></returns>
        private bool isGetNextBox() {
            //能左右移动吗？
            if (NCS[0].Value == NCS[1].Value && NCS[0].Value != 0 || NCS[1].Value == NCS[2].Value && NCS[1].Value != 0 || NCS[2].Value == NCS[3].Value && NCS[2].Value != 0 ||
                NCS[4].Value == NCS[5].Value && NCS[4].Value != 0 || NCS[5].Value == NCS[6].Value && NCS[5].Value != 0 || NCS[6].Value == NCS[7].Value && NCS[6].Value != 0 ||
                NCS[8].Value == NCS[9].Value && NCS[8].Value != 0 || NCS[9].Value == NCS[10].Value && NCS[9].Value != 0 || NCS[10].Value == NCS[11].Value && NCS[10].Value != 0 ||
               NCS[12].Value == NCS[13].Value && NCS[12].Value != 0 || NCS[13].Value == NCS[14].Value && NCS[13].Value != 0 || NCS[14].Value == NCS[15].Value && NCS[14].Value != 0
                )
                return true;
            //能上下移动吗？
            if (NCS[0].Value == NCS[4].Value && NCS[0].Value != 0 || NCS[4].Value == NCS[8].Value && NCS[4].Value != 0 || NCS[8].Value == NCS[12].Value && NCS[8].Value != 0 ||
               NCS[1].Value == NCS[5].Value && NCS[1].Value != 0 || NCS[5].Value == NCS[9].Value && NCS[5].Value != 0 || NCS[9].Value == NCS[13].Value && NCS[9].Value != 0 ||
               NCS[2].Value == NCS[6].Value && NCS[2].Value != 0 || NCS[6].Value == NCS[10].Value && NCS[6].Value != 0 || NCS[10].Value == NCS[14].Value && NCS[10].Value != 0 ||
               NCS[3].Value == NCS[7].Value && NCS[3].Value != 0 || NCS[7].Value == NCS[11].Value && NCS[7].Value != 0 || NCS[11].Value == NCS[15].Value && NCS[11].Value != 0
                )
                return true;
            return false;
        }

        /// <summary>
        /// 根据坐标差值计算移动的方法
        /// </summary>
        /// <param name="xValue"></param>
        /// <param name="yValue"></param>
        /// <returns></returns>
        private Direction GetDirection(int xValue, int yValue) {
            if (xValue > 0 && yValue > 0) { // 右  下 
                if (xValue > yValue) {
                    return Direction.Right;
                } else {
                    return Direction.Down;
                }
            }
            if (xValue > 0 && yValue < 0) { // 右  上
                if (xValue > Math.Abs(yValue)) {
                    return Direction.Right;
                } else {
                    return Direction.Up;
                }
            }
            if (xValue < 0 && yValue > 0) { // 左  下
                if (Math.Abs(xValue) > yValue) {
                    return Direction.Left;
                } else {
                    return Direction.Down;
                }
            }
            if (xValue < 0 && yValue < 0) { // 左  上
                if (Math.Abs(xValue) > Math.Abs(yValue)) {
                    return Direction.Left;
                } else {
                    return Direction.Up;
                }
            }
            if (xValue == 0 && yValue != 0) { // 上  下
                if (yValue > 0) {
                    return Direction.Down;
                } else {
                    return Direction.Up;
                }
            }
            if (xValue != 0 && yValue == 0) {
                if (xValue > 0) {
                    return Direction.Left;
                } else {
                    return Direction.Right;
                }
            }
            return Direction.Nil;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                case Keys.Up:// 上
                case Keys.W:
                case Keys.D8:
                    MoveBox(Direction.Up);
                    break;
                case Keys.Down:// 下
                case Keys.S:
                case Keys.D2:
                    MoveBox(Direction.Down);
                    break;
                case Keys.Left:// 左
                case Keys.D4:
                case Keys.A:
                    MoveBox(Direction.Left);
                    break;
                case Keys.Right: // 右
                case Keys.D6:
                case Keys.D:
                    MoveBox(Direction.Right);
                    break;
                case Keys.F5:
                    this.Start();
                    break;
                case Keys.Escape:
                    if (MessageBox.Show("是否退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK) {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void pb_MouseMove(object sender, MouseEventArgs e) {
            this.Cursor = Cursors.Hand;
            PictureBox pb = sender as PictureBox;
            if (pb.Name.Equals("pb_close")) {
                pb.Image = Resource.close2;
            } else if (pb.Name.Equals("pb_start")) {
                pb.Image = Resource.start2;
            }
        }

        private void pb_MouseLeave(object sender, EventArgs e) {
            this.Cursor = Cursors.Default;
            PictureBox pb = sender as PictureBox;
            this.tt_msg.Hide(pb);
            if (pb.Name.Equals("pb_close")) {
                pb.Image = Resource.close1;
            } else if (pb.Name.Equals("pb_start")) {
                pb.Image = Resource.start1;
            }
        }

        private void pb_Click(object sender, EventArgs e) {
            PictureBox pb = sender as PictureBox;
            this.tt_msg.Hide(pb);
            if (pb.Name.Equals("pb_close")) {
                Application.Exit();
            } else if (pb.Name.Equals("pb_start")) {
                this.Start();
            }
        }

    }
}
