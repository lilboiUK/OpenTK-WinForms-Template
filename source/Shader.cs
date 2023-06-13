using OpenTK.Graphics.OpenGL4;

namespace OpenTK_WinForms_Template
{
    public class Shader
    {
        public int Handle { get; private set; }
        public Shader(string vertLocation, string fragLocation)
        {
            int vertShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertShader, File.ReadAllText(vertLocation));
            GL.CompileShader(vertShader);

            int fragShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragShader, File.ReadAllText(fragLocation));
            GL.CompileShader(fragShader);

            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertShader);
            GL.AttachShader(Handle, fragShader);
            GL.LinkProgram(Handle);

            GL.DetachShader(Handle, vertShader);
            GL.DetachShader(Handle, fragShader);
            GL.DeleteShader(vertShader);
            GL.DeleteShader(fragShader);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }
    }
}