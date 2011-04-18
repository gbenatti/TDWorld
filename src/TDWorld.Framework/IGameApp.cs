using System;

namespace TDWorld.Framework
{
	public delegate IGameLogic CreateGameLogicHandler();
	public delegate bool GameLoadHandler();
	
	public interface IGameApp
	{
		IGameLogic GameLogic {get;}
		CreateGameLogicHandler CreateGameLogic {set; }
		GameLoadHandler LoadGame {set; } 
	}
}

