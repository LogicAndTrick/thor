/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/12/2008
 * Time: 1:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace thor
{
	/// <summary>
	/// Description of VMFParser.
	/// </summary>
	public class VMFParser : MapParserInterface
	{
		public VMFParser()
		{
		}
		
		public bool isError()
		{
			return false;
		}
		
		private decimal[] parseMultipleDecimals(string s, char separator)
		{
			string[] str = s.Split(separator);
			int num = str.Length;
			decimal[] ret = new decimal[num];
			for (int i = 0; i < num; i++) {
				ret[i] = decimal.Parse(str[i], (System.Globalization.NumberStyles)0x00A4);
			}
			return ret;
		}
		
		private MapEntityData loadData(GenericStructure gs)
		{
			MapEntityData ed = new MapEntityData();
			foreach (KeyValuePair<string, string> kv in gs.PropertyList) {
				MapProperty p = new MapProperty();
				p.Key = kv.Key;
				p.Value = kv.Value;
				ed.addProperty(p);
			}
			return ed;
		}
		
		private MapFace loadFace(GenericStructure gs)
		{
			/*
				"id" "3"
				"plane" "(-960 0 0) (-960 1920 0) (-960 1920 640)"
				"material" "NATURE/BLENDCLIFFDIRT001A"
				"uaxis" "[0 -1 0 468] 1"
				"vaxis" "[0 0 -1 128] 1"
				"rotation" "0"
				"lightmapscale" "16"
				"smoothing_groups" "0"
			*/
			Regex clr = new Regex(@"\s+", RegexOptions.Multiline);
			MapFace face;
			GenericStructure dispinfo = gs.substructureNamed("dispinfo");
			if ((object)dispinfo != null) face = new MapDisplacement();
			else face = new MapFace();
			string points = clr.Replace(gs.PropertyList["plane"].Replace("(","").Replace(")","")," ").Trim(" ".ToCharArray());
			string[] pnts = points.Split(' ');
			DecimalPlane pln = new DecimalPlane(new DecimalCoordinate(decimal.Parse(pnts[0]),decimal.Parse(pnts[1]),decimal.Parse(pnts[2])),
			                                    new DecimalCoordinate(decimal.Parse(pnts[3]),decimal.Parse(pnts[4]),decimal.Parse(pnts[5])),
			                                    new DecimalCoordinate(decimal.Parse(pnts[6]),decimal.Parse(pnts[7]),decimal.Parse(pnts[8])));
			face.Plane = pln;
			face.Texture = gs.PropertyList["material"];
			string uax = clr.Replace(gs.PropertyList["uaxis"].Replace("[","").Replace("]","")," ").Trim(" ".ToCharArray());
			string[] ux = uax.Split(' ');
			Vector4 uaxis = new Vector4();
			uaxis.setValue(0,decimal.Parse(ux[0]));
			uaxis.setValue(1,decimal.Parse(ux[1]));
			uaxis.setValue(2,decimal.Parse(ux[2]));
			uaxis.setValue(3,decimal.Parse(ux[3]));
			face.Uaxis = uaxis;
			face.Uscale = decimal.Parse(ux[4]);
			string vax = clr.Replace(gs.PropertyList["vaxis"].Replace("[","").Replace("]","")," ").Trim(" ".ToCharArray());
			string[] vx = vax.Split(' ');
			Vector4 vaxis = new Vector4();
			vaxis.setValue(0,decimal.Parse(vx[0]));
			vaxis.setValue(1,decimal.Parse(vx[1]));
			vaxis.setValue(2,decimal.Parse(vx[2]));
			vaxis.setValue(3,decimal.Parse(vx[3]));
			face.Vaxis = vaxis;
			face.Vscale = decimal.Parse(vx[4]);
			face.Rotation = decimal.Parse(gs.PropertyList["rotation"]);
			if (face is MapDisplacement) {
				/*
					"power" "2"
					"startposition" "[-960 0 640]"
					"flags" "0"
					"elevation" "0"
					"subdiv" "0"
				*/
				MapDisplacement md = (MapDisplacement)face;
				md.Power = int.Parse(dispinfo.PropertyList["power"]);
				md.Startposition = DecimalCoordinate.Parse(dispinfo.PropertyList["startposition"].Trim(']','['), ' ');
				md.Elevation = decimal.Parse(dispinfo.PropertyList["elevation"]);
				md.Subdiv = (dispinfo.PropertyList["subdiv"] != "0");
				int rows = (int)Math.Pow(2, md.Power) + 1;
				/*
				normals
					"row0" "0.993486 0.0235839 -0.11149 0 0 1 0 0 1 0 0 1 0 0 1"
				offset_normals
					"row0" "-0.5 0 0.5 0 0 1 0 0 1 0 0 1 0 0 1"
				distances
					"row0" "150.062 49.6811 90.8529 38.7279 57.8087"
				offsets
					"row0" "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0"
				*/
				DecimalCoordinate[,] norms = new DecimalCoordinate[rows, rows];
				DecimalCoordinate[,] offnorms = new DecimalCoordinate[rows, rows];
				DecimalCoordinate[,] offs = new DecimalCoordinate[rows, rows];
				decimal[,] dists = new decimal[rows, rows];
				decimal[,] alphs = new decimal[rows, rows];
				GenericStructure normals = dispinfo.substructureNamed("normals");
				GenericStructure offset_normals = dispinfo.substructureNamed("offset_normals");
				GenericStructure distances = dispinfo.substructureNamed("distances");
				GenericStructure offsets = dispinfo.substructureNamed("offsets");
				GenericStructure alphas = dispinfo.substructureNamed("alphas");
				for (int i = 0; i < rows; i++) {
					DecimalCoordinate[] tn = DecimalCoordinate.ParseMultiple(normals.PropertyList["row" + i], ' ');
					DecimalCoordinate[] to = DecimalCoordinate.ParseMultiple(offsets.PropertyList["row" + i], ' ');
					DecimalCoordinate[] ton = DecimalCoordinate.ParseMultiple(offset_normals.PropertyList["row" + i], ' ');
					decimal[] td = parseMultipleDecimals(distances.PropertyList["row" + i], ' ');
					decimal[] ta = parseMultipleDecimals(alphas.PropertyList["row" + i], ' ');
					for (int j = 0; j < tn.Length; j++) {
						norms[i,j] = tn[j];
						offnorms[i,j] = ton[j];
						offs[i,j] = to[j];
						dists[i,j] = td[j];
						alphs[i,j] = ta[j];
					}
				}
				md.Normals = norms;
				md.OffsetNormals = offnorms;
				md.Offsets = offs;
				md.Distances = dists;
				md.Alphas = alphs;
			}
			return face;
		}
		
		private MapSolid loadSolid(GenericStructure gs)
		{
			MapSolid solid = new MapSolid();
			Random r = new Random();
			solid.Colour = Color.FromArgb(r.Next(0,256),r.Next(0,256),r.Next(0,256));
			GenericStructure[] listface = gs.substructuresNamed("side");
			foreach (GenericStructure face in listface) {
				solid.addFace(loadFace(face));
			}
			//get vertices
			DecimalPlane[] planes = new DecimalPlane[solid.Faces.Count];
			for (int i = 0; i < solid.Faces.Count; i++) {
				planes[i] = solid.Faces[i].Plane;
			}
			DecimalCoordinate[][] verts = Converter.planesToVertices(planes);
			for (int i = 0; i < verts.Length; i++) {
				solid.Faces[i].addVertices(verts[i]);
			}
			//---
			GenericStructure editor = gs.substructureNamed("editor");
			string[] col = editor.PropertyList["color"].Split(' ');
			Color clr = Color.FromArgb(int.Parse(col[0]),int.Parse(col[1]),int.Parse(col[2]));
			solid.Colour = clr;
			solid.reCalcBBox();
			return solid;
		}
		
		private List<MapSolid> loadSolids(GenericStructure gs)
		{
			List<MapSolid> solids = new List<MapSolid>();
			GenericStructure[] listsol = gs.substructuresNamed("solid");
			foreach (GenericStructure sol in listsol) {
				solids.Add(loadSolid(sol));
			}
			return solids;
		}
		
		private MapWorld loadWorld(GenericStructure gs)
		{
			MapWorld w = new MapWorld();
			w.Data = loadData(gs);
			w.Classname = "worldspawn";
			List<MapSolid> solids = loadSolids(gs);
			foreach (MapSolid sol in solids) w.Children.Add(sol);
			return w;
		}
		
		/// <summary>
		/// Takes a path to a VMF file and returns a parsed MapClass.
		/// </summary>
		/// <param name="path">The string path file to parse.</param>
		/// <returns>A MapClass, as parsed from the file.</returns>
		public MapClass parse(string path)
		{
			GenericParser p = new GenericParser();
			GenericStructure parsed = p.parseFromFile(path);
			//---
			MapClass map = new MapClass();
			GenericStructure world = parsed.substructureNamed("world");
			if ((object)world == null) throw new Exception();
			map.Worldspawn = loadWorld(world);
			
			
			return map;
		}
		
		public void save(Document doc, string path)
		{
			
		}
	}
}
