/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/02/2009
 * Time: 6:52 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

	

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace thor {
	/// <summary>
	/// Credit: http://msdn.microsoft.com/smartclient/default.aspx?pull=/library/en-us/dnwinforms/html/colorpicker.asp
	/// </summary>
	internal class QuadSplitDragPanel : Form {

		[DllImport( "User32.dll" )]
		private static extern IntPtr ShowWindow( IntPtr hwnd, long nCmdShow );

		private const int WM_NCHITTEST    = 0x0084;
		private const int HTTRANSPARENT   = (-1);
		private const int SW_SHOWNOACTIVE = 4;

		/// <summary>
		/// Private data fields.
		/// </summary>
		private int m_cursorXDifference;
		private int m_cursorYDifference;
		private Size m_clientRectangleSize;
		
		/// <summary>
		/// Overloaded constructor that allows you to set the size property.
		/// </summary>
		/// <param name="size">A Size object representing the desired size.</param>

		internal QuadSplitDragPanel() : base() {

			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

			this.Size = new Size( 0, 0 );

			// Since the second parameter of the ShowWindow method in ShowForm
			// is ignored the first time the form is shown, work around this by
			// quickly showing and then hiding the form.
			ShowForm();
			Hide();

		}

		/// <summary>
		/// Sets the client size of the form equal to the Size parameter.
		/// </summary>
		/// <param name="newSize">The desired client area size.</param>

		internal void ChangeSize( Size newSize ) {

			m_clientRectangleSize = newSize;
			this.Size = newSize + new Size( 6, 24 );
			this.Region = new Region( new Rectangle( new Point( 3, 21 ), newSize ) );

		}

		/// <summary>
		/// Sets the location of the form relative to the top left corner of
		/// the client area as opposed to the top left corner of the window.
		/// </summary>
		/// <param name="newLocation">The new location of the form.</param>
		
		internal void UpdateLocation( Point newLocation ) {
			this.Location = new Point( newLocation.X - 3, newLocation.Y - 21 ); 
		}

		/// <summary>
		/// Displays the form with a transparency of .5, but does not make 
		/// it active.
		/// </summary>
		
		internal void ShowForm() {

			this.Opacity = .5f;
			ShowWindow( this.Handle, SW_SHOWNOACTIVE );
		
		}

		/// <summary>
		/// Represents the difference between the horizontal cursor location  
		/// and the location of this form.
		/// </summary>

		internal int CursorXDifference {
			get { return m_cursorXDifference; }
			set { m_cursorXDifference = value; }
		}

		/// <summary>
		/// Represents the difference between the vertical cursor location and 

		/// the location of this form.
		/// </summary>
		
		internal int CursorYDifference {
			get { return m_cursorYDifference; }
			set { m_cursorYDifference = value; }
		}
	
		/// <summary>
		/// Paints a rectangle using a SolidBrush object with the color of the
		/// BackColor property value. A thin 1f border is also drawn around the 
		/// external boundary.
		/// </summary>
		/// <param name="e">A PaintEventArgs that contains the event data.</param>
		
		protected override void OnPaint( PaintEventArgs e ) {
			//e.Graphics.DrawRectangle( Pens.Black, new Rectangle( new Point( 0, 0 ), new Size( m_clientRectangleSize.Width - 1, m_clientRectangleSize.Height - 1 ) ) );		
		}
		
		/// <summary>
		/// Overrides the Form's WndProc method to return HTTRANSPARENT when the
		/// WM_NCHITTEST message is returned.
		/// </summary>
		/// <param name="m">A message object containing the message data.</param>

		protected override void WndProc(ref Message m) {
	
			if (m.Msg == WM_NCHITTEST) {
				m.Result = ( IntPtr ) HTTRANSPARENT;
			} else {
				base.WndProc(ref m);
			}

		}
	
	} // DragForm

} // Sano.PersonalProjects.ColorPicker.Controls
