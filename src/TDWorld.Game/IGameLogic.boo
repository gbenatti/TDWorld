namespace TDWorld.Game

import TDWorld.Os

interface IGameLogic:
	Views as (IGameView):
		get

	def Start()
	def Shutdown()

	def AddGameView(view as IGameView)
	
	def Update(gameTime as GameTime)
