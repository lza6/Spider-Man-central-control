using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using org.in2bits.MyXls;

namespace XXTCC;

public class Excel_class
{
	private OleDbConnection oleDbConnection_0;

	private string string_0;

	public Excel_class(OleDbConnection _conn, string _filePath)
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
		oleDbConnection_0 = _conn;
		string_0 = _filePath;
	}

	public void Import(string DbName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				Worksheet val = new XlsDocument(string_0).Workbook.Worksheets["sheet1"];
				DataTable dataTable = new DataTable();
				int num = (int)val.Rows.MaxRow;
				for (int i = 1; i <= num; i++)
				{
					if (i == 1)
					{
						int cellCount = val.Rows[(ushort)i].CellCount;
						for (int j = 1; j <= cellCount && val.Rows[(ushort)i].GetCell((ushort)j).Value != null && Operators.ConditionalCompareObjectNotEqual(val.Rows[(ushort)i].GetCell((ushort)j).Value, "", TextCompare: false); j++)
						{
							object[] array;
							Cell cell;
							bool[] array2;
							NewLateBinding.LateCall(dataTable.Columns, null, "Add", array = new object[1] { (cell = val.Rows[(ushort)i].GetCell((ushort)j)).Value }, null, null, array2 = new bool[1] { true }, IgnoreReturn: true);
							if (array2[0])
							{
								cell.Value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
							}
						}
						continue;
					}
					DataRow dataRow = dataTable.NewRow();
					try
					{
						if (val.Rows[(ushort)i].MinCellCol != 0)
						{
							int cellCount2 = val.Rows[(ushort)1].CellCount;
							for (int k = 1; k <= cellCount2; k++)
							{
								if (!val.Rows[(ushort)i].CellExists((ushort)k))
								{
									dataRow[dataTable.Columns[k - 1].Caption] = "";
								}
								else
								{
									dataRow[dataTable.Columns[k - 1].Caption] = RuntimeHelpers.GetObjectValue(val.Rows[(ushort)i].CellAtCol((ushort)k).Value);
								}
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					dataTable.Rows.Add(dataRow);
				}
				foreach (DataRow row in dataTable.Rows)
				{
					string text = "";
					string text2 = "";
					foreach (DataColumn column in dataTable.Columns)
					{
						if (Operators.CompareString(column.ColumnName, "id", TextCompare: false) != 0)
						{
							text += column.ColumnName;
							text2 = Conversions.ToString(Operators.AddObject(text2, Operators.ConcatenateObject(Operators.ConcatenateObject("'", row[column.ColumnName]), "'")));
							if (dataTable.Columns.IndexOf(column) + 1 != dataTable.Columns.Count)
							{
								text += ",";
								text2 += ",";
							}
						}
					}
					method_0($"INSERT INTO {DbName} ({text}) VALUES ({text2})");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "数据库导入时出错", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public object Export(string sqlstr)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		checked
		{
			object result;
			try
			{
				XlsDocument val = new XlsDocument();
				val.FileName = string_0;
				Worksheet val2 = val.Workbook.Worksheets.Add("sheet1");
				using OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(sqlstr, oleDbConnection_0);
				using DataSet dataSet = new DataSet();
				oleDbDataAdapter.Fill(dataSet);
				if (dataSet.Tables.Count > 0)
				{
					int count = dataSet.Tables[0].Columns.Count;
					for (int i = 1; i <= count; i++)
					{
						val2.Cells.Add(1, i, (object)dataSet.Tables[0].Columns[i - 1].Caption.ToString());
					}
					int num = dataSet.Tables[0].Rows.Count + 1;
					for (int j = 2; j <= num; j++)
					{
						int count2 = dataSet.Tables[0].Columns.Count;
						for (int k = 1; k <= count2; k++)
						{
							val2.Cells.Add(j, k, (object)dataSet.Tables[0].Rows[j - 2][k - 1].ToString());
						}
					}
					val.Save();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	private bool method_0(string string_1)
	{
		bool result;
		try
		{
			using (OleDbCommand oleDbCommand = new OleDbCommand())
			{
				oleDbCommand.CommandText = string_1;
				oleDbCommand.Connection = oleDbConnection_0;
				oleDbCommand.ExecuteNonQuery();
			}
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void giBijlvknk(object object_0)
	{
		try
		{
			Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(object_0));
			object_0 = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			object_0 = null;
			ProjectData.ClearProjectError();
		}
		finally
		{
			GC.Collect();
		}
	}
}
