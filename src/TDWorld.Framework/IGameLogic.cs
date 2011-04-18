using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public interface IGameLogic
	{
		List<IGameView> Views {get;}
		
		void Start();
		void Shutdown();
		
		void AddGameView(IGameView view);
		
		void Update(GameTime gameTime);
	}
}

