using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace PickandPlace.ImageButtonBasic
{
    public class ImageButtonBasic : Button
    {
        Image _image = null;
      

        public ImageButtonBasic()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            panel.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;

            panel.Margin = new System.Windows.Thickness(0);

            _image = new Image();
            _image.Margin = new System.Windows.Thickness(0, 0, 0, 0);
            panel.Children.Add(_image);


            
            this.BorderThickness = new Thickness(0);
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.BorderBrush = new SolidColorBrush(Colors.Transparent);

            this.Content = panel;
        }

       

        public ImageSource Image
        {
            get
            {
                if (_image != null)
                    return _image.Source;
                else
                    return null;
            }
            set
            {
                if (_image != null)
                    _image.Source = value;
            }
        }

        public double ImageWidth
        {
            get
            {
                if (_image != null)
                    return _image.Width;
                else
                    return double.NaN;
            }
            set
            {
                if (_image != null)
                    _image.Width = value;
            }
        }

        public double ImageHeight
        {
            get
            {
                if (_image != null)
                    return _image.Height;
                else
                    return double.NaN;
            }
            set
            {
                if (_image != null)
                    _image.Height = value;
            }
        }
    }
}
