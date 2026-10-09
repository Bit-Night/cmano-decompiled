namespace VectorTileRenderer;

public interface ITileProvider
{
	byte[] GetTileData(int x, int y, int zoom);
}
