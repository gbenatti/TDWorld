using System;

namespace TDWorld.Framework
{
	public interface IGameState
	{
		string Name { get; }
		
		void Enter();
		void Exit();
	}
}

