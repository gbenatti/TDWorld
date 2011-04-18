using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public interface IGameView
	{
		void Render();
		void Update(GameTime gametime);
	}
}
