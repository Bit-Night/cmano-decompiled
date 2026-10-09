using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace PlaneDisaster.Dba;

public class OleDba : dba
{
	private OleDbConnection oleDbConnection_0;

	private string string_0;

	private string string_1;

	protected override DbConnection Cn
	{
		get
		{
			return (DbConnection)(object)oleDbConnection_0;
		}
		set
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			oleDbConnection_0 = (OleDbConnection)value;
		}
	}

	public new string ConnectionString => string_0;

	public override bool IsAccessDatabase => true;

	public override bool SupportsProcedures
	{
		get
		{
			if (!base.Connected)
			{
				throw new InvalidOperationException("The value of OleDba.SupportsProcedures depends on the database that it is connected to.");
			}
			int result;
			if (!oleDbConnection_0.Provider.StartsWith("Microsoft.Jet.OLEDB"))
			{
				if (oleDbConnection_0.Provider.StartsWith("Microsoft Jet"))
				{
					result = 1;
				}
				else
				{
					if (!Regex.IsMatch(oleDbConnection_0.Provider, "Microsoft Office [0-9]+\\.[0-9] Access Database Engine OLE DB Provider"))
					{
						throw new NotImplementedException($"Currently the OleDba.SupportsProcedures property may only be called when a Microsft Access database is being connected. You are connected with the {oleDbConnection_0.Provider} driver");
					}
					result = 1;
				}
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public override bool SupportsViews
	{
		get
		{
			if (base.Connected)
			{
				if (oleDbConnection_0.Provider != "Microsoft.Jet.OLEDB")
				{
					throw new NotImplementedException($"Currently the OleDba.SupportsViews property may only be called when a Microsft Access database is being connected. You are connected with the {oleDbConnection_0.Provider} driver");
				}
				return true;
			}
			throw new InvalidOperationException("The value of OleDba.SupportsViews depends on the database that it is connected to.");
		}
	}

	public void Connect()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		Cn = (DbConnection)new OleDbConnection(ConnectionString);
		Cn.Open();
	}

	public void method_2(string ConnectionString)
	{
		string_0 = ConnectionString;
		Connect();
	}

	public void method_3()
	{
		string_0 = $"Provider={JetSqlUtil.GetOleDbProviderName()};Data Source={string_1};User Id=admin;Password=;";
		Connect();
	}

	public void method_4(string File)
	{
		string_1 = File;
		method_3();
	}

	public void method_5(string File, string Password)
	{
		string_1 = File;
		string_0 = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={string_1};Jet OLEDB:Database Password={Password};";
		Connect();
	}

	protected override DataAdapter CreateDataAdapter(DbCommand cmd)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		return (DataAdapter)new OleDbDataAdapter((OleDbCommand)cmd);
	}

	public override string[] GetColumnNames(string Table)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		DataTable dataTable = new DataTable();
		dataTable = ((OleDbConnection)Cn).GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[4] { null, null, Table, null });
		int count = dataTable.Rows.Count;
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = (string)dataTable.Rows[i][3];
		}
		return array;
	}

	public override string GetProcedureSQL(string Procedure)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return (string)((OleDbConnection)Cn).GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, new object[4] { null, null, Procedure, null }).Rows[0]["PROCEDURE_DEFINITION"];
	}

	public override DataTable GetTableAsDataTable(string TableName)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002d: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		OleDbCommand val = (OleDbCommand)Cn.CreateCommand();
		((DbCommand)val).CommandType = CommandType.TableDirect;
		((DbCommand)val).CommandText = TableName;
		((DbDataAdapter)new OleDbDataAdapter(val)).Fill(dataTable);
		dataTable.TableName = TableName;
		return dataTable;
	}

	public override string[] GetTables()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		DataTable dataTable = null;
		dataTable = ((OleDbConnection)Cn).GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4] { null, null, null, "TABLE" });
		int count = dataTable.Rows.Count;
		string[] array = new string[count];
		for (num = 0; num < count; num++)
		{
			array[num] = (string)dataTable.Rows[num]["TABLE_NAME"];
		}
		return array;
	}

	public override string vmethod_0(string View)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return (string)((OleDbConnection)Cn).GetOleDbSchemaTable(OleDbSchemaGuid.Views, new object[3] { null, null, View }).Rows[0]["VIEW_DEFINITION"];
	}

	static OleDba()
	{
		Class72.smethod_20();
	}
}
