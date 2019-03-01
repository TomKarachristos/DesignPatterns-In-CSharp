using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Execution.Flyweight {
    /*
     * The Flyweight pattern is specifically designed to be used when all the following conditions
        are in place:
        • There is a very large number of objects (thousands) that may not fit in memory.
        • Most of the state can be kept on disk or calculated at runtime.
        • The remaining state can be factored into a much smaller number of objects with
        shared state.
    */
    public interface IFlyweight {
        void Load(string filename);
        void Display(PaintEventArgs e, int row, int col);
        void DisplayFullImage(Graphics e);
        bool IsHit(int x, int y); // do two thing now!
    }

    public struct Flyweight : IFlyweight {
        Image pThumbnail;
        string filename;
        Point Location;

        public void Display(PaintEventArgs e, int row, int col) {
            this.Location = new Point(col * 100 + 10, row * 130 + 40);
            e.Graphics.DrawImage(pThumbnail, Location.X, Location.Y,
                pThumbnail.Width, pThumbnail.Height);

        }

        public void DisplayFullImage(Graphics e) {
            using (var bitmap = new Bitmap(filename)) {
                e.DrawImageUnscaled(bitmap, 0, 0);
            }
        }

        public bool IsHit(int x, int y) {
            if (this.pThumbnail == null) return false;
            var rc = new Rectangle(Location, pThumbnail.Size);
            return rc.Contains(x, y);
        }

        public void Load(string filename) {
            this.filename = filename;
            using (var bitmap = Bitmap.FromFile(filename)) {
                this.pThumbnail = bitmap.GetThumbnailImage(100, 100, null, new IntPtr()); ;
            }
        }
    }

    public class FlyweightFactory {
        Dictionary<string, IFlyweight> flyweights =
            new Dictionary<string, IFlyweight>();

        public FlyweightFactory() {
            flyweights.Clear();
        }

        public int getLength() {
            return flyweights.Count;
        }

        public IFlyweight this[string index] {
            get {
                if (!flyweights.ContainsKey(index)) {
                    flyweights[index] = new Flyweight();
                }
                return flyweights[index];
            }
        }
    }

    public class Client {
        static FlyweightFactory album = new FlyweightFactory();
        static string Base_Url = @"D:\Code\Design__Pattern_in_C#_#_bishop\Design_Patterns\Execution\Flyweight\Photos\";

        static Dictionary<string, List<string>> allGroups =
            new Dictionary<string, List<string>>();

        public void LoadGroups() {
            var myGroup = new[] {
                new {Name = "Garden",
                    Members = new [] {
                        Base_Url + "pot.jpeg",Base_Url +  "spring.jpg",
                        Base_Url + "barbeque.jpg", Base_Url + "flowers.jpeg"
                    }
                },
                new {Name = "Italy",
                    Members = new [] {
                        Base_Url + "cappucino.jpg",Base_Url + "pasta.jpg",
                        Base_Url + "restaurant.jpg", Base_Url + "church.jpg"
                    }
                },
                new {Name = "Food",
                    Members = new [] {
                        Base_Url + "pasta.jpg",Base_Url +  "veggies.jpg",
                        Base_Url + "barbeque.jpg",Base_Url + "cappucino.jpg",Base_Url + "lemonade.jpg"
                    }
                },
                new {Name = "Friends",
                    Members = new [] {
                        Base_Url + "restaurant.jpg",
                        Base_Url + "dinner.jpg"
                    }
                }
            };

            foreach (var g in myGroup) {
                allGroups.Add(g.Name, new List<string>());
                foreach (string filename in g.Members) {
                    allGroups[g.Name].Add(filename);
                    album[filename].Load(filename);
                }
            }
        }

        private void DisplayGroup(object source, System.Windows.Forms.PaintEventArgs e) {
            // Display the Flyweights, passing the unshared state
            var row = 0;
            foreach (string g in allGroups.Keys) {
                var col = 0;
                e.Graphics.DrawString(g,
                    new Font("Arial", 16),
                    new SolidBrush(Color.Black),
                    new PointF(0, row * 130 + 10));
                foreach (string filename in allGroups[g]) {
                    album[filename].Display(e, row, col);

                    col++;
                }
                row++;
            }
        }

        public void MouseClicks(object sender, EventArgs e) {
            Point cursorPoint = new Point();
            foreach (var g in allGroups) {
                if (album[g.Key].IsHit(cursorPoint.X, cursorPoint.Y)) {
                    Form dialog = new Form();
                    dialog.Show();
                    var graphics = dialog.CreateGraphics();
                    album[g.Key].DisplayFullImage(graphics);
                }
            }
        }

        class Window : Form {
            public Window() {
                this.Height = 600;
                this.Width = 600;
                this.Text = "Picture";
                Client client = new Client();
                client.LoadGroups();
                this.Paint += client.DisplayGroup;
                this.Click += client.MouseClicks;

            }
        }


        public static void Main() {
            using (var window = new Window()) {
                Application.Run(window);
            }
        }

    }

    class Program {

        static void Main() {
            Client.Main();
        }
    }
}
