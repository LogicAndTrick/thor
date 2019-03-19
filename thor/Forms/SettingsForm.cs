/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 10/09/2008
 * Time: 7:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using thor.Models;
using Thorm;

namespace thor
{
	/// <summary>
	/// Description of SettingsForm.
	/// </summary>
	public partial class SettingsForm : Form
	{
		bool populating;
		Build selectedBuildConfig;
		Game selectedGameConfig;
		
		public SettingsForm()
		{
			InitializeComponent();
			populating = false;
			selectedBuildConfig = null;
			selectedGameConfig = null;
			Accessor.Instance.ThorSettings.loadData(GetAllControls(this.Controls));
		}
		
		/* http://www.learn-programming.za.net/programming_cs_getcontrolsonform.html */
		public static List<Control> GetAllControls(System.Collections.IList ctrls)
		{
			List<Control> RetCtrls = new List<Control>();
			foreach (Control ctl in ctrls)
			{
				RetCtrls.Add(ctl);
				List<Control> SubCtrls = GetAllControls(ctl.Controls);
				RetCtrls.AddRange(SubCtrls);
			}
			return RetCtrls;
		}
		
		void BtnApplySettingsClick(object sender, EventArgs e)
		{
			btnApplySettings.Text = "Saving...";
			btnApplySettings.Update();
			Accessor.Instance.ThorSettings.saveData(GetAllControls(this.Controls));
			btnApplySettings.Text = "Apply";
		}
		
		void panelChangeBGColour(object sender, EventArgs e)
		{
			if (sender is Panel) {
				Panel sen = (Panel)sender;
				ColorDialog pick = new ColorDialog();
				pick.Color = sen.BackColor;
				if (pick.ShowDialog() == DialogResult.OK) {
					sen.BackColor = pick.Color;
				}
				pick.Dispose();
			}
		}
		
		void BtnSteamInstallDirBrowseClick(object sender, EventArgs e)
		{
			FileDialog find = new OpenFileDialog();
			find.InitialDirectory = o_SteamInstallDir.Text;
			find.Filter = "Steam Executable File|steam.exe";
			if (find.ShowDialog() == DialogResult.OK) {
				o_SteamInstallDir.Text = Path.GetDirectoryName(find.FileName);
			}
			find.Dispose();
		}
		
		void SteamInstallDirTextChanged(object sender, EventArgs e)
		{
			string apps = Path.Combine(o_SteamInstallDir.Text, "steamapps");
			if (Directory.Exists(apps)) {
				o_SteamUsername.Items.Clear();
				foreach (string s in Directory.GetDirectories(apps)) {
					string[] split = s.Split(Path.DirectorySeparatorChar);
					string sp = split[split.Length - 1];
					string sl = sp.ToLower();
					if (sl != "sourcemods" && sl != "media" && sl != "common") {
						o_SteamUsername.Items.Add(sp);
						o_SteamUsername.SelectedIndex = 0;
					}
				}
			}
		}
		
		void CloseWithoutSaving(object sender, EventArgs e)
		{
			//TODO Accessor.Instance.ThorSettings.restoreSavedData();
		}
		
		void BtnCancelSettingsClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void BtnApplyAndCloseSettingsClick(object sender, EventArgs e)
		{
			btnApplyAndCloseSettings.Text = "Saving...";
			btnApplyAndCloseSettings.Update();
			Accessor.Instance.ThorSettings.saveData(GetAllControls(this.Controls));
			btnApplyAndCloseSettings.Text = "Apply and Close";
			Close();
		}
		
		public void updateSettings()
		{
			Accessor.Instance.ThorSettings.saveNewData(GetAllControls(this.Controls));
		}
		
		#region Build Configs
		void BtnBuildAddClick(object sender, EventArgs e)
		{
			Accessor.Instance.ThorSettings.newBuildConfig();
			Accessor.Instance.ThorSettings.loadData(GetAllControls(this.Controls));
		}
		
