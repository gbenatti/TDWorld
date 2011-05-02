using System;

namespace TDWorld.Framework
{
	public interface IGameView
	{
		void Render();
		void Update(IGameTime gametime);
	}
}
