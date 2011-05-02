using System;
using System.Collections.Generic;

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
		
		public void Update(IGameTime gameTime)
		{
			UpdateViews(gameTime);
		}
		
		private void UpdateViews(IGameTime gameTime)
		{
			foreach(var view in Views)
			{
				view.Update(gameTime);
			}
		}
}
}
