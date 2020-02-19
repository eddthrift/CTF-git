﻿using System.Windows;
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

        public static SolidColorBrush ChooseBrushColour(PlayerTeam team)
        {
            switch (team)
            {
                case PlayerTeam.Red:
                    return Brushes.Red;

                case PlayerTeam.Blue:
                    return Brushes.Blue;

                default:
                    return Brushes.Black;
            }
        }
    }
}
