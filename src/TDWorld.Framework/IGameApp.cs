using System;

namespace TDWorld.Framework
{
	public interface IGameApp
	{
		IGameLogic Game {get;}

		string Title {get;}
		
		bool Running {get;}

		void Start();
		void Shutdown();
	
		bool LoadGame();
		IGameLogic CreateGame();
		
		void Update();
		void Render();
	}
}

