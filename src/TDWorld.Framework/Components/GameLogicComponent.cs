using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework.Components
{
	public class GameLogicComponent : DrawableGameComponent
	{
		public IGameLogic GameLogic {get; set;}
		
		public GameLogicComponent(Game game) : base(game)
		{
		}
		
		override public void Initialize()
		{
			base.Initialize();
			GameLogic.Start();
		}
		
		override public void Update(GameTime gameTime) 
		{
			if (GameLogic != null)
			{
				GameLogic.Update(new GameTimeWrapper(gameTime));
				foreach (var view in GameLogic.Views)
				{
					view.Update(new GameTimeWrapper(gameTime));
				}
			}
		}
        public override void Draw(GameTime gameTime)
		{
			if (GameLogic != null)
			{
				foreach (var view in GameLogic.Views)
				{
					view.Render();
				}
			}
		}
	}
}

