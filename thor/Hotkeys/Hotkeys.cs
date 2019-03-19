/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 29/06/2009
 * Time: 4:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of Hotkeys.
	/// </summary>
	public class Hotkeys
	{
		public delegate void hotkeyTrigger();
		
		private Dictionary<string, hotkeyTrigger> hotKeys;
		private bool enabled;
		public Hotkeys()
		{
			hotKeys = new Dictionary<string, hotkeyTrigger>();
			enabled = false;
		}
		
		public void start()
		{
			enabled = true;
		}
		
		public void subscribe(string key, hotkeyTrigger trigger)
		{
			if (hotKeys.ContainsKey(key)) hotKeys.Remove(key);
			hotKeys.Add(key, trigger);
		}
		
		public void triggerHotkey(string key)
		{
			if (!enabled) return;
			if (hotKeys.ContainsKey(key)) {
				hotKeys[key]();
			}
		}
		
		private static void updateKeys(KeyEventArgs e)
		{
			Accessor a = Accessor.Instance;
			a.Control = e.Control;
			a.Alt = e.Alt;
			a.Shift = e.Shift;
		}
		
		public void keyDown(KeyEventArgs e)
		{
			triggerHotkey(makeKeyString(e.Control, e.Alt, e.Shift, e.KeyCode));
			//update global modifier keys
			updateKeys(e);
			if (!Accessor.Instance.PressedKeys.Contains(e.KeyCode))
				Accessor.Instance.PressedKeys.Add(e.KeyCode);
		}
		
		public void keyUp(KeyEventArgs e)
		{
			//update global modifier keys
			updateKeys(e);
			Accessor.Instance.PressedKeys.Remove(e.KeyCode);
		}
		
		public string makeKeyString(bool control, bool alt, bool shift, Keys k)
		{
			string key = "";
			if (control) key += "Ctrl+";
			if (alt) key += "Alt+";
			if (shift) key += "Shift+";
			string ks = KeysToString(k);
			if (ks == "Return") ks = "Enter";
			key += ks;
			return key;
		}
		
		public string KeysToString(Keys key)
		{
			switch (key)
			{
				case Keys.Add:
					return "+";
				case Keys.Decimal:
					return ".";
				case Keys.Divide:
					return "/";
				case Keys.Multiply:
					return "*";
				case Keys.OemBackslash:
					return "\\";
				case Keys.OemCloseBrackets:
					return "]";
				case Keys.OemMinus:
					return "-";
				case Keys.OemOpenBrackets:
					return "[";
				case Keys.OemPeriod:
					return ".";
				case Keys.OemPipe:
					return "|";
				case Keys.OemQuestion:
					return "/";
				case Keys.OemQuotes:
					return "\"";
				case Keys.OemSemicolon:
					return ";";
				case Keys.Oemcomma:
					return ",";
				case Keys.Oemplus:
					return "+";
				case Keys.Oemtilde:
					return "`";
				case Keys.Separator:
					return "-";
				case Keys.Subtract:
					return "-";
				case Keys.D0:
					return "0";
				case Keys.D1:
					return "1";
				case Keys.D2:
					return "2";
				case Keys.D3:
					return "3";
				case Keys.D4:
					return "4";
				case Keys.D5:
					return "5";
				case Keys.D6:
					return "6";
				case Keys.D7:
					return "7";
				case Keys.D8:
					return "8";
				case Keys.D9:
					return "9";
				case Keys.Space:
					return "Space";
				case Keys.Enter:
					return "Enter";
				default:
					return key.ToString();
			}
		}
	}
}
