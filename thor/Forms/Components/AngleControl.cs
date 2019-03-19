/*
 * User: Dan
 * Date: 20/12/2008
 * Time: 12:05 AM
 * 
 * Comments: I had a lot of fun making this class.
 * Custom graphics, trigonometry, and the satisfaction
 * of seeing it come together to behave like Hammer's
 * version, and look better than it! (Because of AA)
 * 
 * Should consider complete. Some of the variables
 * (size/center of circle, colours) could be extracted,
 * but for now it is unnecessary.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace thor
{
	/// <summary>
	/// Handles the event of the angle of an AngleControl changing.
	/// </summary>
	public delegate void AngleChangedEventHandler(object sender, AngleChangedEventArgs e);
	
	/// <summary>
	/// Holds the event data for the AngleChanged event.
	/// </summary>
	public class AngleChangedEventArgs : EventArgs
	{
		/// <summary>
		/// A string representation of the angle.
		/// </summary>
		private string text;
		
		/// <summary>
		/// The angle in degrees.
		/// </summary>
		private int degrees;
		
		/// <summary>
		/// The angle in radians.
		/// </summary>
		private double radians;
		
		/// <summary>
		/// Get a string representation of the angle.
		/// </summary>
		public string Text {
			get { return text; }
		}
		
		/// <summary>
		/// Get the current angle in degrees.
		/// </summary>
		public int Degrees {
			get { return degrees; }
		}
		
		/// <summary>
		/// Get the current angle in radians.
		/// </summary>
		public double Radians {
			get { return radians; }
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public AngleChangedEventArgs()
		{
			radians = 0;
			degrees = 0;
			text = degrees.ToString();
		}
		
		/// <summary>
		/// Takes arguments from the AngleChanged object
		/// to set the correct properties.
		/// </summary>
		/// <param name="rad">The current angle in radians.</param>
		public AngleChangedEventArgs(double rad)
		{
			radians = rad;
			degrees = (int)(rad*180/Math.PI);
			text = degrees.ToString();
		}
	}
	
	/// <summary>
	/// An AngleControl is used as a convenient way for a user
	/// to set an angle of between 0 and 360 degrees, using a
	/// mouse drag-and-drop approach.
	/// </summary>
	public partial class AngleControl : UserControl
	{
		/// <summary>
		/// The internally represented angle, stored in Radians.
		/// </summary>
		private double angle;
		
		/// <summary>
		/// Indicates whether to use "Up" or "Down" (or neither).<br/>
		/// 0 = Use Angle<br/>
		/// 1 = Up<br/>
		/// 2 = Down
		/// </summary>
		private int elevation;
		
		/// <summary>
		/// Stored so that the control can be clicked inside
		/// and then dragged outside for greater precision.
		/// </summary>
		private bool draggedinside;
		
		/// <summary>
		/// A string representation of the current angle.
		/// Can be 0-360, "Up", or "Down".
		/// </summary>
		private string anglestring;
		
		/// <summary>
		/// Fired when the angle is changed.
		/// </summary>
		public event AngleChangedEventHandler AngleChangedEvent;
		
		/// <summary>
		/// Get the angle that is currently set, in degrees.
		/// </summary>
		public int Angle {
			get { return (int)(angle*180/Math.PI); }
		}
		
		/// <summary>
		/// Get a string representation of the current angle.
		/// </summary>
		public override string Text {
			get { return anglestring; }
		}
		
		/// <summary>
		/// Whether or not to show the up/down/angle combo box.
		/// </summary>
		private bool showTextBox;
		
		/// <summary>
		/// Get or set whether or not to show the up/down/angle combo box.
		/// </summary>
		public bool ShowTextBox {
			get { return showTextBox; }
			set {
				showTextBox = value;
				lblAngles.Visible = value;
				cmbAngles.Visible = value;
			}
		}
		
		/// <summary>
		/// Get or set whether to show the label underneath the angle circle.
		/// </summary>
		public bool ShowLabel {
			get { return lblAngle.Visible; }
			set { lblAngle.Visible = value; }
		}
		
		/// <summary>
		/// Basic constructor.
		/// </summary>
		public AngleControl()
		{
			InitializeComponent();
			//default angle is 0 degrees
			angle = 0;
			elevation = 0;
			draggedinside = false;
			anglestring = Angle.ToString();
			//fireAngleChangedEvent();
			showTextBox = true;
		}
		
		/// <summary>
		/// Fires the AngleChanged Event with the current angle
		/// in degrees, or the "Up"/"Down" strings.
		/// </summary>
		private void fireAngleChangedEvent()
		{
			OnAngleChangedEvent(new AngleChangedEventArgs(angle));
		}
		
		/// <summary>
		/// Fires the AngleChanged event given a AngleChangedEventArgs instance.
		/// </summary>
		/// <param name="e">The AngleChangedEventArgs to fire.</param>
		protected virtual void OnAngleChangedEvent(AngleChangedEventArgs e)
		{
			if (AngleChangedEvent == null) return;
			AngleChangedEvent(this,e);
		}
		
		/// <summary>
		/// Sets the current angle, in degrees.<br/>
		/// Valid inputs:<br/>
		/// -1: Sets the angle to Up<br/>
		/// -2: Sets the angle to Down<br/>
		/// 0-360: Sets the angle to the supplied value in degrees.
		/// </summary>
		/// <param name="ang">The angle to set as current, in degrees.</param>
		/// <exception cref="ArgumentException">If the angle is not in the valid range.</exception>
		public void setAngle(int ang)
		{
			if (ang < -2 || ang > 359) throw new ArgumentException("The angle must be between -2 and 359.");
			if (ang < 0) {
				elevation = -ang;
				if (elevation == 1) anglestring = "Up";
				if (elevation == 2) anglestring = "Down";
			}
			else {
				//convert the angle to radians
				angle = (double)(ang * Math.PI / 180);
				elevation = 0;
				anglestring = Angle.ToString();
			}
			updateAngle();
			fireAngleChangedEvent();
		}
		
		/// <summary>
		/// Sets the current angle, in radians.
		/// </summary>
		/// <param name="ang">The angle to set as current, in radians.</param>
		public void setAngle(double ang)
		{
			setAngle((int)Math.Floor(ang * 180 / Math.PI));
		}
		
		/// <summary>
		/// Sets the current angle to Up.
		/// </summary>
		public void setUp()
		{
			setAngle(-1);
		}
		
		/// <summary>
		/// Sets the current angle to Down.
		/// </summary>
		public void setDown()
		{
			setAngle(-2);
		}
		
		/// <summary>
		/// Paints the control.
		/// </summary>
		/// <param name="e">A PaintEventArgs instance.</param>
		[EditorBrowsableAttribute()]
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			//set the quality to high for some lovely anti-aliasing
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			//just initialising some junk...
			SolidBrush fill = new SolidBrush(Color.Black);		//colour of the background circle
			Pen top = new Pen(Color.FromArgb(167,166,170),4);	//colour of the darker half of the outer rim
			Pen bot = new Pen(Color.White,4);					//...and the lighter half.
			//drawing the outer rim
			int x = Width - 38;
			g.DrawArc(bot,x,2,36,36,315,180);
			g.DrawArc(top,x,2,36,36,135,180);
			//drawing the inner black fill
			g.FillEllipse(fill, x, 2, 36, 36);
			updateAngle(g);
		}
		
		void updateAngle()
		{
			Graphics g = CreateGraphics();
			updateAngle(g);
			g.Dispose();
		}
		
		/// <summary>
		/// Updates the line indicating the angle.
		/// </summary>
		void updateAngle(Graphics g)
		{
			int x = Width - 40;
			SolidBrush fill = new SolidBrush(Color.Black);	//colour of the background circle
			Pen line = new Pen(Color.White,1);				//colour of the angle line
			//drawing the inner black fill
			//this is a slightly smaller fill, it covers the angle line
			//but it doesn't mess with the anti-aliasing.
			//This means that the entire control doesn't have to be redrawn
			//every time the angle changes, which causes a "flickering" effect.
			//turn off anti-aliasing because it might interfere with the edges of the outer rim
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
			//make sure it doesn't touch the rim by making it smaller (but it still covers the angle line)
			g.FillEllipse(fill, x + 4, 4, 32, 32);
			//drawing the angle line
			//use anti-aliasing
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			if (elevation > 0) {
				//draw a single pixel in the center.
				//amazingly, there doesn't appear to be a better way to do this,
				//every other way draws 2 pixels.
				Bitmap pt = new Bitmap(1, 1);
				pt.SetPixel(0, 0, Color.White);		//colour of the angle "dot"
				g.DrawImageUnscaled(pt, 20, 20);
				pt.Dispose();
			}
			else {
				//draw the line so that it doesn't touch
				//the rim, but still looks "normal".
				//basic trigonometry. the line will be 15 pixels long.
				int xcoord = x + (int)Math.Round(Math.Cos(angle)*15,0)+20;
				int ycoord = -(int)Math.Round(Math.Sin(angle)*15,0)+20;
				g.DrawLine(line,x + 20,20,xcoord,ycoord);
			}
			lblAngle.Text = anglestring;
			cmbAngles.Text = anglestring;
		}
		
		/// <summary>
		/// Updates the angle using the current mouse position.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">A MouseEventArgs instance.</param>
		void AngleControlMouseMove(object sender, MouseEventArgs e)
		{
			//check that mouse dragging is enabled
			if (draggedinside) {
				int x = Width - 40;
				int xcoord = (e.X-20) - x;
				int ycoord = -(e.Y-20);
				//find the angle of the imaginary line formed between
				//the center and the mouse position
				double ang = (double)Math.Atan2(ycoord,xcoord);
				//turn "-179" into "181", and the like (in radians though).
				//Easier to work with positive numbers, even though they're the same angle.
				if (ang < 0) ang += (double)(2*Math.PI);
				setAngle(ang);
			}
		}
		
		/// <summary>
		/// Checks to see if the mouse is inside the control
		/// circle when the left button is clicked, and if it
		/// is, enables mouse dragging.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">A MouseEventArgs instance.</param>
		void AngleControlMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			int x = Width - 40;
			int xcoord = (e.X-20) - x;
			int ycoord = -(e.Y-20);
			//check that the mouse was clicked inside the circle.
			float dist = (float)Math.Sqrt(Math.Pow(xcoord,2)+Math.Pow(ycoord,2));
			if (dist < 20) {
				draggedinside = true;
				//update the current angle, in case the mouse isn't
				//moved before the mouse button is released.
				AngleControlMouseMove(sender,e);
			}
		}
		
		/// <summary>
		/// Disables mouse dragging when the left mouse button is released.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">A MouseEventArgs instance.</param>
		void AngleControlMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			draggedinside = false;
		}
		
		void CmbAnglesSelectedIndexChanged(object sender, EventArgs e)
		{
			setAngle(-(cmbAngles.SelectedIndex + 1));
		}
		
		void CmbAnglesKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				int i;
				if (int.TryParse(cmbAngles.Text, out i)) {
					if (i >= 0 && i <= 359) {
						setAngle(i);
					}
				}
			}
		}
	}
}
