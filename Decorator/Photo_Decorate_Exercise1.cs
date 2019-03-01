using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Given_Exercise1 {

    interface IDraw {
        void Drawer(object source, PaintEventArgs e);
    }

    public class Photo : Form {
        readonly System.Drawing.Image image;

        public Photo() {
            System.Console.WriteLine("start");
            image = new Bitmap(@"D:\Code\Design__Pattern_in_C#_#_bishop\Design_Patterns\Execution\Jug.jpg");
            this.Text = "lemonade";
            this.Paint += new PaintEventHandler(Drawers);
        }

        public void Drawers(object source, PaintEventArgs e) {
            e.Graphics.DrawImage(image, 30, 20);
        }
    }

    class BorderedPhoto : Photo, IDraw {
        readonly Form photo;
        readonly Color color;

        private void Let_my_know(object sender, EventArgs e) {
            System.Console.WriteLine("On_Click");
             Trace.WriteLine("Mouse clicked");
        }

        public BorderedPhoto(Form photo, Color color) {
            this.photo = photo;
            this.color = color;
            this.Paint += new PaintEventHandler(Drawer);
            this.Resize += Let_my_know;
        }


        public void Drawer(object source, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(color, 10), 30, 20, this.photo.Width + 30, this.photo.Height + 20);
        }
    }

    class TaggedPhoto : Photo, IDraw {
        Form photo;
        string tag;
        int number;
        static int count;
        static List<string> tags = new List<string>();

        public TaggedPhoto(Form p, string t) {
            photo = p;
            tag = t;
            tags.Add(t);
            number = ++count;
            this.Paint += new PaintEventHandler(Drawer);
        }

        public void Drawer(object source, PaintEventArgs e) {
            e.Graphics.DrawString(tag,
                new Font("Arial", 16),
                new SolidBrush(Color.Black),
                new PointF(80, 100 + number * 20));
        }

        public string List_Tagged_Photos() {
            string s = "Tags are: ";
            foreach (string t in tags) s += t + " ";
            return s;
        }
    }
}

