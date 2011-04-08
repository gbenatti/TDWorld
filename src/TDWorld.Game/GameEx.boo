namespace TDWorld.Game

class GameEx(Game):

	[getter(Running)]
	_isRunning = false
	
	[getter(Game)]
	_game as IGameLogic
	
	[getter(Title)]
	_title = "Base"

	protected Services as IGameServices:
		get:
			return (Environments.Current as IGameServices)	

	_started = false
	
	_window as IWindow

	def constructor():
		Services.RegisterAll()
	
	def Start():
		StartServices()
		BindWindow()
		StartGame()
		
		_started = true
		_isRunning = true
		
	private def BindWindow():
		_window = My.Provide[of IWindow]()
		_window.OnRender += Render
		_window.OnUpdate += Update
		
	private def StartServices():
		Services.StartAll()
			
	private def StartGame():
		_game = CreateGame()
		if _game: _game.Start()
		
	def Shutdown(): 
		ShutdownGame()
		ShutdownServices()
		_started = false
		
	private def ShutdownGame():
		return unless _game
		_game.Shutdown()
		_game = null
		
	private def ShutdownServices():
		Services.ShutdownAll()
			
	def Update():
		OnUpdate()
		
	private def OnUpdate():
		return if not _started or not _game
		frameTime = UpdateTime()
		
		_game.Update(frameTime)
		for view in _game.Views:
			view.Update(frameTime)

	private def UpdateTime() as GameTime:
		timeService = My.Provide[of ITimeService]()
		timeService.Update()
		return timeService.GameTime
		
	def Render(): 
		OnRender()

	private def OnRender():
		return if not _started or not _game
		for view in _game.Views:
			view.Render()


