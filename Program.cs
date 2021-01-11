using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using System.Runtime.InteropServices;

//since we set our console app output to Windows Program and we have no form, this will be invisible.
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //adjust volume code
            //setup and use this library (NAudio)
            MMDeviceEnumerator MMDE = new MMDeviceEnumerator();
            MMDevice mmDevice;
            float maxVolume = 0.10f; //max volume 10
            mmDevice = MMDE.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia); //find our default audio device

            while (true) //force max volume. (Infinite loop.)
            {
                if (mmDevice.AudioEndpointVolume.MasterVolumeLevelScalar > maxVolume) //if volume above 10%...
                    mmDevice.AudioEndpointVolume.MasterVolumeLevelScalar = maxVolume; //set to 10%.
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
