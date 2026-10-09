using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;

namespace PlaneDisaster.Dba;

public class OdbcDba : dba
{
	private OdbcConnection odbcConnection_0;

	protected override DbConnection Cn
	{
		get
		{
			return (DbConnection)(object)odbcConnection_0;
		}
		set
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			odbcConnection_0 = (OdbcConnection)value;
		}
	}

	public override bool IsAccessDatabase => true;

	public override bool SupportsProcedures
	{
		get
		{
			if (!base.Connected)
			{
				throw new InvalidOperationException("The value of OdbcDba.SupportsProcedures depends on the database that it is connected to.");
			}
			int result;
			if (!(odbcConnection_0.Driver != "odbcjt32.dll"))
			{
				result = 1;
			}
			else
			{
				if (odbcConnection_0.Driver != "ACEODBC.DLL")
				{
					throw new NotImplementedException($"Currently the OdbcDba.SupportsProcedures property may only be called when a Microsft Access database is being connected. You are connected with the {odbcConnection_0.Driver} driver");
				}
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
				int result;
				if (odbcConnection_0.Driver != "odbcjt32.dll")
				{
					if (odbcConnection_0.Driver != "ACEODBC.DLL")
					{
						throw new NotImplementedException($"Currently the OdbcDba.SupportsViews property may only be called when a Microsft Access database is being connected. You are connected with the {odbcConnection_0.Driver} driver");
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			throw new InvalidOperationException("The value of OdbcDba.SupportsViews depends on the database that it is connected to.");
		}
	}

	public void method_2(string ConnStr)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		Cn = (DbConnection)new OdbcConnection(ConnStr);
		Cn.Open();
	}

	public void method_3(string File)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		Cn = (DbConnection)new OdbcConnection();
		Cn.ConnectionString = $"Driver={{{JetSqlUtil.GetOdbcProviderName()}}};Dbq={File};Uid=Admin;Pwd=;";
		Cn.Open();
	}

	public void method_4(string File, string Password)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		Cn = (DbConnection)new OdbcConnection();
		Cn.ConnectionString = $"Driver={{Microsoft Access Driver (*.mdb)}};Dbq={File};Uid=Admin;Pwd={Password};";
		Cn.Open();
	}

	protected override DataAdapter CreateDataAdapter(DbCommand cmd)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		return (DataAdapter)new OdbcDataAdapter((OdbcCommand)cmd);
	}

	public override string[] GetColumnNames(string Table)
	{
		DataTable dataTable = new DataTable();
		dataTable = Cn.GetSchema("Columns", new string[4] { null, null, Table, null });
		int count = dataTable.Rows.Count;
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = (string)dataTable.Rows[i]["COLUMN_NAME"];
		}
		return array;
	}

	public override DataTable GetTableAsDataTable(string Table)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_002c: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		OdbcCommand val = (OdbcCommand)Cn.CreateCommand();
		((DbCommand)val).CommandText = $"SELECT * FROM [{Table}]";
		((DbDataAdapter)new OdbcDataAdapter(val)).Fill(dataTable);
		dataTable.TableName = Table;
		return dataTable;
	}

	static OdbcDba()
	{
		Class72.smethod_20();
	}
}
