using System;

using Microsoft.Xna.Framework;

namespace TDWorld.Framework
{
	public class GameApp : Game, IGameApp
	{
		public GameApp ()
		{
		}
		
		public IGameLogic Game 
		{
			get { return null; } 
			set {}
		}

		public string Title { get; protected set; }
		
		public bool Running 
		{
			get 
			{
				return false; 
			}
		}

		public void Start()
		{
		}
		
		public void Shutdown()
		{
		}
	
		public bool LoadGame()
		{
			return false;
		}
		
		public IGameLogic CreateGame()
		{
			return null;
		}
		
		public void Update()
		{
		}
		
		public void Render()
		{
		}
	}
}

