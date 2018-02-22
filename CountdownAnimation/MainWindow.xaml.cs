using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CountdownAnimation
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int seconds;
            if (int.TryParse(inputText.Text, out seconds))
            {
                CreateCountDownAnimation(seconds);
            }
        }

        private void CreateCountDownAnimation(int seconds)
        {
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
            for (Int32 i = 0; i < (seconds  + 1); i++)
            {
                DiscreteObjectKeyFrame clockKeyFrame = new DiscreteObjectKeyFrame();
                clockKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, i));
                clockKeyFrame.Value = ConvertSecondsToClock(seconds - i);
                animation.KeyFrames.Add(clockKeyFrame);
            }
            animation.Duration = new Duration(new TimeSpan(0, 0, seconds));
            Storyboard.SetTarget(animation, countDownText);
            Storyboard.SetTargetProperty(animation, new PropertyPath(TextBlock.TextProperty));            
            var storyboard = new Storyboard();           
            storyboard.Children.Add(animation);           
            storyboard.Begin();
        }

        private string ConvertSecondsToClock(int value)
        {
            TimeSpan s = new TimeSpan(0, 0, value);
            return s.ToString(@"h\:mm\:ss");
        }
    }
}
