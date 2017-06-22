using System;
using OpenTK;
using Engine.Core;
using Engine.Systems;
using OpenTK.Graphics;
//this namespace allows us to use only OpenGL , with all deprecated items removed.
using OpenTK.Graphics.OpenGL;

namespace Engine
{
    public class Game
    {
        //game window Title
        private string Title;
        //game window width
        private int Width;
        //game window height
        private int Height;

        public static Player Player { get; private set; }

        
        private VertexBuffer<ColouredVertex> vertexBuffer;
        private VertexArray<ColouredVertex> vertexArray;
        private Matrix4Uniform projectionMatrix;

        private ShaderProgram shaderProgram;

        //helper funtions to get the private varibles that get set in the constructor
        public int GetWidth() { return Width; }
        public int GetHeight() { return Height; }
        public string GetTitle() { return Title; }

        //constructor
        public Game(string title,int windowWidth, int windowHeight)
        {
            Title = title;
            Width = windowWidth;
            Height = windowHeight;
          
        }

        public void OnLoad()
        {
            // create and fill a vertex buffer
            this.vertexBuffer = new VertexBuffer<ColouredVertex>(ColouredVertex.Size);

            this.vertexBuffer.AddVertex(new ColouredVertex(new Vector3(-1, -1, -1.5f), Color4.Lime));
            this.vertexBuffer.AddVertex(new ColouredVertex(new Vector3(1, 1, -1.5f), Color4.Red));
            this.vertexBuffer.AddVertex(new ColouredVertex(new Vector3(1, -1, -1.5f), Color4.Blue));



            // load shaders
            #region Shaders

            var vertexShader = new Shader(ShaderType.VertexShader,
@"#version 130

// a projection transformation to apply to the vertex' position
uniform mat4 projectionMatrix;

// attributes of our vertex
in vec3 vPosition;
in vec4 vColor;

out vec4 fColor; // must match name in fragment shader

void main()
{
    // gl_Position is a special variable of OpenGL that must be set
	gl_Position = projectionMatrix * vec4(vPosition, 1.0);
	fColor = vColor;
}"
                );
            var fragmentShader = new Shader(ShaderType.FragmentShader,
@"#version 130

in vec4 fColor; // must match name in vertex shader

out vec4 fragColor; // first out variable is automatically written to the screen

void main()
{
    fragColor = fColor;
}"
                );

            #endregion

            // link shaders into shader program
            this.shaderProgram = new ShaderProgram(vertexShader, fragmentShader);



            // create vertex array to specify vertex layout
            this.vertexArray = new VertexArray<ColouredVertex>(
                this.vertexBuffer, shaderProgram,
                new VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, ColouredVertex.Size, 0),
                new VertexAttribute("vColor", 4, VertexAttribPointerType.Float, ColouredVertex.Size, 12)
                );

            // create projection matrix uniform
            this.projectionMatrix = new Matrix4Uniform("projectionMatrix");
            this.projectionMatrix.Matrix = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver2, 16f / 9, 0.1f, 100f);

      

            Player = new Player();

   

            Player.OutPutPlayerValuesToDebugger();
            //This is where you load all of your content
            //Images, Models, Fonts, Sounds.
        }
        public void OnUpdate()
        {
           

            //This is where you handle all of your game logic
            //Jumping, Running, Attacking, Playing Sounds...
        }
        public void OnRender()
        {

            //And this is where you render all of the images
            //models, fonts or anything that you want to show onscreen
        
            // activate shader program and set uniforms
            this.shaderProgram.Use();
            this.projectionMatrix.Set(this.shaderProgram);

            // bind vertex buffer and array objects
            this.vertexBuffer.Bind();
            this.vertexArray.Bind();

            // upload vertices to GPU and draw them
            this.vertexBuffer.BufferData();
            this.vertexBuffer.Draw();

            // reset state for potential further draw calls (optional, but good practice)
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.UseProgram(0);

        }

    }
}
