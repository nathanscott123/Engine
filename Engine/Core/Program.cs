using System;
using Engine.Core;
using Engine.Systems;
using Engine.Interfaces;
using OpenTK.Graphics.OpenGL;

namespace Engine.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Change me in Program.cs", 800, 600);
            // run game with 60 frames per second
            Engine engine = new Engine(game,true);
        }
    }
}
