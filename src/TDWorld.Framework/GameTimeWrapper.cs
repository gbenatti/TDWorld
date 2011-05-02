using System;
using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public class GameTimeWrapper : IGameTime
	{
		GameTime _gameTime;
		
		public GameTimeWrapper (GameTime gameTime)
		{
			_gameTime = gameTime;
		}
	}
}

