using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskbarTimer
{
    class ClockDrawer
    {
        Graphics Graphics;
        Rectangle Rect;
        int ClockDiameter = 50;
        int Padding = 5;
        Point ClockCentre;

        public ClockDrawer(Graphics graphics, Rectangle rect)
        {
            Graphics = graphics;
            Rect = rect;
            ClockDiameter = rect.Height - (Padding * 2);
            ClockCentre = new Point(Padding + Rect.Left + (ClockDiameter / 2),
                Rect.Top + Padding + (ClockDiameter / 2));
        }

        public void DrawFace()
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            Rectangle faceRect = new Rectangle(
                Rect.Left + Padding,
                Rect.Top + Padding,
                ClockDiameter,
                ClockDiameter);
            Graphics.DrawArc(pen, faceRect, 0.0F, 360.0F);

            int outerRingDiameter = ClockDiameter - 8;
            int innerRingDiameter = outerRingDiameter - 5;
            for (int degrees = 0; degrees < 360; degrees += 30)
            {
                double outerX = ClockCentre.X + (0.5 * outerRingDiameter * Math.Cos(degrees * (Math.PI / 180)));
                double outerY = ClockCentre.Y + (0.5 * outerRingDiameter * Math.Sin(degrees * (Math.PI / 180)));
                double innerX = ClockCentre.X + (0.5 * innerRingDiameter * Math.Cos(degrees * (Math.PI / 180)));
                double innerY = ClockCentre.Y + (0.5 * innerRingDiameter * Math.Sin(degrees * (Math.PI / 180)));
                Point point1 = new Point((int)outerX, (int)outerY);
                Point point2 = new Point((int)innerX, (int)innerY);
                Graphics.DrawLine(pen, point1, point2);
            }
        }
    }
}
 