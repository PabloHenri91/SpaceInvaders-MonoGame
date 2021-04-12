using System;

using Dragon;

namespace SpaceInvaders_macOS
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            GameScene scene = new GameScene();
            using var game = new DGame(scene);
            game.Run();
        }
    }
}
