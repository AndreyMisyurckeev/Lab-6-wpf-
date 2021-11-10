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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_6__wpf_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public string WindCourse { get; set; }
        public int WindSpeed { get; set; }
        public enum Downfall
        {
            Sunny = 0,
            Cloudly = 1,
            Rain = 2,
            Snow = 3
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                    typeof(WeatherControl),
                    new FrameworkPropertyMetadata(
                        0,
                        FrameworkPropertyMetadataOptions.Journal |
                        FrameworkPropertyMetadataOptions.AffectsMeasure,
                        null,
                        new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature)
                    );
        }
        private static bool ValidateTemperature(object value)
        {
            int T = (int)(value);
            if (T >= -50 && T <= 50)
                return true;
            else
            {
                return false;
            }
        }
        private static object CoerceTemperature(DependencyObject d, object basevalue)
        {
            int T = (int)(basevalue);
            if (T >= -50)
                return T;
            else
            {
                return 0;
            }
        }
    }
}
