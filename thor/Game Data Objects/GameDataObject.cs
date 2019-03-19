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
	public class GameDataObject : IComparable<GameDataObject>
	{
		string name;
		string description;
		GameDataClassTypes classType;
		List<string> baseClasses;
		List<GameDataBehaviour> behaviours;
		List<GameDataProperty> properties;
		List<GameDataIO> io;
		
		public List<GameDataIO> IO {
			get { return io; }
		}
		
		public GameDataClassTypes ClassType {
			get { return classType; }
		}
		
		public List<string> BaseClasses {
			get { return baseClasses; }
		}
		
		public List<GameDataBehaviour> Behaviours {
			get { return behaviours; }
		}
		
		public List<GameDataProperty> Properties {
			get { return properties; }
		}
		
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		public string Name {
			get { return name; }
		}
		
		public GameDataObject(string n, string d, GameDataClassTypes ct)
		{
			name = n;
			description = d;
			classType = ct;
			baseClasses = new List<string>();
			behaviours = new List<GameDataBehaviour>();
			properties = new List<GameDataProperty>();
			io = new List<GameDataIO>();
		}
		
		public bool containsBehaviour(string name)
		{
			foreach (GameDataBehaviour b in behaviours) {
				if (b.Name == name) return true;
			}
			return false;
		}
		
		public GameDataBehaviour getBehaviour(string name)
		{
			foreach (GameDataBehaviour b in behaviours) {
				if (b.Name == name) return b;
			}
			return null;
		}
		
		public bool containsProperty(string name)
		{
			foreach (GameDataProperty p in properties) {
				if (p.Name == name) return true;
			}
			return false;
		}
		
		public bool containsIO(string name, GameDataIOTypes type)
		{
			foreach (GameDataIO i in io) {
				if (i.Name == name && i.IOType == type) return true;
			}
			return false;
		}
		
		public void inherit(GameDataObject gdo)
		{
			if (gdo == null) throw new Exception("Cannot interit from a null base");
			foreach (GameDataBehaviour o in gdo.behaviours) {
				if (!containsBehaviour(o.Name)) behaviours.Add(o);
			}
			foreach (GameDataProperty o in gdo.properties) {
				if (!containsProperty(o.Name)) properties.Add(o);
			}
			foreach (GameDataIO o in gdo.io) {
				if (!containsIO(o.Name,o.IOType)) io.Add(o);
			}
		}
		
		public int CompareTo(GameDataObject o)
		{
			return this.name.CompareTo(o.name);
		}
		
		private List<GameDataIO> getInputs()
		{
			List<GameDataIO> lst = new List<GameDataIO>();
			foreach (GameDataIO gdio in io) {
				if (gdio.IOType == GameDataIOTypes.Input) lst.Add(gdio);
			}
			return lst;
		}
		
		private List<GameDataIO> getOutputs()
		{
			List<GameDataIO> lst = new List<GameDataIO>();
			foreach (GameDataIO gdio in io) {
				if (gdio.IOType == GameDataIOTypes.Output) lst.Add(gdio);
			}
			return lst;
		}
		
		/*
			@TypeClass base(base, classes) behav1(b1val) behav2(b2val) = classname : "Description"
			[
				//Properties
				spawnflags(flags) =
				[
					1 : "Description" : 0
					...
				]
			
				propname(choices) : "Short Desc" : 0 : "Long Desc" =
				[
					0 : "Description"
					...
				]
			
				propname(proptype) : "Short Desc" : 1 : "Long Desc"
				
				// Inputs
				input inname(intype) : "Description"
				
				// Outputs
				output outname(outtype) : "Description"
			]
		*/
		
		public override string ToString()
		{
			string s = "";
			s += "@" + classType.ToString() + "Class";
			if (baseClasses.Count > 0) s += " base(";
			for (int i = 0; i < baseClasses.Count; i++) {
				if (i != 0) s += ", ";
				s += baseClasses[i];
			}
			if (baseClasses.Count > 0) s += ")";
			foreach (GameDataBehaviour b in behaviours) s += " " + b.ToString();
			s += " = " + name;
			if (description != "") s += " : \"" + description + "\"";
			s += "\r\n[";
			if (properties.Count > 0) s += "\r\n\t//Properties";
			foreach (GameDataProperty p in properties) {
				s += "\r\n" + p.ToString("\t") + "\r\n";
			}
			List<GameDataIO> ins = getInputs();
			if (ins.Count > 0) s += "\r\n\t//Inputs";
			foreach (GameDataIO gdio in ins) {
				s += "\r\n\t" + gdio.ToString();
			}
			List<GameDataIO> outs = getOutputs();
			if (ins.Count > 0 && outs.Count > 0) s += "\r\n";
			if (outs.Count > 0) s += "\r\n\t//Outputs";
			foreach (GameDataIO gdio in outs) {
				s += "\r\n\t" + gdio.ToString();
			}
			s += "\r\n]";
			return s;
		}
	}
}
