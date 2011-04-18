using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public class GameApp : Game, IGameApp
	{
		public IGameLogic GameLogic { get; protected set; }

		public CreateGameLogicHandler CreateGameLogic {protected get; set; }

		public GameLoadHandler LoadGame {protected get; set; } 

		public GameApp ()
		{
		}
	}
}

