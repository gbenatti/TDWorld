using System;

namespace TDWorld.Framework
{
	public interface IGameViewState : IGameState
	{
		void Update(IGameTime gameTime);		
		void Render();
	}
}

