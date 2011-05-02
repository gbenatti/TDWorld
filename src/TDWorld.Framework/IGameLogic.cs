using System;
using System.Collections.Generic;

namespace TDWorld.Framework
{
	public interface IGameLogic
	{
		List<IGameView> Views {get;}
		
		void Start();
		void Shutdown();
		
		void AddGameView(IGameView view);
		
		void Update(IGameTime gameTime);
	}
}

