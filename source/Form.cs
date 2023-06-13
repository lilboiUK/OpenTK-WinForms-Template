#nullable disable  // Disables nullability warnings
using OpenTK.WinForms;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System.Diagnostics;

namespace OpenTK_WinForms_Template
{
    public partial class MainForm : Form
    {
        GLControl glControl;
        Shader basicShader;
        Stopwatch deltaTimeStopwatch;
        float timeElapsed;

        int triangleVAO;

        float[] triangleVerts =
        {
            -0.5f, -0.5f, 1.0f,
             0.5f, -0.5f, 1.0f,
             0.0f,  0.5f, 1.0f,
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            // Create and configure the GLControl
            glControl = new GLControl();
            glControl.Load += OnLoad;
            glControl.Paint += OnRender;

            // Parent the GLControl context to the panel
            glControl.Dock = DockStyle.Fill;
            glParentPanel.Controls.Add(glControl);

            deltaTimeStopwatch = Stopwatch.StartNew();
            
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.Black);

            basicShader = new Shader("shaders/vert.vert", "shaders/frag.frag");

            // Generate a new VAO and bind it
            triangleVAO = GL.GenVertexArray();
            GL.BindVertexArray(triangleVAO);

            // Generate a new VBO and bind it
            int triangleVBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, triangleVBO);
            
            // Provide vertex data to the VBO
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * triangleVerts.Length, triangleVerts, BufferUsageHint.StaticDraw);

            // Specify the vertex attribute pointers
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.EnableVertexArrayAttrib(triangleVAO, 0);
        }

        private void OnUpdate(float deltaTime)
        {
            timeElapsed += deltaTime;

            // Make the backgound color change
            float sinValue = (float)Math.Sin(timeElapsed);
            Color4 color = new Color4(sinValue, sinValue, sinValue, 1.0f);
            GL.ClearColor(color);
        }

        private void OnRender(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Bind the shader and VAO then draw the triangle
            basicShader.Use();
            GL.BindVertexArray(triangleVAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            glControl.SwapBuffers();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            float deltaTime = (float)deltaTimeStopwatch.Elapsed.TotalSeconds;
            deltaTimeStopwatch.Restart();

            OnUpdate(deltaTime);
            glControl.Invalidate();
        }

        private void OnFormResize(object sender, EventArgs e)
        {
            // Adjust the size of the GLControl parent panel when the form is resize
            glParentPanel.Size = new Size(Size.Width - 40, Size.Height - 63);
            
            // Update the viewport size
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
        }
    }
}