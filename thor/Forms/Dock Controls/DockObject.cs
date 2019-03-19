/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 28/01/2009
 * Time: 7:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace thor
{
	/// <summary>
	/// Description of DockObject.
	/// </summary>
	public partial class DockObject : DockContent
	{
		public DockObject()
		{
			InitializeComponent();
			/**/this.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Float;
			this.AutoHidePortion = 218;
			this.ShowHint = DockState.DockRight;
			this.TabText = "New Objects";
			this.Text = "New Objects";/**/
			//foreach (BrushInterface b in Accessor.Instance.MasterPrimitiveList) cmbObjectList.Items.Add(b.getName());
		}
		
		public string getSelectedString()
		{
			return cmbObjectList.SelectedItem.ToString();
		}
		
		public void setList(List<string> items)
		{
			cmbObjectList.Items.Clear();
			foreach (string s in items) cmbObjectList.Items.Add(s);
			if (cmbObjectList.Items.Count > 0) cmbObjectList.SelectedIndex = 0;
			cmbObjectList.DropDownHeight = 100;
			if (cmbObjectList.Items.Count > 50) cmbObjectList.DropDownHeight = 200;
		}
		
		public void setSelected(string item)
		{
			if (cmbObjectList.Items.Contains(item)) {
				cmbObjectList.SelectedIndex = cmbObjectList.Items.IndexOf(item);
			}
		}
		
		public void clearList()
		{
			cmbObjectList.Items.Clear();
		}
		
		public void enableList(bool number)
		{
			nudNumber.Enabled = number;
			cmbObjectList.Enabled = true;
		}
		
		public void disableList()
		{
			nudNumber.Enabled = false;
			cmbObjectList.Enabled = false;
		}
		
		public int getNumber()
		{
			return (int)nudNumber.Value;
		}
	}
}
