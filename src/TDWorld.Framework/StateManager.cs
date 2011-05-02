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
		
		Dictionary<string, T> _states;
		
		public StateManager (T state)
		{
			_states = new Dictionary<string, T>();
			if (state != null)
			{
				_states.Add(state.Name.ToLower(), state);
				Current = state;
			}
		}
		
		public void AddState(T state)
		{
			if (_states.ContainsKey(state.Name.ToLower())) 
				throw(new InvalidOperationException(string.Format("The state {0} was already added", state.Name)));
			
			_states.Add(state.Name.ToLower(), state);
		}
		
		public void RemoveState(string stateName)
		{
			_states.Remove(stateName.ToLower());
		}
		
		public void ChangeState(string stateName) 
		{
			Current = _states[stateName.ToLower()];
		}
	}
}