		void populateBuildsTab(Build config)
		{
			populating = true;
			if (config != null) {
				txtBuildCommandLine.Text = config.CommandLine;
				txtBuildExeFolder.Text = config.ExecutableFolder;
				txtBuildName.Text = config.Name;
				cmbBuildBSP.Text = config.BspExecutable;
				cmbBuildCSG.Text = config.CsgExecutable;
				cmbBuildEngine.SelectedIndex = config.EngineID - 1;
				cmbBuildRAD.Text = config.RadExecutable;
				cmbBuildVIS.Text = config.VisExecutable;
				chkBuildAskBeforeRun.Checked = config.AskBeforeRun;
				chkBuildCopyBSP.Checked = config.CopyBsp;
				chkBuildShowLog.Checked = config.ShowLog;
				radBuildDontRunGame.Checked = (config.RunType == 0);
				radBuildRunGame.Checked = (config.RunType == 1);
				radBuildRunGameOnChange.Checked = (config.RunType == 2);
				
				List<Control> bldcontrols;
				bldcontrols = GetAllControls(tabBuildAdvancedShared.Controls);
				foreach (Control c in bldcontrols) if (c is BuildControl) (c as BuildControl).setCommandLine(config.CsgFlags);
				bldcontrols = GetAllControls(tabBuildAdvancedCSG.Controls);
				foreach (Control c in bldcontrols) if (c is BuildControl) (c as BuildControl).setCommandLine(config.CsgFlags);
				bldcontrols = GetAllControls(tabBuildAdvancedBSP.Controls);
				foreach (Control c in bldcontrols) if (c is BuildControl) (c as BuildControl).setCommandLine(config.BspFlags);
				bldcontrols = GetAllControls(tabBuildAdvancedVIS.Controls);
				foreach (Control c in bldcontrols) if (c is BuildControl) (c as BuildControl).setCommandLine(config.VisFlags);
				bldcontrols = GetAllControls(tabBuildAdvancedRAD.Controls);
				foreach (Control c in bldcontrols) if (c is BuildControl) (c as BuildControl).setCommandLine(config.RadFlags);
			}
			tabBuildSubTabs.Visible = (config != null);
			populating = false;
		}
		
		void Tree_buildsAfterSelect(object sender, TreeViewEventArgs e)
		{
			if (tree_builds.SelectedNode != null) {
				string s = tree_builds.SelectedNode.Text;
				selectedBuildConfig = Data.DB.Query<Build>().Where("buildName", Condition.Equal, s).ExecuteSingle();
				populateBuildsTab(selectedBuildConfig);
			}
		}
		
		void updateSelectedBuildConfig(object sender, EventArgs e)
		{
			if (populating) return;
			if (selectedBuildConfig != null) {
				selectedBuildConfig.CommandLine = txtBuildCommandLine.Text;
				selectedBuildConfig.ExecutableFolder = txtBuildExeFolder.Text;
				selectedBuildConfig.BspExecutable = cmbBuildBSP.Text;
				selectedBuildConfig.CsgExecutable = cmbBuildCSG.Text;
				selectedBuildConfig.EngineID = cmbBuildEngine.SelectedIndex + 1;
				selectedBuildConfig.RadExecutable = cmbBuildRAD.Text;
				selectedBuildConfig.VisExecutable = cmbBuildVIS.Text;
				selectedBuildConfig.AskBeforeRun = chkBuildAskBeforeRun.Checked;
				selectedBuildConfig.CopyBsp = chkBuildCopyBSP.Checked;
				selectedBuildConfig.ShowLog = chkBuildShowLog.Checked;
				selectedBuildConfig.RunType = radBuildDontRunGame.Checked ? 0 : (radBuildRunGame.Checked ? 1 : 2);
				updateAdvancedBuild();
				Accessor.Instance.ThorSettings.loadBuildConfigs(tree_builds);
				updateGameBuilds();
			}
		}
		
		void BtnBuildChangeNameClick(object sender, EventArgs e)
		{
			if (Accessor.Instance.ThorSettings.isValidBuildName(txtBuildName.Text)) {
				if (selectedBuildConfig != null) {
					selectedBuildConfig.Name = txtBuildName.Text;
				}
				updateSelectedBuildConfig(sender, e);
			} else {
				MessageBox.Show("Name must be unique, and cannot be blank.");
			}
		}
		
