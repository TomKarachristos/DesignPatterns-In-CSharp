using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Given {
    public class Photo : Form {
        System.Drawing.Image image;

        public Photo() {
            System.Console.Write("start");
            // ara auto sikonete dio fores
            image = new Bitmap(@"D:\Code\Design__Pattern_in_C#_#_bishop\Design_Patterns\Execution\Decorator\Jug.jpg");
            this.Text = "lemonade";
            this.Paint += new PaintEventHandler(Drawer);
        }

        public virtual void Drawer(object source, PaintEventArgs e) {
            e.Graphics.DrawImage(image, 30, 20);
        }
    }

    class Bordered_Photo: Photo {
        readonly Photo photo;
        readonly Color color;

        public Bordered_Photo(Photo photo, Color color) {
            this.photo = photo;
            this.color = color;
        }

        public override void Drawer(object source, PaintEventArgs e) {
            photo.Drawer(source, e);
            e.Graphics.DrawRectangle(new Pen(color, 10), 30, 20, this.photo.Width + 30, this.photo.Height + 20);
        }
    }

    class TaggedPhoto : Photo {
        Photo photo;
        string tag;
        int number;
        static int count;
        static List<string> tags = new List<string>();

        public TaggedPhoto(Photo p, string t) {
            photo = p;
            tag = t;
            tags.Add(t);
            number = ++count;
        }

        public override void Drawer(object source, PaintEventArgs e) {
            photo.Drawer(source, e);
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

