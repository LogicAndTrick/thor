from System import *
from System.Drawing import *
from System.Windows.Forms import *
from thor import *
"""class TestTool(BoxTool):
	def __init__(self, doc):
		self.toolName = "PyTest"
	def Copy(self, doc):
		return TestTool(doc)
	def getCursor(self, atype, e, view):
		return Cursors.Cross
	def singleClick(self, e, view):
		return # MessageBox.Show("You clicked once!")
	def postActionCleanup(self):
		return
	def getBoxRenderColour(self):
		return Color.Blue
		
class GuideTool(BaseTool):
	def __init__(self, doc):
		self.toolName = "PyGuide"
		self.point1 = DecimalCoordinate(0,0,0)
		self.point2 = DecimalCoordinate(0,0,0)
	def getImage(self):
		return Bitmap(40,40);
	def Copy(self, doc):
		return GuideTool(doc)
	def getCursor(self, atype, e, view):
		return Cursors.Default
	def actionNeeded(self, atype):
		return True
	def performAction(self, atype, e, view):
		return
	def render(self, s, view):
		sizeFont = Graphics.Font(ThorFonts.FreeSans,16);
		tstFont = sizeFont.Render("GUIDE MODE",Color.White,True);
		s.Blit(tstFont);
		return
    	
plugtest = GuideTool(Document.makeDummyDocument())
PluginAPI.addTool(plugtest)"""