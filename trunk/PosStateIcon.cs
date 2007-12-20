using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace EVEPOSMon
{
    public partial class PosStateIcon : Panel
    {
        public enum PosState
        {
            Reinforced,
            Online,
            Anchored,
            Unknown
            
        };

        public PosStateIcon()
        {
            InitializeComponent();
        }

        private ImageList StateImages;
        private IContainer components;
        private PosState _state = PosState.Anchored;

        public PosState State
        {
            get { return _state; } 
            set {
                if (value == _state)
                    return;
                _state = value;
                InvalidateEx();
                this.Invalidate();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
                return;
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do Nothing
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(StateImages.Images[(int)_state], 0, 0);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PosStateIcon));
            this.StateImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // StateImages
            // 
            this.StateImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StateImages.ImageStream")));
            this.StateImages.TransparentColor = System.Drawing.Color.Transparent;
            this.StateImages.Images.SetKeyName(0, "POS-States-blue.png");
            this.StateImages.Images.SetKeyName(1, "POS-States-green.png");
            this.StateImages.Images.SetKeyName(2, "POS-States-grey.png");
            this.StateImages.Images.SetKeyName(3, "POS-States-red.png");
            // 
            // PosStateIcon
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Size = new System.Drawing.Size(43, 50);
            this.ResumeLayout(false);

        }
    }
}
