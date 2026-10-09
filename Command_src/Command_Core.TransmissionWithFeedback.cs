using System.Collections.Generic;
using System.Drawing;

namespace Command_Core;

public class TransmissionWithFeedback
{
	public Contact theContact;

	public List<ActiveUnit> senderUnitList;

	public Transmission theTransmission;

	public ActiveUnit receiver;

	public TransmissionFeedbacResult result;

	public TransmissionWithFeedback(Contact theContact, List<ActiveUnit> senderUnitList, Transmission theTransmission, ActiveUnit myUnit, TransmissionFeedbacResult theResult)
	{
		this.theContact = theContact;
		this.senderUnitList = senderUnitList;
		this.theTransmission = theTransmission;
		receiver = myUnit;
		result = theResult;
	}

	internal Color GetFeedbackColor()
	{
		Color color = default(Color);
		return result switch
		{
			TransmissionFeedbacResult.Invalid => Color.Red, 
			TransmissionFeedbacResult.Discarded => Color.Yellow, 
			TransmissionFeedbacResult.Updated => Color.Purple, 
			TransmissionFeedbacResult.Added => Color.LimeGreen, 
			_ => color, 
		};
	}

	static TransmissionWithFeedback()
	{
		Class72.smethod_20();
	}
}
