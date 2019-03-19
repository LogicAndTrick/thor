/*
 * HLExtract.Net
 * Copyright (C) 2008 Ryan Gregg
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using System;
using System.Runtime.InteropServices;

public sealed class HLLib
{
    #region Constants
    public const int VersionNumber = ((2 << 24) | (0 << 16) | (11 << 8) | 0);
    public const string VersionString = "2.0.11";

    public const uint IdInvalid = 0xffffffff;

    public const uint DefaultPackageTestBufferSize = 8;
    public const uint DefaultViewSize = 131072;
    public const uint DefaultCopyBufferSize = 131072;
    #endregion

    #region Enumerations
    public enum Option
    {
        Version = 0,
        Error,
        ErrorSystem,
        ErrorShortFormated,
        ErrorLongFormated,
        ProcOpen,
        ProcClose,
        ProcRead,
        ProcWrite,
        ProcSeek,
        ProcTell,
        ProcSize,
        ProcExtractItemStart,
        ProcExtractItemEnd,
        ProcExtractFileProgress,
        ProcValidateFileProgress,
        OverwriteFiles,
        PackageBound,
        PackageId,
        PackageSize,
        PackageTotalAllocations,
        PackageTotalMemoryAllocated,
        PackageTotalMemoryUsed,
        ReadEncrypted,
        ForceDefragment,
        ProcDefragmentProgress
    }

    public enum FileMode
	{
        ModeInvalid = 0x00,
        Read = 0x01,
        Write = 0x02,
        Create = 0x04,
        Volatile = 0x08,
        NoFilemapping = 0x10,
        QuickFilemapping = 0x20
	}

    public enum SeekMode
    {
        Beginning = 0,
        Current,
        End
    }

    public enum DirectoryItemType
    {
        None = 0,
        Folder,
        File
    }

    public enum SortOrder
    {
        Ascending = 0,
        Descending
    }

    public enum SortField
    {
        Name = 0,
        Size
    }

    public enum FindType
    {
        Files = 0x01,
        Folders = 0x02,
        NoRecurse = 0x04,
        CaseSensitive = 0x08,
        ModeString = 0x10,
        ModeSubstring = 0x20,
        ModeWildcard = 0x00,
        All = Files | Folders
    }

    public enum StreamType
    {
        StreamNone = 0,
        File,
        Gcf,
        Mapping,
        Memory,
        Proc
    }

    public enum MappingType
    {
        MappingNone = 0,
        File,
        Memory,
        Stream
    }

    public enum PackageType
    {
        None = 0,
        Bsp,
        Gcf,
        Pak,
        Vbsp,
        Wad,
        Xzp,
        Zip,
        Ncf
    }

    public enum AttributeType
    {
        Invalid = 0,
        Boolean,
        Integer,
        UnsignedInteger,
        Float,
        String
    }

    public enum PackageAttribute
    {
        BspPackageVersion = 0,
        BspPackageCount,
        BspItemWidth = 0,
        BspItemHeight,
        BspItemPaletteEntries,
        BspItemCount,

        GcfPackageVersion = 0,
        GcfPackageId,
        GcfPackageAllocatedBlocks,
        GcfPackageUsedBlocks,
        GcfPackageBlockLength,
        GcfPackageLastVersionPlayed,
        GcfPackageCount,
        GcfItemEncrypted = 0,
        GcfItemCopyLocal,
        GcfItemOverwriteLocal,
        GcfItemBackupLocal,
        GcfItemFlags,
        GcfItemFragmentation,
        GcfItemCount,

        NcfPackageVersion = 0,
        NcfPackageId,
        NcfPackageLastVersionPlayed,
        NcfPackageCount,
        NcfItemEncrypted = 0,
        NcfItemCopyLocal,
        NcfItemOverwriteLocal,
        NcfItemBackupLocal,
        NcfItemFlags,
        NcfItemCount,

        PakPackageCount = 0,
        PakItemCount = 0,

        VbspPackageVersion = 0,
        VbspPackageMapRevision,
        VbspPackageCount,
        VbspItemVersion = 0,
        VbspItemFourCc,
        VbspZipPackageDisk,
        VbspZipPackageComment,
        VbspZipItemCreateVersion,
        VbspZipItemExtractVersion,
        VbspZipItemFlags,
        VbspZipItemCompressionMethod,
        VbspZipItemCrc,
        VbspZipItemDisk,
        VbspZipItemComment,
        VbspItemCount,

        WadPackageVersion = 0,
        WadPackageCount,
        WadItemWidth = 0,
        WadItemHeight,
        WadItemPaletteEntries,
        WadItemMipmaps,
        WadItemCompressed,
        WadItemType,
        WadItemCount,

        XzpPackageVersion = 0,
        XzpPackagePreloadBytes,
        XzpPackageCount,
        XzpItemCreated = 0,
        XzpItemPreloadBytes,
        XzpItemCount,

        ZipPackageDisk = 0,
        ZipPackageComment,
        ZipPackageCount,
        ZipItemCreateVersion = 0,
        ZipItemExtractVersion,
        ZipItemFlags,
        ZipItemCompressionMethod,
        ZipItemCrc,
        ZipItemDisk,
        ZipItemComment,
        ZipItemCount
    }

    public enum Validation
    {
        Ok = 0,
        AssumedOk,
        Incomplete,
        Corrupt,
        Canceled,
        Error
    }
    #endregion

    #region Structures
    [StructLayout(LayoutKind.Explicit)]
    public struct Attribute
    {
        [FieldOffset(0)]
        public AttributeType eAttributeType;
        [FieldOffset(4)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=252)]
        public char[] lpName;
        [FieldOffset(256)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=256)]
        public byte[] lpValue;

        public string GetName()
        {
            int iLength = 0;
            while(lpName[iLength] != 0)
            {
                iLength++;
            }
            try
            {
                return new string(lpName, 0, iLength);
            }
            catch
            {
                return string.Empty;
            }
        }

        public object GetData()
        {
            switch (eAttributeType)
            {
                case AttributeType.Boolean:
                    return hlAttributeGetBoolean(ref this);
                case AttributeType.Integer:
                    return hlAttributeGetInteger(ref this);
                case AttributeType.UnsignedInteger:
                    return hlAttributeGetUnsignedInteger(ref this);
                case AttributeType.Float:
                    return hlAttributeGetFloat(ref this);
                case AttributeType.String:
                    return hlAttributeGetString(ref this);
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            switch (eAttributeType)
            {
                case AttributeType.Boolean:
                    return hlAttributeGetBoolean(ref this).ToString();
                case AttributeType.Integer:
                    return hlAttributeGetInteger(ref this).ToString("#,##0");
                case AttributeType.UnsignedInteger:
                    if (lpValue[4] == 0)
                    {
                        return hlAttributeGetUnsignedInteger(ref this).ToString("#,##0");
                    }
                    else // Display as hexadecimal.
                    {
                        return "0x" + hlAttributeGetUnsignedInteger(ref this).ToString("x8");
                    }
                case AttributeType.Float:
                    return hlAttributeGetFloat(ref this).ToString("#,##0.00000000");
                case AttributeType.String:
                    return hlAttributeGetString(ref this);
                default:
                    return string.Empty;
            }
        }
    }
    #endregion

    #region Callback Functions
	//
	// Important: Callback functions cannot use IntPtr.  Instead, I use [MarshalAs(UnmanagedType.I4)]int.
	// Convert IntPtr objects using IntPtr.ToInt32().  Convert int objects to IntPtr using new IntPtr(int).
	// This obviously only works on 32 bit builds of HLLib.
	//

	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	[return:MarshalAs(UnmanagedType.U1)]
	public delegate bool OpenProc(uint uiMode, [MarshalAs(UnmanagedType.I4)]int pUserData);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	[return:MarshalAs(UnmanagedType.U1)]
	public delegate bool CloseProc([MarshalAs(UnmanagedType.I4)]int pUserData);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate uint ReadProc([MarshalAs(UnmanagedType.I4)]int lpData, uint uiBytes, [MarshalAs(UnmanagedType.I4)]int pUserData);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate uint WriteProc([MarshalAs(UnmanagedType.I4)]int lpData, uint uiBytes, [MarshalAs(UnmanagedType.I4)]int pUserData);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate uint SeekProc(Int64 iOffset, SeekMode eSeekMode, [MarshalAs(UnmanagedType.I4)]int pUserData);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate uint TellProc([MarshalAs(UnmanagedType.I4)]int pUserData);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate uint SizeProc([MarshalAs(UnmanagedType.I4)]int pUserData);

	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate void ExtractItemStartProc([MarshalAs(UnmanagedType.I4)]int pItem);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate void ExtractItemEndProc([MarshalAs(UnmanagedType.I4)]int pItem, [MarshalAs(UnmanagedType.U1)]bool bSuccess);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate void ExtractFileProgressProc([MarshalAs(UnmanagedType.I4)]int pFile, uint uiBytesExtracted, uint uiBytesTotal, [MarshalAs(UnmanagedType.U1)]ref bool bCancel);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate void ValidateFileProgressProc(int pFile, uint uiBytesValidated, uint uiBytesTotal, [MarshalAs(UnmanagedType.U1)]ref bool pCancel);
	[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
	public delegate void DefragmentFileProgressProc([MarshalAs(UnmanagedType.I4)]int pFile, uint uiFilesDefragmented, uint uiFilesTotal, uint uiBytesDefragmented, uint uiBytesTotal, [MarshalAs(UnmanagedType.U1)]ref bool pCancel);
	#endregion

    #region Functions
    //
    // VTFLib
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlInitialize();
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlShutdown();

    //
    // Get/Set
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetBoolean(Option eOption);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetBooleanValidate(Option eOption, [MarshalAs(UnmanagedType.U1)]out bool pValue);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlSetBoolean(Option eOption, [MarshalAs(UnmanagedType.U1)]bool bValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int hlGetInteger(Option eOption);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetIntegerValidate(Option eOption, out int pValue);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlSetInteger(Option eOption, int iValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlGetUnsignedInteger(Option eOption);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetUnsignedIntegerValidate(Option eOption, out uint pValue);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlSetUnsignedInteger(Option eOption, uint uiValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern float hlGetFloat(Option eOption);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetFloatValidate(Option eOption, out float pValue);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlSetFloat(Option eOption, float pValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlGetString(Option eOption);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetStringValidate(Option eOption, out string pValue);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlSetString(Option eOption, string lpValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlGetVoid(Option eOption);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlGetVoidValidate(Option eOption, out IntPtr pValue);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlSetVoid(Option eOption, IntPtr lpValue);

    //
    // Attributes
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlAttributeGetBoolean(ref Attribute pAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlAttributeSetBoolean(ref Attribute pAttribute, string lpName, [MarshalAs(UnmanagedType.U1)]bool bValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int hlAttributeGetInteger(ref Attribute pAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlAttributeSetInteger(ref Attribute pAttribute, string lpName, int iValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlAttributeGetUnsignedInteger(ref Attribute pAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlAttributeSetUnsignedInteger(ref Attribute pAttribute, string lpName, uint uiValue, [MarshalAs(UnmanagedType.U1)]bool bHexadecimal);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern float hlAttributeGetFloat(ref Attribute pAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlAttributeSetFloat(ref Attribute pAttribute, string lpName, float fValue);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlAttributeGetString(ref Attribute pAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlAttributeSetString(ref Attribute pAttribute, string lpName, string lpValue);

    //
    // Directory Item
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern DirectoryItemType hlItemGetType(IntPtr pItem);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlItemGetName(IntPtr pItem);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlItemGetID(IntPtr pItem);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlItemGetData(IntPtr pItem);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlItemGetPackage(IntPtr pItem);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlItemGetParent(IntPtr pItem);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlItemGetSize(IntPtr pItem, out uint pSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlItemGetSizeOnDisk(IntPtr pItem, out uint pSize);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlItemGetPath(IntPtr pItem, IntPtr lpPath, uint uiPathSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlItemExtract(IntPtr pItem, string lpPath);

    //
    // Directory Folder
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFolderGetCount(IntPtr pItem);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlFolderGetItem(IntPtr pItem, uint uiIndex);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlFolderGetItemByName(IntPtr pItem, string lpName, FindType eFind);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlFolderGetItemByPath(IntPtr pItem, string lpPath, FindType eFind);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlFolderSort(IntPtr pItem, SortField eField, SortOrder eOrder, [MarshalAs(UnmanagedType.U1)]bool bRecurse);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlFolderFindFirst(IntPtr pFolder, string lpSearch, FindType eFind);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlFolderFindNext(IntPtr pFolder, IntPtr pItem, string lpSearch, FindType eFind);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFolderGetSize(IntPtr pItem, [MarshalAs(UnmanagedType.U1)]bool bRecurse);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFolderGetSizeOnDisk(IntPtr pItem, [MarshalAs(UnmanagedType.U1)]bool bRecurse);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFolderGetFolderCount(IntPtr pItem, [MarshalAs(UnmanagedType.U1)]bool bRecurse);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFolderGetFileCount(IntPtr pItem, [MarshalAs(UnmanagedType.U1)]bool bRecurse);

    //
    // Directory File
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFileGetExtractable(IntPtr pItem);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern Validation hlFileGetValidation(IntPtr pItem);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFileGetSize(IntPtr pItem);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlFileGetSizeOnDisk(IntPtr pItem);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlFileCreateStream(IntPtr pItem, out IntPtr pStream);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlFileReleaseStream(IntPtr pItem, IntPtr pStream);

    //
    // Stream
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern StreamType hlStreamGetType(IntPtr pStream);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlStreamGetOpened(IntPtr pStream);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlStreamGetMode(IntPtr pStream);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlStreamOpen(IntPtr pStream, uint uiMode);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlStreamClose(IntPtr pStream);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlStreamGetStreamSize(IntPtr pStream);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlStreamGetStreamPointer(IntPtr pStream);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlStreamSeek(IntPtr pStream, Int64 iOffset, SeekMode eSeekMode);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlStreamReadChar(IntPtr pStream, out char pChar);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlStreamRead(IntPtr pStream, IntPtr lpData, uint uiBytes);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlStreamWriteChar(IntPtr pStream, char iChar);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlStreamWrite(IntPtr pStream, IntPtr lpData, uint uiBytes);

    //
    // Package
    //

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlBindPackage(uint uiPackage);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern PackageType hlGetPackageTypeFromName(string lpName);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern PackageType hlGetPackageTypeFromMemory(IntPtr lpBuffer, uint uiBufferSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern PackageType hlGetPackageTypeFromStream(IntPtr pStream);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlCreatePackage(PackageType ePackageType, out uint uiPackage);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlDeletePackage(uint uiPackage);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern PackageType hlPackageGetType();
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlPackageGetExtension();
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlPackageGetDescription();

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageGetOpened();

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageOpenFile(string lpFileName, uint uiMode);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageOpenMemory(IntPtr lpData, uint uiBufferSize, uint uiMode);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageOpenProc(IntPtr pUserData, uint uiMode);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageOpenStream(IntPtr pStream, uint uiMode);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlPackageClose();

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageDefragment();

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr hlPackageGetRoot();

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlPackageGetAttributeCount();
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlPackageGetAttributeName(PackageAttribute eAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageGetAttribute(PackageAttribute eAttribute, out Attribute pAttribute);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint hlPackageGetItemAttributeCount();
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlPackageGetItemAttributeName(PackageAttribute eAttribute);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageGetItemAttribute(IntPtr pItem, PackageAttribute eAttribute, out Attribute pAttribute);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageGetExtractable(IntPtr pItem, [MarshalAs(UnmanagedType.U1)]out bool pExtractable);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageGetFileSize(IntPtr pItem, out uint pSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageGetFileSizeOnDisk(IntPtr pItem, out uint pSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlPackageCreateStream(IntPtr pItem, out IntPtr pStream);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlPackageReleaseStream(IntPtr pStream);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern string hlNCFFileGetRootPath();
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void hlNCFFileSetRootPath(string lpRootPath);

    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlWADFileGetImageSizePaletted(IntPtr pItem, out uint uiPaletteDataSize, out uint uiPixelDataSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlWADFileGetImageDataPaletted(IntPtr pItemm, out uint uiWidth, out uint uiHeight, out IntPtr lpPaletteData, out IntPtr lpPixelData);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlWADFileGetImageSize(IntPtr pItem, out uint uiPixelDataSize);
    [DllImport("HLLib.dll", CallingConvention = CallingConvention.Cdecl)]
    [return:MarshalAs(UnmanagedType.U1)]
    public static extern bool hlWADFileGetImageData(IntPtr pItem, out uint uiWidth, out uint uiHeight, out IntPtr lpPixelData);
    #endregion
}
