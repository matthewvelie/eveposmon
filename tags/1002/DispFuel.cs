using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EVEPOSMon
{
    public class DispFuel
    {
           
        public event EventHandler Changed; 
        private DispFuelGroup m_fuelGroup;
        private string name;
        private int amount;
        private int rate;
        private int time;
        private Image image;

        static Dictionary<string, string> icons = new Dictionary<string, string>();

        static DispFuel()
        {
            icons["Helium Isotopes"] = "icon51_13.png";
            icons["Hydrogen Isotopes"] = "icon51_14.png";
            icons["Oxygen Isotopes"] = "icon51_15.png";
            icons["Nitrogen Isotopes"] = "icon51_16.png";

            icons["Liquid Ozone"] = "icon51_11.png";
            icons["Heavy Water"] = "icon51_12.png";
            icons["Strontium Clathrates"] = "icon51_10.png";
            icons["Robotics"] = "icon24_14.png";
            icons["Oxygen"] = "icon10_07.png";
            icons["Mechanical Parts"] = "icon10_10.png";
            icons["Enriched Uranium"] = "icon06_06.png";
            icons["Coolant"] = "icon24_06.png";
        }

        public DispFuel(string n, string a, string r, TimeSpan t)
        {
            int hours = Convert.ToInt32(t.TotalHours);

            name = n;
            amount = Convert.ToInt32(a);
            rate = Convert.ToInt32(r);
            time = hours;
            string basePath = Path.Combine(Application.StartupPath, "icons");
            string fileName = Path.Combine(basePath, icons[name]);
            image = Image.FromFile(fileName);
        }

        public DispFuel(string n, int a, int r, int t)
        {
            name = n;
            amount = a;
            rate = r;
            time = t;
            string basePath = Path.Combine(Application.StartupPath, "icons");
            string fileName = Path.Combine(basePath, icons[name]);
            image = Image.FromFile(fileName);
        }
        

        /// <summary>
        /// Gets the fuel group this skill is part of.
        /// </summary>
        public DispFuelGroup FuelGroup
        {
            get { return m_fuelGroup; }
        }


        internal void SetFuelGroup(DispFuelGroup gsg)
        {
            if (m_fuelGroup != null)
            {
                throw new InvalidOperationException("can only set fuelgroup once");
            }

            m_fuelGroup = gsg;
        }

        #region Appearance in List Box
        // Region & text padding
        private const int IMAGE_OFFSET = 50;
        private const int AMOUNT_OFFSET = 260;
        private const int RATE_OFFSET = 340;
        private const int TIME_OFFSET = 420;

        private const int PAD_TOP = 2;
        private const int PAD_LEFT = 36;
        private const int PAD_RIGHT = 7;
        private const int LINE_VPAD = 0;
        // Boxes
        private const int BOX_WIDTH = 57;
        private const int BOX_HEIGHT = 14;
        private const int SUBBOX_HEIGHT = 8;
        private const int BOX_HPAD = 6;
        private const int BOX_VPAD = 2;
        private const int SKILL_DETAIL_HEIGHT = 31;

        public static int Height
        {
            get
            {
                Font fontr = new Font("Tahoma", 12.0F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
                return Math.Max(fontr.Height * 2 + PAD_TOP + LINE_VPAD + PAD_TOP, SKILL_DETAIL_HEIGHT);
            }
        }

        public void Draw(DrawItemEventArgs e)
        {
            Font fontr = new Font("Tahoma", 14.0F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            Font fonts = new Font("Tohoma", 12.0F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            Font fontt = new Font("Tohoma", 10.0F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            Graphics g = e.Graphics;

            
            if ((e.Index % 2) == 1)
                g.FillRectangle(Brushes.White, e.Bounds);
            else
                g.FillRectangle(Brushes.LightGray, e.Bounds);            
            
            // Image
                g.DrawImage(image, new Rectangle(e.Bounds.Left + 9, e.Bounds.Top + 3, 36, 36));

            string amountString = this.amount.ToString("###,###");
            string rateString = this.rate.ToString("#,###") + "/hr";
            int tmpTime = this.time;
            int weeks = tmpTime / 68;
            tmpTime = tmpTime % 68;
            int days = tmpTime / 24;
            tmpTime = tmpTime % 24;
            int hours = tmpTime;
            string timeString = "";
            if (weeks > 0)
                timeString += weeks.ToString() + "w ";
            if (days > 0)
                timeString += days.ToString() + "d ";
            timeString += hours.ToString() + "h";

            
            string fuelName = this.name;

            // Name
            Size size = TextRenderer.MeasureText(g, fuelName, fontr, new Size(0, 0),
                                                 TextFormatFlags.NoPadding | TextFormatFlags.NoClipping);
            Point topLeftInt = new Point(e.Bounds.Left + 3 + IMAGE_OFFSET,
                                         e.Bounds.Top + ((e.Bounds.Height / 2) - (size.Height / 2)));
            TextRenderer.DrawText(g, fuelName, fontr, topLeftInt, Color.Black);


            

            // Amount
            size = TextRenderer.MeasureText(g, amountString, fonts, new Size(0, 0),
                                            TextFormatFlags.NoPadding | TextFormatFlags.NoClipping);
            topLeftInt = new Point(e.Bounds.Left + 3 + AMOUNT_OFFSET,
                                   e.Bounds.Top + ((e.Bounds.Height / 2) - (size.Height / 2) + 2));
            TextRenderer.DrawText(g, amountString, fonts, topLeftInt, Color.Black);


            // Rate
            size = TextRenderer.MeasureText(g, rateString, fonts, new Size(0, 0),
                                            TextFormatFlags.NoPadding | TextFormatFlags.NoClipping);
            topLeftInt = new Point(e.Bounds.Left + 3 + RATE_OFFSET,
                                   e.Bounds.Top + ((e.Bounds.Height / 2) - (size.Height / 2) + 2));
            TextRenderer.DrawText(g, rateString, fonts, topLeftInt, Color.Black);


            // Time
            size = TextRenderer.MeasureText(g, timeString, fontt, new Size(0, 0),
                                            TextFormatFlags.NoPadding | TextFormatFlags.NoClipping);
            topLeftInt = new Point(e.Bounds.Left + 3 + TIME_OFFSET,
                                   e.Bounds.Top + ((e.Bounds.Height / 2) - (size.Height / 2) + 0));
            TextRenderer.DrawText(g, timeString, fontt, topLeftInt, Color.Black);
                

                

            
        }
        #endregion
        

    }
}
