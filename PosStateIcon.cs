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
            PosStateTip.SetToolTip(this, _state.ToString());  
        }

        private ImageList StateImages;
        private IContainer components;
        private ToolTip PosStateTip;
        private PosState _state = PosState.Anchored;

        public PosState State
        {
            get { return _state; } 
            set {
                if (value == _state)
                    return;
                _state = value;
                PosStateTip.SetToolTip(this, _state.ToString());
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
            this.PosStateTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // StateImages
            // 
            this.StateImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("StateImages.ImageStream")));
            this.StateImages.TransparentColor = System.Drawing.Color.Transparent;
            this.StateImages.Images.SetKeyName(0, "POS-States-2-reinforced.png");
            this.StateImages.Images.SetKeyName(1, "POS-States-2-online.png");
            this.StateImages.Images.SetKeyName(2, "POS-States-2-anchored.png");
            this.StateImages.Images.SetKeyName(3, "POS-States-2-unknown.png");
            // 
            // PosStateIcon
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Size = new System.Drawing.Size(50, 50);
            this.ResumeLayout(false);

        }
    }
}