		void TxtBuildExeFolderTextChanged(object sender, EventArgs e)
		{
			updateSelectedBuildConfig(sender, e);
			string folder = txtBuildExeFolder.Text;
			cmbBuildBSP.Items.Clear();
			cmbBuildCSG.Items.Clear();
			cmbBuildRAD.Items.Clear();
			cmbBuildVIS.Items.Clear();
			lstBuildPresets.Items.Clear();
			if (Directory.Exists(folder)) {
				foreach (string str in Directory.GetFiles(folder, "*.exe", SearchOption.TopDirectoryOnly)) {
					string s = Path.GetFileName(str);
					cmbBuildBSP.Items.Add(s);
					cmbBuildCSG.Items.Add(s);
					cmbBuildRAD.Items.Add(s);
					cmbBuildVIS.Items.Add(s);
				}
				List<string> presets = Accessor.Instance.ThorSettings.presetsInDirectory(folder);
				foreach (string s in presets) {
					lstBuildPresets.Items.Add(s);
				}
				if (presets.Count == 1) {
					lstBuildPresets.SelectedIndex = 0;
				}
			}
		}
		
		void LstBuildPresetsSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstBuildPresets.SelectedIndex < 0) return;
			string name = lstBuildPresets.SelectedItem.ToString();
			Preset pre = Data.DB.Query<Preset>().Where("presetName", Condition.Equal, name).ExecuteSingle();
			if (pre != null) {
				cmbBuildBSP.SelectedIndex = cmbBuildBSP.Items.IndexOf(pre.BspExecutable);
				cmbBuildCSG.SelectedIndex = cmbBuildCSG.Items.IndexOf(pre.CsgExecutable);
				cmbBuildVIS.SelectedIndex = cmbBuildVIS.Items.IndexOf(pre.VisExecutable);
				cmbBuildRAD.SelectedIndex = cmbBuildRAD.Items.IndexOf(pre.RadExecutable);
			}
		}
		
		void BtnBuildExeFolderBrowseClick(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Directory.Exists(txtBuildExeFolder.Text)) {
				fbd.SelectedPath = txtBuildExeFolder.Text;
			}
			if (fbd.ShowDialog() == DialogResult.OK) {
				txtBuildExeFolder.Text = fbd.SelectedPath;
			}
			fbd.Dispose();
		}
		
		void CmbBuildEngineSelectedIndexChanged(object sender, EventArgs e)
		{
			updateSelectedBuildConfig(sender, e);
			cmbBuildCSG.Enabled = (cmbBuildEngine.SelectedIndex == 0);
		}
		
		void updateAdvancedBuild()
		{
			txtBuildAdvancedPreview.Text = "";
			List<string> temp = new List<string>();
			List<Control> bldcontrols;
			string sharedcmd = "";
			string flagstr = "";
			
			bldcontrols = GetAllControls(tabBuildAdvancedShared.Controls);
			foreach (Control c in bldcontrols) {
				if (c is BuildControl) {
					string cmd = ((BuildControl)c).getCommandLine();
					if (cmd != "") temp.Add(cmd);
				}
			}
			sharedcmd += string.Join(" ", temp.ToArray());
			temp.Clear();
			
			bldcontrols = GetAllControls(tabBuildAdvancedCSG.Controls);
			foreach (Control c in bldcontrols) {
				if (c is BuildControl) {
					string cmd = ((BuildControl)c).getCommandLine();
					if (cmd != "") temp.Add(cmd);
				}
			}
			if (sharedcmd != "") temp.Add(sharedcmd);
			flagstr = string.Join(" ", temp.ToArray());
			txtBuildAdvancedPreview.Text += flagstr + "\r\n\r\n";
			if (selectedBuildConfig != null) selectedBuildConfig.CsgFlags = flagstr;
			temp.Clear();
			
			bldcontrols = GetAllControls(tabBuildAdvancedBSP.Controls);
			foreach (Control c in bldcontrols) {
				if (c is BuildControl) {
					string cmd = ((BuildControl)c).getCommandLine();
					if (cmd != "") temp.Add(cmd);
				}
			}
			if (sharedcmd != "") temp.Add(sharedcmd);
			flagstr = string.Join(" ", temp.ToArray());
			txtBuildAdvancedPreview.Text += flagstr + "\r\n\r\n";
			if (selectedBuildConfig != null) selectedBuildConfig.BspFlags = flagstr;
			temp.Clear();
			
			bldcontrols = GetAllControls(tabBuildAdvancedVIS.Controls);
			foreach (Control c in bldcontrols) {
				if (c is BuildControl) {
					string cmd = ((BuildControl)c).getCommandLine();
					if (cmd != "") temp.Add(cmd);
				}
			}
			if (sharedcmd != "") temp.Add(sharedcmd);
			flagstr = string.Join(" ", temp.ToArray());
			txtBuildAdvancedPreview.Text += flagstr + "\r\n\r\n";
			if (selectedBuildConfig != null) selectedBuildConfig.VisFlags = flagstr;
			temp.Clear();
			
			bldcontrols = GetAllControls(tabBuildAdvancedRAD.Controls);
			foreach (Control c in bldcontrols) {
				if (c is BuildControl) {
					string cmd = ((BuildControl)c).getCommandLine();
					if (cmd != "") {
						temp.Add(cmd);
					}
				}
			}
			if (sharedcmd != "") temp.Add(sharedcmd);
			flagstr = string.Join(" ", temp.ToArray());
			txtBuildAdvancedPreview.Text += flagstr + "\r\n\r\n";
			if (selectedBuildConfig != null) selectedBuildConfig.RadFlags = flagstr;
			temp.Clear();
		}
		#endregion
		
		#region Game Configs
		void BtnGameAddClick(object sender, EventArgs e)
		{
			Accessor.Instance.ThorSettings.newGameConfig();
			Accessor.Instance.ThorSettings.loadData(GetAllControls(this.Controls));
		}
		
		void updateGameBuilds()
		{
			cmbGameBuild.Items.Clear();
			foreach (Build bld in Data.DB.List<Build>()) {
				cmbGameBuild.Items.Add(bld.Name);
			}
		}
		
		void populateGamesTab(Game config)
		{
			populating = true;
			
			updateGameBuilds();
			
			if (config != null) {
				txtGameName.Text = config.Name;
				cmbGameBuild.SelectedIndex = config.BuildID - 1;
				
				lstGameFGD.Items.Clear();
				foreach (string s in config.FGDs) lstGameFGD.Items.Add(s);
				updateGameEntities();
				cmbGameBrushEnt.Text = config.BrushEntity;
				cmbGamePointEnt.Text = config.PointEntity;
				
				lstGameWAD.Items.Clear();
				foreach (string s in config.WADs) lstGameWAD.Items.Add(s);
				nudGameLightmapScale.Value = config.LightmapScale;
				nudGameTextureScale.Value = config.TextureScale;
				
				lstGameWAD.Items.Clear();
				foreach (string s in config.WADs) lstGameWAD.Items.Add(s);
				
				cmbGameEngine.SelectedIndex = config.IsWON ? 0 : config.EngineID;
				if (config.IsWON) {
					cmbGameSteamDir.Text = "";
					txtGameWONDir.Text = config.GameDirectory;
				} else {
					txtGameWONDir.Text = "";
					cmbGameSteamDir.Text = config.GameDirectory;
				}
				cmbGameMod.Text = config.ModDirectory;
				
				txtGameAutosaveDir.Text = config.AutosaveDirectory;
				txtGameMapDir.Text = config.MapDirectory;
				chkGameEnableAutosave.Checked = config.AutosaveEnabled;
				chkGameMapDiffAutosaveDir.Checked = config.UseAlternateAutosaveDirectory;
			}
			
			tabGameSubTabs.Visible = (config != null);
			populating = false;
		}
		
		void Tree_gamesAfterSelect(object sender, TreeViewEventArgs e)
		{
			if (tree_games.SelectedNode != null) {
				string s = tree_games.SelectedNode.Text;
				selectedGameConfig = Data.DB.Query<Game>().Where("gameName", Condition.Equal, s).ExecuteSingle();
				populateGamesTab(selectedGameConfig);
			}
		}
		
		void updateSelectedGameConfig(object sender, EventArgs e)
		{
			if (populating) return;
			if (selectedGameConfig != null) {
				selectedGameConfig.EngineID = cmbGameEngine.SelectedIndex == 0 ? 1 : cmbGameEngine.SelectedIndex;
				selectedGameConfig.IsWON = cmbGameEngine.SelectedIndex == 0;
				selectedGameConfig.BuildID = cmbGameBuild.SelectedIndex + 1;
				selectedGameConfig.GameDirectory = selectedGameConfig.IsWON ? txtGameWONDir.Text : cmbGameSteamDir.Text;
				selectedGameConfig.ModDirectory = cmbGameMod.Text;
				selectedGameConfig.MapDirectory = txtGameMapDir.Text;
				selectedGameConfig.AutosaveDirectory = txtGameAutosaveDir.Text;
				selectedGameConfig.AutosaveEnabled = chkGameEnableAutosave.Checked;
				selectedGameConfig.UseAlternateAutosaveDirectory = chkGameMapDiffAutosaveDir.Checked;
				selectedGameConfig.FGDs.Clear();
				foreach (object o in lstGameFGD.Items) selectedGameConfig.FGDs.Add(o.ToString());
				selectedGameConfig.WADs.Clear();
				foreach (object o in lstGameWAD.Items) selectedGameConfig.WADs.Add(o.ToString());
				selectedGameConfig.PointEntity = cmbGamePointEnt.Text;
				selectedGameConfig.BrushEntity = cmbGameBrushEnt.Text;
				selectedGameConfig.TextureScale = nudGameTextureScale.Value;
				selectedGameConfig.LightmapScale = (int)nudGameLightmapScale.Value;
				Accessor.Instance.ThorSettings.loadGameConfigs(tree_games);
			}
		}
		
		void BtnGameChangeNameClick(object sender, EventArgs e)
		{
			if (Accessor.Instance.ThorSettings.isValidGameName(txtGameName.Text)) {
				if (selectedGameConfig != null) {
					selectedGameConfig.Name = txtGameName.Text;
				}
				updateSelectedGameConfig(sender, e);
			} else {
				MessageBox.Show("Name must be unique, and cannot be blank.");
			}
		}
		
		void BtnGameDirBrowseClick(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Directory.Exists(txtGameWONDir.Text)) {
				fbd.SelectedPath = txtGameWONDir.Text;
			}
			if (fbd.ShowDialog() == DialogResult.OK) {
				txtGameWONDir.Text = fbd.SelectedPath;
			}
			fbd.Dispose();
		}
		
		void BtnGameMapDirBrowseClick(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Directory.Exists(txtGameMapDir.Text)) {
				fbd.SelectedPath = txtGameMapDir.Text;
			}
			if (fbd.ShowDialog() == DialogResult.OK) {
				txtGameMapDir.Text = fbd.SelectedPath;
			}
			fbd.Dispose();
		}
		
		void BtnGameAutosaveDirBrowseClick(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (Directory.Exists(txtGameAutosaveDir.Text)) {
				fbd.SelectedPath = txtGameAutosaveDir.Text;
			}
			if (fbd.ShowDialog() == DialogResult.OK) {
				txtGameAutosaveDir.Text = fbd.SelectedPath;
			}
			fbd.Dispose();
		}
		
		void CmbGameEngineSelectedIndexChanged(object sender, EventArgs e)
		{
			updateSelectedGameConfig(sender, e);
			bool won = (cmbGameEngine.SelectedIndex == 0);
			txtGameWONDir.Enabled = won;
			btnGameDirBrowse.Enabled = won;
			cmbGameSteamDir.Enabled = !won;
			bool gs = (cmbGameEngine.SelectedIndex < 2);
			lstGameWAD.Enabled = gs;
			btnGameAddWAD.Enabled = gs;
			btnGameRemoveWAD.Enabled = gs;
			cmbGameMod.Enabled = gs;
			
			cmbGameSteamDir.Items.Clear();
			
			if (won) {
				//won
			} else {
				//steam
				string apps = Path.Combine(o_SteamInstallDir.Text, "steamapps");
				string user = Path.Combine(apps, o_SteamUsername.Text);
				if (Directory.Exists(user)) {
					foreach (string s in Directory.GetDirectories(user)) {
						string[] split = s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
						string folder = split[split.Length - 1];
						cmbGameSteamDir.Items.Add(folder);
					}
				} else {
					MessageBox.Show("Please configure your Steam settings.");
					tbcSettings.SelectedTab = tabSteam;
				}
			}
		}
		
		void ChkGameMapDiffAutosaveDirCheckedChanged(object sender, EventArgs e)
		{
			txtGameAutosaveDir.Enabled = chkGameEnableAutosave.Checked;
			btnGameAutosaveDirBrowse.Enabled = chkGameEnableAutosave.Checked;
			updateSelectedGameConfig(sender, e);
		}
		
		void updateGameMods(string path)
		{
			cmbGameMod.Items.Clear();
			if (Directory.Exists(path)) {
				if (Directory.Exists(Path.Combine(path, "valve"))) {
					cmbGameMod.Items.Add("valve");
				}
				foreach (string s in Directory.GetDirectories(path)) {
					if (File.Exists(Path.Combine(s, "liblist.gam")) || File.Exists(Path.Combine(s, "gameinfo.txt"))) {
						string[] split = s.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
						string folder = split[split.Length - 1];
						cmbGameMod.Items.Add(folder);
					}
				}
			}
			if (cmbGameMod.Items.Count == 1) {
				cmbGameMod.SelectedIndex = 0;
			}
		}
		
		void CmbGameSteamDirSelectedIndexChanged(object sender, EventArgs e)
		{
			updateSelectedGameConfig(sender, e);
			string apps = Path.Combine(o_SteamInstallDir.Text, "steamapps");
			string user = Path.Combine(apps, o_SteamUsername.Text);
			updateGameMods(Path.Combine(user, cmbGameSteamDir.Text));
		}
		
		void TxtGameWONDirTextChanged(object sender, EventArgs e)
		{
			updateSelectedGameConfig(sender, e);
			updateGameMods(txtGameWONDir.Text);
		}
		
		void updateGameEntities()
		{
			FGDParser parse = new FGDParser();
			GameData data = new GameData();
			foreach (object o in lstGameFGD.Items) {
				string s = o.ToString();
				if (File.Exists(s)) {
					data.merge(parse.parse(s));
				}
			}
			cmbGameBrushEnt.Items.Clear();
			cmbGamePointEnt.Items.Clear();
			List<GameDataObject> pointents = data.getClasses(GameDataClassTypes.Point);
			pointents.Sort();
			foreach (GameDataObject o in pointents) {
				cmbGamePointEnt.Items.Add(o.Name);
			}
			List<GameDataObject> brushents = data.getClasses(GameDataClassTypes.Solid);
			brushents.Sort();
			foreach (GameDataObject o in brushents) {
				cmbGameBrushEnt.Items.Add(o.Name);
			}
		}
		
		void BtnGameAddFGDClick(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Forge Game Data Files (*.fgd)|*.fgd";
			ofd.Multiselect = true;
			if (ofd.ShowDialog() == DialogResult.OK) {
				foreach (string s in ofd.FileNames) {
					lstGameFGD.Items.Add(s);
				}
			}
			lstGameFGD.Items.Remove("");
			updateSelectedGameConfig(sender, e);
			updateGameEntities();
		}
		
		void BtnGameRemoveFGDClick(object sender, EventArgs e)
		{
			List<int> rem = new List<int>();
			foreach (int i in lstGameFGD.SelectedIndices) {
				rem.Add(i);
			}
			foreach (int i in rem) {
				lstGameFGD.Items.RemoveAt(i);
			}
			rem.Clear();
			updateSelectedGameConfig(sender, e);
			updateGameEntities();
		}
		
		void BtnGameAddWADClick(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "WAD Files (*.wad)|*.wad";
			ofd.Multiselect = true;
			if (ofd.ShowDialog() == DialogResult.OK) {
				foreach (string s in ofd.FileNames) {
					lstGameWAD.Items.Add(s);
				}
			}
			lstGameWAD.Items.Remove("");
			updateSelectedGameConfig(sender, e);
		}
		#endregion
		
		void BtnGameRemoveWADClick(object sender, EventArgs e)
		{
			List<int> rem = new List<int>();
			foreach (int i in lstGameWAD.SelectedIndices) {
				rem.Add(i);
			}
			foreach (int i in rem) {
				lstGameWAD.Items.RemoveAt(i);
			}
			rem.Clear();
			updateSelectedGameConfig(sender, e);
		}
	}
}
