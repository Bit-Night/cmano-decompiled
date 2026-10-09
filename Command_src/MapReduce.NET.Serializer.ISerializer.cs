namespace MapReduce.NET.Serializer;

public interface ISerializer
{
	object Serialize<T>(T item);

	T Deserialize<T>(object source);
}
