/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/01/2009
 * Time: 2:48 PM
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
	/// Description of FGDEditor.
	/// </summary>
	public partial class FGDEditor : Form
	{
		private bool open;
		private GameData openFile;
		private GameDataObject selectedClass;
		public FGDEditor()
		{
			InitializeComponent();
			open = false;
			openFile = null;
			selectedClass = null;
			cmbFilter.SelectedIndex = 0;
			cmbBehaviourType.SelectedIndex = 0;
		}
		
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();
			d.Filter = "Forge Game Data Files (*.fgd)|*.fgd";
			if (d.ShowDialog() == DialogResult.OK) {
				FGDParser p = new FGDParser();
				openFile = p.parseForEditing(d.FileName);
				Text = "FGD Editor - " + System.IO.Path.GetFileName(d.FileName);
				open = true;
				updateFields();
			}
		}
		
		void clearAllFields()
		{
			lstClass.Items.Clear();
			lstIncludes.Items.Clear();
			txtIncludeAdd.Text = "";
			txtMapSizeHigh.Text = "";
			txtMapSizeLow.Text = "";
			clearItemFields(true);
		}
		
		void clearItemFields(bool complete)
		{
			//behaviour tab
			lstBaseClasses.Items.Clear();
			cmbBaseClassAdd.Items.Clear();
			lstBehaviours.Items.Clear();
			txtClassDescription.Text = "";
			//properties tab
			lstProperties.Items.Clear();
			//io tab
			lstIO.Items.Clear();
			//flags tab
			lstFlags.Items.Clear();
			//preview tab
			txtPreview.Text = "";
			if (complete) {
				txtBehaviourValue.Text = "";
				selectedClass = null;
			}
		}
		
		void updateFields()
		{
			clearAllFields();
			if (!open || (object)openFile == null) return;
			//populate class list
			List<GameDataObject> classes = openFile.getClasses(
				(GameDataClassTypes)Enum.Parse(typeof(GameDataClassTypes),cmbFilter.SelectedItem.ToString(),true));
			foreach (GameDataObject o in classes) {
				lstClass.Items.Add(o.Name);
			}
			//populate include list
			foreach (string s in openFile.Includes) {
				lstIncludes.Items.Add(s);
			}
			//populate map sizes
			if (openFile.SizeSet) {
				txtMapSizeHigh.Text = openFile.MapSizeHigh.ToString();
				txtMapSizeLow.Text = openFile.MapSizeLow.ToString();
			}
		}
		
		void CmbFilterSelectedIndexChanged(object sender, EventArgs e)
		{
			updateFields();
		}
		
		void updateItemFields()
		{
			clearItemFields(false);
			if (!open || (object)openFile == null) return;
			if ((object)selectedClass == null) return;
			//populate base class list
			List<string> baseclasses = selectedClass.BaseClasses;
			foreach (string s in baseclasses) {
				lstBaseClasses.Items.Add(s);
			}
			//populate base addition list
			List<GameDataObject> classes = openFile.getClasses(GameDataClassTypes.Any);
			foreach (GameDataObject o in classes) {
				cmbBaseClassAdd.Items.Add(o.Name);
			}
			//populate class description
			txtClassDescription.Text = selectedClass.Description;
			//populate behaviour list
			List<GameDataBehaviour> behavs = selectedClass.Behaviours;
			foreach (GameDataBehaviour b in behavs) {
				lstBehaviours.Items.Add(new ListViewItem(new string[] { b.Name, b.Value }));
			}
			//populate property list
			GameDataProperty flags = null;
			List<GameDataProperty> props = selectedClass.Properties;
			foreach (GameDataProperty p in props) {
				if (p.Name == "spawnflags") {
					flags = p;
					continue;
				}
				lstProperties.Items.Add(new ListViewItem(new string[] { p.Name, p.OrigType, p.ShortDescription, p.DefaultValue, p.LongDescription }));
			}
			//populate io list
			List<GameDataIO> ios = selectedClass.IO;
			foreach (GameDataIO io in ios) {
				lstIO.Items.Add(new ListViewItem(new string[] { io.IOType.ToString(), io.Name, io.OrigType, io.Description }));
			}
			//populate flags list
			if ((object)flags != null)
			{
				foreach (GameDataChoice c in flags.Choices) {
					lstFlags.Items.Add(new ListViewItem(new string[] { c.Key, c.Description, ((c.IsOn)?"1":"0") }));
				}
			}
			//update preview
			txtPreview.Text = selectedClass.ToString();
		}
		
		void LstClassSelectedIndexChanged(object sender, EventArgs e)
		{
			clearItemFields(true);
			if (!open || (object)openFile == null) return;
			if (lstClass.SelectedItems.Count == 0) return;
			//get our class to work with
			selectedClass = openFile.getClass(lstClass.SelectedItems[0].Text,
			                                  (GameDataClassTypes)Enum.Parse(
			                                  	typeof(GameDataClassTypes),
			                                  	cmbFilter.SelectedItem.ToString(),true
			                                  ));
			updateItemFields();
		}
		
		void BtnBaseClassAddClick(object sender, EventArgs e)
		{
			if (cmbBaseClassAdd.Text == "") return;
			selectedClass.BaseClasses.Add(cmbBaseClassAdd.Text);
			updateItemFields();
		}
		
		void BtnBaseClassRemoveClick(object sender, EventArgs e)
		{
			if (lstBaseClasses.SelectedIndex < 0) return;
			int temp = lstBaseClasses.SelectedIndex;
			selectedClass.BaseClasses.RemoveAt(temp);
			updateItemFields();
			if (lstBaseClasses.Items.Count == temp) temp--;
			lstBaseClasses.SelectedIndex = temp;
		}
		
		void LstBehavioursSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstBehaviours.SelectedItems.Count == 0) return;
			ListViewItem lvi = lstBehaviours.SelectedItems[0];
			cmbBehaviourType.Text = lvi.SubItems[0].Text;
			txtBehaviourValue.Text = lvi.SubItems[1].Text;
		}
		
		void BtnBehaviourApplyClick(object sender, EventArgs e)
		{
			if (lstBehaviours.SelectedItems.Count == 0) return;
			string key = cmbBehaviourType.Text;
			if (key == "") return;
			string val = txtBehaviourValue.Text;
			GameDataBehaviour b = new GameDataBehaviour(key,val);
			selectedClass.Behaviours[lstBehaviours.SelectedIndices[0]] = b;
			updateItemFields();
		}
		
		void BtnBehaviourNewClick(object sender, EventArgs e)
		{
			string key = cmbBehaviourType.Text;
			if (key == "") return;
			string val = txtBehaviourValue.Text;
			GameDataBehaviour b = new GameDataBehaviour(key,val);
			selectedClass.Behaviours.Add(b);
			updateItemFields();
		}
		
		void BtnBehaviourRemoveClick(object sender, EventArgs e)
		{
			if (lstBehaviours.SelectedItems.Count == 0) return;
			int temp = lstBehaviours.SelectedIndices[0];
			selectedClass.Behaviours.RemoveAt(temp);
			updateItemFields();
		}
		
		void BtnClassDescResetClick(object sender, EventArgs e)
		{
			if (!open || (object)openFile == null) return;
			if ((object)selectedClass == null) return;
			txtClassDescription.Text = selectedClass.Description;
		}
		
		void BtnClassDescApplyClick(object sender, EventArgs e)
		{
			if (!open || (object)openFile == null) return;
			if ((object)selectedClass == null) return;
			selectedClass.Description = txtClassDescription.Text;
			updateItemFields();
		}
		
		void LstPropertiesSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!open || (object)openFile == null) return;
			if ((object)selectedClass == null) return;
		}
	}
}
