using System;
using System.Windows.Forms;

namespace TextEditor.Properties
{
	public partial class FormL : Form
	{
		public FormL()
		{
			InitializeComponent();
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			Close();		
		}

	}
}
