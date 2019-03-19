/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 30/12/2008
 * Time: 11:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using thor.Models;
using Thorm;

namespace thor
{
	/// <summary>
	/// Description of GameChooseForm.
	/// </summary>
	public partial class GameChooseForm : Form
	{
		Game selectedConfig;
		
		public Game SelectedConfig {
			get { return selectedConfig; }
		}
		
		public GameChooseForm()
		{
			selectedConfig = null;
			
			InitializeComponent();
			lstWONGS.Items.Clear();
			lstSteamGS.Items.Clear();
			lstSource.Items.Clear();
			
			foreach (Game game in Data.DB.List<Game>()) {
				if (game.Engine.Name == "Goldsource") {
					if (game.IsWON) {
						lstWONGS.Items.Add(game.Name);
					} else {
						lstSteamGS.Items.Add(game.Name);
					}
				} else {
					lstSource.Items.Add(game.Name);
				}
			}
		}
		
		void LstWONGSSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstWONGS.SelectedIndex < 0) return;
			lstSteamGS.SelectedIndex = -1;
			lstSource.SelectedIndex = -1;
		}
		
		void LstSteamGSSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstSteamGS.SelectedIndex < 0) return;
			lstWONGS.SelectedIndex = -1;
			lstSource.SelectedIndex = -1;
		}
		
		void LstSourceSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstSource.SelectedIndex < 0) return;
			lstWONGS.SelectedIndex = -1;
			lstSteamGS.SelectedIndex = -1;
		}
		
		void BthCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}
		
		Game getSelection()
		{
			string name = "";
			if (lstWONGS.SelectedIndex >= 0) name = lstWONGS.SelectedItem.ToString();
			else if (lstSteamGS.SelectedIndex >= 0) name = lstSteamGS.SelectedItem.ToString();
			else if (lstSource.SelectedIndex >= 0) name = lstSource.SelectedItem.ToString();
			
			if (name != "") {
				return Data.DB.Query<Game>().Where("gameName", Condition.Equal, name).ExecuteSingle();
			}
			
			return null;
		}
		
		void finish(bool forceClose)
		{
			if (selectedConfig != null) {
				DialogResult = DialogResult.OK;
				Log.LogMessage(selectedConfig.Name + " configuration selected.");
				Close();
			}
			else if (forceClose) {
				Close();
			}
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			selectedConfig = getSelection();
			finish(true);
		}
		
		void LstGameDoubleClick(object sender, EventArgs e)
		{
			selectedConfig = getSelection();
			finish(false);
		}
	}
}
