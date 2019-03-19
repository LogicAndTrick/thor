/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 19/12/2008
 * Time: 6:07 PM
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
	/// Description of EntityEditor.
	/// </summary>
	public partial class EntityEditor : Form
	{
		Document associatedDocument;
		List<MapEntity> entities;
		
		public List<MapEntity> Entities {
			get { return entities; }
			set {
				entities = value;
				updateForm();
			}
		}
		
		public EntityEditor(Document doc)
		{
			InitializeComponent();
			associatedDocument = doc;
			entities = new List<MapEntity>();
		}
		
		private GameDataClassTypes getType()
		{
			//
			return GameDataClassTypes.Point;
		}
		
		void updateForm()
		{
			
		}
	}
}
