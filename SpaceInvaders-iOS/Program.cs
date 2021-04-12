using System;
using Foundation;
using UIKit;
using Dragon;

namespace SpaceInvaders_iOS
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static DGame game;

        internal static void RunGame()
        {
            game = new DGame(new GameScene());
            game.Run();
        }

        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }
}
