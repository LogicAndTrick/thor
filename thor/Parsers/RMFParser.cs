/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 10/10/2008
 * Time: 10:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace thor
{
	/// <summary>
	/// Description of RMFParser.
	/// </summary>
	public class RMFParser : MapParserInterface
	{
		bool error;
		public RMFParser()
		{
		}
		
		public bool isError()
		{
			return error;
		}
		
		/// <summary>
		/// Reads a string of specified length from a BinaryReader, and returns it.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the string from.</param>
		/// <param name="length">The fixed length of the string.</param>
		/// <param name="terminated">If true, will trim all bytes after the terminating \0.</param>
		/// <returns>The string, as read from the BinaryReader.</returns>
		private string readConstantLengthString(ref BinaryReader br, int length, bool terminated)
		{
			//use bytes to avoid the BinaryReader using unicode or something
			byte[] bstr = br.ReadBytes(length);
			char[] cstr = new char[length];
			//copy the byte array into a char array, to use in string constructor
			for (int i = 0; i < length; i++) cstr[i] = (char)bstr[i];
			//create string from array
			string sstr = new string(cstr);
			//strip off everything after the terminating \0 if
			//the string is terminated
			if (terminated) sstr = sstr.Substring(0,sstr.IndexOf('\0'));
			return sstr;
		}
		
		/// <summary>
		/// Writes a string of specified length to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="length">The fixed length of the string.</param>
		/// <param name="str">The string to write into the BinaryWriter.</param>
		private void writeConstantLengthString(ref BinaryWriter bw, int length, string str)
		{
			char[] cstr = new char[length];
			for (int i = 0; i < length; i++) cstr[i] = (char)((byte)0);
			if (str.Length > length-1) str = str.Substring(0,length-1);
			for (int i = 0; i < str.Length; i++) {
				cstr[i] = str[i];
			}
			bw.Write(cstr);
		}
		
		/// <summary>
		/// Reads a variable length string from a BinaryReader and returns it.
		/// A variable length string has its length preceeding it as an 8-bit
		/// integer. This function will strip off any terminating \0.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the string from.</param>
		/// <returns>The string, as read from the BinaryReader.</returns>
		private string readVariableLengthString(ref BinaryReader br)
		{
			//read the variable length string, then strip off the terminator (if it exists)
			return br.ReadString().Trim(new char[] {'\0'});
		}
		
		/// <summary>
		/// Writes a variable length string to a BinaryWriter. A variable length string
		/// has its length preceeding it as an 8-bit integer.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="str">The string to write into the BinaryWriter.</param>
		/// <param name="terminated">A bool representing whether the
		/// string needs to be terminated or not.</param>
		/// <returns></returns>
		private void writeVariableLengthString(ref BinaryWriter bw, string str, bool terminated)
		{
			if (terminated) str += '\0';
			bw.Write(str);
		}
		
		/// <summary>
		/// Reads a visgroup from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the visgroup from.</param>
		/// <returns>A MapVisgroup object, read from the BinaryReader.</returns>
		private MapVisgroup readVisGroup(ref BinaryReader br)
		{
			MapVisgroup vis = new MapVisgroup();
			string name = readConstantLengthString(ref br, 128, true);
			vis.Name = name;
			byte r = br.ReadByte();
			byte g = br.ReadByte();
			byte b = br.ReadByte();
			byte a = br.ReadByte();
			vis.Colour = Color.FromArgb(a,r,g,b);
			vis.ID = br.ReadInt32();
			vis.Visible = br.ReadBoolean();
			br.ReadBytes(3);
			return vis;
		}
		
		/// <summary>
		/// Writes a visgroup to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="vis">The MapVisgroup object to write to the BinaryWriter.</param>
		private void writeVisGroup(ref BinaryWriter bw, MapVisgroup vis)
		{
			writeConstantLengthString(ref bw, 128, vis.Name);
			bw.Write((byte)vis.Colour.R);
			bw.Write((byte)vis.Colour.G);
			bw.Write((byte)vis.Colour.B);
			bw.Write((byte)vis.Colour.A);
			bw.Write(vis.ID);
			bw.Write(vis.Visible);
			bw.Write(new byte[3]);
		}
		
		/// <summary>
		/// Reads a camera from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the camera from.</param>
		/// <returns>A MapCamera object, read from the BinaryReader.</returns>
		private MapCamera readCamera(ref BinaryReader br)
		{
			MapCamera cam = new MapCamera();
			cam.Eye = readCoordinate(ref br);
			cam.Look = readCoordinate(ref br);
			return cam;
		}
		
		/// <summary>
		/// Writes a camera to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="cam">The MapCamera object to write to the BinaryWriter.</param>
		private void writeCamera(ref BinaryWriter bw, MapCamera cam)
		{
			writeCoordinate(ref bw, cam.Eye);
			writeCoordinate(ref bw, cam.Look);
		}
		
		/// <summary>
		/// Reads a map base from a BinaryReader. Does not return
		/// anything, rather modifies a supplied MapObject.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the base from.</param>
		/// <param name="mo">A reference to a MapObject to insert the base data into.</param>
		private void readBase(ref BinaryReader br, ref MapObject mo)
		{
			//class name has already been loaded
			mo.Visgroups.Add(br.ReadInt32());
			mo.Colour = Color.FromArgb(255,br.ReadByte(),br.ReadByte(),br.ReadByte());
			int numchildren = br.ReadInt32();
			for (int i = 0; i < numchildren; i++) {
				mo.addChild(readMapObject(ref br));
			}
		}
		
		/// <summary>
		/// Writes a map base to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="mo">A reference to a MapObject to collect the base data from.</param>
		private void writeBase(ref BinaryWriter bw, ref MapObject mo)
		{
			//class name has already been written
			// only write the first visgroup as RMF doesn't support multiple groups
			if (mo.Visgroups.Count > 0) {
				bw.Write(mo.Visgroups[0]);
			} else {
				bw.Write(0);
			}
			bw.Write(mo.Colour.R);
			bw.Write(mo.Colour.G);
			bw.Write(mo.Colour.B);
			bw.Write(mo.Children.Count);
			for (int i = 0; i < mo.Children.Count; i++) {
				writeMapObject(ref bw, mo.Children[i]);
			}
		}
		
		/// <summary>
		/// Reads a property from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the property from.</param>
		/// <returns>A MapProperty object, read from the BinaryReader.</returns>
		private MapProperty readProperty(ref BinaryReader br)
		{
			MapProperty mp = new MapProperty();
			mp.Key = readVariableLengthString(ref br);
			mp.Value = readVariableLengthString(ref br);
			return mp;
		}
		
		/// <summary>
		/// Writes a property to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="prop">The MapProperty object to write to the BinaryWriter.</param>
		private void writeProperty(ref BinaryWriter bw, MapProperty prop)
		{
			writeVariableLengthString(ref bw, prop.Key, true);
			writeVariableLengthString(ref bw, prop.Value, true);
		}
		
		/// <summary>
		/// Reads entity data from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the entity data from.</param>
		/// <returns>A MapEntityData object, read from the BinaryReader.</returns>
		private MapEntityData readEntityData(ref BinaryReader br)
		{
			MapEntityData data = new MapEntityData();
			data.Name = readVariableLengthString(ref br);
			br.ReadBytes(4);
			data.Flags = br.ReadInt32();
			int props = br.ReadInt32();
			for (int i = 0; i < props; i++) {
				data.addProperty(readProperty(ref br));
			}
			br.ReadBytes(12);
			return data;
		}
		
		/// <summary>
		/// Writes entity data to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="data">The MapEntityData object to write to the BinaryWriter.</param>
		private void writeEntityData(ref BinaryWriter bw, MapEntityData data)
		{
			writeVariableLengthString(ref bw, data.Name, true);
			bw.Write(new byte[4]);
			bw.Write(data.Flags);
			bw.Write(data.Properties.Count);
			for (int i = 0; i < data.Properties.Count; i++) {
				writeProperty(ref bw, data.Properties[i]);
			}
			bw.Write(new byte[12]);
		}
		
		/// <summary>
		/// Reads a coordinate from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the coordinate from.</param>
		/// <returns>A Coordinate object, read from the BinaryReader.</returns>
		private DecimalCoordinate readCoordinate(ref BinaryReader br)
		{
			decimal x = (decimal)br.ReadSingle();
			decimal y = (decimal)br.ReadSingle();
			decimal z = (decimal)br.ReadSingle();
			DecimalCoordinate c = new DecimalCoordinate(x,y,z);
			return c;
		}
		
		/// <summary>
		/// Writes a coordinate to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="c">The Coordinate object to write to the BinaryWriter.</param>
		private void writeCoordinate(ref BinaryWriter bw, DecimalCoordinate c)
		{
			bw.Write((float)c.getX());
			bw.Write((float)c.getY());
			bw.Write((float)c.getZ());
		}
		
		/// <summary>
		/// Reads a path node from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the node from.</param>
		/// <returns>A MapNode object, read from the BinaryReader.</returns>
		private MapNode readNode(ref BinaryReader br)
		{
			MapNode mn = new MapNode();
			mn.Position = readCoordinate(ref br);
			mn.Id = br.ReadInt32();
			mn.Name = readConstantLengthString(ref br, 128,true);
			int props = br.ReadInt32();
			for (int i = 0; i < props; i++) {
				mn.addProperty(readProperty(ref br));
			}
			return mn;
		}
		
		/// <summary>
		/// Writes a node to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="node">The MapNode object to write to the BinaryWriter.</param>
		private void writeNode(ref BinaryWriter bw, MapNode node)
		{
			writeCoordinate(ref bw, node.Position);
			bw.Write(node.Id);
			writeConstantLengthString(ref bw, 128, node.Name);
			bw.Write(node.Properties.Count);
			for (int i = 0; i < node.Properties.Count; i++) {
				writeProperty(ref bw, node.Properties[i]);
			}
		}
		
		/// <summary>
		/// Reads a path from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the path from.</param>
		/// <returns>A MapPath object, read from the BinaryReader.</returns>
		private MapPath readPath(ref BinaryReader br)
		{
			MapPath mp = new MapPath();
			mp.Name = readConstantLengthString(ref br,128,true);
			mp.Type = readConstantLengthString(ref br,128,true);
			mp.Direction = br.ReadInt32();
			int nodes = br.ReadInt32();
			for (int i = 0; i < nodes; i++) {
				mp.addNode(readNode(ref br));
			}
			return mp;
		}
		
		/// <summary>
		/// Writes a path to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="path">The MapPath object to write to the BinaryWriter.</param>
		private void writePath(ref BinaryWriter bw, MapPath path)
		{
			writeConstantLengthString(ref bw, 128, path.Name);
			writeConstantLengthString(ref bw, 128, path.Type);
			bw.Write(path.Direction);
			bw.Write(path.Nodes.Count);
			for (int i = 0; i < path.Nodes.Count; i++) {
				writeNode(ref bw, path.Nodes[i]);
			}
		}
		
		/// <summary>
		/// Reads a 4-valued vector from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the vector from.</param>
		/// <returns>A Vector4 object, read from the BinaryReader.</returns>
		private Vector4 readVector4(ref BinaryReader br)
		{
			Vector4 v = new Vector4();
			v.setValue(0,(decimal)br.ReadSingle());
			v.setValue(1,(decimal)br.ReadSingle());
			v.setValue(2,(decimal)br.ReadSingle());
			v.setValue(3,(decimal)br.ReadSingle());
			return v;
		}
		
		/// <summary>
		/// Writes a 4-valued vector to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="v">The Vector4 object to write to the BinaryWriter.</param>
		private void writeVector4(ref BinaryWriter bw, Vector4 v)
		{
			bw.Write((float)v.getValue(0));
			bw.Write((float)v.getValue(1));
			bw.Write((float)v.getValue(2));
			bw.Write((float)v.getValue(3));
		}
		
		/// <summary>
		/// Reads a plane from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the plane from.</param>
		/// <returns>A Plane object, read from the BinaryReader.</returns>
		private DecimalPlane readPlane(ref BinaryReader br)
		{
			DecimalPlane p = new DecimalPlane(readCoordinate(ref br),
			                    readCoordinate(ref br),
			                    readCoordinate(ref br));
			return p;
		}
		
		/// <summary>
		/// Writes a plane to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="p">The Plane object to write to the BinaryWriter.</param>
		private void writePlane(ref BinaryWriter bw, DecimalPlane p)
		{
			writeCoordinate(ref bw, p.getCoordinate(1));
			writeCoordinate(ref bw, p.getCoordinate(2));
			writeCoordinate(ref bw, p.getCoordinate(3));
		}
		
		/// <summary>
		/// Reads a brush face from a BinaryReader.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the face from.</param>
		/// <returns>A MapFace object, read from the BinaryReader.</returns>
		private MapFace readFace(ref BinaryReader br)
		{
			MapFace mf = new MapFace();
			mf.Texture = readConstantLengthString(ref br,256,true);
			br.ReadBytes(4);
			mf.Uaxis = readVector4(ref br);
			mf.Vaxis = readVector4(ref br);
			mf.Rotation = (decimal)br.ReadSingle();
			mf.Uscale = (decimal)br.ReadSingle();
			mf.Vscale = (decimal)br.ReadSingle();
			br.ReadBytes(16);
			int verts = br.ReadInt32();
			DecimalCoordinate[] temp = new DecimalCoordinate[verts];
			for (int i = 0; i < verts; i++) {
				temp[i] = readCoordinate(ref br);
			}
			mf.addVertices(temp);
			mf.Plane = readPlane(ref br);
			
			return mf;
		}
		
		/// <summary>
		/// Writes a brush face to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="face">The  object to write to the BinaryWriter.</param>
		private void writeFace(ref BinaryWriter bw, MapFace face)
		{
			writeConstantLengthString(ref bw, 256, face.Texture);
			bw.Write(new byte[4]);
			writeVector4(ref bw, face.Uaxis);
			writeVector4(ref bw, face.Vaxis);
			bw.Write((float)face.Rotation);
			bw.Write((float)face.Uscale);
			bw.Write((float)face.Vscale);
			bw.Write(new byte[16]);
			bw.Write(face.Vertices.Count);
			for (int i = 0; i < face.Vertices.Count; i++) {
				writeCoordinate(ref bw, face.Vertices[i].Location);
			}
			writePlane(ref bw, face.Plane);
		}
		
		/// <summary>
		/// Reads a world object from a BinaryReader. Does not return
		/// anything, rather modifies a supplied MapObject.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the world from.</param>
		/// <param name="mo">A reference to a MapObject to insert the data into.</param>
		private void readWorld(ref BinaryReader br, ref MapObject mo)
		{
			readBase(ref br, ref mo);
			((MapWorld)mo).Data = readEntityData(ref br);
			int paths = br.ReadInt32();
			for (int i = 0; i < paths; i++) {
				((MapWorld)mo).addPath(readPath(ref br));
			}
		}
		
		/// <summary>
		/// Writes a world object to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="mo">A reference to a MapObject to read the data from.</param>
		private void writeWorld(ref BinaryWriter bw, ref MapObject mo)
		{
			writeBase(ref bw, ref mo);
			writeEntityData(ref bw, ((MapWorld)mo).Data);
			bw.Write(((MapWorld)mo).Paths.Count);
			for (int i = 0; i < ((MapWorld)mo).Paths.Count; i++) {
				writePath(ref bw, ((MapWorld)mo).Paths[i]);
			}
		}
		
		/// <summary>
		/// Reads a group object from a BinaryReader. Does not return
		/// anything, rather modifies a supplied MapObject.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the group from.</param>
		/// <param name="mo">A reference to a MapObject to insert the data into.</param>
		private void readGroup(ref BinaryReader br, ref MapObject mo)
		{
			readBase(ref br, ref mo);
		}
		
		/// <summary>
		/// Writes a group object to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="mo">A reference to a MapObject to read the data from.</param>
		private void writeGroup(ref BinaryWriter bw, ref MapObject mo)
		{
			writeBase(ref bw, ref mo);
		}
		
		/// <summary>
		/// Reads a solid object from a BinaryReader. Does not return
		/// anything, rather modifies a supplied MapObject.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the solid from.</param>
		/// <param name="mo">A reference to a MapObject to insert the data into.</param>
		private void readSolid(ref BinaryReader br, ref MapObject mo)
		{
			readBase(ref br, ref mo);
			int faces = br.ReadInt32();
			for (int i = 0; i < faces; i++) {
				((MapSolid)mo).addFace(readFace(ref br));
			}
		}
		
		/// <summary>
		/// Writes a solid object to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="mo">A reference to a MapObject to read the data from.</param>
		private void writeSolid(ref BinaryWriter bw, ref MapObject mo)
		{
			writeBase(ref bw, ref mo);
			bw.Write(((MapSolid)mo).Faces.Count);
			for (int i = 0; i < ((MapSolid)mo).Faces.Count; i++) {
				writeFace(ref bw, ((MapSolid)mo).Faces[i]);
			}
		}
		
		/// <summary>
		/// Reads an entity object from a BinaryReader. Does not return
		/// anything, rather modifies a supplied MapObject.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the entity from.</param>
		/// <param name="mo">A reference to a MapObject to insert the data into.</param>
		private void readEntity(ref BinaryReader br, ref MapObject mo)
		{
			readBase(ref br, ref mo);
			((MapEntity)mo).Data = readEntityData(ref br);
			br.ReadBytes(2);
			((MapEntity)mo).Origin = readCoordinate(ref br);
			br.ReadBytes(4);
		}
		
		/// <summary>
		/// Writes an entity object to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="mo">A reference to a MapObject to read the data from.</param>
		private void writeEntity(ref BinaryWriter bw, ref MapObject mo)
		{
			writeBase(ref bw, ref mo);
			writeEntityData(ref bw, ((MapEntity)mo).Data);
			bw.Write(new byte[2]);
			writeCoordinate(ref bw, ((MapEntity)mo).Origin);
			bw.Write(new byte[4]);
		}
		
		/// <summary>
		/// Reads a map object from a BinaryReader. The map object can either be
		/// a world, a group, a solid, or an entity.
		/// </summary>
		/// <param name="br">A reference to a BinaryReader to read the entity from.</param>
		/// <returns>A MapObject, as read from the BinaryReader.</returns>
		private MapObject readMapObject(ref BinaryReader br)
		{
			//read type of object
			string type = readVariableLengthString(ref br);
			MapObject mo;
			if (type.Contains("World")) {
				mo = new MapWorld();
				mo.Classname = type;
				readWorld(ref br, ref mo);
			}
			else if (type.Contains("Group")) {
				mo = new MapGroup();
				mo.Classname = type;
				readGroup(ref br, ref mo);
			}
			else if (type.Contains("Solid")) {
				mo = new MapSolid();
				mo.Classname = type;
				readSolid(ref br, ref mo);
			}
			else if (type.Contains("Entity")) {
				mo = new MapEntity();
				mo.Classname = type;
				readEntity(ref br, ref mo);
			}
			else throw new Exception();
			return mo;
		}
		
		/// <summary>
		/// Writes a map object to a BinaryWriter.
		/// </summary>
		/// <param name="bw">A reference to a BinaryWriter to write the string to.</param>
		/// <param name="mo">The MapObject object to write to the BinaryWriter.</param>
		private void writeMapObject(ref BinaryWriter bw, MapObject mo)
		{
			if (mo is MapWorld) {
				writeVariableLengthString(ref bw, "CMapWorld", true);
				writeWorld(ref bw, ref mo);
			}
			else if (mo is MapGroup) {
				writeVariableLengthString(ref bw, "CMapGroup", true);
				writeGroup(ref bw, ref mo);
			}
			else if (mo is MapSolid) {
				writeVariableLengthString(ref bw, "CMapSolid", true);
				writeSolid(ref bw, ref mo);
			}
			else if (mo is MapEntity) {
				writeVariableLengthString(ref bw, "CMapEntity", true);
				writeEntity(ref bw, ref mo);
			}
			else throw new Exception();
		}
		
		/// <summary>
		/// Parses the structure of an RMF file.
		/// </summary>
		/// <param name="path">The full string path of the RMF file to open.</param>
		/// <returns>A MapClass containing the data retrieved from the RMF file.</returns>
		public MapClass parse(string path)
		{
			error = false;
			//setup return object
			MapClass map = new MapClass();
			//Open the RMF with a BinaryReader
			Stream s = new FileStream(path,FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(s);
			//Read the version and error out if it is incompatible
			//Note that currently, only 2.2 is supported!
			//Needs to be rounded otherwise it isn't exactly 2.2,
			//it'd be 2.200000012312 or whatever.
			float version = (float)Math.Round(br.ReadSingle(),1);
			if (version != 2.2f) {
				error = true;
				System.Windows.Forms.MessageBox.Show("Invalid version.\nExpected: 2.2\nActual: "+version);
				throw new Exception();
			}
			map.Version = (decimal)version;
			//read the header, just to check it's an RMF
			string RMF = readConstantLengthString(ref br, 3, false);
			if (RMF != "RMF") {
				error = true;
				System.Windows.Forms.MessageBox.Show("Invalid file.\nExpected: RMF\nActual: "+RMF);
				throw new Exception();
			}
			//read all the visgroups
			int numvisgroups = br.ReadInt32();
			for (int i = 0; i < numvisgroups; i++) {
				MapVisgroup vis = readVisGroup(ref br);
				map.addVisgroup(vis);
			}
			//tiny bit haxy here, but it's true that if this is a
			//valid RMF, readMapObject() should return a MapWorld,
			//so technically, this is perfectly acceptable.
			map.Worldspawn = (MapWorld)readMapObject(ref br);
			//just checking the DOCINFO. RMF is an anal format, so if
			//everything else works and this doesn't, it's still invalid.
			string DOCINFO = readConstantLengthString(ref br, 8, true);
			if (DOCINFO != "DOCINFO") {
				error = true;
				System.Windows.Forms.MessageBox.Show("Invalid file.\nExpected: DOCINFO\nActual: "+DOCINFO);
				throw new Exception();
			}
			//unused float. seems to be a version number of some sort.
			//why this needs to be here when the RMF has a version already
			//confuses and scares me. for the record, it's 0.2.
			br.ReadSingle();
			//finally, read all the camera data.
			map.Activecamera = br.ReadInt32();
			int numcams = br.ReadInt32();
			for (int i = 0; i < numcams; i++) {
				MapCamera cam = readCamera(ref br);
				map.addCamera(cam);
			}
			return map;
		}
		
		/// <summary>
		/// Saves an RMF to the specified path.
		/// </summary>
		/// <param name="map">The map class to save.</param>
		/// <param name="path">The location of the file to save to.</param>
		public void save(Document doc, string path)
		{
			MapClass map = doc.Map;
			error = false;
			Stream s = new FileStream(path,FileMode.Create,FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(s);
			//Write the version - 2.2
			float version = 2.2f;
			bw.Write(version);
			//write the header
			bw.Write("RMF".ToCharArray());
			//write all the visgroups
			int numvisgroups = map.Visgroups.Count;
			bw.Write(numvisgroups);
			for (int i = 0; i < numvisgroups; i++) {
				writeVisGroup(ref bw, map.Visgroups[i]);
			}
			//write the world (also writes all the children)
			writeMapObject(ref bw, map.Worldspawn);
			//write DOCINFO
			bw.Write("DOCINFO".ToCharArray());
			bw.Write('\0');
			//unused float. seems to be a version number of some sort.
			//why this needs to be here when the RMF has a version already
			//confuses and scares me. for the record, it's 0.2.
			float camversion = 0.2f;
			bw.Write(camversion);
			//finally, write all the camera data.
			bw.Write((int)map.Activecamera);
			int numcams = map.Cameras.Count;
			bw.Write(numcams);
			for (int i = 0; i < numcams; i++) {
				writeCamera(ref bw, map.Cameras[i]);
			}
		}
	}
}
