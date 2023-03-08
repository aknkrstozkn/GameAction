using System;
using Helper;

namespace Core
{
	#region Base
	public abstract class GameActionBase
	{
		public enum RaiseType
		{
			Pre,
			Post,
			All
		}
		
		protected readonly string name;
		protected Action preRaiseAction;
		protected Action postRaiseAction;
		
		protected GameActionBase(string name, ref Action destroyEvent)
		{
			this.name = name;
			destroyEvent += DestroyEvent;
		}

		protected GameActionBase(string name, Action onRaise, RaiseType raiseType,  ref Action destroyEvent)
		{
			this.name = name;
			destroyEvent += DestroyEvent;
			SetRaiseActions(onRaise, raiseType);
		}

		protected GameActionBase(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent)
		{
			this.name = name;
			destroyEvent += DestroyEvent;
			preRaiseAction = onPreRaise;
			postRaiseAction = onPostRaise;
		}

		protected GameActionBase(string name)
		{
			this.name = name;
		}
		
		public GameActionBase(string name, Action onRaise, RaiseType raiseType)
		{
			this.name = name;
			SetRaiseActions(onRaise, raiseType);
		}

		public GameActionBase(string name, Action onPreRaise, Action onPostRaise)
		{
			this.name = name;
			preRaiseAction = onPreRaise;
			postRaiseAction = onPostRaise;
		}
		
		private void SetRaiseActions(Action onRaise, RaiseType raiseType)
		{
			switch (raiseType)
			{
				case RaiseType.Pre:
					preRaiseAction = onRaise;
					break;
				case RaiseType.Post:
					postRaiseAction = onRaise;
					break;
				case RaiseType.All:
					preRaiseAction = onRaise;
					postRaiseAction = onRaise;
					break;
			}
		}

		public abstract void DestroyEvent();

#region Debug

		protected void RecordEvent()
		{
#if UNITY_EDITOR
			EventHelper.RecordEvent($"Raise{name}");
#endif		
		}
		
		protected static void CheckNameFormatting(string applicantName, string targetName, bool isSub)
		{
#if UNITY_EDITOR
			EventHelper.CheckNameFormatsMatching(applicantName, targetName, isSub);
#endif		
		}

#endregion
		
	}
	#endregion
	
	#region GameAction
	public class GameAction : GameActionBase
	{
		private System.Action _action;
		
		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}

		public void Raise()
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke();
			postRaiseAction?.Invoke();
		}
		
		public static GameAction operator +(GameAction c1, System.Action x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction operator -(GameAction c1, System.Action x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	}
	#endregion
	#region GameAction<T1>
	public class GameAction<T1> : GameActionBase
	{
		private System.Action<T1> _action;
		
		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1> operator +(GameAction<T1> c1, System.Action<T1> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1> operator -(GameAction<T1> c1, System.Action<T1> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
	#region GameAction<T1, T2>
	public class GameAction<T1, T2> : GameActionBase
	{
		private System.Action<T1, T2> _action;
		
		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1, T2 arg2)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1, arg2);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1, T2> operator +(GameAction<T1, T2> c1, System.Action<T1, T2> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1, T2> operator -(GameAction<T1, T2> c1, System.Action<T1, T2> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
	#region GameAction<T1, T2, T3>
	public class GameAction<T1, T2, T3> : GameActionBase
	{
		private System.Action<T1, T2, T3> _action;

		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1, T2 arg2, T3 arg3)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1, arg2, arg3);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1, T2, T3> operator +(GameAction<T1, T2, T3> c1, System.Action<T1, T2, T3> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1, T2, T3> operator -(GameAction<T1, T2, T3> c1, System.Action<T1, T2, T3> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
	#region GameAction<T1, T2, T3, T4>
	public class GameAction<T1, T2, T3, T4> : GameActionBase
	{
		private System.Action<T1, T2, T3, T4> _action;

		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1, arg2, arg3, arg4);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1, T2, T3, T4> operator +(GameAction<T1, T2, T3, T4> c1, System.Action<T1, T2, T3, T4> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1, T2, T3, T4> operator -(GameAction<T1, T2, T3, T4> c1, System.Action<T1, T2, T3, T4> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
	#region GameAction<T1, T2, T3, T4, T5>
	public class GameAction<T1, T2, T3, T4, T5> : GameActionBase
	{
		private System.Action<T1, T2, T3, T4, T5> _action;

		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1, arg2, arg3, arg4, arg5);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1, T2, T3, T4, T5> operator +(GameAction<T1, T2, T3, T4, T5> c1, System.Action<T1, T2, T3, T4, T5> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1, T2, T3, T4, T5> operator -(GameAction<T1, T2, T3, T4, T5> c1, System.Action<T1, T2, T3, T4, T5> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
	#region GameAction<T1, T2, T3, T4, T5, T6>
	public class GameAction<T1, T2, T3, T4, T5, T6> : GameActionBase
	{
		private System.Action<T1, T2, T3, T4, T5, T6> _action;

		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1, T2, T3, T4, T5, T6> operator +(GameAction<T1, T2, T3, T4, T5, T6> c1, System.Action<T1, T2, T3, T4, T5, T6> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1, T2, T3, T4, T5, T6> operator -(GameAction<T1, T2, T3, T4, T5, T6> c1, System.Action<T1, T2, T3, T4, T5, T6> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
	#region GameAction<T1, T2, T3, T4, T5, T6, T7>
	public class GameAction<T1, T2, T3, T4, T5, T6, T7> : GameActionBase
	{
		private System.Action<T1, T2, T3, T4, T5, T6, T7> _action;

		public GameAction(string name, ref Action destroyEvent) : base(name, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType, ref Action destroyEvent) : base(name, onRaise, raiseType, ref destroyEvent)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise, ref Action destroyEvent) : base(name, onPreRaise, onPostRaise, ref destroyEvent)
		{
		}
		public GameAction(string name) : base(name)
		{
		}
		public GameAction(string name, Action onRaise, RaiseType raiseType) : base(name, onRaise, raiseType)
		{
		}
		public GameAction(string name, Action onPreRaise, Action onPostRaise) : base(name, onPreRaise, onPostRaise)
		{
		}
		
		public override void DestroyEvent()
		{
			_action = null;
		}
	
		public void Raise(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
		{
			RecordEvent();
			preRaiseAction?.Invoke();
			_action?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			postRaiseAction?.Invoke();
		}
		
		public static GameAction<T1, T2, T3, T4, T5, T6, T7> operator +(GameAction<T1, T2, T3, T4, T5, T6, T7> c1, System.Action<T1, T2, T3, T4, T5, T6, T7> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, true);
			c1._action += x;
			return c1;
		}
	
		public static GameAction<T1, T2, T3, T4, T5, T6, T7> operator -(GameAction<T1, T2, T3, T4, T5, T6, T7> c1, System.Action<T1, T2, T3, T4, T5, T6, T7> x)
		{
			CheckNameFormatting(x.Method.Name, c1.name, false);
			c1._action -= x;
			return c1;
		}
	}
	#endregion
}