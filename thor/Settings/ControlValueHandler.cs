/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/06/2009
 * Time: 11:57 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of ControlValueHandler.
	/// </summary>
	public static class ControlValueHandler
	{
		
		public static string getName(Control c)
		{
			string name = c.Name;
			if (name.StartsWith("o_")) {
				name = name.Substring(2);
				if (name.StartsWith("col_")) {
					name = name.Substring(4);
				}
				return name;
			}
			return null;
		}
		
		public static string getValue(Control c)
		{
			string val = "";
			string name = c.Name;
			if (name.StartsWith("o_")) {
				name = name.Substring(2);
				if (name.StartsWith("col_")) {
					name = name.Substring(4);
					val = c.BackColor.ToArgb().ToString();
				} else if (c is RadioButton) {
					if (((RadioButton)c).Checked) val = "true";
					else val = "false";
				} else if (c is CheckBox) {
					if (((CheckBox)c).Checked) val = "true";
					else val = "false";
				} else if (c is NumericUpDown) {
					val = ((NumericUpDown)c).Value.ToString();
				} else if (c is TrackBar) {
					val = ((TrackBar)c).Value.ToString();
				} else { //if (c is ComboBox || c is TextBox) {
					val = c.Text;
				}
			}
			return val;
		}
		
		public static void setValue(Control c, string val)
		{
			string name = c.Name;
			if (name.StartsWith("o_")) {
				name = name.Substring(2);
				if (name.StartsWith("col_")) {
					name = name.Substring(4);
					c.BackColor = Color.FromArgb(int.Parse(val));
				} else if (c is RadioButton) {
					((RadioButton)c).Checked = (val == "true");
				} else if (c is CheckBox) {
					((CheckBox)c).Checked = (val == "true");
				} else if (c is NumericUpDown) {
					((NumericUpDown)c).Value = decimal.Parse(val);
				} else if (c is TrackBar) {
					((TrackBar)c).Value = int.Parse(val);
				} else { //if (c is ComboBox || c is TextBox) {
					c.Text = val;
				}
			}
		}
	}
}
