using System;

namespace TDWorld.Framework
{
	public interface IGameApp
	{
		IGameLogic GameLogic {get;}

		bool LoadGame();
		IGameLogic CreateGameLogic();
	}
}

