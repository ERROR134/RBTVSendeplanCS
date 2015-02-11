using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RBTVSendeplanCS
{
    public partial class PlanGUI : UserControl
    {

        private int scrollOffset = 0;

        private List<RbtvEvent> events_;

        //list containing the events
        public List<RbtvEvent> Events
        {
            get
            {
                return this.events_;
            }
        }

        private Bitmap plan;

        

        public PlanGUI()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            events_ = new List<RbtvEvent>();
            //events_.ItemCountChanged += new MyList<RbtvEvent>.ItemCountChangedHandler(this.ListItemCountChanged);
        }

        private void ListItemCountChanged(int oldCount, int newCount, MyList<RbtvEvent> sender)
        {
            updateControl();
         }

        private void  ControlLoad(object sender, EventArgs e)
        {
            updateControl();
        }

        public void updateEvents(List<RbtvEvent> events)
        {
            events_ = events;
        }

        //paints the control (only use when the size changes, because the events doesn't update
        private void ControlPaint(object sender, PaintEventArgs e)
        {
            int x = this.Size.Width;
            int y = this.Size.Height;

            int verhaeltnis = x / 16 - y / 9;

            if (verhaeltnis == 0)
            {
                e.Graphics.DrawImage(plan,0,0,x,y);
            }
            else if(verhaeltnis > 0)
            {
                e.Graphics.DrawImage(plan,0,0,x,(int) x/ 16 * 9);
            }
            else
            {
                e.Graphics.DrawImage(plan,(int) (x - (y / 9 * 16)) / 2, 0, (int) y / 9 * 16 ,y);
            }
        }

        //updates the control
        public void updateControl()
        {
            plan = new Bitmap(RBTVSendeplanCS.Properties.Resources.template);
            Graphics g = Graphics.FromImage(plan);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Font dateFont = new Font("Arial", 55, FontStyle.Bold, GraphicsUnit.Pixel);
            Font monthFont = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);

            Font timeFont = new Font("LetterOMatic!", 21, FontStyle.Regular, GraphicsUnit.Pixel);//LetterOMatic!
            Font eventFont = new Font("LetterOMatic!", 18, FontStyle.Regular, GraphicsUnit.Pixel);

            SolidBrush timeBrush = new SolidBrush(Color.FromArgb(12, 65, 128));
            SolidBrush eventBrush = new SolidBrush(Color.FromArgb(9, 10, 0));

            //Zeichnet das Datum in den Kalender

            DateTime firstElement;
            if(events_.Count > scrollOffset)
                  firstElement = events_[scrollOffset].Start;
            else
                 firstElement = DateTime.Now ;


            g.DrawString(getDateString(firstElement), dateFont, new SolidBrush(Color.FromArgb(35, 17, 12)), new Rectangle(824, 187, 124, 76), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            //Zeichnet den Monat in den Kalender
            g.DrawString(getMonthString(firstElement), monthFont, new SolidBrush(Color.FromArgb(255, 255, 255)), new Rectangle(824, 163, 121, 22), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });



            //Zeichnet die Uhrzeiten
            Rectangle[] zeitenRectangles = {
		new Rectangle(380, 184, 79, 25),
		new Rectangle(386, 230, 79, 25),
		new Rectangle(376, 280, 79, 25),
		new Rectangle(384, 330, 79, 25),
		new Rectangle(386, 380, 79, 25),
		new Rectangle(375, 425, 79, 25),
		new Rectangle(382, 475, 79, 25),
		new Rectangle(386, 525, 79, 25)
	};

            int i = 0;
            while (i + scrollOffset< events_.Count & i < zeitenRectangles.Length)
            {
                g.DrawString(events_[i + scrollOffset].Start.ToString("HH:mm"), timeFont, timeBrush, zeitenRectangles[i], new StringFormat { Alignment = StringAlignment.Center });
                i += 1;
            }

            Matrix rotate = new Matrix();


            //Zeichnet die Events
            rotate.RotateAt((float)1.2, new PointF((float)520, (float)0));
            g.Transform = rotate;

            Rectangle[] namenRectangles = {
		new Rectangle(520, 184, 290, 25),
		new Rectangle(515, 255, 290, 25),
		new Rectangle(520, 270, 310, 25),
		new Rectangle(520, 357, 310, 25),
		new Rectangle(540, 370, 310, 25),
		new Rectangle(496, 463, 310, 25),
		new Rectangle(535, 475, 310, 25),
		new Rectangle(510, 545, 310, 25)
	};
            double[] transformations = {
		0,
		-3,
		3.4,
		-3.2,
		3,
		-4.1,
		4,
		-2.2
	};


            i = 0;
            while (i + scrollOffset < events_.Count & i< namenRectangles.Length)
            {
                g.RotateTransform((float)transformations[i]);
                g.DrawString(events_[i + scrollOffset].Name, eventFont, eventBrush, namenRectangles[i]);
                i += 1;
            }

            //Ändert die Scrollbar Maximumwerte

            int scrollMax = (events_.Count - 7) * 10;
            if (scrollMax > 0)
                scrollBar.Maximum = scrollMax;
            else
                scrollBar.Maximum = 0;

            this.Refresh();
        }

        //return the the day
        private string getDateString(DateTime pDate)
        {
            int day = pDate.Day;
            if (day < 10)
            {
                return "0" + day + ".";
            }
            else
            {
                return day + ".";
            }
        }

        //return the month
        private string getMonthString(DateTime pDate)
        {
            int month = pDate.Month;
            String[] monthNames = { "Jan", "Feb", "Mär", "Apr", "Mai", "Jun", "Jul", "Aug", "Sep", "Nov", "Dez" };
            return monthNames[month - 1];
        }

        private void ControlSizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        
        private void scrollBarScroll(object sender, ScrollEventArgs e)
        {
            int old = scrollOffset;
            scrollOffset = e.NewValue / 10;
            if (old != scrollOffset)
            {
                updateControl();
            }
        }

       private void mouseWheel(object sender, EventArgs e)
        {
            HandledMouseEventArgs args = (HandledMouseEventArgs)e;
           try
           {
               scrollBar.Value -= args.Delta / 10;
              int old = scrollOffset;
              scrollOffset = scrollBar.Value / 10;
                if (old != scrollOffset)
                {
                    updateControl();
                }
           }
           catch(Exception ex)
           {
              
           }
        }



    }
}
