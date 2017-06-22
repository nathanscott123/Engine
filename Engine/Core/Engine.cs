using System;
using OpenTK;
using Engine.Core;
using Engine.Systems;
using OpenTK.Graphics;
//this namespace allows us to use only OpenGL 4, with all deprecated items removed.
using OpenTK.Graphics.OpenGL;

namespace Engine.Core
{
    public class Engine : GameWindow
    {

        private Game game;
        private Debugger debugger;

        //the class constructor 
        public Engine(Game _game, bool _DebuggerON)
              : base(800, 600, OpenTK.Graphics.GraphicsMode.Default, "window", GameWindowFlags.Default,
            DisplayDevice.Default, 3, 0, OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible)
        {
            this.game = _game; 
            debugger = new Debugger(game);
            Title = game.GetTitle();
            Width = game.GetWidth();
            Height = game.GetHeight();
            Run(60);
        }

        protected override void OnLoad(EventArgs e)
        {

            //This is where you load all of your content
            //Images, Models, Fonts, Sounds.

            int major, minor;
            GL.GetInteger(GetPName.MajorVersion, out major);
            GL.GetInteger(GetPName.MinorVersion, out minor);
            Debugger.Print("OpenGL Version Major: " + major);
            Debugger.Print("OpenGL Version Minor: " + minor);
            //you can also get your GLSL version, although not sure if it varies from the above
            Debugger.Print("GLSL Version: " + GL.GetString(StringName.ShadingLanguageVersion));
            Debugger.NewLine();

            game.OnLoad();
           
            //set clear color [black]
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            //When the NativeWindow is resized this is called
            //This is where we define are viewport and aspect ratio
            GL.Viewport(0, 0, this.Width, this.Height);
            base.OnResize(e);

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            //This is where you handle all of your game logic
            //Jumping, Running, Attacking, Playing Sounds...

            if (Keyboard[OpenTK.Input.Key.W])
                Debugger.Print("W");
            if (Keyboard[OpenTK.Input.Key.S])
                Debugger.Print("S");
            if (Keyboard[OpenTK.Input.Key.A])
                Debugger.Print("A");
            if (Keyboard[OpenTK.Input.Key.D])
                Debugger.Print("D");

            game.OnUpdate();
            base.OnUpdateFrame(e);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //And this is where you render all of the images
            //models, fonts or anything that you want to show onscreen

            //clear the screen to BLACK
            GL.ClearColor(0, 0, 0, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            game.OnRender();

            base.OnRenderFrame(e);

            // swap backbuffer
            this.SwapBuffers();


            
        }
    }
}



