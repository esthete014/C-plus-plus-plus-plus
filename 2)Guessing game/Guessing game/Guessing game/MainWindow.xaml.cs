// / ============================= \
// | -------  esthete014  -------- |
// | ============================= |
// |     || copyright 2022 ||      |
// |     || Nikolay        ||      |
// |     || Kochetov       ||      |
// | _____________________________ |
// | https://github.com/esthete014 |
// \ ============================= /

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Guessing_game
{
    public partial class MainWindow : Window
    {
        List<string> imageNames = new List<string>();
        List<int> imageUsed = new List<int>();
        List<string> objectsNames = new List<string>();
        List<Image> imageObjects;
        List<Image> questPictures;

        Random rnd = new Random();

        bool stop = false;
        int complete;

        public string wasOpen = null;
        public Image wasOpenImg = null;
        public int wasOpenQuestN;

        static private string GetExeDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            path = System.IO.Path.GetDirectoryName(path);
            return path;
        }

        public MainWindow()
        {
            InitializeComponent();
            imageNames.Add("back");
            imageNames.Add("11");
            imageNames.Add("12");
            imageNames.Add("21");
            imageNames.Add("22");
            imageNames.Add("31");
            imageNames.Add("32");
            imageNames.Add("41");
            imageNames.Add("42");
            imageNames.Add("51");
            imageNames.Add("52");
            complete = 0;
            imageObjects = new List<Image>() { image0, image1, image2, image3, image4, image5, image6, image7, image8, image9 };
            questPictures = new List<Image>() { img0, img1, img2, img3, img4, img5, img6, img7, img8, img9 };
            var dir = GetExeDirectory();
            for (int i = 0; i < imageObjects.Count; i++)
            {
                string n = imageNames[GetRand()];
                imageObjects[i].Source = BitmapFrame.Create(new Uri(dir + @"\pics\" + n + ".png"));
                objectsNames.Add(n);
            }
        }

        private int GetRand()
        {
            int r = 0;
            while (r == 0 || imageUsed.Contains(r))
            {
                r = rnd.Next(1, imageNames.Count);
            }
            imageUsed.Add(r);
            return r;
        }

        async void cardClick(Image image, Image questimg, int n)
        {
            if (!stop)
            {
                if (wasOpen == null)
                {
                    wasOpen = objectsNames[n];
                    wasOpenImg = image;
                    wasOpenQuestN = n;
                    questimg.Opacity = 0;
                }
                else if (wasOpen[0] == objectsNames[n][0] && wasOpen != objectsNames[n])
                {
                    questimg.Opacity = 0;
                    wasOpen = null;
                    wasOpenImg = null;
                    image.Height = 220;
                    image.Width = 140;
                    image.IsEnabled = false;
                    questimg.IsEnabled = false;
                    complete++;
                    if (complete == imageObjects.Count / 2)
                    {
                        mainVid.IsEnabled = false;
                        await Task.Delay(1000);
                        new Window1().ShowDialog();
                        //Application.Current.Shutdown();
                    }
                }
                else
                {
                    questimg.Opacity = 0;
                    mainVid.IsEnabled = false;
                    await Task.Delay(1000);
                    mainVid.IsEnabled = true;
                    questimg.Opacity = 100;
                    questPictures[wasOpenQuestN].Opacity = 100;
                    wasOpen = null;
                    wasOpenImg = null;
                    wasOpenQuestN = 0;
                }
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            img0.Height = 230;
            img0.Width = 150;
        }

        private void brd0_MouseLeave(object sender, MouseEventArgs e)
        {
            img0.Height = 220;
            img0.Width = 140;
        }

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            img1.Height = 230;
            img1.Width = 150;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            img1.Height = 220;
            img1.Width = 140;
        }

        private void brd2_MouseEnter(object sender, MouseEventArgs e)
        {
            img2.Height = 230;
            img2.Width = 150;
        }

        private void brd2_MouseLeave(object sender, MouseEventArgs e)
        {
            img2.Height = 220;
            img2.Width = 140;
        }

        private void brd3_MouseEnter(object sender, MouseEventArgs e)
        {
            img3.Height = 230;
            img3.Width = 150;
        }

        private void brd3_MouseLeave(object sender, MouseEventArgs e)
        {
            img3.Height = 220;
            img3.Width = 140;
        }

        private void brd4_MouseEnter(object sender, MouseEventArgs e)
        {
            img4.Height = 230;
            img4.Width = 150;
        }

        private void brd4_MouseLeave(object sender, MouseEventArgs e)
        {
            img4.Height = 220;
            img4.Width = 140;
        }

        private void brd5_MouseEnter(object sender, MouseEventArgs e)
        {
            img5.Height = 230;
            img5.Width = 150;
        }

        private void brd5_MouseLeave(object sender, MouseEventArgs e)
        {
            img5.Height = 220;
            img5.Width = 140;
        }

        private void brd6_MouseEnter(object sender, MouseEventArgs e)
        {
            img6.Height = 230;
            img6.Width = 150;
        }

        private void brd6_MouseLeave(object sender, MouseEventArgs e)
        {
            img6.Height = 220;
            img6.Width = 140;
        }

        private void brd7_MouseEnter(object sender, MouseEventArgs e)
        {
            img7.Height = 230;
            img7.Width = 150;
        }

        private void brd7_MouseLeave(object sender, MouseEventArgs e)
        {
            img7.Height = 220;
            img7.Width = 140;
        }

        private void brd8_MouseEnter(object sender, MouseEventArgs e)
        {
            img8.Height = 230;
            img8.Width = 150;
        }

        private void brd8_MouseLeave(object sender, MouseEventArgs e)
        {
            img8.Height = 220;
            img8.Width = 140;
        }

        private void brd9_MouseEnter(object sender, MouseEventArgs e)
        {
            img9.Height = 230;
            img9.Width = 150;
        }

        private void brd9_MouseLeave(object sender, MouseEventArgs e)
        {
            img9.Height = 220;
            img9.Width = 140;
        }

        private void img0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image0, img0, 0);
        }

        private void img1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image1, img1, 1);
        }

        private void img2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image2, img2, 2);
        }

        private void img3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image3, img3, 3);
        }

        private void img4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image4, img4, 4);
        }

        private void img5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image5, img5, 5);
        }

        private void img6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image6, img6, 6);
        }

        private void img7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image7, img7, 7);
        }

        private void img8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image8, img8, 8);
        }

        private void img9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardClick(image9, img9, 9);
        }
    }
}
