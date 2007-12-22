using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace EVEPOSMon
{
    public class DispFuelGroup : IEnumerable<Fuel>
    {

        private string m_name;
        private int m_ID;
        private Dictionary<string, Fuel> m_fuels = new Dictionary<string, Fuel>();

        public DispFuelGroup(string n)
        {
            m_name = n;
        }

        private int m_cachedKnownCount = -1;

        private void gs_Changed(object sender, EventArgs e)
        {
            m_cachedKnownCount = -1;
        }

        public int ID
        {
            get { return m_ID; }
        }

        public string Name
        {
            get { return m_name; }
        }

        public Fuel this[string name]
        {
            get
            {
                Fuel result;
                m_fuels.TryGetValue(name, out result);
                return result;
            }
        }

        public int Count
        {
            get { return m_fuels.Count; }
        }


        public bool Contains(string fuelName)
        {
            return m_fuels.ContainsKey(fuelName);
        }

        public bool Contains(Fuel gs)
        {
            return m_fuels.ContainsValue(gs);
        }
        
        public IEnumerator<Fuel> GetEnumerator()
        {
            foreach (Fuel gs in m_fuels.Values)
            {
                yield return gs;
            }
        }
        

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        internal void InsertFuel(Fuel gs)
        {
            m_fuels[gs.typeId] = gs;
            //gs.Changed += new EventHandler(gs_Changed);
            //gs.SetFuelGroup(this);

            gs_Changed(this, new EventArgs());
        }

        #region Appearance in List box
        private static Image m_collapseImage;
        private static Image m_expandImage;
        private bool m_collapsed;

        public bool isCollapsed
        {
            get { return m_collapsed; }
            set
            {
                if (m_collapsed != value)
                {
                    m_collapsed = value;
                }
            }
        }

        public static Image CollapseImage
        {
            get
            {
                string basePath = Path.Combine(Application.StartupPath, "icons");
                string fileName = Path.Combine(basePath, "collapsed.png");
                return Image.FromFile(fileName);
            }
        }

        public static Image ExpandImage
        {
            get
            {
                string basePath = Path.Combine(Application.StartupPath, "icons");
                string fileName = Path.Combine(basePath, "expanded.png");
                return Image.FromFile(fileName);
            }
        }

        private const int FUEL_HEADER_HEIGHT = 25;

        private const int FG_COLLAPSER_PAD_RIGHT = 6;

        public static int Height
        {
            get { return FUEL_HEADER_HEIGHT; }
        }

        public void Draw(DrawItemEventArgs e)
        {
            Font fontr = new Font("Tahoma", 10.0F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
            Graphics g = e.Graphics;
            bool hasemptyfuel = false;
            foreach (Fuel gs in m_fuels.Values)
            {
                if (Convert.ToUInt32(gs.quantity) == 0)
                {
                    hasemptyfuel = true;
                    break;
                }
            }

            using (Brush b = new SolidBrush(Color.FromArgb(75, 75, 75)))
            {
                g.FillRectangle(b, e.Bounds);
            }
            using (Pen p = new Pen(Color.FromArgb(100, 100, 100)))
            {
                g.DrawLine(p, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right + 1, e.Bounds.Top);
            }
            using (Font boldf = new Font(fontr, FontStyle.Bold))
            {
                Size titleSizeInt = TextRenderer.MeasureText(g, this.Name, boldf, new Size(0, 0),
                                                             TextFormatFlags.NoPadding | TextFormatFlags.NoClipping);
                Point titleTopLeftInt = new Point(e.Bounds.Left + 3,
                                                  e.Bounds.Top + ((e.Bounds.Height / 2) - (titleSizeInt.Height / 2)));
                
               
                TextRenderer.DrawText(g, this.Name, boldf, titleTopLeftInt, Color.White);
            }
            Image i;
            if (isCollapsed)
            {
                i = ExpandImage;
            }
            else
            {
                i = CollapseImage;
            }
            
            g.DrawImageUnscaled(i, new Point(e.Bounds.Right - i.Width - FG_COLLAPSER_PAD_RIGHT,
                                             (FUEL_HEADER_HEIGHT / 2) - (i.Height / 2) + e.Bounds.Top));
        }

        public Rectangle GetButtonRectangle(Rectangle itemRect)
        {
            Image btnImage;
            if (isCollapsed)
            {
                btnImage = ExpandImage;
            }
            else
            {
                btnImage = CollapseImage;
            }
            Size btnSize = btnImage.Size;
            Point btnPoint = new Point(itemRect.Right - btnImage.Width - FG_COLLAPSER_PAD_RIGHT,
                                       (FUEL_HEADER_HEIGHT / 2) - (btnImage.Height / 2) + itemRect.Top);
            return new Rectangle(btnPoint, btnSize);
        }
        #endregion
    }
}
