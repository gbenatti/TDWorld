
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Runner
{
	[Register ("AppDelegate")]
	class Application : UIApplicationDelegate 
	{
		IGameApp _gameApp;
		
		public override void FinishedLaunching (UIApplication app)
		{
			Environments.Using(new GameEngineEnvironment());

			_gameApp = new SampleApp();
			_gameApp.Start();
		}
		
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}

		static void Main (string [] args)
		{
			UIApplication.Main (args,null,"AppDelegate");
		}
    }	
}


