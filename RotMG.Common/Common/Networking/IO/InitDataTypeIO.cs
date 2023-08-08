using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using RotMG.Common.IO;

namespace RotMG.Common.Networking.IO
{
	// Token: 0x02000047 RID: 71
	public class InitDataTypeIO<T>
	{
		// Token: 0x06000223 RID: 547 RVA: 0x000077B4 File Offset: 0x000059B4
		internal InitDataTypeIO()
		{
			this.typeT = typeof(T);
			this.isValueType = this.typeT.IsValueType;
			this.load = new DynamicMethod("Load_" + this.typeT.FullName, this.typeT, new Type[] { typeof(ByteBuffer).MakeByRefType() }, true);
			this.save = new DynamicMethod("Save_" + this.typeT.FullName, typeof(void), new Type[]
			{
				typeof(ByteBuffer).MakeByRefType(),
				this.typeT
			}, true);
			this.size = new DynamicMethod("Size_" + this.typeT.FullName, typeof(int), new Type[] { this.typeT }, true);
			this.loadGen = this.load.GetILGenerator();
			this.saveGen = this.save.GetILGenerator();
			this.sizeGen = this.size.GetILGenerator();
			this.Init();
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000078EC File Offset: 0x00005AEC
		private void Init()
		{
			this.loadGen.DeclareLocal(typeof(T));
			this.loadGen.DeclareLocal(typeof(int));
			if (this.isValueType)
			{
				this.loadGen.Emit(OpCodes.Ldloca_S, 0);
				this.loadGen.Emit(OpCodes.Initobj, typeof(T));
			}
			else
			{
				this.loadGen.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
				this.loadGen.Emit(OpCodes.Stloc_0);
			}
			this.sizeGen.DeclareLocal(typeof(int));
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000079A4 File Offset: 0x00005BA4
		private void EmitLoadCall(string method)
		{
			this.loadGen.Emit(OpCodes.Ldarg_0);
			this.loadGen.Emit(OpCodes.Call, typeof(ByteBuffer).GetMethod(method));
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000079D8 File Offset: 0x00005BD8
		private void EmitLoad(MemberInfo member, FieldType type)
		{
			if (this.isValueType)
			{
				this.loadGen.Emit(OpCodes.Ldloca_S, 0);
			}
			else
			{
				this.loadGen.Emit(OpCodes.Ldloc_0);
			}
			switch (type)
			{
			case FieldType.UTF:
				this.EmitLoadCall("ReadUTF");
				break;
			case FieldType.UTF32:
				this.EmitLoadCall("ReadUTF32");
				break;
			case FieldType.Byte:
				this.EmitLoadCall("ReadByte");
				break;
			case FieldType.Bool:
				this.EmitLoadCall("ReadBool");
				break;
			case FieldType.Int16:
				this.EmitLoadCall("ReadUInt16");
				break;
			case FieldType.Int32:
				this.EmitLoadCall("ReadUInt32");
				break;
			case FieldType.Int64:
				this.EmitLoadCall("ReadUInt64");
				break;
			case FieldType.Float32:
				this.EmitLoadCall("ReadFloat32");
				break;
			case FieldType.Float64:
				this.EmitLoadCall("ReadFloat64");
				break;
			case FieldType.Buffer16:
				this.EmitLoadCall("ReadBuffer16");
				break;
			case FieldType.UTF32Array:
				this.EmitLoadCall("ReadUTF32Array");
				break;
			case FieldType.IntArray:
				this.EmitLoadCall("ReadIntArray");
				break;
			case FieldType.DataArray:
			{
				Type type2;
				if (member is PropertyInfo)
				{
					type2 = ((PropertyInfo)member).PropertyType.GetElementType();
				}
				else
				{
					type2 = ((FieldInfo)member).FieldType.GetElementType();
				}
				this.loadGen.Emit(OpCodes.Ldarg_0);
				this.loadGen.Emit(OpCodes.Call, typeof(IOHelper).GetMethod("ReadDataArray").MakeGenericMethod(new Type[] { type2 }));
				break;
			}
			case FieldType.DataType:
			{
				Type type3;
				if (member is PropertyInfo)
				{
					type3 = ((PropertyInfo)member).PropertyType;
				}
				else
				{
					type3 = ((FieldInfo)member).FieldType;
				}
				this.loadGen.Emit(OpCodes.Ldarg_0);
				this.loadGen.Emit(OpCodes.Call, typeof(DataTypeIO).GetMethod("Load").MakeGenericMethod(new Type[] { type3 }));
				break;
			}
			default:
				throw new NotSupportedException();
			}
			if (member is PropertyInfo)
			{
				this.loadGen.Emit(OpCodes.Call, ((PropertyInfo)member).GetSetMethod());
				return;
			}
			this.loadGen.Emit(OpCodes.Stfld, (FieldInfo)member);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00007C34 File Offset: 0x00005E34
		private void EmitSaveCall(string method, Action loadField)
		{
			this.saveGen.Emit(OpCodes.Ldarg_0);
			loadField();
			this.saveGen.Emit(OpCodes.Call, typeof(ByteBuffer).GetMethod(method));
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00007CEC File Offset: 0x00005EEC
		private void EmitSave(MemberInfo member, FieldType type)
		{
			Action action = delegate
			{
				this.saveGen.Emit(OpCodes.Ldarg_1);
				if (member is PropertyInfo)
				{
					this.saveGen.Emit(OpCodes.Call, ((PropertyInfo)member).GetGetMethod());
					return;
				}
				this.saveGen.Emit(OpCodes.Ldfld, (FieldInfo)member);
			};
			switch (type)
			{
			case FieldType.UTF:
				this.EmitSaveCall("WriteUTF", action);
				return;
			case FieldType.UTF32:
				this.EmitSaveCall("WriteUTF32", action);
				return;
			case FieldType.Byte:
				this.EmitSaveCall("WriteByte", action);
				return;
			case FieldType.Bool:
				this.EmitSaveCall("WriteBool", action);
				return;
			case FieldType.Int16:
				this.EmitSaveCall("WriteUInt16", action);
				return;
			case FieldType.Int32:
				this.EmitSaveCall("WriteUInt32", action);
				return;
			case FieldType.Int64:
				this.EmitSaveCall("WriteUInt64", action);
				return;
			case FieldType.Float32:
				this.EmitSaveCall("WriteFloat32", action);
				return;
			case FieldType.Float64:
				this.EmitSaveCall("WriteFloat64", action);
				return;
			case FieldType.Buffer16:
				this.EmitSaveCall("WriteBuffer16", action);
				return;
			case FieldType.UTF32Array:
				this.EmitSaveCall("WriteUTF32Array", action);
				return;
			case FieldType.IntArray:
				this.EmitSaveCall("WriteIntArray", action);
				return;
			case FieldType.DataArray:
			{
				Type type2;
				if (member is PropertyInfo)
				{
					type2 = ((PropertyInfo)member).PropertyType.GetElementType();
				}
				else
				{
					type2 = ((FieldInfo)member).FieldType.GetElementType();
				}
				this.saveGen.Emit(OpCodes.Ldarg_0);
				action();
				this.saveGen.Emit(OpCodes.Call, typeof(IOHelper).GetMethod("WriteDataArray").MakeGenericMethod(new Type[] { type2 }));
				return;
			}
			case FieldType.DataType:
			{
				Type type3;
				if (member is PropertyInfo)
				{
					type3 = ((PropertyInfo)member).PropertyType;
				}
				else
				{
					type3 = ((FieldInfo)member).FieldType;
				}
				this.saveGen.Emit(OpCodes.Ldarg_0);
				action();
				this.saveGen.Emit(OpCodes.Call, typeof(DataTypeIO).GetMethod("Save").MakeGenericMethod(new Type[] { type3 }));
				return;
			}
			default:
				throw new NotSupportedException();
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00007F0C File Offset: 0x0000610C
		private void EmitSizeCall(string method, Action loadField)
		{
			this.sizeGen.Emit(OpCodes.Ldloca_S, 0);
			loadField();
			this.sizeGen.Emit(OpCodes.Call, typeof(IOHelper).GetMethod(method));
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00007FC8 File Offset: 0x000061C8
		private void EmitSize(MemberInfo member, FieldType type)
		{
			switch (type)
			{
			case FieldType.Byte:
			case FieldType.Bool:
				this.sizeAccumulator++;
				return;
			case FieldType.Int16:
				this.sizeAccumulator += 2;
				return;
			case FieldType.Int32:
			case FieldType.Float32:
				this.sizeAccumulator += 4;
				return;
			case FieldType.Int64:
			case FieldType.Float64:
				this.sizeAccumulator += 8;
				return;
			default:
			{
				if (this.sizeAccumulator != 0)
				{
					this.sizeGen.Emit(OpCodes.Ldloc_0);
					this.sizeGen.Emit(OpCodes.Ldc_I4, this.sizeAccumulator);
					this.sizeGen.Emit(OpCodes.Add);
					this.sizeGen.Emit(OpCodes.Stloc_0);
					this.sizeAccumulator = 0;
				}
				Action action = delegate
				{
					this.sizeGen.Emit(OpCodes.Ldarg_0);
					if (member is PropertyInfo)
					{
						this.sizeGen.Emit(OpCodes.Call, ((PropertyInfo)member).GetGetMethod());
						return;
					}
					this.sizeGen.Emit(OpCodes.Ldfld, (FieldInfo)member);
				};
				switch (type)
				{
				case FieldType.UTF:
					this.EmitSizeCall("NextUTF", action);
					return;
				case FieldType.UTF32:
					this.EmitSizeCall("NextUTF32", action);
					return;
				default:
					switch (type)
					{
					case FieldType.Buffer16:
						this.EmitSizeCall("NextBuffer16", action);
						return;
					case FieldType.UTF32Array:
						this.EmitSizeCall("NextUTF32Array", action);
						return;
					case FieldType.IntArray:
						this.EmitSizeCall("NextIntArray", action);
						return;
					case FieldType.DataArray:
					{
						Type type2;
						if (member is PropertyInfo)
						{
							type2 = ((PropertyInfo)member).PropertyType.GetElementType();
						}
						else
						{
							type2 = ((FieldInfo)member).FieldType.GetElementType();
						}
						this.sizeGen.Emit(OpCodes.Ldloc_0);
						action();
						this.sizeGen.Emit(OpCodes.Call, typeof(IOHelper).GetMethod("SizeOfDataArray").MakeGenericMethod(new Type[] { type2 }));
						this.sizeGen.Emit(OpCodes.Add);
						this.sizeGen.Emit(OpCodes.Stloc_0);
						return;
					}
					case FieldType.DataType:
					{
						Type type3;
						if (member is PropertyInfo)
						{
							type3 = ((PropertyInfo)member).PropertyType;
						}
						else
						{
							type3 = ((FieldInfo)member).FieldType;
						}
						this.sizeGen.Emit(OpCodes.Ldloc_0);
						action();
						this.sizeGen.Emit(OpCodes.Call, typeof(DataTypeIO).GetMethod("SizeOf").MakeGenericMethod(new Type[] { type3 }));
						this.sizeGen.Emit(OpCodes.Add);
						this.sizeGen.Emit(OpCodes.Stloc_0);
						return;
					}
					default:
						throw new NotSupportedException();
					}
					break;
				}
				break;
			}
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00008288 File Offset: 0x00006488
		public InitDataTypeIO<T> Field<TField>(Expression<Func<T, TField>> field, FieldType type)
		{
			if (!(field.Body is MemberExpression))
			{
				throw new ArgumentException("Invalid lambda expression; expected MemberExpression.", "field");
			}
			MemberInfo member = ((MemberExpression)field.Body).Member;
			if (!(member is PropertyInfo) && !(member is FieldInfo))
			{
				throw new ArgumentException("Invalid MemberInfo; expected PropertyInfo/FieldInfo.", "field");
			}
			this.EmitLoad(member, type);
			this.EmitSave(member, type);
			this.EmitSize(member, type);
			return this;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x000082FC File Offset: 0x000064FC
		public void End()
		{
			this.loadGen.Emit(OpCodes.Ldloc_0);
			this.loadGen.Emit(OpCodes.Ret);
			DataTypeIO.IOData<T>.LoadFunc = (DataTypeIO.LoadFunc<T>)this.load.CreateDelegate(typeof(DataTypeIO.LoadFunc<T>));
			this.saveGen.Emit(OpCodes.Ret);
			DataTypeIO.IOData<T>.SaveFunc = (DataTypeIO.SaveFunc<T>)this.save.CreateDelegate(typeof(DataTypeIO.SaveFunc<T>));
			if (this.sizeAccumulator != 0)
			{
				this.sizeGen.Emit(OpCodes.Ldloc_0);
				this.sizeGen.Emit(OpCodes.Ldc_I4, this.sizeAccumulator);
				this.sizeGen.Emit(OpCodes.Add);
			}
			else
			{
				this.sizeGen.Emit(OpCodes.Ldloc_0);
			}
			this.sizeGen.Emit(OpCodes.Ret);
			DataTypeIO.IOData<T>.SizeFunc = (DataTypeIO.SizeFunc<T>)this.size.CreateDelegate(typeof(DataTypeIO.SizeFunc<T>));
			DataTypeIO.IOData<T>.Initialized = true;
		}

		// Token: 0x040001A8 RID: 424
		private readonly Type typeT;

		// Token: 0x040001A9 RID: 425
		private readonly bool isValueType;

		// Token: 0x040001AA RID: 426
		private readonly DynamicMethod load;

		// Token: 0x040001AB RID: 427
		private readonly DynamicMethod save;

		// Token: 0x040001AC RID: 428
		private readonly DynamicMethod size;

		// Token: 0x040001AD RID: 429
		private readonly ILGenerator loadGen;

		// Token: 0x040001AE RID: 430
		private readonly ILGenerator saveGen;

		// Token: 0x040001AF RID: 431
		private readonly ILGenerator sizeGen;

		// Token: 0x040001B0 RID: 432
		private int sizeAccumulator;
	}
}
