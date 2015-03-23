using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBTVSendeplanCS
{
    public partial class PlanForm : Form
    {
        public PlanForm()
        {
            InitializeComponent();
        }
        public virtual void RbtvEventsLoaded(List<RbtvEvent> e)
        {
        }
    }
}
