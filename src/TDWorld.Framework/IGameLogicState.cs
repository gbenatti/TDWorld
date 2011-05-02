using System;

namespace TDWorld.Framework
{
	public interface IGameLogicState : IGameState
	{
		void Update(IGameTime gameTime);		

	}
}

