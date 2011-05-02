using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public interface IGameLogicState : IGameState
	{
		void Update(GameTime gameTime);		

	}
}

