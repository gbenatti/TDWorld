using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public class AbstractGameLogic : IGameLogic
	{
		public List<IGameView> Views {get; private set;}

		public AbstractGameLogic ()
		{
			Views = new List<IGameView>();
		}
		
		public void Start()
		{
			SetupInitialView();
		}
		
		protected virtual void SetupInitialView ()
		{
			AddGameView(new HumanView());
		}

		public void Shutdown()
		{
		}
		
		public void AddGameView(IGameView view)
		{
			Views.Add(view);
		}
		
		public void Update(GameTime gameTime)
		{
			UpdateViews(gameTime);
		}
		
		private void UpdateViews(GameTime gameTime)
		{
			foreach(var view in Views)
			{
				view.Update(gameTime);
			}
		}
}
}
