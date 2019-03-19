/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 5/01/2009
 * Time: 12:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of Hotkeys.
	/// </summary>
	public static class oldBrokenHotkeys
	{
		private static void CtrlAltShiftKeys(MainForm form, KeyEventArgs e)
		{
			if (!e.Control || !e.Alt || !e.Shift) return;
		}
		
		private static void CtrlAltKeys(MainForm form, KeyEventArgs e)
		{
			if (!e.Control || !e.Alt || e.Shift) return;
		}
		
		private static void CtrlShiftKeys(MainForm form, KeyEventArgs e)
		{
			if (!e.Control || e.Alt || !e.Shift) return;
			switch (e.KeyCode) {
				case Keys.Y:
					MessageBox.Show("You pressed Ctrl-Shift-Y!");
					e.SuppressKeyPress = true;
					break;
			}
		}
		
		private static void AltShiftKeys(MainForm form, KeyEventArgs e)
		{
			if (e.Control || !e.Alt || !e.Shift) return;
		}
		
		private static void CtrlKeys(MainForm form, KeyEventArgs e)
		{
			if (!e.Control || e.Alt || e.Shift) return;
			switch (e.KeyCode) {
				case Keys.A:
					if (Accessor.Instance.getActiveForm() != null) Accessor.Instance.getActiveForm().Views.autosize();
					e.SuppressKeyPress = true;
					break;
			}
		}
		
		private static void AltKeys(MainForm form, KeyEventArgs e)
		{
			if (e.Control || !e.Alt || e.Shift) return;
		}
		
		private static void ShiftKeys(MainForm form, KeyEventArgs e)
		{
			if (e.Control || e.Alt || !e.Shift) return;
		}
		
		private static void RegularKeys(MainForm form, KeyEventArgs e)
		{
			if (e.Control || e.Alt || e.Shift) return;
			switch (e.KeyCode) {
				case Keys.OemOpenBrackets:
					Accessor.Instance.getActiveDocument().decGridDistance();
					break;
				case Keys.OemCloseBrackets:
					Accessor.Instance.getActiveDocument().incGridDistance();
					break;
			}
		}
		
		private static void updateKeys(KeyEventArgs e)
		{
			Accessor a = Accessor.Instance;
			a.Control = e.Control;
			a.Alt = e.Alt;
			a.Shift = e.Shift;
		}
		
		public static void keyDown(MainForm form, KeyEventArgs e)
		{
			//three modifier keys pressed
			CtrlAltShiftKeys(form,e);
			//two modifier keys pressed
			CtrlAltKeys(form,e);
			CtrlShiftKeys(form,e);
			AltShiftKeys(form,e);
			//one modifier key pressed
			CtrlKeys(form,e);
			AltKeys(form,e);
			ShiftKeys(form,e);
			//zero modifier keys pressed
			RegularKeys(form,e);
			//update global modifier keys
			updateKeys(e);
			if (!Accessor.Instance.PressedKeys.Contains(e.KeyCode)) Accessor.Instance.PressedKeys.Add(e.KeyCode);
		}
		
		public static void keyUp(MainForm form, KeyEventArgs e)
		{
			//update global modifier keys
			updateKeys(e);
			//if (Accessor.Instance.PressedKeys.Contains(e.KeyCode)) 
			Accessor.Instance.PressedKeys.Remove(e.KeyCode);
		}
	}
}
