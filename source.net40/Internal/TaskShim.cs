using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Runtime.CompilerServices;

namespace System.Threading.Tasks.Dataflow.Internal
{
	internal static class TaskShim
	{
		/// <summary>使用的常数指定一个无限期等待周期，接受一个 TimeSpan 参数的方法。</summary>
		/// <remarks>该常数的值是表示 -1 毫秒的 TimeSpan 对象。 对于接受 timeout 参数的线程处理方法（如 Thread.Sleep(TimeSpan) 和 Thread.Join(TimeSpan)），该值用于取消超时行为。</remarks>
		public static TimeSpan InfiniteTimeSpan
		{
			get { return new TimeSpan(0, 0, 0, 0, -1); }
		}

		/// <summary>创建异步产生当前上下文的等待任务。</summary>
		/// <returns>等待时，上下文将异步转换回等待时的当前上下文。 
		/// 如果当前 SynchronizationContext 不为 null，则将其视为当前上下文。 否则，与当前执行任务关联的任务计划程序将视为当前上下文。</returns>
		public static YieldAwaitable Yield()
		{
			return TaskEx.Yield();
		}

		/// <summary>创建指定结果的、成功完成的任务。</summary>
		/// <typeparam name="TResult">任务返回的结果的类型</typeparam>
		/// <param name="value">存储入已完成任务的结果</param>
		/// <returns></returns>
		public static Task<TResult> FromResult<TResult>(TResult value)
		{
			return TaskEx.FromResult(value);
		}

		#region -- Delay --

		/// <summary>创建在时间后将完成的任务</summary>
		/// <param name="dueTime"></param>
		/// <returns></returns>
		public static Task Delay(Int32 dueTime)
		{
			return TaskEx.Delay(dueTime);
		}

		/// <summary>创建在时间后将完成的任务</summary>
		/// <param name="dueTime"></param>
		/// <returns></returns>
		public static Task Delay(TimeSpan dueTime)
		{
			return TaskEx.Delay(dueTime);
		}

		/// <summary>创建在时间后将完成的任务</summary>
		/// <param name="dueTime"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task Delay(Int32 dueTime, CancellationToken cancellationToken)
		{
			return TaskEx.Delay(dueTime, cancellationToken);
		}

		/// <summary>创建在时间后将完成的任务</summary>
		/// <param name="dueTime"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task Delay(TimeSpan dueTime, CancellationToken cancellationToken)
		{
			return TaskEx.Delay(dueTime, cancellationToken);
		}

		#endregion

		#region -- Run --

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <param name="action"></param>
		/// <returns></returns>
		public static Task Run(Action action)
		{
			return TaskEx.Run(action);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="function"></param>
		/// <returns></returns>
		public static Task<TResult> Run<TResult>(Func<Task<TResult>> function)
		{
			return TaskEx.Run(function);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <param name="function"></param>
		/// <returns></returns>
		public static Task Run(Func<Task> function)
		{
			return TaskEx.Run(function);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="function"></param>
		/// <returns></returns>
		public static Task<TResult> Run<TResult>(Func<TResult> function)
		{
			return TaskEx.Run(function);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <param name="action"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task Run(Action action, CancellationToken cancellationToken)
		{
			return TaskEx.Run(action, cancellationToken);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="function"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken)
		{
			return TaskEx.Run(function, cancellationToken);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <param name="function"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task Run(Func<Task> function, CancellationToken cancellationToken)
		{
			return TaskEx.Run(function, cancellationToken);
		}

		/// <summary>在线程池队列所指定的工作运行并返回该工作的任务句柄</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="function"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public static Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken)
		{
			return TaskEx.Run(function, cancellationToken);
		}

		#endregion

		#region -- WhenAll --

		/// <summary>所有提供的任务已完成时，创建将完成的任务</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task<TResult[]> WhenAll<TResult>(IEnumerable<Task<TResult>> tasks)
		{
			return TaskEx.WhenAll(tasks);
		}

		/// <summary>所有提供的任务已完成时，创建将完成的任务</summary>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task WhenAll(IEnumerable<Task> tasks)
		{
			return TaskEx.WhenAll(tasks);
		}

		/// <summary>所有提供的任务已完成时，创建将完成的任务</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task<TResult[]> WhenAll<TResult>(params Task<TResult>[] tasks)
		{
			return TaskEx.WhenAll(tasks);
		}

		/// <summary>所有提供的任务已完成时，创建将完成的任务</summary>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task WhenAll(params Task[] tasks)
		{
			return TaskEx.WhenAll(tasks);
		}

		#endregion

		#region -- WhenAny --

		/// <summary>任何提供的任务已完成时，创建将完成的任务</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task<Task<TResult>> WhenAny<TResult>(IEnumerable<Task<TResult>> tasks)
		{
			return TaskEx.WhenAny(tasks);
		}

		/// <summary>任何提供的任务已完成时，创建将完成的任务</summary>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task<Task> WhenAny(IEnumerable<Task> tasks)
		{
			return TaskEx.WhenAny(tasks);
		}

		/// <summary>任何提供的任务已完成时，创建将完成的任务</summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task<Task<TResult>> WhenAny<TResult>(params Task<TResult>[] tasks)
		{
			return TaskEx.WhenAny(tasks);
		}

		/// <summary>任何提供的任务已完成时，创建将完成的任务</summary>
		/// <param name="tasks"></param>
		/// <returns></returns>
		public static Task<Task> WhenAny(params Task[] tasks)
		{
			return TaskEx.WhenAny(tasks);
		}

		#endregion
	}
}
