/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 25/12/2008
 * Time: 3:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace thor
{
	/// <summary>
	/// Description of QuadSplitControl.
	/// </summary>
	public partial class QuadSplitControl : UserControl
	{
		public enum DisplayMode {
			Normal,
			TopLeft,
			TopRight,
			BottomLeft,
			BottomRight
		}
		
		int horizontalSplitLocation;
		int verticalSplitLocation;
		
		int newHorizontalSplitLocation;
		int newVerticalSplitLocation;
		
		int splitterWidth;
		int borderPadding;
		
		int minHeight;
		int minWidth;
		
		bool draggingH;
		bool draggingV;
		
		DisplayMode display;
		bool autosizeViews;
		
		QuadSplitDragPanel qsH;
		QuadSplitDragPanel qsV;
		
		#region Properties
		/// <summary>
		/// Get or set the location of the horizontal splitter.
		/// </summary>
		public int HorizontalSplitLocation {
			get { return horizontalSplitLocation; }
			set { horizontalSplitLocation = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set the location of the vertical splitter.
		/// </summary>
		public int VerticalSplitLocation {
			get { return verticalSplitLocation; }
			set { verticalSplitLocation = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set the width of the splitters.
		/// </summary>
		public int SplitterWidth {
			get { return splitterWidth; }
			set { splitterWidth = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set the padding between the sides of the control
		/// and the sides of the panels.
		/// </summary>
		public int BorderPadding {
			get { return borderPadding; }
			set { borderPadding = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set the minimum height of each panel.
		/// </summary>
		public int MinHeight {
			get { return minHeight; }
			set { minHeight = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set the minimum Width of each panel.
		/// </summary>
		public int MinWidth {
			get { return minWidth; }
			set { minWidth = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set the display mode of the control.
		/// </summary>
		public DisplayMode Display {
			get { return display; }
			set { display = value; updateAllPanels(); }
		}
		
		/// <summary>
		/// Get or set whether the views will automatically
		/// resize themselves to all the the same size.
		/// </summary>
		public bool AutosizeViews {
			get { return autosizeViews; }
			set { autosizeViews = value; updateAllPanels(); }
		}
		#endregion
		
		#region Initialize Component
		private System.ComponentModel.IContainer components = null;
		
		private thor.QuadSplitPanel panel1;
		private thor.QuadSplitPanel panel2;
		private thor.QuadSplitPanel panel3;
		private thor.QuadSplitPanel panel4;
		
		public QuadSplitPanel TopLeftPanel {
			get { return panel1; }
		}
		
		public QuadSplitPanel TopRightPanel {
			get { return panel2; }
		}
		
		public QuadSplitPanel BottomLeftPanel {
			get { return panel3; }
		}
		
		public QuadSplitPanel BottomRightPanel {
			get { return panel4; }
		}
		
		private Panel hGhost;
		private Panel vGhost;
		
		private void InitializeComponent()
		{
			this.panel1 = new thor.QuadSplitPanel(this);
			this.panel2 = new thor.QuadSplitPanel(this);
			this.panel3 = new thor.QuadSplitPanel(this);
			this.panel4 = new thor.QuadSplitPanel(this);
			this.hGhost = new Panel();
			this.vGhost = new Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightBlue;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 0;
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.LightCyan;
			this.panel2.Location = new System.Drawing.Point(3, 109);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 100);
			this.panel2.TabIndex = 0;
			this.panel2.BorderStyle = BorderStyle.Fixed3D;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.LightSeaGreen;
			this.panel3.Location = new System.Drawing.Point(3, 215);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 100);
			this.panel3.TabIndex = 0;
			this.panel3.BorderStyle = BorderStyle.Fixed3D;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Bisque;
			this.panel4.Location = new System.Drawing.Point(3, 321);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 103);
			this.panel4.TabIndex = 0;
			this.panel4.BorderStyle = BorderStyle.Fixed3D;
			//
			// hGhost
			//
			this.hGhost.Visible = false;
			this.hGhost.Location = new Point(0,0);
			this.hGhost.Size = new Size(1,1);
			//
			// vGhost
			//
			this.vGhost.Visible = true;
			this.vGhost.Location = new Point(0,0);
			this.vGhost.Size = new Size(1,1);
			// 
			// QuadSplitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.hGhost);
			this.Controls.Add(this.vGhost);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Name = "QuadSplitControl";
			this.Size = new System.Drawing.Size(469, 548);
			this.ResumeLayout(false);
		}
		#endregion
		
		#region Constructor
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public QuadSplitControl()
		{
			//SplitContainer
			InitializeComponent();
			display = DisplayMode.Normal;
			newHorizontalSplitLocation = 0;
			newVerticalSplitLocation = 0;
			splitterWidth = 3;
			borderPadding = 3;
			minHeight = 20;
			minWidth = 20;
			autosizeViews = false;
			qsH = new QuadSplitDragPanel();
			qsV = new QuadSplitDragPanel();
			autosize();
		}
		#endregion
		
		#region Update Panel Sizes
		/// <summary>
		/// Autosizes the 4 panels to each be half the
		/// width and height of the size of the control.
		/// </summary>
		public void autosize()
		{
			if (display != DisplayMode.Normal) return;
			horizontalSplitLocation = this.Height/2;
			verticalSplitLocation = this.Width/2;
			updateAllPanels();
		}
		
		/// <summary>
		/// Handles resize. Autosizes if it is enabled,
		/// otherwise attempts to leave the splitter in
		/// the same position.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			if (autosizeViews) {
				autosize();
				return;
			}
			updateAllPanels();
			base.OnResize(e);
		}
		
		/// <summary>
		/// Updates all 4 panels and splitters based on their current co-ordinates.
		/// </summary>
		private void updateAllPanels()
		{
			int usablewidth = this.Width - (borderPadding*2);
			int usableheight = this.Height - (borderPadding*2);
			if (display != DisplayMode.Normal) {
				panel1.Visible = false;
				panel2.Visible = false;
				panel3.Visible = false;
				panel4.Visible = false;
				if (display == DisplayMode.TopLeft) {
					panel1.Visible = true;
					panel1.Location = new Point(borderPadding,borderPadding);
					panel1.Size = new Size(usablewidth,usableheight);
				}
				else if (display == DisplayMode.TopRight) {
					panel2.Visible = true;
					panel2.Location = new Point(borderPadding,borderPadding);
					panel2.Size = new Size(usablewidth,usableheight);
				}
				else if (display == DisplayMode.BottomLeft) {
					panel3.Visible = true;
					panel3.Location = new Point(borderPadding,borderPadding);
					panel3.Size = new Size(usablewidth,usableheight);
				}
				else if (display == DisplayMode.BottomRight) {
					panel4.Visible = true;
					panel4.Location = new Point(borderPadding,borderPadding);
					panel4.Size = new Size(usablewidth,usableheight);
				}
				return;
			}
			else {
				panel1.Visible = true;
				panel2.Visible = true;
				panel3.Visible = true;
				panel4.Visible = true;
			}
			//-----
			if (horizontalSplitLocation - (splitterWidth/2) <= minHeight) horizontalSplitLocation = minHeight - (splitterWidth/2);
			else if (usableheight - (horizontalSplitLocation - (splitterWidth/2)) <= minHeight) horizontalSplitLocation = usableheight - (minHeight - (splitterWidth/2));
			if (verticalSplitLocation - (splitterWidth/2) <= minWidth) verticalSplitLocation = minWidth - (splitterWidth/2);
			else if (usablewidth - (verticalSplitLocation - (splitterWidth/2)) <= minWidth) verticalSplitLocation = usablewidth - (minWidth - (splitterWidth/2));
			//-----
			int leftwidth = verticalSplitLocation - (splitterWidth / 2) - borderPadding;
			int rightwidth = usablewidth - (splitterWidth + leftwidth);
			int topheight = horizontalSplitLocation - (splitterWidth / 2) - borderPadding;
			int bottomheight = usableheight - (splitterWidth + topheight);
			//-----
			panel1.Location = new Point(borderPadding, borderPadding);
			panel1.Size = new Size(leftwidth,topheight);
			panel2.Location = new Point(borderPadding + leftwidth + splitterWidth, borderPadding);
			panel2.Size = new Size(rightwidth,topheight);
			panel3.Location = new Point(borderPadding, borderPadding + topheight + splitterWidth);
			panel3.Size = new Size(leftwidth,bottomheight);
			panel4.Location = new Point(borderPadding + leftwidth + splitterWidth, borderPadding + topheight + splitterWidth);
			panel4.Size = new Size(rightwidth,bottomheight);
		}
		#endregion
		
		#region Collision Detection
		/// <summary>
		/// Used to detect if a point is inside =
		/// the horizontal splitter or not.
		/// </summary>
		/// <param name="x">The X co-ordinate of the point.</param>
		/// <param name="y">The Y co-ordinate of the point.</param>
		/// <returns>True if the given point is inside
		/// the horizontal splitter, false otherwise.</returns>
		private bool insideHorizontalSplitter(int x, int y)
		{
			int usablewidth = this.Width - (borderPadding*2);
			//-----
			int topheight = horizontalSplitLocation - (splitterWidth / 2) - borderPadding;
			//-----
			if (x <= borderPadding) return false;
			if (x >= borderPadding + usablewidth) return false;
			if (y < borderPadding + topheight) return false;
			if (y > borderPadding + topheight + splitterWidth) return false;
			return true;
		}
		
		/// <summary>
		/// Used to detect if a point is inside =
		/// the vertical splitter or not.
		/// </summary>
		/// <param name="x">The X co-ordinate of the point.</param>
		/// <param name="y">The Y co-ordinate of the point.</param>
		/// <returns>True if the given point is inside
		/// the vertical splitter, false otherwise.</returns>
		private bool insideVerticalSplitter(int x, int y)
		{
			int usableheight = this.Height - (borderPadding*2);
			//-----
			int leftwidth = verticalSplitLocation - (splitterWidth / 2) - borderPadding;
			//-----
			if (y <= borderPadding) return false;
			if (y >= borderPadding + usableheight) return false;
			if (x < borderPadding + leftwidth) return false;
			if (x > borderPadding + leftwidth + splitterWidth) return false;
			return true;
		}
		#endregion
		
		#region Ghost Splitters
		/// <summary>
		/// Draws the horizontal ghost splitter.
		/// </summary>
		private void repositionHorizontalGhostSplitter()
		{
			int usableheight = this.Height - (borderPadding*2);
			//-----
			if (newHorizontalSplitLocation - (splitterWidth/2) <= minHeight) newHorizontalSplitLocation = minHeight - (splitterWidth/2);
			else if (usableheight - (newHorizontalSplitLocation - (splitterWidth/2)) <= minHeight) newHorizontalSplitLocation = usableheight - (minHeight - (splitterWidth/2));
			//-----
			/*HatchBrush b = new HatchBrush(HatchStyle.Percent40,Color.Gray,Color.Transparent);
			hGhost.Location = new Point(borderPadding,newHorizontalSplitLocation-(splitterWidth/2));
			hGhost.Size = new Size(this.Width-(borderPadding*2),splitterWidth);
			Graphics g = hGhost.CreateGraphics();
			g.FillRectangle(b,0,0,hGhost.Width,hGhost.Height);
			g.Dispose();
			b.Dispose();*/
			qsH.UpdateLocation( this.PointToScreen( new Point(borderPadding,newHorizontalSplitLocation-(splitterWidth/2)) ) );
		}
		
		/// <summary>
		/// Draws the vertical ghost splitter.
		/// </summary>
		private void repositionVerticalGhostSplitter()
		{
			int usablewidth = this.Width - (borderPadding*2);
			//-----
			if (newVerticalSplitLocation - (splitterWidth/2) <= minWidth) newVerticalSplitLocation = minWidth - (splitterWidth/2);
			else if (usablewidth - (newVerticalSplitLocation - (splitterWidth/2)) <= minWidth) newVerticalSplitLocation = usablewidth - (minWidth - (splitterWidth/2));
			//-----
			/*HatchBrush b = new HatchBrush(HatchStyle.Percent40,Color.Gray,Color.Transparent);
			vGhost.Location = new Point(newVerticalSplitLocation-(splitterWidth/2),borderPadding);
			vGhost.Size = new Size(splitterWidth,this.Height-(borderPadding*2));
			Graphics g = vGhost.CreateGraphics();
			g.FillRectangle(b,0,0,vGhost.Width,vGhost.Height);
			g.Dispose();
			b.Dispose();*/
			qsV.UpdateLocation( this.PointToScreen( new Point(newVerticalSplitLocation-(splitterWidth/2),borderPadding) ) );
		}
		#endregion
		
		#region Mouse Events		
		/// <summary>
		/// Allows an object to manually execute a MouseMove event
		/// </summary>
		/// <param name="e">A MouseEventArgs instance.</param>
		public void MouseOver(MouseEventArgs e)
		{
			if (draggingH || draggingV) OnMouseMove(e);
		}
		
		/// <summary>
		/// Handles mouse move. Draws ghost splitters if
		/// they are enabled, and handle hover cursor icons.
		/// </summary>
		/// <param name="e">A MouseEventArgs instance.</param>
		[EditorBrowsableAttribute()]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			int mouseX = e.X;
			int mouseY = e.Y;
			if (draggingH) {
				newHorizontalSplitLocation = mouseY;
				repositionHorizontalGhostSplitter();
			}
			if (draggingV) {
				newVerticalSplitLocation = mouseX;
				repositionVerticalGhostSplitter();
			}
			if (!draggingH && !draggingV) {
				bool inHSplit = insideHorizontalSplitter(mouseX,mouseY);
				bool inVSplit = insideVerticalSplitter(mouseX,mouseY);
				if (inHSplit && inVSplit) Cursor = Cursors.SizeAll;
				else if (inHSplit) Cursor = Cursors.HSplit;
				else if (inVSplit) Cursor = Cursors.VSplit;
				else Cursor = Cursors.Default;
			}
			base.OnMouseMove(e);
		}
		
		/// <summary>
		/// Handles mouse click down. Enables resizing
		/// if left button is on the resize area.
		/// </summary>
		/// <param name="e">A MouseEventArgs instance.</param>
		[EditorBrowsableAttribute()]
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			int mouseX = e.X;
			int mouseY = e.Y;
			bool inHSplit = insideHorizontalSplitter(mouseX,mouseY);
			bool inVSplit = insideVerticalSplitter(mouseX,mouseY);
			draggingH = false;
			draggingV = false;
			if (inHSplit) {
				//
				qsH.UpdateLocation( this.PointToScreen( new Point(borderPadding,newHorizontalSplitLocation-(splitterWidth/2)) ) );
				qsH.CursorXDifference =  Cursor.Position.X - qsH.Location.X;
				qsH.CursorYDifference = Cursor.Position.Y - qsH.Location.Y;
				qsH.BackColor = Color.LightGray;
				qsH.ChangeSize( new Size(this.Width-(borderPadding*2),splitterWidth) );
				qsH.ShowForm();
				//
				hGhost.Visible = true;
				repositionHorizontalGhostSplitter();
				draggingH = true;
			}
			if (inVSplit) {
				//
				qsV.UpdateLocation( this.PointToScreen( new Point(newVerticalSplitLocation-(splitterWidth/2),borderPadding) ) );
				qsV.CursorXDifference =  Cursor.Position.X - qsV.Location.X;
				qsV.CursorYDifference = Cursor.Position.Y - qsV.Location.Y;
				qsV.BackColor = Color.LightGray;
				qsV.ChangeSize( new Size(splitterWidth,this.Height-(borderPadding*2)) );
				qsV.ShowForm();
				//
				vGhost.Visible = true;
				repositionVerticalGhostSplitter();
				draggingV = true;
			}
			base.OnMouseDown(e);
		}
		
		/// <summary>
		/// Handles mouse click up. Disables resizing
		/// and resizes appropriately if it was enabled.
		/// </summary>
		/// <param name="e">A MouseEventArgs instance.</param>
		[EditorBrowsableAttribute()]
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			if (draggingH) horizontalSplitLocation = newHorizontalSplitLocation;
			if (draggingV) verticalSplitLocation = newVerticalSplitLocation;
			if (draggingH || draggingV) updateAllPanels();
			draggingH = false;
			hGhost.Visible = false;
			qsH.Hide();
			draggingV = false;
			qsV.Hide();
			vGhost.Visible = false;
			base.OnMouseUp(e);
		}
		
		/// <summary>
		/// Handles mouse leaving the control. Resets
		/// the cursor, unless resizing is enabled.
		/// </summary>
		/// <param name="e">An EventArgs instance.</param>
		[EditorBrowsableAttribute()]
		protected override void OnMouseLeave(EventArgs e)
		{
			if (draggingH || draggingV) return;
			this.Cursor = Cursors.Default;
			base.OnMouseLeave(e);
		}
		#endregion
		
		#region Dispose
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			qsV.Dispose();
			qsH.Dispose();
			base.Dispose(disposing);
		}
		#endregion
	}
}
