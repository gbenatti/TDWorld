namespace TDWorld.Game

interface IGameApp:
	Title as string:
		get
		
	Game as IGameLogic:
		get
		
	Running as bool:
		get

	def Start() as void
	""" Should start all subsystems, entry point for the engine.
	
	Steps:
		ParseOptions
		Start Video, Audio, Input, ResourceMgr, ScriptMgr, EventMgr and others
		CreateGame
	"""
		
	def Shutdown() as void
	
	def LoadGame() as bool
	def CreateGame() as IGameLogic
	
	def Update() as void
	def Render() as void
