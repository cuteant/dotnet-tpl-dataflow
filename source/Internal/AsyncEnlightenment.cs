using System;
using System.Threading.Tasks;

namespace System.Threading.Tasks.Dataflow.Internal
{
	internal static class AsyncEnlightenment
	{
#if NET_4_5_BELOW
		/// <summary>The <c>TaskCreationOptions.DenyChildAttach</c> value, if it exists; otherwise, <c>0</c>.</summary>
		internal static readonly TaskCreationOptions _CreationDenyChildAttach;
		/// <summary>The <c>TaskContinuationOptions.DenyChildAttach</c> value, if it exists; otherwise, <c>0</c>.</summary>
		private static readonly TaskContinuationOptions _ContinuationDenyChildAttach;

		static AsyncEnlightenment()
		{
			_CreationDenyChildAttach = EnumValue<TaskCreationOptions>("DenyChildAttach") ?? 0;
			_ContinuationDenyChildAttach = EnumValue<TaskContinuationOptions>("DenyChildAttach") ?? 0;
		}

		private static T? EnumValue<T>(String name) where T : struct
		{
			try
			{
				return (T)Enum.Parse(typeof(T), name, true);
			}
			catch (ArgumentException) { }
			catch (OverflowException) { }
			return null;
		}
#endif

		internal static TaskCreationOptions AddDenyChildAttach(TaskCreationOptions options)
		{
#if NET_4_0_ABOVE
			return options | TaskCreationOptions.DenyChildAttach;
#else
			return options | _CreationDenyChildAttach;
#endif
		}

		internal static TaskContinuationOptions AddDenyChildAttach(TaskContinuationOptions options)
		{
#if NET_4_0_ABOVE
			return options | TaskContinuationOptions.DenyChildAttach;
#else
			return options | _ContinuationDenyChildAttach;
#endif
		}
	}
}
