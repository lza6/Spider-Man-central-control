using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace XXTCC;

public class Class_GenThreadPool
{
	public interface IThreadPool
	{
		void AddJob(Thread jobToRun);

		Stats GetStats();
	}

	public class GenThreadPoolImpl : IThreadPool
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private static bool bool_0;

		private ArrayList arrayList_0;

		private ArrayList arrayList_1;

		public ArrayList PendingJobs
		{
			get
			{
				return arrayList_0;
			}
			set
			{
				arrayList_0 = value;
			}
		}

		public ArrayList AvailableThreads
		{
			get
			{
				return arrayList_1;
			}
			set
			{
				arrayList_1 = value;
			}
		}

		public bool Debug
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public int MaxIdleTime
		{
			get
			{
				return int_2;
			}
			set
			{
				int_2 = value;
			}
		}

		public int MaxThreads
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public int MinThreads
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		public GenThreadPoolImpl()
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			int_0 = 1;
			int_1 = 0;
			int_2 = 300;
			arrayList_0 = ArrayList.Synchronized(new ArrayList());
			arrayList_1 = ArrayList.Synchronized(new ArrayList());
			bool_0 = false;
		}

		public GenThreadPoolImpl(int maxThreads, int minThreads, int maxIdleTime)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			int_0 = maxThreads;
			int_1 = minThreads;
			int_2 = maxIdleTime;
			arrayList_0 = ArrayList.Synchronized(new ArrayList());
			arrayList_1 = ArrayList.Synchronized(new ArrayList());
			bool_0 = false;
			InitAvailableThreads();
		}

		public void InitAvailableThreads()
		{
			if (int_0 > 0)
			{
				int num = int_0;
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					Thread th = new Thread(new GenPool(this, this).Run);
					ThreadElement threadElement = new ThreadElement(th);
					threadElement.Idle = true;
					arrayList_1.Add(threadElement);
				}
			}
		}

		public GenThreadPoolImpl(int maxThreads, int minThreads, int maxIdleTime, bool debug)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			int_0 = maxThreads;
			int_1 = minThreads;
			int_2 = maxIdleTime;
			arrayList_0 = ArrayList.Synchronized(new ArrayList());
			arrayList_1 = ArrayList.Synchronized(new ArrayList());
			bool_0 = debug;
		}

		public void AddJob(Thread job)
		{
			if (job == null)
			{
				return;
			}
			lock (this)
			{
				arrayList_0.Add(job);
				int num = FindFirstIdleThread();
				if (bool_0)
				{
					Console.WriteLine("第一空闲线程是" + num);
				}
				if (num == -1)
				{
					if ((int_0 == -1) | (arrayList_1.Count < int_0))
					{
						if (bool_0)
						{
							Console.WriteLine("创建新的线程");
						}
						Thread th = new Thread(new GenPool(this, this).Run);
						ThreadElement threadElement = new ThreadElement(th);
						threadElement.Idle = false;
						threadElement.GetMyThread().Start();
						try
						{
							arrayList_1.Add(threadElement);
							return;
						}
						catch (OutOfMemoryException ex)
						{
							ProjectData.SetProjectError(ex);
							OutOfMemoryException ex2 = ex;
							Console.WriteLine("内存不足：" + ex2.ToString());
							Thread.Sleep(3000);
							arrayList_1.Add(threadElement);
							Console.WriteLine("再次增加工作");
							ProjectData.ClearProjectError();
							return;
						}
					}
					if (bool_0)
					{
						Console.WriteLine("没有可用的线程…" + GetStats().ToString());
					}
					return;
				}
				try
				{
					if (bool_0)
					{
						Console.WriteLine("使用现有线程…");
					}
					((ThreadElement)arrayList_1[num]).Idle = false;
					lock (((ThreadElement)arrayList_1[num]).GetMyThread())
					{
						Monitor.Pulse(((ThreadElement)arrayList_1[num]).GetMyThread());
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Console.WriteLine("重用线程时出错" + ex4.Message);
					if (bool_0)
					{
						Console.WriteLine("线程" + num);
						Console.WriteLine("可用线程的大小为" + arrayList_1.Count);
						Console.WriteLine("可用线程是" + arrayList_1.IsSynchronized);
					}
					ProjectData.ClearProjectError();
				}
			}
		}

		public Stats GetStats()
		{
			return new Stats
			{
				MaxThreads = int_0,
				MinThreads = int_1,
				MaxIdleTime = int_2,
				PendingJobs = arrayList_0.Count,
				NumThreads = arrayList_1.Count,
				JobsInProgress = checked(arrayList_1.Count - FindIdleThreadCount())
			};
		}

		public int FindIdleThreadCount()
		{
			int num = 0;
			checked
			{
				int num2 = arrayList_1.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (((ThreadElement)arrayList_1[i]).Idle)
					{
						num++;
					}
				}
				return num;
			}
		}

		public int FindFirstIdleThread()
		{
			checked
			{
				int num = arrayList_1.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (((ThreadElement)arrayList_1[num2]).Idle)
						{
							break;
						}
						num2++;
						continue;
					}
					return -1;
				}
				return num2;
			}
		}

		public int FindThread()
		{
			checked
			{
				int num = arrayList_1.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (((ThreadElement)arrayList_1[num2]).GetMyThread().Equals(Thread.CurrentThread))
						{
							break;
						}
						num2++;
						continue;
					}
					return -1;
				}
				return num2;
			}
		}

		public void RemoveThread()
		{
			checked
			{
				int num = arrayList_1.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (((ThreadElement)arrayList_1[num2]).GetMyThread().Equals(Thread.CurrentThread))
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				arrayList_1.RemoveAt(num2);
			}
		}
	}

	public class GenPool
	{
		private object object_0;

		private GenThreadPoolImpl genThreadPoolImpl_0;

		public GenPool(object lock_, GenThreadPoolImpl gn)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			object_0 = RuntimeHelpers.GetObjectValue(lock_);
			genThreadPoolImpl_0 = gn;
		}

		public void Run()
		{
			while (true)
			{
				object obj = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				Thread thread;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (genThreadPoolImpl_0.PendingJobs.Count == 0)
					{
						int num = genThreadPoolImpl_0.FindThread();
						if (num == -1)
						{
							break;
						}
						((ThreadElement)genThreadPoolImpl_0.AvailableThreads[num]).Idle = true;
						goto IL_0099;
					}
					thread = (Thread)genThreadPoolImpl_0.PendingJobs[0];
					genThreadPoolImpl_0.PendingJobs.RemoveAt(0);
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
				thread.Start();
				thread.Join();
				continue;
				IL_0099:
				try
				{
					lock (this)
					{
						if (genThreadPoolImpl_0.MaxIdleTime == -1)
						{
							Monitor.Wait(this);
						}
						else
						{
							Monitor.Wait(this, genThreadPoolImpl_0.MaxIdleTime);
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				object obj2 = object_0;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
				bool lockTaken2 = false;
				try
				{
					Monitor.Enter(obj2, ref lockTaken2);
					if (genThreadPoolImpl_0.PendingJobs.Count == 0 && ((genThreadPoolImpl_0.MinThreads != -1) & (genThreadPoolImpl_0.AvailableThreads.Count > genThreadPoolImpl_0.MinThreads)))
					{
						genThreadPoolImpl_0.RemoveThread();
						break;
					}
				}
				finally
				{
					if (lockTaken2)
					{
						Monitor.Exit(obj2);
					}
				}
			}
		}
	}

	public class ThreadElement
	{
		private bool bool_0;

		private Thread thread_0;

		public bool Idle
		{
			get
			{
				return bool_0;
			}
			set
			{
				bool_0 = value;
			}
		}

		public ThreadElement(Thread th)
		{
			Class14.QwnfEIbzxvDCI();
			base._002Ector();
			thread_0 = th;
			bool_0 = true;
		}

		public Thread GetMyThread()
		{
			return thread_0;
		}
	}

	public struct Stats
	{
		public int MaxThreads;

		public int MinThreads;

		public int MaxIdleTime;

		public int NumThreads;

		public int PendingJobs;

		public int JobsInProgress;

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("MaxThreads = ", 107);
			stringBuilder.Append(MaxThreads);
			stringBuilder.Append("\nMinThreads=" + Conversions.ToString(MinThreads));
			stringBuilder.Append("\nMaxIdleTime=" + Conversions.ToString(MaxIdleTime));
			stringBuilder.Append("\nPendingJobs=" + Conversions.ToString(PendingJobs));
			stringBuilder.Append("\nJobsInProgress=" + Conversions.ToString(JobsInProgress));
			return stringBuilder.ToString();
		}
	}

	public Class_GenThreadPool()
	{
		Class14.QwnfEIbzxvDCI();
		base._002Ector();
	}
}
