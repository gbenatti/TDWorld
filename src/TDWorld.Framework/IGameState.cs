using System;
using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public interface IGameState
	{
		void Enter();
		void Exit();
	}
}

