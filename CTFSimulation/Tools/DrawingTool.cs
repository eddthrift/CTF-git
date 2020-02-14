using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CTFSimulation.Tools
{
    static class DrawingTool
    {
        private static Canvas _canvas;

        public static void SetupDrawingTool(ref Canvas canvas)
        {
            _canvas = canvas;
        }

        public static void DrawCircle(double diameter, SolidColorBrush colour, Vector position)
        {
            var circle = new Ellipse();
            circle.Width = diameter;
            circle.Height = diameter;
            circle.Stroke = colour;
            circle.Fill = colour;
            Canvas.SetLeft(circle, position.X);
            Canvas.SetBottom(circle, position.Y);
            _canvas.Children.Add(circle);
        }

        public static void ClearCanvas()
        {
            _canvas.Children.Clear();
        }
    }
}
