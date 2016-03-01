using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _2048Game
{
    public partial class OverForm : Form
    {
        private int score;

        public int Score {
            get {
                return score;
            }
            set {
                score = value;
            }
        }

        public OverForm()
            : this(0) {

        }

        public OverForm(int score) {
            InitializeComponent();
            this.score = score;
            this.lbl_socre.Text = this.Score.ToString();
        }

        private void OverForm_Click(object sender, EventArgs e) {
            PictureBox pb = sender as PictureBox;
            if (pb.Name.Equals("pb_close")) {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            } else if (pb.Name.Equals("pb_restart")) {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void OverForm_MouseMove(object sender, MouseEventArgs e) {
            this.Cursor = Cursors.Hand;
            //PictureBox pb = sender as PictureBox;
            //if (pb.Name.Equals("pb_close")) {
            //} else if (pb.Name.Equals("pb_restart")) {
            //}
        }

        private void OverForm_MouseLeave(object sender, EventArgs e) {
            this.Cursor = Cursors.Default;
            //PictureBox pb = sender as PictureBox;
            //if (pb.Name.Equals("pb_close")) {
            //} else if (pb.Name.Equals("pb_restart")) {
            //}
        }
    }
}
