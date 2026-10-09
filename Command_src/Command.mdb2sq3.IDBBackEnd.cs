using System.Data.Common;

namespace Command.mdb2sq3;

public abstract class IDBBackEnd
{
	public abstract void CloneSchema(SchemaTablesMetaData schema);

	public abstract void DumpTable(TableMetaData table, DbDataReader reader);

	public abstract SchemaTablesMetaData QuerySchemaDefinition(string schema);

	public abstract void QueryTableDefinition(TableMetaData table);

	public abstract void DumpTableContents(TableMetaData table, IDBBackEnd target);

	static IDBBackEnd()
	{
		Class72.smethod_20();
	}
}
