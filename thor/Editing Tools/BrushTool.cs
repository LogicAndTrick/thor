/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 14/03/2009
 * Time: 6:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace thor
{
	/// <summary>
	/// Description of BrushTool.
	/// </summary>
	public class BrushTool : BoxTool
	{
		public BrushTool(Document doc) : base(doc)
		{
		}
		
		public override BaseTool Copy(Document doc)
		{
			return new BrushTool(doc);
		}
		
		public override System.Drawing.Image getImage()
		{
			return new Bitmap("brushtool.png");
		}
		
		protected override Color getBoxRenderColour()
		{
			return Color.Green;
		}
		
		protected override void postActionCleanup()
		{
			return;
		}
		
		protected override void singleClick(System.Windows.Forms.MouseEventArgs e, NewGLMapView2D view)
		{
			return;
		}
		
		protected override void pressKey(System.Windows.Forms.KeyPressEventArgs e, NewGLMapView2D view)
		{
			if (e.KeyChar == 13) {
				if (state == BoxState.Drawn) {
					string brushName = Accessor.Instance.Main.ObjectTools.getSelectedString();
					BrushInterface brushFactory = Accessor.Instance.getPrimitive(brushName);
					if (brushFactory != null) {
						TextureObject current = null;
						if (associatedDocument.RecentTextures.Count > 0) {
							current = associatedDocument.RecentTextures[0];
						}
						List<MapObject> newBrush = brushFactory.makeBrush(selectBox);
						
						decimal scale = associatedDocument.GameConfig.TextureScale;
						
						foreach (MapObject o in newBrush) {
							foreach (MapFace f in ((MapSolid)o).Faces) {
								f.Uscale = scale;
								f.Vscale = scale;
								f.TextureResource = current;
								if (current != null) {
									f.Texture = current.ShortName;
									current.addReference();
								}
								f.alignToWorld();
							}
						}
						
						HistoryTransaction ht = associatedDocument.History.StartTransaction("Create " + brushName);
						ht.Create(newBrush);
						associatedDocument.History.FinishTransaction(ht);
						
						associatedDocument.addToMap(newBrush);
						
						/*foreach (MapObject o in newBrush) {
							associatedDocument.Map.Worldspawn.addChild(o);
						}*/
						
						associatedDocument.refreshAllViews();
					}
				}
				state = BoxState.None;
			}
			else {
				base.pressKey(e, view);
			}
		}
		
		public override void selected(bool isSelect)
		{
			DockObject o = Accessor.Instance.Main.ObjectTools;
			if (isSelect) {
				List<string> primList = new List<string>();
				foreach (BrushInterface b in Accessor.Instance.MasterPrimitiveList) {
					primList.Add(b.getName());
				}
				o.setList(primList);
				o.enableList(true);
			} else {
				o.clearList();
				o.disableList();
			}
			base.selected(isSelect);
		}
	}
}
