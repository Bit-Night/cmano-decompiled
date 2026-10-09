using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class BinGridModule
{
	public sealed class TBinGrid
	{
		internal class RAMCache_Terrain
		{
			private short[,] short_0;

			public RAMCache_Terrain()
			{
				short_0 = null;
			}

			public short GetElev(short theRow, short theCol, int numRows, int numCols)
			{
				short result;
				try
				{
					if (short_0 == null)
					{
						short_0 = new short[numRows - 1 + 1, numCols - 1 + 1];
					}
					short num = short_0[theRow, theCol];
					if (num == 0)
					{
						num = short.MinValue;
					}
					result = num;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200494", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					int num2;
					if (!Debugger.IsAttached)
					{
						num2 = 0;
					}
					else
					{
						Debugger.Break();
						num2 = 0;
					}
					result = (short)num2;
					ProjectData.ClearProjectError();
				}
				return result;
			}

			public void SetElev(short theRow, short theCol, short theElev, int numRows, int numCols)
			{
				try
				{
					if (short_0 == null)
					{
						short_0 = new short[numRows - 1 + 1, numCols - 1 + 1];
					}
					short_0[theRow, theCol] = theElev;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200496", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}

			static RAMCache_Terrain()
			{
				Class72.smethod_20();
			}
		}

		internal class DDictItem : ConcurrentDictionary<short, short>
		{
			public DDictItem Add(short key, short value)
			{
				TryAdd(key, value);
				return this;
			}

			static DDictItem()
			{
				Class72.smethod_20();
			}
		}

		internal class DDict : ConcurrentDictionary<short, DDictItem>
		{
			internal DDictItem Add(short key)
			{
				if (!ContainsKey(key))
				{
					DDictItem dDictItem = new DDictItem();
					TryAdd(key, dDictItem);
					return dDictItem;
				}
				return base[key];
			}

			static DDict()
			{
				Class72.smethod_20();
			}
		}

		public double dx;

		public double dy;

		private double double_0;

		private double double_1;

		public double xllcenter;

		public double yllcenter;

		public int ncols;

		public int nrows;

		public int datatype;

		public int i4nodata;

		public short i2nodata;

		public double r8nodata;

		public float r4nodata;

		public byte[] projection;

		public byte[] notes;

		public int[][] i4array;

		public short[][] i2array;

		public double[][] r8array;

		public float[][] r4array;

		private string string_0;

		internal RAMCache_Terrain Cache_RAM;

		private LockObject lockObject_0;

		public bool ReadingInProgress;

		protected FileStream _fs;

		protected BinaryReader _BR;

		public string Filename => string_0;

		public double xurcenter
		{
			get
			{
				double x = default(double);
				double y = default(double);
				CellToProj(ncols - 1, 0, ref x, ref y);
				return x;
			}
		}

		public double yurcenter
		{
			get
			{
				double x = default(double);
				double y = default(double);
				CellToProj(ncols - 1, 0, ref x, ref y);
				return y;
			}
		}

		public double xExtent
		{
			get
			{
				double x = default(double);
				double y = default(double);
				CellToProj(ncols - 1, 0, ref x, ref y);
				return x - xllcenter;
			}
		}

		public double yExtent
		{
			get
			{
				double x = default(double);
				double y = default(double);
				CellToProj(ncols - 1, 0, ref x, ref y);
				return y - yllcenter;
			}
		}

		internal float[,] ConvertToSingle2DArray()
		{
			float[,] array = new float[nrows - 1 + 1, ncols - 1 + 1];
			switch (datatype)
			{
			case 0:
			{
				int num7 = nrows - 1;
				for (int num8 = 0; num8 <= num7; num8++)
				{
					int num9 = ncols - 1;
					for (int num10 = 0; num10 <= num9; num10++)
					{
						array[num8, num10] = i2array[num8][num10];
					}
				}
				break;
			}
			case 1:
			{
				int num3 = nrows - 1;
				for (int k = 0; k <= num3; k++)
				{
					int num4 = ncols - 1;
					for (int l = 0; l <= num4; l++)
					{
						array[k, l] = i4array[k][l];
					}
				}
				break;
			}
			case 2:
			{
				int num5 = nrows - 1;
				for (int m = 0; m <= num5; m++)
				{
					int num6 = ncols - 1;
					for (int n = 0; n <= num6; n++)
					{
						array[m, n] = r4array[m][n];
					}
				}
				break;
			}
			case 3:
			{
				int num = nrows - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = ncols - 1;
					for (int j = 0; j <= num2; j++)
					{
						array[i, j] = (float)r8array[i][j];
					}
				}
				break;
			}
			}
			return array;
		}

		internal void ProjToCell(double x, double y, ref int row, ref int column)
		{
			try
			{
				double num = (x - xllcenter) * double_0;
				double num2 = (y - yllcenter) * double_1;
				if (num + 0.5 < 0.0)
				{
					column = 0;
				}
				else if (num + 0.5 > (double)(ncols - 1))
				{
					column = ncols - 1;
				}
				else
				{
					column = (int)Math.Round(num + 0.5);
				}
				if ((double)nrows - (num2 + 0.5) - 1.0 < 0.0)
				{
					row = 0;
				}
				else if ((double)nrows - (num2 + 0.5) - 1.0 > (double)(nrows - 1))
				{
					row = nrows - 1;
				}
				else
				{
					row = (int)Math.Round((double)nrows - (num2 + 0.5) - 1.0);
				}
				if (row >= nrows)
				{
					row = nrows - 1;
				}
				else if (row < 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					row = 0;
				}
				if (column >= ncols)
				{
					column = ncols - 1;
				}
				else if (column < 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					column = 0;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200300", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public void CellToProj(int column, int row, ref double x, ref double y)
		{
			try
			{
				if (row < 0 || row >= nrows)
				{
					throw new Exception("row doesn't belong to this tile");
				}
				if (column < 0 || column >= ncols)
				{
					throw new Exception("column doesn't belong to this tile");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200227", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			x = xllcenter + (double)column * dx;
			y = yllcenter + (double)(nrows - row - 1) * dy;
		}

		private short method_0()
		{
			try
			{
				if (i2array == null)
				{
					throw new Exception("i2array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200228", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			short num = short.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					short num4 = i2array[i][j];
					if (num4 != i2nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		private short method_1()
		{
			try
			{
				if (i2array == null)
				{
					throw new Exception("i2array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200229", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			short num = short.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					short num4 = i2array[i][j];
					if (num4 != i2nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		private int method_2()
		{
			if (i4array == null)
			{
				throw new Exception("i4array not inited!");
			}
			int num = int.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = i4array[i][j];
					if (num4 != i4nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal int method_3()
		{
			try
			{
				if (i4array == null)
				{
					throw new Exception("i4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200235", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			int num = int.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					int num4 = i4array[i][j];
					if (num4 != i4nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal float method_4()
		{
			try
			{
				if (r4array == null)
				{
					throw new Exception("r4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200236", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			float num = float.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					float num4 = r4array[i][j];
					if (num4 != r4nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal float method_5()
		{
			try
			{
				if (r4array == null)
				{
					throw new Exception("r4array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200237", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			float num = float.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					float num4 = r4array[i][j];
					if (num4 != r4nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal double method_6()
		{
			try
			{
				if (r8array == null)
				{
					throw new Exception("r8array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200238", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			double num = double.MaxValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					double num4 = r8array[i][j];
					if (num4 != r8nodata && num4 < num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal double method_7()
		{
			try
			{
				if (r8array == null)
				{
					throw new Exception("r8array not inited!");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200239", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			double num = double.MinValue;
			int num2 = nrows - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = ncols - 1;
				for (int j = 0; j <= num3; j++)
				{
					double num4 = r8array[i][j];
					if (num4 != r8nodata && num4 > num)
					{
						num = num4;
					}
				}
			}
			return num;
		}

		internal int roundX(double d)
		{
			if (Math.Ceiling(d) - d > 0.5)
			{
				return RadarModel.Floor(d);
			}
			return (int)Math.Ceiling(d);
		}

		protected void dealloc()
		{
			if (i2array != null)
			{
				int num = nrows - 1;
				for (int i = 0; i <= num; i++)
				{
					i2array[i] = null;
				}
				i2array = null;
			}
			if (i4array != null)
			{
				int num2 = nrows - 1;
				for (int j = 0; j <= num2; j++)
				{
					i4array[j] = null;
				}
				i4array = null;
			}
			if (r4array != null)
			{
				int num3 = nrows - 1;
				for (int k = 0; k <= num3; k++)
				{
					r4array[k] = null;
				}
				r4array = null;
			}
			if (r8array != null)
			{
				int num4 = nrows - 1;
				for (int l = 0; l <= num4; l++)
				{
					r8array[l] = null;
				}
				r8array = null;
			}
		}

		protected void method_8()
		{
			i2array = new short[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				i2array[i] = new short[ncols - 1 + 1];
			}
		}

		protected void method_9()
		{
			i4array = new int[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				i4array[i] = new int[ncols - 1 + 1];
			}
		}

		protected void method_10()
		{
			r4array = new float[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				r4array[i] = new float[ncols - 1 + 1];
			}
		}

		protected void method_11()
		{
			r8array = new double[nrows - 1 + 1][];
			int num = nrows - 1;
			for (int i = 0; i <= num; i++)
			{
				r8array[i] = new double[ncols - 1 + 1];
			}
		}

		internal bool ReadTile(string fn)
		{
			FileStream fileStream = new FileStream(fn, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, FileOptions.SequentialScan);
			BinaryReader binaryReader = new BinaryReader(fileStream, new ASCIIEncoding());
			bool result;
			try
			{
				int num = binaryReader.ReadInt32();
				int num2 = binaryReader.ReadInt32();
				dx = binaryReader.ReadDouble();
				dy = binaryReader.ReadDouble();
				double_0 = 1.0 / dx;
				double_1 = 1.0 / dy;
				xllcenter = binaryReader.ReadDouble();
				yllcenter = binaryReader.ReadDouble();
				int num3 = binaryReader.ReadInt32();
				if (num3 != datatype)
				{
					dealloc();
				}
				datatype = num3;
				switch (datatype)
				{
				default:
					try
					{
						throw new Exception("invalid datatype");
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200241", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				case 0:
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						notes = binaryReader.ReadBytes(255);
						byte[] array3 = new byte[ncols * 2 - 1 + 1];
						int num6 = nrows;
						for (int k = 1; k <= num6; k++)
						{
							fileStream.Read(array3, 0, ncols * 2);
							Buffer.BlockCopy(array3, 0, i2array[k - 1], 0, ncols * 2);
						}
						method_8();
					}
					i2nodata = binaryReader.ReadInt16();
					projection = binaryReader.ReadBytes(255);
					break;
				case 1:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_9();
					}
					i4nodata = binaryReader.ReadInt32();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array2 = new byte[ncols * 4 - 1 + 1];
					int num5 = nrows;
					for (int j = 1; j <= num5; j++)
					{
						fileStream.Read(array2, 0, ncols * 4);
						Buffer.BlockCopy(array2, 0, i4array[j - 1], 0, ncols * 4);
					}
					break;
				}
				case 2:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_10();
					}
					r4nodata = binaryReader.ReadSingle();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array4 = new byte[ncols * 4 - 1 + 1];
					int num7 = nrows;
					for (int l = 1; l <= num7; l++)
					{
						fileStream.Read(array4, 0, ncols * 4);
						Buffer.BlockCopy(array4, 0, r4array[l - 1], 0, ncols * 4);
					}
					break;
				}
				case 3:
				{
					if (num != ncols || num2 != nrows)
					{
						ncols = num;
						nrows = num2;
						method_11();
					}
					r8nodata = binaryReader.ReadDouble();
					projection = binaryReader.ReadBytes(255);
					notes = binaryReader.ReadBytes(255);
					byte[] array = new byte[ncols * 8 - 1 + 1];
					int num4 = nrows;
					for (int i = 1; i <= num4; i++)
					{
						fileStream.Read(array, 0, ncols * 8);
						Buffer.BlockCopy(array, 0, r8array[i - 1], 0, ncols * 8);
					}
					break;
				}
				case 4:
					try
					{
						throw new Exception("unknown datatype");
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200240", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 200242", ex6.Message);
				GameGeneral.WriteExceptionsToLog(ex6);
				int num8;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num8 = 0;
				}
				else
				{
					num8 = 0;
				}
				result = (byte)num8 != 0;
				ProjectData.ClearProjectError();
				goto IL_0495;
			}
			finally
			{
				binaryReader.Close();
			}
			result = true;
			goto IL_0495;
			IL_0495:
			return result;
		}

		public TBinGrid(string theFileName)
		{
			datatype = -1;
			projection = new byte[255];
			notes = new byte[255];
			lockObject_0 = new LockObject();
			string_0 = theFileName;
		}

		public void CloseTile()
		{
			try
			{
				if (!Information.IsNothing((object)_BR))
				{
					_BR.Close();
					_BR = null;
				}
				if (!Information.IsNothing((object)_fs))
				{
					_fs = null;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}

		private void method_12(double double_2, double double_3, ref short short_0)
		{
			try
			{
				if (_fs == null)
				{
					throw new Exception("file stream not open!");
				}
				if (datatype != 0)
				{
					throw new Exception("invalid data type");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200243", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			int row = default(int);
			int column = default(int);
			ProjToCell(double_2, double_3, ref row, ref column);
			_fs.Seek(556 + row * ncols * 2 + column * 2, SeekOrigin.Begin);
			short_0 = _BR.ReadInt16();
		}

		internal Terrain.TerrainRasterCell GetSingleRasterCell(double theLat, double theLon)
		{
			Terrain.TerrainRasterCell result;
			try
			{
				ReadingInProgress = true;
				if (_fs == null || double.IsNaN(xllcenter) || double.IsNaN(yllcenter) || xllcenter == 0.0 || yllcenter == 0.0 || xllcenter < -180.0 || xllcenter > 180.0 || yllcenter < -90.0 || yllcenter > 90.0 || (xllcenter < 1.0 && xllcenter > -1.0) || (yllcenter < 1.0 && yllcenter > -1.0) || double.IsNaN(xllcenter) || double.IsNaN(yllcenter))
				{
					lock (lockObject_0)
					{
						ReadTileHeader(GameGeneral.GISFolderPath + "\\Terrain\\SRTM30Plus\\" + Filename);
					}
				}
				ReadingInProgress = false;
				theLon = Math2.NormalizeLongitude(theLon);
				theLat = Math2.NormalizeLatitude(theLat);
				int row = default(int);
				int column = default(int);
				try
				{
					ProjToCell(theLon, theLat, ref row, ref column);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 20023452456546344442221", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = default(Terrain.TerrainRasterCell);
					ProjectData.ClearProjectError();
					goto end_IL_0001;
				}
				if (row > nrows - 1)
				{
					_ = Debugger.IsAttached;
					row = nrows - 1;
				}
				if (column > ncols - 1)
				{
					_ = Debugger.IsAttached;
					column = ncols - 1;
				}
				double x = default(double);
				double y = default(double);
				CellToProj(column, row, ref x, ref y);
				return new Terrain.TerrainRasterCell
				{
					CenterLatitude = y,
					CenterLongitude = x,
					UniqueKey = "SRTM30PLUS_" + Filename + "_" + Conversions.ToString(column) + "_" + Conversions.ToString(row)
				};
				end_IL_0001:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101292353453266662", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = default(Terrain.TerrainRasterCell);
				ProjectData.ClearProjectError();
			}
			return result;
		}

		internal short ReadValue_CacheFirst(double theLon, double theLat, bool IsGUIRequest, bool UseCaching = true)
		{
			short result;
			try
			{
				ReadingInProgress = true;
				if (_fs == null || xllcenter == 0.0 || yllcenter == 0.0 || xllcenter < -180.0 || xllcenter > 180.0 || yllcenter < -90.0 || yllcenter > 90.0 || (xllcenter < 1.0 && xllcenter > -1.0) || (yllcenter < 1.0 && yllcenter > -1.0))
				{
					ReadTileHeader(Path.Combine(BinaryGridProvider._TerrainFilesPath, string_0));
				}
				if (UseCaching && Cache_RAM == null)
				{
					Cache_RAM = new RAMCache_Terrain();
				}
				if (theLat > 90.0 || theLat < -90.0)
				{
					theLat = Math2.NormalizeLatitude(theLat);
				}
				if (theLon > 180.0 || !(theLon >= -180.0))
				{
					theLon = Math2.NormalizeLongitude(theLon);
				}
				int row = default(int);
				int column = default(int);
				try
				{
					ProjToCell(theLon, theLat, ref row, ref column);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200030", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 0;
					}
					else
					{
						Debugger.Break();
						num = 0;
					}
					result = (short)num;
					ProjectData.ClearProjectError();
					goto end_IL_0001;
				}
				if (row > nrows - 1)
				{
					_ = Debugger.IsAttached;
					row = nrows - 1;
				}
				int num2;
				if (column > ncols - 1)
				{
					_ = Debugger.IsAttached;
					column = ncols - 1;
					num2 = -32768;
				}
				else
				{
					num2 = -32768;
				}
				short short_ = (short)num2;
				if (UseCaching)
				{
					Cache_RAM.GetElev((short)row, (short)column, nrows, ncols);
				}
				if (short_ == short.MinValue || short_ == 0)
				{
					short terrainTileIndex = BinaryGridProvider.GetTerrainTileIndex(ref theLat, ref theLon, CoordsAlreadyNormalized: true);
					int value = default(int);
					try
					{
						ReadValueFromOpenTile(row, column, terrainTileIndex, ref value, UseCaching);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ReadValueFromOpenTile(row, column, terrainTileIndex, ref value, UseCaching);
						ProjectData.ClearProjectError();
					}
					int num3;
					if (value <= 32767)
					{
						if (value >= -32768)
						{
							short_ = (short)value;
							goto IL_0254;
						}
						num3 = 0;
					}
					else
					{
						num3 = 0;
					}
					short_ = (short)num3;
					goto IL_0254;
				}
				goto IL_027e;
				IL_027e:
				method_13(ref short_);
				result = short_;
				goto end_IL_0001;
				IL_0254:
				if (UseCaching && row >= 0 && column >= 0)
				{
					Cache_RAM.SetElev((short)row, (short)column, short_, nrows, ncols);
				}
				goto IL_027e;
				end_IL_0001:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 101294", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				int num4;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num4 = 0;
				}
				else
				{
					num4 = 0;
				}
				result = (short)num4;
				ProjectData.ClearProjectError();
			}
			finally
			{
				ReadingInProgress = false;
			}
			return result;
		}

		private void method_13(ref short short_0)
		{
			if (short_0 < 0 && short_0 > -20)
			{
				short_0 = -20;
			}
		}

		public void ReadValueFromOpenTile(int row, int col, short CacheArrayIndex, ref int value, bool UseByteArrayBuffer)
		{
			if (UseByteArrayBuffer)
			{
				try
				{
					byte[] array = BinaryGridProvider.GetGridFromCache(CacheArrayIndex);
					if (array == null)
					{
						array = File.ReadAllBytes(Path.Combine(BinaryGridProvider._TerrainFilesPath, string_0));
						BinaryGridProvider.AddGridToCache(CacheArrayIndex, array);
					}
					if (array == null)
					{
						throw new Exception("Memory buffer was unexpectedly unavailable.");
					}
					if (datatype != 1)
					{
						throw new Exception("Invalid data type");
					}
					int startIndex = 558 + row * ncols * 4 + col * 4;
					value = BitConverter.ToInt32(array, startIndex);
					return;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200245", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					lock (lockObject_0)
					{
						if (_fs == null)
						{
							ReadTileHeader(Path.Combine(BinaryGridProvider._TerrainFilesPath, string_0));
						}
						if (datatype != 1)
						{
							throw new Exception("invalid data type");
						}
						_fs.Seek(558 + row * ncols * 4 + col * 4, SeekOrigin.Begin);
						value = _BR.ReadInt32();
					}
					throw;
				}
			}
			try
			{
				lock (lockObject_0)
				{
					if (_fs == null)
					{
						ReadTileHeader(Path.Combine(BinaryGridProvider._TerrainFilesPath, string_0));
					}
					if (datatype != 1)
					{
						throw new Exception("invalid data type");
					}
					_fs.Seek(558 + row * ncols * 4 + col * 4, SeekOrigin.Begin);
					value = _BR.ReadInt32();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200245", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}

		private void method_14(double double_2, double double_3, ref float float_0)
		{
			try
			{
				if (_fs == null)
				{
					throw new Exception("file stream not open!");
				}
				if (datatype != 2)
				{
					throw new Exception("invalid data type");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200246", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			int row = default(int);
			int column = default(int);
			ProjToCell(double_2, double_3, ref row, ref column);
			_fs.Seek(558 + row * ncols * 4 + column * 4, SeekOrigin.Begin);
			float_0 = _BR.ReadSingle();
		}

		private void method_15(double double_2, double double_3, ref double double_4)
		{
			try
			{
				if (_fs == null)
				{
					throw new Exception("file stream not open!");
				}
				if (datatype != 3)
				{
					throw new Exception("invalid data type");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200247", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
			int row = default(int);
			int column = default(int);
			ProjToCell(double_2, double_3, ref row, ref column);
			_fs.Seek(562 + row * ncols * 8 + column * 8, SeekOrigin.Begin);
			double_4 = _BR.ReadDouble();
		}

		internal bool ReadTileHeader(string theFileName)
		{
			bool result;
			lock (lockObject_0)
			{
				_fs = new FileStream(theFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 65536, FileOptions.RandomAccess);
				_BR = new BinaryReader(_fs, new ASCIIEncoding());
				try
				{
					_fs.Seek(0L, SeekOrigin.Begin);
					int num = _BR.ReadInt32();
					int num2 = _BR.ReadInt32();
					dx = _BR.ReadDouble();
					dy = _BR.ReadDouble();
					double_0 = 1.0 / dx;
					double_1 = 1.0 / dy;
					xllcenter = _BR.ReadDouble();
					yllcenter = _BR.ReadDouble();
					int num3 = _BR.ReadInt32();
					datatype = num3;
					switch (datatype)
					{
					default:
						try
						{
							throw new Exception("invalid datatype");
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200249", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							_ = Debugger.IsAttached;
							throw;
						}
					case 0:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						i2nodata = _BR.ReadInt16();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 1:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						i4nodata = _BR.ReadInt32();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 2:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						r4nodata = _BR.ReadSingle();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 3:
						if (num != ncols || num2 != nrows)
						{
							ncols = num;
							nrows = num2;
						}
						r8nodata = _BR.ReadDouble();
						projection = _BR.ReadBytes(255);
						notes = _BR.ReadBytes(255);
						break;
					case 4:
						try
						{
							throw new Exception("unknown datatype");
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 200248", ex2.Message);
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw;
						}
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 200250", ex6.Message);
					GameGeneral.WriteExceptionsToLog(ex6);
					int num4;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num4 = 0;
					}
					else
					{
						num4 = 0;
					}
					result = (byte)num4 != 0;
					ProjectData.ClearProjectError();
					goto end_IL_0009;
				}
				result = true;
				end_IL_0009:;
			}
			return result;
		}

		internal bool WriteTile(string fn, bool ShallOverwrite)
		{
			FileMode mode = ((!ShallOverwrite) ? FileMode.CreateNew : FileMode.Create);
			FileStream fileStream = null;
			bool result;
			try
			{
				fileStream = new FileStream(fn, mode, FileAccess.Write, FileShare.None, 65536, FileOptions.SequentialScan);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_0432;
			}
			BinaryWriter binaryWriter = new BinaryWriter(fileStream, new ASCIIEncoding());
			try
			{
				binaryWriter.Write(ncols);
				binaryWriter.Write(nrows);
				binaryWriter.Write(dx);
				binaryWriter.Write(dy);
				binaryWriter.Write(xllcenter);
				binaryWriter.Write(yllcenter);
				binaryWriter.Write(datatype);
				switch (datatype)
				{
				default:
					try
					{
						throw new Exception("invalid datatype");
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200252", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				case 0:
				{
					binaryWriter.Write(i2nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr4 = Marshal.AllocHGlobal(2 * ncols);
					byte[] array4 = new byte[ncols * 2 - 1 + 1];
					int num4 = nrows;
					for (int l = 1; l <= num4; l++)
					{
						Marshal.Copy(i2array[l - 1], 0, intPtr4, ncols);
						Marshal.Copy(intPtr4, array4, 0, ncols * 2);
						fileStream.Write(array4, 0, ncols * 2);
					}
					Marshal.FreeHGlobal(intPtr4);
					break;
				}
				case 1:
				{
					binaryWriter.Write(i4nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr2 = Marshal.AllocHGlobal(4 * ncols);
					byte[] array2 = new byte[ncols * 4 - 1 + 1];
					int num2 = nrows;
					for (int j = 1; j <= num2; j++)
					{
						Marshal.Copy(i4array[j - 1], 0, intPtr2, ncols);
						Marshal.Copy(intPtr2, array2, 0, ncols * 4);
						fileStream.Write(array2, 0, ncols * 4);
					}
					Marshal.FreeHGlobal(intPtr2);
					break;
				}
				case 2:
				{
					binaryWriter.Write(r4nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr3 = Marshal.AllocHGlobal(4 * ncols);
					byte[] array3 = new byte[ncols * 4 - 1 + 1];
					int num3 = nrows;
					for (int k = 1; k <= num3; k++)
					{
						Marshal.Copy(r4array[k - 1], 0, intPtr3, ncols);
						Marshal.Copy(intPtr3, array3, 0, ncols * 4);
						fileStream.Write(array3, 0, ncols * 4);
					}
					Marshal.FreeHGlobal(intPtr3);
					break;
				}
				case 3:
				{
					binaryWriter.Write(r8nodata);
					binaryWriter.Write(projection);
					binaryWriter.Write(notes);
					IntPtr intPtr = Marshal.AllocHGlobal(8 * ncols);
					byte[] array = new byte[ncols * 8 - 1 + 1];
					int num = nrows;
					for (int i = 1; i <= num; i++)
					{
						Marshal.Copy(r8array[i - 1], 0, intPtr, ncols);
						Marshal.Copy(intPtr, array, 0, ncols * 8);
						fileStream.Write(array, 0, ncols * 8);
					}
					Marshal.FreeHGlobal(intPtr);
					break;
				}
				case 4:
					try
					{
						throw new Exception("unknown datatype");
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200251", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 200253", ex6.Message);
				GameGeneral.WriteExceptionsToLog(ex6);
				int num5;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num5 = 0;
				}
				else
				{
					num5 = 0;
				}
				result = (byte)num5 != 0;
				ProjectData.ClearProjectError();
				goto IL_0432;
			}
			finally
			{
				binaryWriter.Close();
			}
			result = true;
			goto IL_0432;
			IL_0432:
			return result;
		}

		static TBinGrid()
		{
			Class72.smethod_20();
		}
	}

	public const string ModuleVersion = "version 0.06";

	public const string ModuleCredits = "MapWindow 6 developers for new info on copying raw data";

	static BinGridModule()
	{
		Class72.smethod_20();
	}
}
