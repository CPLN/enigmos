using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Utils
{
    /// <summary>
    /// This kind of label allows the rotation at an angle.
    /// </summary>
    class RotatingLabel : Label
    {
        private double angle;

        /// <summary>
        /// Sets or gets the angle of rotation in degrees.
        /// <code>rotatingLabel.Angle = 360.0;</code> being equal to <code>rotatingLabel.Angle = 0.0;</code>
        /// </summary>
        public double Angle
        {
            get
            {
                return angle * 180 / Math.PI;
            }
            set
            {
                angle = Math.PI / 180 * value;
                Size linearSize = TextRenderer.MeasureText(Text, Font);
                Size = new Size((int)(Math.Abs(Math.Cos(angle) * linearSize.Width) + Math.Abs(Math.Sin(angle) * linearSize.Height)), (int)(Math.Abs(Math.Sin(angle) * linearSize.Width) + Math.Abs(Math.Cos(angle) * linearSize.Height)));
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            double realAngle = angle;
            while (realAngle < 0)
            {
                realAngle += 2 * Math.PI;
            }
            while (realAngle > 2 * Math.PI)
            {
                realAngle -= 2 * Math.PI;
            }

            Size linearSize = TextRenderer.MeasureText(Text, Font);
            Brush b = new SolidBrush(this.ForeColor);

            if (realAngle <= Math.PI / 2)
            {
                e.Graphics.TranslateTransform((float)(Math.Sin(angle) * linearSize.Height), 0);
            }
            else if (realAngle <= Math.PI)
            {
                e.Graphics.TranslateTransform((float)Size.Width, (float)(-Math.Cos(angle) * linearSize.Height));
            }
            else if (realAngle <= 3 * Math.PI / 2)
            {
                e.Graphics.TranslateTransform((float)(-Math.Cos(angle) * linearSize.Width), Size.Height);
            }
            else
            {
                e.Graphics.TranslateTransform(0f, (float)(-Math.Sin(angle) * linearSize.Width));
            }
            e.Graphics.RotateTransform((float)Angle);
            e.Graphics.DrawString(Text, Font, b, 0f, 0f);
        }
    }
}
