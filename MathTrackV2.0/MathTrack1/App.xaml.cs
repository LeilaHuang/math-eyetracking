using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


//for using Tobii
using EyeXFramework;
using Tobii.EyeX.Framework;

//for using background worker
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace MathTrack1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private double eyeX, eyeY;
        private readonly BackgroundWorker myBGWorker = new BackgroundWorker();
        private EyeXHost eyeXHost;
        Boolean startedEyeX = false;
        private GazePointDataStream gazeStream;
        Boolean startedStream = false;
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public App()
        {
            myBGWorker.DoWork += bgWorker_Work;
            myBGWorker.RunWorkerCompleted += bgWorker_Completed;
            myBGWorker.RunWorkerAsync();
        }

        private void bgWorker_Work(object sender, DoWorkEventArgs ev)
        {
/*            AllocConsole();
            using (eyeXHost = new EyeXHost())
            {
                eyeXHost.Start();
                gazeStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

                // Write the data to the background console.
                gazeStream.Next += (s, e) => { eyeX = e.X; eyeY = e.Y; };
                Console.Read();
            }
*/        }

        public double getX()
        {
            return eyeX;
        }
        public double getY()
        {
            return eyeY;
        }

        private void bgWorker_Completed(object s, RunWorkerCompletedEventArgs e)
        {
            if (startedEyeX)
                eyeXHost.Dispose();
            if (startedStream)
                gazeStream.Dispose();
        }


    }
}
