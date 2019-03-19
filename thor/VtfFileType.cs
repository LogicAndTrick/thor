using System;
using System.Runtime.InteropServices;

namespace thor
{
    public class VTFFileTypes : IFileTypeFactory
    {
		public static readonly FileType Vtf = new VtfFileType();
	    private static FileType[] FileTypes = new FileType[] { Vtf };

		internal FileTypeCollection GetFileTypeCollection()
		{
            return new FileTypeCollection(FileTypes);
		}

		public FileType[] GetFileTypeInstances()
		{
            return (FileType[])FileTypes.Clone();
		}
    }

    [Guid("449c5c3e-cf3c-11db-8314-0800200c9a66")]
    public class VtfFileType : FileType
    {
		public VtfFileType() : base("VTF", true, false, true, true, false, new string[] { ".vtf" })
		{
            VtfLib.vlInitialize();
		}

        ~VtfFileType()
        {
            // It seems there are multiple concurrent instances of this class...
            //VtfLib.vlShutdown();
        }

		public override SaveConfigWidget CreateSaveConfigWidget()
		{
			return new VtfSaveConfigWidget();
		}

		protected override SaveConfigToken OnCreateDefaultSaveConfigToken()
		{
            return new VtfSaveConfigToken();
		}

        protected override void OnSave(Document Input, System.IO.Stream Output, SaveConfigToken Token, Surface ScratchSurface, ProgressEventHandler Callback)
		{
            new VtfFile().Save(Output, Input, (VtfSaveConfigToken)Token, ScratchSurface);
		}

		protected override Document OnLoad(System.IO.Stream Input)
		{
            return new VtfFile().Load(Input);
		}
	}
}
