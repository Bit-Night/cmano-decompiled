namespace CommandNetcode.RT;

public enum ContactMiscAction
{
	Null,
	Drop,
	MarkFriendly,
	MarkNeutral,
	MarkUnfriendly,
	MarkHostile,
	MarkPosition,
	ToggleFilteredOutStatus,
	FilterOutAllOn,
	FilterOutAllOff,
	FilterOutCivilianOn,
	FilterOutCivilianOff,
	FilterOutBiologicOn,
	FilterOutBiologicOff,
	FilterOutNeutralOn,
	FilterOutNeutralOff,
	FilterOutFriendlyOn,
	FilterOutFriendlyOff,
	RequestUpdateOnContacts
}
