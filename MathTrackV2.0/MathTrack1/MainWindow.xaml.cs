using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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


namespace MathTrack1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*int term1 = 0, term2 = 0, result = 0;
          int correctIndex = 1;
          Random rand = new Random();
          //int eyeX, eyeY;
        */

        Level[] levels = new Level[12];
        int levelStatus = 0;

        string path;
        BitmapImage img;

        TextStorage textStorage;
        string chosen;

     //   MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            //   generate();

            levels[0] = new Level(4, 2, 7, 6, 3, 6, "png");
            levels[1] = new Level(5, 2, 9, 6, 7, 7, "png");
            levels[2] = new Level(3, 4, 6, 7, 5, 7, "png");
            levels[3] = new Level(1, 1, 2, 1, 3, 2, "gif");
            levels[4] = new Level(1, 3, 6, 5, 4, 4, "png");
            levels[5] = new Level(3, 3, 6, 2, 3, 6, "png");
            levels[6] = new Level(2, 2, 4, 5, 6, 4, "gif");
            levels[7] = new Level(5, 4, 7, 9, 5, 9, "png");
            levels[8] = new Level(4, 1, 6, 4, 5, 5, "png");
            levels[9] = new Level(2, 1, 3, 6, 4, 3, "gif");
            levels[10] = new Level(1, 5, 3, 7, 6, 6, "png");
            levels[11] = new Level(3, 2, 4, 5, 3, 5, "gif");

            generate();

            textStorage = new TextStorage();
            textStorage.WriteText(DateTime.Now.ToString(" Start!"));



        }
        public string[] Files
        { get; set; }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /*  private void check(int ans)
             {
              if (correctIndex == ans)
                     lblResult.Content = "Good!";
                 else
                     lblResult.Content = "Wrong!";
               //  lblXY.Content = ((App)Application.Current).getX().ToString("F0") + "; " + 
                 //    ((App)Application.Current).getY().ToString("F0");

               generate();

             }
             */
        /* private void generate()
             {
                 term1 = rand.Next(1, 5);
                 term2 = rand.Next(1, 5);
                 result = term1 + term2;
                 lblNumeric.Content = term1 + " + " + term2 + " = ?";
                 correctIndex = rand.Next(1, 4);

                 switch (correctIndex)
                 {
                     case 1:
                         btnOp1.Content = result;
                         btnOp2.Content = result + 1;
                         btnOp3.Content = term2;
                         break;
                     case 2:
                         btnOp1.Content = term1;
                         btnOp2.Content = result;
                         btnOp3.Content = result + 1;
                         break;
                     case 3:
                         btnOp1.Content = term2;
                         btnOp2.Content = result + 1;
                         btnOp3.Content = result;
                         break;
                 }
             }
             */

        private void generate()
        {
            lblNumeric.Content = " " + levels[levelStatus].q1 + "    " + levels[levelStatus].q2;

            btnOp1.Content = levels[levelStatus].a1;
            btnOp2.Content = levels[levelStatus].a2;
            btnOp3.Content = levels[levelStatus].a3;

            switch (levels[levelStatus].format)
            {
                case "png":
                    gifq1.Visibility = Visibility.Collapsed;
                    gifq2.Visibility = Visibility.Collapsed;
                    gifa1.Visibility = Visibility.Collapsed;
                    gifa2.Visibility = Visibility.Collapsed;
                    gifa3.Visibility = Visibility.Collapsed;

                    imgq1.Opacity = 100;
                    imgq2.Opacity = 100;
                    imga1.Opacity = 100;
                    imga2.Opacity = 100;
                    imga3.Opacity = 100;

                    
                    btnOp1Img.Opacity = 1;
                    btnOp2Img.Opacity = 1;
                    btnOp3Img.Opacity = 1;

                    //images
                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].q1 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    imgq1.Source = img;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].q2 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    imgq2.Source = img;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].a1 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    imga1.Source = img; //new ImageBrush(imageSource);

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].a2 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    imga2.Source = img; //new ImageBrush(imageSource);

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].a3 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    imga3.Source = img; //new ImageBrush(imageSource);
                    break;

                case "gif":
                    gifq1.Visibility = Visibility.Visible;
                    gifq2.Visibility = Visibility.Visible;
                    gifa1.Visibility = Visibility.Visible;
                    gifa2.Visibility = Visibility.Visible;
                    gifa3.Visibility = Visibility.Visible;

                    imgq1.Opacity = 0;
                    imgq2.Opacity = 0;
                    path = "levels/white.png";
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    imgq1.Source = img;
                    imga1.Source = img;
                    imga2.Source = img;
                    imga3.Source = img;

                    btnOp1Img.Opacity = 0.5;
                    btnOp2Img.Opacity = 0.5;
                    btnOp3Img.Opacity = 0.5;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].q1 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    gifq1.Source = new Uri(path, UriKind.Relative);
                    gifq1.OpacityMask = new ImageBrush(img);
                    gifq1.LoadedBehavior = MediaState.Manual;
                    gifq1.Play();
                    gifq1.MediaEnded += ImageGifView_MediaEnded;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].q2 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    gifq2.Source = new Uri(path, UriKind.Relative);
                    gifq2.OpacityMask = new ImageBrush(img);
                    gifq2.LoadedBehavior = MediaState.Manual;
                    gifq2.Play();
                    gifq2.MediaEnded += ImageGifView_MediaEnded;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].a1 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    gifa1.Source = new Uri(path, UriKind.Relative);
                    gifa1.OpacityMask = new ImageBrush(img);
                    gifa1.LoadedBehavior = MediaState.Manual;
                    gifa1.Play();
                    gifa1.MediaEnded += ImageGifView_MediaEnded;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].a2 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    gifa2.Source = new Uri(path, UriKind.Relative);
                    gifa2.OpacityMask = new ImageBrush(img);
                    gifa2.LoadedBehavior = MediaState.Manual;
                    gifa2.Play();
                    gifa2.MediaEnded += ImageGifView_MediaEnded;

                    path = "levels/" + (levelStatus + 1) + "/" + levels[levelStatus].a3 + "." + levels[levelStatus].format;
                    img = new BitmapImage(new Uri(path, UriKind.Relative));
                    gifa3.Source = new Uri(path, UriKind.Relative);
                    gifa3.OpacityMask = new ImageBrush(img);
                    gifa3.LoadedBehavior = MediaState.Manual;
                    gifa3.Play();
                    gifa3.MediaEnded += ImageGifView_MediaEnded;


                    break;
            }

        }//end generate()

        private void ImageGifView_MediaEnded(object sender, RoutedEventArgs e)
         {
 
             MediaElement media = (MediaElement)sender;
             media.Position = TimeSpan.FromMilliseconds(1);
             media.Play();
 
         }

    private void check(int levelIndex,int ans)
        {
            if (levels[levelIndex].correctAns.Equals(ans))
            {
                //correct!
                lblResult.Content = "√ 答对了！你真棒！";

                textStorage.WriteText(DateTime.Now.ToString("Level " + (levelStatus + 1) + " : " + chosen + " √"));
                //good.Play();
                SoundPlayer good = new SoundPlayer("voice/good.wav");
                good.Play();

            }
            else
            {
                //wrong!
                lblResult.Content = "× 错了哦。继续加油！";

                textStorage.WriteText(DateTime.Now.ToString("Level " + (levelStatus + 1) + " : " + chosen + " ×"));

                MessageBox.Show("correct: " + levels[levelIndex].correctAns);
                SoundPlayer wrong = new SoundPlayer("voice/wrong.wav");
                wrong.Play();

            }



            if (levelStatus == 11)
            {
                MessageBox.Show("做完啦！你真棒！");

                Environment.Exit(0);
            }
            else
            {
                levelStatus++;

                generate();
            }
            
        }

        private void op1_Click(object sender, RoutedEventArgs e)
        {
            //check(1);

            var d = sender as Button;
            chosen = d.Name;
            //MessageBox.Show(chosen);
            check(levelStatus, Convert.ToInt32(btnOp1.Content.ToString()));

        }

        private void op2_Click(object sender, RoutedEventArgs e)
        {
            //check(2);

            var d = sender as Button;
            chosen = d.Name;
            //MessageBox.Show(chosen);
            check(levelStatus, Convert.ToInt32(btnOp2.Content.ToString()));

        }

        private void op3_Click(object sender, RoutedEventArgs e)
        {
            //check(3);

            var d = sender as Button;
            chosen = d.Name;
            //MessageBox.Show(chosen);
            check(levelStatus, Convert.ToInt32(btnOp3.Content.ToString()));

        }

        private void MouseEnter(object sender, MouseEventArgs e)
        {
            var d = sender as Button;
            d.BorderThickness = new Thickness(4);
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            var d = sender as Button;
            d.BorderThickness = new Thickness(1);
        }
    }//end class
}
