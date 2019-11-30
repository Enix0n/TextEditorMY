using System;
using System.Windows.Forms;

namespace TextEditor
{
	public partial class Password : Form
	{
		static int count = 3;
		static bool flag = false;
		public Password()
		{
			InitializeComponent();
		}

		private void Password_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!flag)
			{
				Application.Exit();
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (count > 0)
			{
				if (passwordBox.Text == "91011")
				{
					flag = true;
					Close();
				}
				else
				{
					passwordBox.Text = "";
					count--;
				}
			}
			else Application.Exit();
		}
	}
}
