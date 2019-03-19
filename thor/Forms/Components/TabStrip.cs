/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 4/11/2009
 * Time: 7:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Description of TabStrip.
	/// </summary>
	public partial class TabStrip : UserControl
	{
		public event EventHandler<EventArgs<int>> SelectedIndexChanged;
		public event EventHandler TabAdded;
		public event EventHandler TabRemoved;
		
		protected virtual void OnSelectedIndexChanged(int si) 
		{
			if (SelectedIndexChanged != null) {
				SelectedIndexChanged(this, new EventArgs<int>(si));
			}
			Refresh();
		}
		
		protected virtual void OnTabAdded() 
		{
			if (TabAdded != null) {
				TabAdded(this, EventArgs.Empty);
			}
			Refresh();
		}
		
		protected virtual void OnTabRemoved() 
		{
			if (TabRemoved != null) {
				TabRemoved(this, EventArgs.Empty);
			}
			Refresh();
		}
		
		private EventList<object> items;
		private Color inactiveTabBackColour;
		private Color activeTabBackColour;
		private Color inactiveTabForeColour;
		private Color activeTabForeColour;
		private int selectedIndex;
		private Font selectedFont;
		
		bool dragging;
		int startDragIndex;
		int tabOffset;
		
		public Color InactiveTabBackColour {
			get { return inactiveTabBackColour; }
			set { inactiveTabBackColour = value; }
		}
		
		public Color ActiveTabBackColour {
			get { return activeTabBackColour; }
			set { activeTabBackColour = value; }
		}
		
		public Color InactiveTabForeColour {
			get { return inactiveTabForeColour; }
			set { inactiveTabForeColour = value; }
		}
		
		public Color ActiveTabForeColour {
			get { return activeTabForeColour; }
			set { activeTabForeColour = value; }
		}

		[Browsable(false)]
		public int SelectedIndex {
			get { return selectedIndex; }
			set {
				if (value >= items.Count) throw new IndexOutOfRangeException();
				selectedIndex = value;
				OnSelectedIndexChanged(value);
			}
		}
		
		[Browsable(false)]
		public EventList<object> Items {
			get { return items; }
		}
		
		public Font SelectedFont {
			get { return selectedFont; }
			set { selectedFont = value; }
		}
		
		public TabStrip()
		{
			items = new EventList<object>();
			items.AddRange(new string[] { "one is long", "two is longer", "three is really really long", "four is kinda long", "five", "six is longer than most", "seven is not", "eight", "nine is longer than eight", "and finally, ten is the longest of all!" });
			items.Changed += new EventHandler<EventArgs<ChangeEvent>>(items_Changed);
			selectedIndex = -1;
			dragging = false;
			startDragIndex = -1;
			tabOffset = 0;
			InitializeComponent();
		}

		void items_Changed(object sender, EventArgs<ChangeEvent> e)
		{
			if (items.Count > 0) {
				if (SelectedIndex < 0) {
					SelectedIndex = items.Count - 1;
				}
			} else {
				SelectedIndex = -1;
			}
			if (e.Value == ChangeEvent.Add) OnTabAdded();
			else OnTabRemoved();
		}
		
		int[] GetTabLengths()
		{
			Graphics g = CreateGraphics();
			int[] lengths = new int[items.Count];
			for (int i = 0; i < items.Count; i++) {
				string measure = items[i].ToString();
				lengths[i] = (int)g.MeasureString(measure, Font).Width + 20;
				if (i == selectedIndex) lengths[i] += 5;
			}
			g.Dispose();
			return lengths;
		}
		
		protected override void OnResize(EventArgs e)
		{
			int[] lengths = GetTabLengths();
			int sum = 70;
			for (int i = tabOffset; i < lengths.Length; i++) {
				sum += lengths[i];
			}
			for (int i = tabOffset - 1; i >= 0; i--) {
				sum += lengths[i];
				if (sum < Width) tabOffset = i;
			}
			Refresh();
			base.OnResize(e);
		}
		
		int iconOffset = -2;
		
		int arrowLeft = 6;
		int arrowRight = 26;
		int arrowWidth = 6;
		int arrowHeight = 10;
		
		int closeWidth = 8;
		int closeRight = 7;
		
		int tabLeft = 20;
		int tabRight = 50;
		
		protected override void OnPaint(PaintEventArgs e)
		{
			if (items.Count == 0) return;
			
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;
			
			SolidBrush iabg = new SolidBrush(inactiveTabBackColour);			
			SolidBrush abg = new SolidBrush(activeTabBackColour);			
			SolidBrush iafg = new SolidBrush(inactiveTabForeColour);
			SolidBrush afg = new SolidBrush(activeTabForeColour);
			
			bool drawLeftArrow = tabOffset > 0;
			bool drawRightArrow = false;
			
			int[] lengths = GetTabLengths();
			
			for (int i = items.Count-1; i >= -1; i--) {
				if (i >= 0 && (i == selectedIndex || i < tabOffset)) continue;
				if (i < 0) {
					i = selectedIndex;
					g.DrawLine(Pens.Black, 0, Height-1, Width, Height-1);
					if (i < 0 || i < tabOffset) {
						break;
					}
				}
				
				int startx = tabLeft;
				for (int j = tabOffset; j < i; j++) startx += lengths[j];
				
				int width = lengths[i];
				if ((startx + width + tabRight) > Width) {
					drawRightArrow = true;
					if (i == selectedIndex) break;
					continue;
				}
				PointF[] points = new PointF[] {
					new PointF(startx - 10, Height),
					new PointF(startx - 8, Height - 1),
					new PointF(startx - 5, Height - 3),
					new PointF(startx + 5, 3),
					new PointF(startx + 8, 1),
					new PointF(startx + 10, 0),
					new PointF(startx + width - 2, 0),
					new PointF(startx + width, 2),
					new PointF(startx + width, Height)
				};
				
				g.DrawClosedCurve(Pens.Black, points, 0, FillMode.Winding);
				
				if (i == selectedIndex) {
					g.FillClosedCurve(abg, points, FillMode.Winding, 0);
					g.DrawString(items[i].ToString(), selectedFont, afg, startx + 12, (Height - Font.Height) / 2);
				} else {
					g.FillClosedCurve(iabg, points, FillMode.Winding, 0);
					g.DrawString(items[i].ToString(), Font, iafg, startx + 12, (Height - Font.Height) / 2);
				}
				
				if (i == selectedIndex) break;
			}
			
			if (drawRightArrow) {
				DrawRightArrow(g);
			}
			if (drawLeftArrow) {
				DrawLeftArrow(g);
			}
			if (items.Count > 0 || selectedIndex >= 0) {
				DrawClose(g);
			}
			
			afg.Dispose();
			abg.Dispose();
			iafg.Dispose();
			iabg.Dispose();
		}
		
		void DrawRightArrow(Graphics g)
		{
			int end = Width - arrowRight;
			int start = end - arrowWidth;
			int height = arrowHeight / 2;
			int offset = Height / 2 + iconOffset;
			PointF[] points = new PointF[] {
              	new PointF(start, offset - height),
              	new PointF(end, offset),
              	new PointF(start, offset + height)
			};
			g.FillPolygon(Brushes.Black, points);
		}
		
		void DrawLeftArrow(Graphics g)
		{
			int end = arrowLeft + arrowWidth;
			int start = arrowLeft;
			int height = arrowHeight / 2;
			int offset = Height / 2 + iconOffset;
			PointF[] points = new PointF[] {
              	new PointF(end, offset - height),
              	new PointF(start, offset),
              	new PointF(end, offset + height)
			};
			g.FillPolygon(Brushes.Black, points);
		}
		
		void DrawClose(Graphics g)
		{
			int end = Width - closeRight;
			int start = end - closeWidth;
			int height = closeWidth / 2;
			int offset = Height / 2 + iconOffset;
			Pen p = new Pen(Color.Black, 2);
			g.DrawLine(p, start, offset - height, end, offset + height);
			g.DrawLine(p, start, offset + height, end, offset - height);
			p.Dispose();
		}
		
		int IndexOfTabAt(int xposition)
		{
			int[] lengths = GetTabLengths();
			
			for (int i = tabOffset; i < items.Count; i++) {
				
				int startx = tabLeft;
				for (int j = tabOffset; j < i; j++) startx += lengths[j];
				
				int width = lengths[i];
				if ((startx + width + tabRight) > Width) break;
				if (xposition >= startx && xposition <= startx + width) return i;
			}
			return -1;
		}
		
		int ArrowState(int xposition)
		{
			bool right = false;
			bool left = (tabOffset > 0);
			
			int[] lengths = GetTabLengths();
			
			for (int i = 0; i < items.Count; i++) {
				
				int startx = tabLeft;
				for (int j = tabOffset; j < i; j++) startx += lengths[j];
				
				int width = lengths[i];
				if ((startx + width + tabRight) > Width) {
					right = true;
					break;
				}
			}
			
			int rend = Width - arrowRight;
			int rstart = rend - arrowWidth;
			int lend = arrowLeft + arrowWidth;
			int lstart = arrowLeft;
			
			if (right && xposition >= rstart && xposition <= rend) return 1;
			if (left && xposition >= lstart && xposition <= lend) return -1;
			return 0;
		}
		
		bool CloseState(int xposition)
		{
			if (selectedIndex < 0) return false;
			if (items.Count == 0) return false;
			int end = Width - closeRight;
			int start = end - closeWidth;
			if (xposition >= start && xposition <= end) return true;
			return false;
		}
			
		
		void TabStripMouseDown(object sender, MouseEventArgs e)
		{
			int tabIndex = IndexOfTabAt(e.X);
			int arrow = ArrowState(e.X);
			if (tabIndex >= 0) {
				SelectedIndex = tabIndex;
				dragging = true;
				startDragIndex = tabIndex;
			} else if (arrow > 0) {
				tabOffset++;
				Refresh();
			} else if (arrow < 0) {
				tabOffset--;
				Refresh();
			}
		}
		
		void TabStripMouseUp(object sender, MouseEventArgs e)
		{
			if (dragging) {
				dragging = false;
				if (selectedIndex != startDragIndex) {
					OnSelectedIndexChanged(selectedIndex);
				}
				startDragIndex = -1;
			}
		}
		
		void TabStripMouseMove(object sender, MouseEventArgs e)
		{
			if (dragging) {
				int i = IndexOfTabAt(e.X);
				if (i >= 0 && i != selectedIndex) {
					object temp = items[i];
					items[i] = items[selectedIndex];
					items[selectedIndex] = temp;
					selectedIndex = i;
					Refresh();
				}
			}
		}
	}
}
