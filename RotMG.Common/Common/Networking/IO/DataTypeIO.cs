using System;
using System.Reflection;
using RotMG.Common.IO;

namespace RotMG.Common.Networking.IO
{
	// Token: 0x02000018 RID: 24
	public class DataTypeIO
	{
		// Token: 0x060000A3 RID: 163 RVA: 0x000039D4 File Offset: 0x00001BD4
		static DataTypeIO()
		{
			foreach (Type type in typeof(DataTypeIO).Assembly.GetTypes())
			{
				if (!type.IsAbstract && !type.IsInterface && type.GetCustomAttributes(typeof(DataTypeAttribute), true).Length != 0)
				{
					MethodInfo method = type.GetMethod("InitIO", BindingFlags.Static | BindingFlags.Public);
					if (method == null)
					{
						MethodInfo method2 = type.GetMethod("Load");
						MethodInfo method3 = type.GetMethod("Save");
						MethodInfo method4 = type.GetMethod("SizeOf");
						if (method2 == null || method3 == null || method4 == null)
						{
							throw new NotSupportedException("Invalid data type.");
						}
						Type type2 = typeof(DataTypeIO.IOData<>).MakeGenericType(new Type[] { type });
						Delegate @delegate = Delegate.CreateDelegate(typeof(DataTypeIO.LoadFunc<>).MakeGenericType(new Type[] { type }), method2);
						type2.GetField("LoadFunc").SetValue(null, @delegate);
						Delegate delegate2 = Delegate.CreateDelegate(typeof(DataTypeIO.SaveFunc<>).MakeGenericType(new Type[] { type }), method3);
						type2.GetField("SaveFunc").SetValue(null, delegate2);
						Delegate delegate3 = Delegate.CreateDelegate(typeof(DataTypeIO.SizeFunc<>).MakeGenericType(new Type[] { type }), method4);
						type2.GetField("SizeFunc").SetValue(null, delegate3);
						type2.GetField("Initialized").SetValue(null, true);
					}
					else
					{
						method.Invoke(null, null);
					}
				}
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003B9C File Offset: 0x00001D9C
		public static void Init<T>(Action<InitDataTypeIO<T>> initFunc)
		{
			initFunc(new InitDataTypeIO<T>());
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003BA9 File Offset: 0x00001DA9
		public static T Load<T>(ref ByteBuffer buffer)
		{
			return DataTypeIO.IOData<T>.LoadFunc(ref buffer);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003BB6 File Offset: 0x00001DB6
		public static void Save<T>(ref ByteBuffer buffer, T item)
		{
			DataTypeIO.IOData<T>.SaveFunc(ref buffer, item);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003BC4 File Offset: 0x00001DC4
		public static int SizeOf<T>(T item)
		{
			return DataTypeIO.IOData<T>.SizeFunc(item);
		}

		// Token: 0x02000019 RID: 25
		internal static class IOData<T>
		{
			// Token: 0x04000065 RID: 101
			public static bool Initialized;

			// Token: 0x04000066 RID: 102
			public static DataTypeIO.LoadFunc<T> LoadFunc;

			// Token: 0x04000067 RID: 103
			public static DataTypeIO.SaveFunc<T> SaveFunc;

			// Token: 0x04000068 RID: 104
			public static DataTypeIO.SizeFunc<T> SizeFunc;
		}

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x060000AA RID: 170
		internal delegate T LoadFunc<T>(ref ByteBuffer buffer);

		// Token: 0x0200001B RID: 27
		// (Invoke) Token: 0x060000AE RID: 174
		internal delegate void SaveFunc<T>(ref ByteBuffer buffer, T item);

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x060000B2 RID: 178
		internal delegate int SizeFunc<T>(T item);
	}
}
