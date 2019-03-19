/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 21/12/2008
 * Time: 3:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace thor
{
	public class GameData
	{
		int mapsizelow;
		int mapsizehigh;
		bool sizeset;
		int concreteclasses;
		List<GameDataObject> classes;
		bool dependent;
		List<string> includes;
		
		public bool SizeSet {
			get { return sizeset; }
		}
		
		public List<string> Includes {
			get { return includes; }
		}
		
		/// <summary>
		/// Get the lower limit of the map size.
		/// </summary>
		public int MapSizeLow {
			get { return mapsizelow; }
		}
		
		/// <summary>
		/// Get the upper limit of the map size.
		/// </summary>
		public int MapSizeHigh {
			get { return mapsizehigh; }
		}
		
		public GameData()
		{
			mapsizehigh = 4096;
			mapsizelow = -4096;
			sizeset = false;
			concreteclasses = 0;
			classes = new List<GameDataObject>();
			dependent = false;
			includes = new List<string>();
		}
		
		public void merge(GameData gd)
		{
			if (gd.sizeset) {
				this.mapsizehigh = gd.mapsizehigh;
				this.mapsizelow = gd.mapsizelow;
				this.sizeset = true;
			}
			this.concreteclasses += gd.concreteclasses;
			foreach (GameDataObject gdo in gd.classes) {
				this.classes.Add(gdo);
			}
		}
		
		public GameDataObject getClass(string name, GameDataClassTypes type)
		{
			foreach (GameDataObject gdo in classes) {
				if (gdo.Name == name) {
					if (type == GameDataClassTypes.Any) return gdo;
					if (type == GameDataClassTypes.Solid && gdo.ClassType == GameDataClassTypes.Solid) {
						return gdo;
					}
					else if (type == GameDataClassTypes.Base && gdo.ClassType == GameDataClassTypes.Base) {
						return gdo;
					}
					else if (gdo.ClassType != GameDataClassTypes.Base && gdo.ClassType != GameDataClassTypes.Solid) {
						return gdo;
					}
				}
			}
			return null;
		}
		
		public List<GameDataObject> getClasses(GameDataClassTypes type)
		{
			List<GameDataObject> ret = new List<GameDataObject>();
			foreach (GameDataObject gdo in classes) {
				if (type == GameDataClassTypes.Any) ret.Add(gdo);
				else if (type == gdo.ClassType) ret.Add(gdo);
			}
			return ret;
		}
		
		public void addClass(GameDataObject gdo)
		{
			if (getClass(gdo.Name,gdo.ClassType) != null) {
				//throw new Exception("Duplicate class: "+gdo.Name);
				getClass(gdo.Name,gdo.ClassType).inherit(gdo);
			}
			classes.Add(gdo);
			if (gdo.ClassType != GameDataClassTypes.Base) concreteclasses++;
		}
		
		public void createDependencies()
		{
			if (dependent) return;
			dependent = true;
			foreach (GameDataObject gdo in classes) {
				foreach (string s in gdo.BaseClasses) {
					GameDataObject inherit = getClass(s, GameDataClassTypes.Any);
					if (inherit == null) throw new Exception("Base class not found: " + s);
					gdo.inherit(inherit);
				}
			}
		}
		
		public void setMapSize(string low, string high)
		{
			int l = int.Parse(low);
			int h = int.Parse(high);
			mapsizelow = l;
			mapsizehigh = h;
			sizeset = true;
		}
		
		public void unsetMapSize()
		{
			sizeset = false;
		}
		
		public override string ToString()
		{
			string s = "";
			s += 	"//Generated with Thor FGD Editor, " + DateTime.Now.ToLongDateString() + ".\n" +
					"//All content copyright the original creators.\n" +
					"//Thor and the Thor FGD Editor are open source software - http://www.twhl.co.za";
			if (includes.Count > 0) s += "\n\n//INCLUDES";
			foreach (string str in includes) s += "\n\n@include " + str;
			if (sizeset) s += "\n\n//MAP SIZE\n\n@mapsize(" + mapsizelow + ", " + mapsizehigh + ")";
			if (classes.Count > 0) s += "\n\n//CLASSES";
			foreach (GameDataObject gdo in classes) s += "\n\n" + gdo.ToString();
			return s;
		}
	}
}
