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

        public static void DrawCircle(double diameter, ObjectTeam team, Vector position)
        {
            var colour = ChooseBrushColour(team);
            var circle = new Ellipse();

            circle.Width = diameter;
            circle.Height = diameter;
            circle.Stroke = colour;
            circle.Fill = colour;

            Canvas.SetLeft(circle, position.X);
            Canvas.SetBottom(circle, position.Y);

            _canvas.Children.Add(circle);
        }

        public static void DrawFlag(double diameter, ObjectTeam team, Vector position)
        {
            var colour = ChooseBrushColour(team);
            var pole = new Line();
            var flag = new Rectangle();

            pole.Stroke = colour;
            pole.Fill = colour;
            pole.StrokeThickness = 0.8;

            pole.X1 = position.X;
            pole.Y1 = position.Y;

            pole.X2 = position.X;
            pole.Y2 = position.Y + diameter;

            flag.Width = diameter;
            flag.Height = diameter / 2;

            flag.Stroke = colour;
            flag.Fill = colour;
            flag.Margin = new Thickness(0,0,0,0);

            Canvas.SetLeft(flag, position.X);
            Canvas.SetBottom(flag, position.Y - diameter/2);

            _canvas.Children.Add(flag);
            _canvas.Children.Add(pole);
        }

        public static void ClearCanvas()
        {
            _canvas.Children.Clear();
        }

        public static SolidColorBrush ChooseBrushColour(ObjectTeam team)
        {
            switch (team)
            {
                case ObjectTeam.Red:
                    return Brushes.Red;

                case ObjectTeam.Blue:
                    return Brushes.Blue;

                default:
                    return Brushes.Black;
            }
        }
    }
}
