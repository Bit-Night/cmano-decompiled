namespace Command.SlitherinePBEM3.Models;

internal class SerialVerificationModel
{
	public int GameID;

	public string Version;

	public int ErrorCode;

	public string ErrorComment;

	public string DebugMessage;

	static SerialVerificationModel()
	{
		Class72.smethod_20();
	}
}
