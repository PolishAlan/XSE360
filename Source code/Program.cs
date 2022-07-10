using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using SharpDX.XInput;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace XSE360
{
	internal class Program
    {
		[DllImport("Kernel32.dll")]

		private static extern IntPtr GetConsoleWindow();
		[DllImport("User32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        static void Main(string[] args)
        {
			string[] passedInArgs = Environment.GetCommandLineArgs();

            if ((passedInArgs.Contains("-nogui") || passedInArgs.Contains("-NOGUI")))
            {

				IntPtr hWnd = GetConsoleWindow();
				if(hWnd != IntPtr.Zero)
                {
					ShowWindow(hWnd, 0);
                }

				var inputMonitor = new XBoxControllerAsMouse();
				inputMonitor.Start();
			}
            else
            {
				string version = "v0.0019";

				Console.Title = String.Format("XSE360 {0}", version);

				var inputMonitor = new XBoxControllerAsMouse();
				inputMonitor.Start();

				Console.WriteLine(@" __   __ _____ ______ ____    __   ___  ");
				Console.WriteLine(@" \ \ / // ____|  ____|___ \  / /  / _ \ ");
				Console.WriteLine(@"  \ V /| (___ | |__    __) |/ /_ | | | |");
				Console.WriteLine(@"   > <  \___ \|  __|  |__ <| '_ \| | | |");
				Console.WriteLine(@"  / . \ ____) | |____ ___) | (_) | |_| |");
				Console.WriteLine(@" /_/ \_\_____/|______|____/ \___/ \___/ ");
				Console.WriteLine("");
				Console.WriteLine("Try to move your cursor with the controller's left thumbstick,");
				Console.WriteLine("");
				Console.WriteLine("if you plug in a controller now, you don't have to run the application again.");
				Console.WriteLine("");
				Console.WriteLine("Made with: 'Input Simulator' and 'SharpDX.XInput'.");
				for (; ; )
				{
					Console.Read();
				}
			}
		}
    }
}
