using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace CountdownApp
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
            for (Int32 i = 0; i < (seconds + 1); i++)
            {
                DiscreteObjectKeyFrame clockKeyFrame = new DiscreteObjectKeyFrame();
                clockKeyFrame.KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, i));
                clockKeyFrame.Value = ConvertSecondsToClock(seconds - i);
                animation.KeyFrames.Add(clockKeyFrame);
            }
            animation.Duration = new Duration(new TimeSpan(0, 0, seconds));

            Storyboard.SetTarget(animation, countDownText);
            Storyboard.SetTargetProperty(animation, "TextBlock.Text");
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
