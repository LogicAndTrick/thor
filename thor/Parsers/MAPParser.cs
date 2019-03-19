/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 11/10/2008
 * Time: 7:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace thor
{
	/// <summary>
	/// Description of MAPParser.
	/// </summary>
	public class MAPParser : MapParserInterface
	{
		bool error;
		int numlines;
		Random rnd;
		
		public MAPParser()
		{
			error = false;
			numlines = 0;
			rnd = new Random();
		}
		
		public bool isError()
		{
			return error;
		}
		
		private string cleanLine(string line)
		{
			string ret = line;
			//strip comments
			if (ret.Contains("//")) {
				ret = ret.Substring(0,ret.IndexOf("//"));
			}
			//strip all whitespace characters into a single space
			//ret = Regex.Replace(ret, @"\s+", " ", RegexOptions.Multiline);
			//strip leading and trailing spaces
			ret = ret.Trim(" ".ToCharArray());
			//our line is now ready for parsing!
			return ret;
		}
		
		private string ReadLine(ref StreamReader sr)
		{
			string line;
			do {
				line = cleanLine(sr.ReadLine());
				numlines++;
				progress.progressBar.Value++;
			} while (line == "");
			return line;
		}
		
		/// <summary>
		/// Writes a single map property to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mp">The MapProperty object to write to the StreamWriter.</param>
		private void writeProperty(ref StreamWriter sw, MapProperty mp)
		{
			sw.WriteLine("\""+mp.Key+"\" \""+mp.Value+"\"");
		}
		
		/// <summary>
		/// Writes a single map property to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="key">The Key of the Property.</param>
		/// <param name="val">The Value of the Property.</param>
		private void writeProperty(ref StreamWriter sw, string key, string val)
		{
			sw.WriteLine("\""+key+"\" \""+val+"\"");
		}
		
		/// <summary>
		/// Writes map entity data to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="data">The MapEntityData object to write to the StreamWriter.</param>
		private void writeEntityData(ref StreamWriter sw, MapEntityData data)
		{
			writeProperty(ref sw,"classname",data.Name);
			writeProperty(ref sw,"spawnflags",data.Flags.ToString());
			foreach (MapProperty mp in data.Properties) {
				if (mp.Key == "classname" || mp.Key == "spawnflags") continue;
				writeProperty(ref sw, mp);
			}
		}
		
		/// <summary>
		/// Writes a single map face to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mf">The MapFace object to write to the StreamWriter.</param>
		private void writeFace(ref StreamWriter sw, MapFace mf)
		{
			//( -128 64 64 ) ( -64 64 64 ) ( -64 0 64 ) AAATRIGGER [ 1 0 0 0 ] [ 0 -1 0 0 ] 0 1 1 
			sw.WriteLine(mf.Plane.ToString(true) + " " +
			             mf.Texture + " " +
			             mf.Uaxis.ToString(true) + " " +
			             mf.Vaxis.ToString(true) + " " +
			             mf.Rotation + " " +
			             mf.Uscale + " " +
			             mf.Vscale + " ");
		}
		
		/// <summary>
		/// Writes a single map solid to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mo">The MapSolid object to write to the StreamWriter.</param>
		private void writeSolid(ref StreamWriter sw, MapSolid mo)
		{
			sw.WriteLine("{");
			foreach (MapFace mf in mo.Faces) {
				writeFace(ref sw, mf);
			}
			sw.WriteLine("}");
		}
		
		/// <summary>
		/// Writes a single map entity to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mo">The MapEntity object to write to the StreamWriter.</param>
		private void writeEntity(ref StreamWriter sw, MapEntity mo)
		{
			sw.WriteLine("{");
			writeEntityData(ref sw, mo.Data);
			if (mo.Children.Count == 0) writeProperty(ref sw, "origin", mo.Origin.X + " " +
			                                          mo.Origin.getY() + " " + mo.Origin.getZ());
			foreach (MapObject m in mo.Children) {
				writeSolids(ref sw, m);
			}
			sw.WriteLine("}");
		}
		
		/// <summary>
		/// Writes all map solids to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mo">The MapObject object to read the solid data from.</param>
		private void writeSolids(ref StreamWriter sw, MapObject mo)
		{
			if (mo is MapWorld || mo is MapGroup) {
				foreach (MapObject m in mo.Children) {
					writeSolids(ref sw, m);
				}
			}
			else if (mo is MapSolid) {
				writeSolid(ref sw, (MapSolid)mo);
			}
		}
		
		/// <summary>
		/// Writes all map entities to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mo">The MapObject object to read the entity data from.</param>
		private void writeEntities(ref StreamWriter sw, MapObject mo)
		{
			if (mo is MapWorld || mo is MapGroup) {
				foreach (MapObject m in mo.Children) {
					writeEntities(ref sw, m);
				}
			}
			else if (mo is MapEntity) {
				writeEntity(ref sw, (MapEntity)mo);
			}
		}
		
		/// <summary>
		/// Writes map paths to a StreamWriter, in MAP format.
		/// </summary>
		/// <param name="sw">A reference to a StreamWriter to write the string to.</param>
		/// <param name="mw">The MapWorld object to read the path data from.</param>
		private void writePaths(ref StreamWriter sw, MapWorld mw)
		{
			foreach (MapPath mp in mw.Paths) {
				int numnodes = 0;
				int lastnode = 0;
				if (mp.Nodes.Count < 3 && mp.Direction == MapPath.PINGPONG) mp.Direction = MapPath.CIRCULAR;
				foreach (MapNode mn in mp.Nodes) {
					numnodes++;
					sw.WriteLine("{");
					writeProperty(ref sw,"classname",mp.Type);
					writeProperty(ref sw, "origin", 
					              mn.Position.getX() + " " +
					              mn.Position.getY() + " " + 
					              mn.Position.getZ());
					if (mn.Id > 1) writeProperty(ref sw,"targetname",mp.Name + mn.Id);
					else writeProperty(ref sw,"targetname",mp.Name);
					if (numnodes == mp.Nodes.Count) {
						switch (mp.Direction) {
							case MapPath.CIRCULAR:
								writeProperty(ref sw,"target",mp.Name);
								break;
							case MapPath.PINGPONG:
								lastnode = mn.Id;
								writeProperty(ref sw,"target",mp.Name + (mn.Id + 1));
								break;
							default:
								break;
						}
					}
					else {
						writeProperty(ref sw,"target",mp.Name + mp.Nodes[mp.Nodes.IndexOf(mn)+1].Id);
					}
					sw.WriteLine("}");
				}
				if (mp.Direction == MapPath.PINGPONG) {
					for (int i = 1; i < numnodes-1; i++) {
						sw.WriteLine("{");
						writeProperty(ref sw,"classname",mp.Type);
						writeProperty(ref sw, "origin", 
						              mp.Nodes[(numnodes-1)-i].Position.getX() + " " +
									  mp.Nodes[(numnodes-1)-i].Position.getY() + " " + 
									  mp.Nodes[(numnodes-1)-i].Position.getZ());
						writeProperty(ref sw,"targetname",mp.Name + (lastnode + i));
						if (i == (numnodes - 2)) {
							writeProperty(ref sw,"target",mp.Name);
						}
						else {
							writeProperty(ref sw,"target",mp.Name + (lastnode + i + 1));
						}
						sw.WriteLine("}");
					}
				}
			}
			
		}
		
		/// <summary>
		/// Reads a single property from a MAP file.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A MapProperty, as read from the StreamReader.</returns>
		private MapProperty readProperty(ref StreamReader sr)
		{
			string line = ReadLine(ref sr);
			line = line.Substring(1,line.Length-2);
			string[] spl = line.Split(new char[] {'"'});
			MapProperty prop = new MapProperty();
			prop.Key = spl[0];
			prop.Value = spl[2];
			return prop;
		}
		
		/// <summary>
		/// Reads Entity Data from a MAP file. Continues until no more data is found.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A MapEntityData, as read from the StreamReader.</returns>
		private MapEntityData readEntityData(ref StreamReader sr, out DecimalCoordinate origin)
		{
			origin = null;
			MapEntityData data = new MapEntityData();
			while ((char)sr.Peek() == '"') {
				MapProperty prop = readProperty(ref sr);
				if (prop.Key != "wad" && prop.Key != "mapversion") {
					if (prop.Key == "classname") data.Name = prop.Value;
					else if (prop.Key == "spawnflags") data.Flags = int.Parse(prop.Value);
					else if (prop.Key == "origin") origin = DecimalCoordinate.Parse(prop.Value, ' ');
					else data.addProperty(prop);
				}
			}
			return data;
		}
		
		/// <summary>
		/// Reads a Face from a MAP file.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A MapFace, as read from the StreamReader.</returns>
		private MapFace readFace(ref StreamReader sr)
		{
			MapFace face = new MapFace();
			//ignore extra spaces, they are there for comment readability only
			//0 1    2  3  4 5 6   7  8  9 10 11  12 13 14 15         16 17 18 19 20 21 22 23 24 25 26 27 28 29 30
			//( -128 64 64 ) ( -64 64 64 ) (  -64 0  64 )  AAATRIGGER [  1  0  0  0  ]  [  0  -1 0  0  ]  0  1  1 
			string line = ReadLine(ref sr);
			string[] tokens = line.Split(new char[] {' '});
			face.Plane = new DecimalPlane(new DecimalCoordinate(decimal.Parse(tokens[1]),decimal.Parse(tokens[2]),decimal.Parse(tokens[3])),
			                       new DecimalCoordinate(decimal.Parse(tokens[6]),decimal.Parse(tokens[7]),decimal.Parse(tokens[8])),
			                       new DecimalCoordinate(decimal.Parse(tokens[11]),decimal.Parse(tokens[12]),decimal.Parse(tokens[13])));
			face.Texture = tokens[15];
			Vector4 ua = new Vector4();
			ua.setValue(0,decimal.Parse(tokens[17], (System.Globalization.NumberStyles)0x00A4));
			ua.setValue(1,decimal.Parse(tokens[18], (System.Globalization.NumberStyles)0x00A4));
			ua.setValue(2,decimal.Parse(tokens[19], (System.Globalization.NumberStyles)0x00A4));
			ua.setValue(3,decimal.Parse(tokens[20], (System.Globalization.NumberStyles)0x00A4));
			face.Uaxis = ua;
			Vector4 va = new Vector4();
			va.setValue(0,decimal.Parse(tokens[23], (System.Globalization.NumberStyles)0x00A4));
			va.setValue(1,decimal.Parse(tokens[24], (System.Globalization.NumberStyles)0x00A4));
			va.setValue(2,decimal.Parse(tokens[25], (System.Globalization.NumberStyles)0x00A4));
			va.setValue(3,decimal.Parse(tokens[26], (System.Globalization.NumberStyles)0x00A4));
			face.Vaxis = va;
			face.Rotation = decimal.Parse(tokens[28], (System.Globalization.NumberStyles)0x00A4);
			face.Uscale = decimal.Parse(tokens[29], (System.Globalization.NumberStyles)0x00A4);
			face.Vscale = decimal.Parse(tokens[30], (System.Globalization.NumberStyles)0x00A4);
			return face;
		}
		
		/// <summary>
		/// Reads a single solid from a MAP file.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A MapSolid, as read from the StreamReader.</returns>
		private MapSolid readSolid(ref StreamReader sr)
		{
			MapSolid solid = new MapSolid();
			solid.Colour = Color.FromArgb(255,0,rnd.Next(50,256),rnd.Next(50,256));
			ReadLine(ref sr); //{
			while ((char)sr.Peek() != '}') {
				solid.addFace(readFace(ref sr));
			}
			ReadLine(ref sr); //}
			//get vertices
			DecimalPlane[] planes = new DecimalPlane[solid.Faces.Count];
			for (int i = 0; i < solid.Faces.Count; i++) {
				planes[i] = solid.Faces[i].Plane;
			}
			DecimalCoordinate[][] verts = Converter.planesToVertices(planes);
			for (int i = 0; i < solid.Faces.Count; i++) {
				if (verts[i] == null) {
					System.Windows.Forms.MessageBox.Show("Error around line " + numlines);
					return new MapSolid();
				}
			}
			for (int i = 0; i < solid.Faces.Count; i++) {
				solid.Faces[i].addVertices(verts[i]);
			}
			solid.reCalcBBox();
			return solid;
		}
		
		/// <summary>
		/// Reads all the possible solids from a MAP file.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A List of MapObjects (all MapSolid), as read from the StreamReader.</returns>
		private List<MapObject> readSolids(ref StreamReader sr)
		{
			List<MapObject> solids = new List<MapObject>();
			while ((char)sr.Peek() != '}') {
				solids.Add(readSolid(ref sr));
			}
			return solids;
		}
		
		/// <summary>
		/// Reads a single entity from a MAP file.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A MapEntity, as read from the StreamReader.</returns>
		private MapEntity readEntity(ref StreamReader sr)
		{
			MapEntity entity = new MapEntity();
			ReadLine(ref sr); //{
			DecimalCoordinate origin;
			entity.Data = readEntityData(ref sr, out origin);
			entity.Origin = origin;
			entity.Children.AddRange(readSolids(ref sr));
			ReadLine(ref sr); //}
			return entity;
		}
		
		/// <summary>
		/// Reads all the possible entities from a MAP file.
		/// </summary>
		/// <param name="sr">A reference to a StreamReader to read the string from.</param>
		/// <returns>A List of MapObjects (all MapEntity), as read from the StreamReader.</returns>
		private List<MapObject> readEntities(ref StreamReader sr)
		{
			List<MapObject> entities = new List<MapObject>();
			while ((char)sr.Peek() == '{') {
				entities.Add(readEntity(ref sr));
				if (sr.EndOfStream) return entities;
			}
			return entities;
		}
		
		ProgressForm progress;
		
		/// <summary>
		/// Parses the structure of a MAP file.
		/// </summary>
		/// <param name="path">The full string path of the MAP file to open.</param>
		/// <returns>A MapClass containing the data retrieved from the MAP file.</returns>
		public MapClass parse(string path)
		{
			using (progress = new ProgressForm()) {
				//System.Diagnostics.Stopwatch stop = new System.Diagnostics.Stopwatch();
				//stop.Start();
				error = false;
				numlines = 0;
				StreamReader sr = new StreamReader(path);
				int num = 0;
				while (sr.ReadLine() != null) num++;
				progress.progressBar.Maximum = num;
				progress.Show();
				sr = new StreamReader(path);
				MapClass map = new MapClass();
				string openbracket = ReadLine(ref sr);
				if (openbracket != "{") {
					error = true;
					System.Windows.Forms.MessageBox.Show("Invalid file.\nExpected: {\nActual: "+openbracket);
					throw new Exception();
				}
				MapObject world = new MapWorld();
				DecimalCoordinate tmp;
				((MapWorld)world).Data = readEntityData(ref sr, out tmp);
				//this is important, in case the worldspawn doesn't exist
				((MapWorld)world).Data.Name = "worldspawn";
				//MAPs have no concept of groups
				//all brushes are stored in the worldspawn object.
				world.addChildren(readSolids(ref sr));
				string closebracket = ReadLine(ref sr);
				if (closebracket != "}") {
					error = true;
					System.Windows.Forms.MessageBox.Show("Invalid file.\nExpected: }\nActual: "+closebracket);
					throw new Exception();
				}
				//read entities now.
				if (!sr.EndOfStream) world.addChildren(readEntities(ref sr));
				map.Worldspawn = (MapWorld)world;
				progress.Close();
				//System.Windows.Forms.MessageBox.Show(stop.ElapsedMilliseconds / 1000d + " seconds");
				//stop.Stop();
				return map;
			}
		}
		
		/// <summary>
		/// Saves a MAP to the specified path.
		/// </summary>
		/// <param name="map">The map class to save.</param>
		/// <param name="path">The location of the file to save to.</param>
		public void save(Document doc, string path)
		{
			MapClass map = doc.Map;
			StreamWriter sw = new StreamWriter(path,false);
			sw.WriteLine("{");
			writeEntityData(ref sw, map.Worldspawn.Data);
			writeProperty(ref sw,"mapversion","220");
			string wads = "";
			for (int i = 0; i < doc.GameConfig.WADs.Count; i++) {
				if (i > 0) wads += ";";
				wads += doc.GameConfig.WADs[i];
			}
			writeProperty(ref sw, "wad", wads);
			writeSolids(ref sw, map.Worldspawn);
			sw.WriteLine("}");
			writeEntities(ref sw, map.Worldspawn);
			writePaths(ref sw, map.Worldspawn);
			sw.Close();
		}
	}
}
