using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using TextEditor.Properties;

namespace TextEditor
{
	public partial class Form1 : Form
	{
		String path = "";
		static object[] fontFmailes = Fonts.SystemFontFamilies.OrderBy(f => f.Source).ToArray();
		static List<string> fontFamiles = new List<string>();
		static int start = 0;
		static int indexOfSearchText = 0;

		public Form1()
		{
			InitializeComponent();
			FormL f1 = new FormL();
			f1.ShowDialog();
			Password pas = new Password();
			pas.ShowDialog();
			foreach (object f in Fonts.SystemFontFamilies)
			{
				fontFamiles.Add(f.ToString());
			}
			toolStripComboBox2.Items.AddRange(fontFamiles.ToArray());
			toolStripComboBox2.SelectedItem = fontFmailes[2];
			richTextBox1.Text = fontFmailes[3].ToString();

		}
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.Text = File.ReadAllText(path = openFileDialog1.FileName);
			}
		}
		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(path = saveFileDialog1.FileName, richTextBox1.Text);
			}
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (path != "")
			{
				File.WriteAllText(path, richTextBox1.Text);
			}
			else
			{
				SaveAsToolStripMenuItem_Click(sender, e);
			}
		}
		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.Text != "")
			{
				ExitPrompt();

				if (DialogResult == DialogResult.Yes)
				{
					SaveToolStripMenuItem_Click(sender, e);
					richTextBox1.Text = "";
					path = "";
				}
				else if (DialogResult == DialogResult.No)
				{
					richTextBox1.Text = "";
					path = "";
				}
			}
		}
		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Cut();
		}
		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Copy();
		}
		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Paste();
		}
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void FontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (fontDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.Font = richTextBox1.Font = new Font(fontDialog1.Font, fontDialog1.Font.Style);
				richTextBox1.ForeColor = fontDialog1.Color;
			}
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (richTextBox1.Text != "")
			{
				ExitPrompt();

				if (DialogResult == DialogResult.Yes)
				{
					SaveToolStripMenuItem_Click(sender, e);
				}
				else if (DialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}
		private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.A:
						e.SuppressKeyPress = true;
						richTextBox1.SelectAll();
						break;
					case Keys.N:
						e.SuppressKeyPress = true;
						NewToolStripMenuItem_Click(sender, e);
						break;
					case Keys.S:
						e.SuppressKeyPress = true;
						SaveToolStripMenuItem_Click(sender, e);
						break;
				}
			}
		}
		private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectAll();
		}
		private void ExitPrompt()
		{
			DialogResult = MessageBox.Show("Вы хотите сохранить текущий файл?",
				"Текстовый редактор",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2);
		}
		private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Undo();
		}
		private void MidToolStripButton_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
		}
		private void RightToolStripButton_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
		}
		private void LeftToolStripButton_Click(object sender, EventArgs e)
		{
			richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
		}
		private void ToolStripButton8_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionFont != null)
			{
				System.Drawing.Font currentFont = richTextBox1.SelectionFont;
				System.Drawing.FontStyle newFontStyle;
				if (currentFont.Italic == false) {
					newFontStyle = (currentFont.Style | FontStyle.Italic);
					richTextBox1.SelectionFont = new Font(
					currentFont,
					newFontStyle);
				}
				else
				{
					newFontStyle = (currentFont.Style & ~FontStyle.Italic);
					richTextBox1.SelectionFont = new Font(
					currentFont,
					newFontStyle);
				}
			}
		}
		private void ToolStripButton9_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionFont != null)
			{
				System.Drawing.Font currentFont = richTextBox1.SelectionFont;
				System.Drawing.FontStyle newFontStyle;
				if (currentFont.Bold == false) {
					newFontStyle = (currentFont.Style | FontStyle.Bold);
					richTextBox1.SelectionFont = new Font(
					currentFont,
					newFontStyle);
				}
				else
				{
					newFontStyle = (currentFont.Style & ~FontStyle.Bold);
					richTextBox1.SelectionFont = new Font(
					currentFont,
					newFontStyle);
				}
			}
		}

		private void ToolStripButton10_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionFont != null)
			{
				System.Drawing.Font currentFont = richTextBox1.SelectionFont;
				System.Drawing.FontStyle newFontStyle;
				if (currentFont.Underline == false)
				{					
					newFontStyle = (currentFont.Style | FontStyle.Underline);
					richTextBox1.SelectionFont = new Font(
					currentFont,
					newFontStyle);
				}
				else {
					newFontStyle = (currentFont.Style & ~FontStyle.Underline);
					richTextBox1.SelectionFont = new Font(
					currentFont,
					newFontStyle);
				}
			}
		}

		private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionFont != null)
			{
				System.Drawing.Font currentFont = richTextBox1.SelectionFont;
				richTextBox1.SelectionFont = new Font(currentFont.FontFamily, Single.Parse(toolStripComboBox1.SelectedItem.ToString()), currentFont.Style);
			}
		}

		private void ToolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionFont != null)
			{
				System.Drawing.Font currentFont = richTextBox1.SelectionFont;
				richTextBox1.SelectionFont = new Font(toolStripComboBox2.SelectedItem.ToString(), currentFont.Size, currentFont.Style);
			}
		}

		private void RichTextBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (richTextBox1.SelectionFont != null)
			{
				toolStripComboBox1.SelectedItem = richTextBox1.SelectionFont.Size.ToString();
				toolStripComboBox2.SelectedItem = richTextBox1.SelectionFont.FontFamily.Name.ToString();
			}
			if (toolStripComboBox1.SelectedItem != null)
			{
				toolStripComboBox1.Text = toolStripComboBox1.SelectedItem.ToString();
			}
			if (toolStripComboBox2.SelectedItem != null)
			{
				toolStripComboBox2.Text = toolStripComboBox2.SelectedItem.ToString();
			}
			if (richTextBox1.SelectionColor != null)
			{
				colorStripDropDownButton.BackColor = richTextBox1.SelectionColor;
				if (richTextBox1.SelectionColor.IsNamedColor)
				{
					colorStripDropDownButton.Text = richTextBox1.SelectionColor.Name.ToString();
				}
				else { colorStripDropDownButton.Text = ""; }
				colorStripDropDownButton.BackColor = richTextBox1.SelectionColor;
			}
		}

		private void colorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				richTextBox1.SelectionColor = colorDialog1.Color;
			}
		}

		private void FindToolStripMenuItem_Click(object sender, EventArgs e)
		{
			groupBox1.Visible = true;
		}
		private void btnFind_Click(object sender, EventArgs e)
		{
			int startindex = 0;

			if (txtSearch.Text.Length > 0)
				startindex = FindMyText(txtSearch.Text.Trim(), start, richTextBox1.Text.Length);

			// Если строка найдена в RichTextBox, выделите ее
			if (startindex >= 0)
			{
				// Установить цвет подсветки как красный
				richTextBox1.SelectionColor = System.Drawing.Color.Red;
				// Найти конечный индекс. Конечный индекс = количество символов в текстовом поле
				int endindex = txtSearch.Text.Length;
				// Выделить строку поиска
				richTextBox1.Select(startindex, endindex);
				// отмечаем начальную позицию после позиции
				// последняя строка поиска
				start = startindex + endindex;
			}
		}
		public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
		{


			// Set the return value to -1 by default.
			int retVal = -1;

			// A valid starting index should be specified.
			// if indexOfSearchText = -1, the end of search
			if (searchStart >= 0 && indexOfSearchText >= 0)
			{
				// A valid ending index
				if (searchEnd > searchStart || searchEnd == -1)
				{
					// Find the position of search string in RichTextBox
					indexOfSearchText = richTextBox1.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None);
					// Determine whether the text was found in richTextBox1.
					if (indexOfSearchText != -1)
					{
						// Return the index to the specified search text.
						retVal = indexOfSearchText;
					}
				}
			}
			return retVal;
		}
		

		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			start = 0;
			indexOfSearchText = 0;
			txtSearch.Text = "";
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			groupBox1.Visible = false;
			if (indexOfSearchText > 0)
			{
				richTextBox1.Undo();
			}
		}

		private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			groupBox2.Visible = true;
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			int startindex = 0;

			if (txtSearch1.Text.Length > 0)
				startindex = FindMyText(txtSearch1.Text.Trim(), start, richTextBox1.Text.Length);

			// Если строка найдена в RichTextBox, выделите ее
			if (startindex >= 0)
			{			
				// Найти конечный индекс. Конечный индекс = количество символов в текстовом поле
				int endindex = txtSearch1.Text.Length;
				// Выделить строку поиска
				richTextBox1.Select(startindex, endindex);
				richTextBox1.SelectedText = textBox2.Text;
				// отмечаем начальную позицию после позиции
				// последняя строка поиска
				start = startindex + endindex;
			}
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			groupBox2.Visible = false;
			txtSearch1.Text = "Поиск";
			textBox2.Text = "Замена";
		}

	}
}

