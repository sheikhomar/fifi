using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fifi.WinUI
{
    public partial class BaseForm : Form
    {
        /// <summary>
        /// Since UI controls can only be modified by the UI thread, we
        /// need an SychronizationContext object for our Task.
        /// Source: http://www.codeproject.com/Articles/152765/Task-Parallel-Library-of-n
        /// </summary>
        protected readonly TaskScheduler FormTaskScheduler;

        public BaseForm()
        {
            InitializeComponent();

            FormTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }
    }
}
