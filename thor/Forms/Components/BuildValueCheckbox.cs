/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/07/2009
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	public enum BuildValueCheckboxType
	{
		Bool,
		Text,
		File,
		Integer,
		Decimal,
		DropDown,
		Colour,
		ColourBrightness
	}
	/// <summary>
	/// Description of BuildValueCheckbox.
	/// </summary>
	public partial class BuildValueCheckbox : BuildControl
	{
		public event EventHandler Changed;
		
		private BuildValueCheckboxType valueType;
		private int checkWidth;
		private int valueWidth;
		private string dropDownFormatting;
		
		
		[DefaultValue("")]
		public string DropDownFormatting {
			get { return dropDownFormatting; }
			set { dropDownFormatting = value; }
		}
		
		[DefaultValue(0)]
		public int CheckWidth {
			get { return checkWidth; }
			set { checkWidth = value; setDisplay(); }
		}
		
		[DefaultValue(0)]
		public int ValueWidth {
			get { return valueWidth; }
			set { valueWidth = value; setDisplay(); }
		}
		
		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(true), MergableProperty(false)]
		public ComboBox.ObjectCollection DropDownItems {
			get { return cmbValue.Items; }
		}
		
		[DefaultValue(BuildValueCheckboxType.Bool)]
		public BuildValueCheckboxType ValueType {
			get { return valueType; }
			set { valueType = value; setDisplay(); }
		}
		
		public string Label {
			get { return chkEnabled.Text; }
			set { chkEnabled.Text = value; setDisplay(); }
		}
		
		public decimal MaxValue {
			get { return nudValue.Maximum; }
			set { nudValue.Maximum = value; }
		}
		
		public decimal MinValue {
			get { return nudValue.Minimum; }
			set { nudValue.Minimum = value; }
		}
		
		public decimal NumValue {
			get { return nudValue.Value; }
			set { nudValue.Value = value; }
		}
		
		public string TextValue {
			get { return txtValue.Text; }
			set { txtValue.Text = value; }
		}
		
		public bool Checked {
			get { return chkEnabled.Checked; }
			set { chkEnabled.Checked = value; }
		}
		
		public BuildValueCheckbox()
		{
			InitializeComponent();
			cmbValue.Items.Clear();
			valueType = BuildValueCheckboxType.Bool;
			checkWidth = valueWidth = 0;
			dropDownFormatting = "";
		}
		
		protected virtual void OnChanged(EventArgs e) 
		{
			if (Changed != null)
				Changed(this, e);
		}
		
		public override void setToolTipText(string s)
		{
			tipHelper.SetToolTip(chkEnabled, s);
			base.setToolTipText(s);
		}
		
		private void setDisplay()
		{
			if (checkWidth == 0 && valueWidth == 0) {
				Bitmap b = new Bitmap(1,1);
				Graphics g = Graphics.FromImage(b);
				int wid = (int)g.MeasureString(Label,Font).Width;
				g.Dispose();
				b.Dispose();
				
				chkEnabled.Width = 25 + wid;
			}
			
			int x, y, w, h;
			y = chkEnabled.Location.Y;
			
			if (checkWidth > 0) {
				chkEnabled.Width = checkWidth;
			}
			
			x = chkEnabled.Width + 3;
			
			if (valueWidth > 0) {
				x = Width - 3 - valueWidth;
				if (checkWidth == 0) {
					chkEnabled.Width = x - 6;
				}
			}
			
			w = Width - x - 3;
			h = chkEnabled.Height;
			
			nudValue.Location = new Point(x, y);
			nudValue.Size = new Size(w, h);
			cmbValue.Location = new Point(x, y);
			cmbValue.Size = new Size(w, h);
			txtValue.Location = new Point(x, y);
			txtValue.Size = new Size(w, h);
			btnBrowse.Location = new Point(x, y);
			btnBrowse.Size = new Size(w, h);
			pnlColour.Location = new Point(x, y);
			pnlColour.Size = new Size(w, h);
			
			nudValue.Visible = false;
			cmbValue.Visible = false;
			txtValue.Visible = false;
			btnBrowse.Visible = false;
			pnlColour.Visible = false;
			
			switch (valueType) {
				case BuildValueCheckboxType.Bool:
					chkEnabled.Size = new Size(Width - 3, chkEnabled.Height);
					break;
				case BuildValueCheckboxType.Decimal:
					nudValue.Visible = true;
					nudValue.Increment = 0.1m;
					nudValue.DecimalPlaces = 1;
					break;
				case BuildValueCheckboxType.Integer:
					nudValue.Visible = true;
					nudValue.Increment = 1;
					nudValue.DecimalPlaces = 0;
					break;
				case BuildValueCheckboxType.DropDown:
					cmbValue.Visible = true;
					break;
				case BuildValueCheckboxType.File:
					btnBrowse.Visible = true;
					txtValue.Visible = true;
					btnBrowse.Width = 25;
					btnBrowse.Location =  new Point(x + w - 25, y);
					txtValue.Width -= 28;
					break;
				case BuildValueCheckboxType.Text:
					txtValue.Visible = true;
					break;
				case BuildValueCheckboxType.Colour:
					pnlColour.Visible = true;
					break;
				case BuildValueCheckboxType.ColourBrightness:
					pnlColour.Visible = true;
					nudValue.Visible = true;
					nudValue.Width = 40;
					nudValue.Location =  new Point(x + w - 40, y);
					pnlColour.Width -= 45;
					nudValue.Increment = 1;
					nudValue.DecimalPlaces = 0;
					break;
				default:
					throw new Exception();
			}
			
			if (cmbValue.Items.Count > 0) cmbValue.SelectedIndex = 0;
			Refresh();
		}
		
		public override string getCommandLine()
		{
			if (!chkEnabled.Checked) return "";
			string cmdline = commandLineSwitch;
			switch (valueType) {
				case BuildValueCheckboxType.Bool:
					break;
				case BuildValueCheckboxType.Decimal:
					cmdline += " " + nudValue.Value.ToString("0.0");
					break;
				case BuildValueCheckboxType.Integer:
					cmdline += " " + (int)Math.Round(nudValue.Value,0);
					break;
				case BuildValueCheckboxType.DropDown:
					cmdline += " ";
					if (dropDownFormatting != "") {
						string[] cst = dropDownFormatting.Split('?');
						try {
							cmdline = cst[cmbValue.SelectedIndex];
							cmdline = cmdline.Replace("switch", commandLineSwitch);
							cmdline = cmdline.Replace("value", cmbValue.SelectedText);
							cmdline = cmdline.Replace("index", cmbValue.SelectedIndex.ToString());
							break;
						} catch (Exception) { }
					}
					cmdline += cmbValue.SelectedItem.ToString();
					break;
				case BuildValueCheckboxType.File:
					cmdline += " \"" + txtValue.Text + "\"";
					break;
				case BuildValueCheckboxType.Text:
					cmdline += " " + txtValue.Text;
					break;
				case BuildValueCheckboxType.Colour:
					cmdline += " ";
					cmdline += (((decimal)pnlColour.BackColor.R) / 255).ToString("0.0000");
					cmdline += " ";
					cmdline += (((decimal)pnlColour.BackColor.G) / 255).ToString("0.0000");
					cmdline += " ";
					cmdline += (((decimal)pnlColour.BackColor.B) / 255).ToString("0.0000");
					break;
				case BuildValueCheckboxType.ColourBrightness:
					cmdline += " ";
					cmdline += (((decimal)pnlColour.BackColor.R) / 255).ToString("0.0000");
					cmdline += " ";
					cmdline += (((decimal)pnlColour.BackColor.G) / 255).ToString("0.0000");
					cmdline += " ";
					cmdline += (((decimal)pnlColour.BackColor.B) / 255).ToString("0.0000");
					cmdline += " ";
					cmdline += ((nudValue.Value) / 255).ToString("0.0000");
					break;
				default:
					throw new Exception();
			}
			return cmdline;
		}
		
		public override void setCommandLine(string str)
		{
			string[] split = str.Split(' ');
			decimal d;
			int num = 0;
			decimal[] col = new decimal[4];
			string s = "";
			List<string> tmp = new List<string>();
			for (int i = 0; i < split.Length; i++) {
				if (i > 0 && split[i].StartsWith("-")) {
					tmp.Add(s);
					s = "";
					num = 0;
				}
				if (num > 0) s += " ";
				s += split[i];
				num++;
			}
			tmp.Add(s);
			string[] tags = tmp.ToArray();
			tmp.Clear();
			foreach (string tag in tags) {
				string[] spl = tag.Split(' ');
				switch (valueType) {
					case BuildValueCheckboxType.Bool:
						if (spl.Length == 1 && spl[0] == commandLineSwitch) {
							chkEnabled.Checked = true;
						}
						break;
					case BuildValueCheckboxType.Decimal:
						if (spl.Length == 2 && spl[0] == commandLineSwitch && decimal.TryParse(spl[1], out d) && d >= nudValue.Minimum && d <= nudValue.Maximum) {
							chkEnabled.Checked = true;
							nudValue.Value = Math.Round(d, 1);
						}
						break;
					case BuildValueCheckboxType.Integer:
						if (spl.Length == 2 && spl[0] == commandLineSwitch && int.TryParse(spl[1], out num) && num >= nudValue.Minimum && num <= nudValue.Maximum) {
							chkEnabled.Checked = true;
							nudValue.Value = num;
						}
						break;
					case BuildValueCheckboxType.DropDown:
						/*cmdline += " ";
						if (dropDownFormatting != "") {
							string[] cst = dropDownFormatting.Split('?');
							try {
								cmdline = cst[cmbValue.SelectedIndex];
								cmdline = cmdline.Replace("switch", commandLineSwitch);
								cmdline = cmdline.Replace("value", cmbValue.SelectedText);
								cmdline = cmdline.Replace("index", cmbValue.SelectedIndex.ToString());
								break;
							} catch (Exception) { }
						}
						cmdline += cmbValue.SelectedItem.ToString();*/
						if (dropDownFormatting != "") {
							string[] cst = dropDownFormatting.Split('?');
							bool ddf = false;
							for (int j = 0; j < cmbValue.Items.Count; j++) {
								if (cst.Length == cmbValue.Items.Count) s = cst[j];
								else s = dropDownFormatting;
								s = s.Replace("switch", commandLineSwitch);
								s = s.Replace("value", cmbValue.Items[j].ToString());
								s = s.Replace("index", j.ToString());
								if (tag == s) {
									ddf = true;
									chkEnabled.Checked = true;
									cmbValue.SelectedIndex = j;
									break;
								}
							}
							if (ddf) break;
						}
						if (spl.Length == 2 && spl[0] == commandLineSwitch && cmbValue.Items.IndexOf(spl[1]) >= 0) {
							chkEnabled.Checked = true;
							cmbValue.SelectedIndex = cmbValue.Items.IndexOf(spl[1]);
						}
						break;
					case BuildValueCheckboxType.File:
						if (spl.Length == 2 && spl[0] == commandLineSwitch && spl[1].StartsWith("\"") && spl[1].EndsWith("\"")) {
							chkEnabled.Checked = true;
							txtValue.Text = spl[1];
						}
						break;
					case BuildValueCheckboxType.Text:
						if (spl.Length == 2 && spl[0] == commandLineSwitch) {
							chkEnabled.Checked = true;
							txtValue.Text = spl[1];
						}
						break;
					case BuildValueCheckboxType.Colour:
						if (spl.Length == 4 && spl[0] == commandLineSwitch &&
						    decimal.TryParse(spl[1], out col[0]) && col[0] >= 0 && col[0] <= 1 && 
						    decimal.TryParse(spl[2], out col[1]) && col[1] >= 0 && col[1] <= 1 && 
						    decimal.TryParse(spl[3], out col[2]) && col[2] >= 0 && col[2] <= 1)
						{
							chkEnabled.Checked = true;
							pnlColour.BackColor = Color.FromArgb((int)(col[0] * 255), (int)(col[1] * 255), (int)(col[2] * 255));
						}
						break;
					case BuildValueCheckboxType.ColourBrightness:
						if (spl.Length == 5 && spl[0] == commandLineSwitch &&
						    decimal.TryParse(spl[1], out col[0]) && col[0] >= 0 && col[0] <= 1 && 
						    decimal.TryParse(spl[2], out col[1]) && col[1] >= 0 && col[1] <= 1 && 
						    decimal.TryParse(spl[3], out col[2]) && col[2] >= 0 && col[2] <= 1 && 
						    decimal.TryParse(spl[4], out col[3]) && col[3] >= 0 && col[3] <= 1)
						{
							chkEnabled.Checked = true;
							pnlColour.BackColor = Color.FromArgb((int)(col[0] * 255), (int)(col[1] * 255), (int)(col[2] * 255));
							nudValue.Value = Math.Round(col[3] * 255);
						}
						break;
					default:
						throw new Exception();
				}
				if (chkEnabled.Checked) break;
			}
		}
		
		void BtnBrowseClick(object sender, EventArgs e)
		{
			OpenFileDialog file = new OpenFileDialog();
			file.Multiselect = false;
			if (file.ShowDialog() == DialogResult.OK) {
				txtValue.Text = file.FileName;
			}
			file.Dispose();
		}
		
		void PnlColourClick(object sender, EventArgs e)
		{
			ColorDialog clr = new ColorDialog();
			if (clr.ShowDialog() == DialogResult.OK) {
				pnlColour.BackColor = clr.Color;
			}
			clr.Dispose();
		}
		
		protected override void OnResize(EventArgs e)
		{
			setDisplay();
			base.OnResize(e);
		}
		
		void ChkEnabledCheckedChanged(object sender, EventArgs e)
		{
			OnChanged(e);
		}
		
		void NudValueValueChanged(object sender, EventArgs e)
		{
			OnChanged(e);
		}
		
		void TxtValueTextChanged(object sender, EventArgs e)
		{
			OnChanged(e);
		}
		
		void CmbValueSelectedIndexChanged(object sender, EventArgs e)
		{
			OnChanged(e);
		}
		
		void PnlColourBackColorChanged(object sender, EventArgs e)
		{
			OnChanged(e);
		}
	}
}
