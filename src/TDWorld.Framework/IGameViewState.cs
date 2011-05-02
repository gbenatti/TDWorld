using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public interface IGameViewState : IGameState
	{
		void Update(GameTime gameTime);		
		void Render();
	}
}

