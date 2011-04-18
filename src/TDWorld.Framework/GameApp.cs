using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public class GameApp : Game, IGameApp
	{
		public IGameLogic GameLogic { get; protected set; }

		public GameApp ()
		{
		}
		
		public bool LoadGame()
		{
			return false;
		}
		
		public IGameLogic CreateGameLogic()
		{
			return null;
		}
	}
}

