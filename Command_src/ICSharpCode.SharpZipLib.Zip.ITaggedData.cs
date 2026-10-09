namespace ICSharpCode.SharpZipLib.Zip;

public interface ITaggedData
{
	ushort TagID { get; }

	void SetData(byte[] data, int offset, int count);

	byte[] GetData();
}
