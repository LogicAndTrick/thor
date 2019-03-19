from System import *
from System.Drawing import *
from System.Windows.Forms import *
from thor import *
from QuickForms import *

titles = ["Twist", "Curve", "Corner", "Circle", "Cone", "Dome", "Noise", "Convert", "Heightmap", "Formula"]

def Twist(sender, e):
	form = QuickForm("Twist")
	form.Width = 250
	form.Label("Create the signature twisted hallway of Twister.")
	form.NumericUpDown("Start Angle", 0, 90, 0)
	form.NumericUpDown("Finish Angle", 1, 180, 0)
	form.GetControl("Finish Angle").Value = 90
	form.OkCancel(None, None)
	if form.ShowDialog() == DialogResult.OK:
		start = form.Decimal("Start Angle")
		finish = form.Decimal("Finish Angle")
		MessageBox.Show("Values:\n" + start.ToString() + " - " + finish.ToString())
	form.Dispose()

def Curve(sender, e):
	form = Form();
	form.Show();

def Corner(sender, e):
	form = Form();
	form.Show();

def Circle(sender, e):
	form = Form();
	form.Show();

def Cone(sender, e):
	form = Form();
	form.Show();

def Dome(sender, e):
	form = Form();
	form.Show();

def Noise(sender, e):
	form = Form();
	form.Show();

def Convert(sender, e):
	form = Form();
	form.Show();

def Heightmap(sender, e):
	form = Form();
	form.Show();

def Formula(sender, e):
	form = Form();
	form.Show();

item = ToolStripMenuItem("Twister")
for x in titles:
	ddi = ToolStripMenuItem(x);
	ddi.Click += locals()[x]
	item.DropDownItems.Add(ddi);

PluginAPI.AddMenuItem(item);
