using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using TDWorld.Framework.Components;

namespace TDWorld.Framework
{
	public class GameApp : Game, IGameApp
	{
		public IGameLogic GameLogic { get; protected set; }

		public CreateGameLogicHandler CreateGameLogic {protected get; set; }

		public GameLoadHandler LoadGame {protected get; set; } 
		
		GraphicsDeviceManager graphics;

		public GameApp ()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.IsFullScreen = true;
			graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight | DisplayOrientation.PortraitUpsideDown;
		}

		protected override void Initialize()
        {
			CreateAndBindGameLogic();
			
            base.Initialize();
        }
		
		private void CreateAndBindGameLogic()
		{
			if (CreateGameLogic != null) 
			{
				this.GameLogic = CreateGameLogic();
				var glc = new GameLogicComponent(this) {GameLogic = this.GameLogic};
				Components.Add(glc);
			}
		}
		
        protected override void LoadContent()
        {
		}
		
		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
		
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
		}
		                             	
	}
}

