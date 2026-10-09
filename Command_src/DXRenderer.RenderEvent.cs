namespace DXRenderer;

internal enum RenderEvent : byte
{
	BeginDrawing,
	DrawingEnabled,
	CombinePolygons,
	Present,
	FinishedDrawing,
	Keypress
}
