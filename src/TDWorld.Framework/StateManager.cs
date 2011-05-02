using System;
using System.Collections.Generic;

namespace TDWorld.Framework
{
	public class StateManager<T> where T : IGameState
	{
		public int StateCount 
		{ 
			get { return _states.Count; }
		}

		public T Current 
		{ 
			get 
			{
				return _current;
			}
			
			private set
			{
				if (_current != null) { _current.Exit(); }
				_current = value;
				if (_current != null) { _current.Enter(); }
			}
		}
		
		T _current;
		
		List<T> _states;
		
		public StateManager (T state)
		{
			_states = new List<T>();
			Current = state;
		}
		
		public void AddState(T state)
		{
			if (_states.Contains(state)) 
				throw(new InvalidOperationException(string.Format("The state {0} was already added", state)));
			
			_states.Add(state);
		}
		
		public void RemoveState(T state)
		{
			_states.Remove(state);
		}
		
		public void ChangeState(T state) 
		{
			Current = state;
		}
	}
}

