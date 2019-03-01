//using Given_Exercise1;
using Given;
using System;
using System.Drawing;
using System.Windows.Forms;

class Decoratordelete {
    class Program {

        static void Main() {

            var photo = new Photo();
            Application.Run(photo);
            var foodTaggedPhoto = new TaggedPhoto(photo, "Food");
            var colorTaggedPhoto = new TaggedPhoto(foodTaggedPhoto, "Yellow");
            var composition = new Bordered_Photo(colorTaggedPhoto, Color.Blue);
            Application.Run(composition);
            Console.WriteLine(colorTaggedPhoto.List_Tagged_Photos());
            // Compose a photo with one TaggedPhoto and a yellow BorderedPhoto
            photo = new Photo();
            var tag = new TaggedPhoto(photo, "Jug");
            composition = new Bordered_Photo(tag, Color.Yellow);
            Application.Run(composition);
        }

    }
}
