
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using TDWorld.Framework;

namespace TDWorld.Runner
{
    [Register("AppDelegate")]
    class Application : UIApplicationDelegate
    {
        public override void FinishedLaunching(UIApplication app)
        {
            // Fun begins..
            using (var game = new GameApp())
            {
                game.Run();
            }
        }

		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
}
