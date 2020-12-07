using System;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class NoConnectionPage : UserControl
    {
        public NoConnectionPage()
        {
            InitializeComponent();
        }

        public event Action RetryConnection = delegate { };

        private void RetryButton_Click(object sender, EventArgs e)
        {
            // try to show browse page
            // should accomplish this via an event
            RetryConnection.Invoke();
        }
    }
}
