using System;
using System.Runtime.InteropServices;
using System.Threading;

using GregsStack.InputSimulatorStandard;

namespace AutoUnlocker_Utility.Core
{
    /// <summary>
    /// Реализация анлокера для DayZ
    /// </summary>
    internal class AutoUnlockerDayZ : IAutoUnlocker
    {
        private readonly InputSimulator inputSimulator;

        public AutoUnlockerDayZ() => inputSimulator = new InputSimulator();

        /// <summary>
        /// Запуск процесса
        /// </summary>
        public void Start()
        {
            SetForegroundGame("DayZ", "DayZ");

            Thread.Sleep(300);
            for(int i = 0; i < 10; i++)
            {
                SelectNext(2);
                for (int j = 0; j < 10; j++)
                {
                    Selecting();
                    SelectNext(2);
                    Thread.Sleep(300);
                    Selecting(200, 1100);
                    SelectNext(1);
                    Thread.Sleep(300);
                }
                SelectNext(1);
                Selecting(200, 1100);
            }
        }

        /// <summary>
        /// Перебор единиц
        /// </summary>
        private void Selecting(int pause = 200, int time = 4200)
        {
            Thread.Sleep(pause);
            inputSimulator.Mouse.RightButtonDown();
            Thread.Sleep(time);
            inputSimulator.Mouse.RightButtonUp();
        }

        /// <summary>
        /// Переход на другой порядок
        /// </summary>
        private void SelectNext(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Thread.Sleep(800);
                inputSimulator.Mouse.RightButtonDown();
                Thread.Sleep(100);
                inputSimulator.Mouse.RightButtonUp();
            }
        }



        /// <summary>
        /// Развернуть игру
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <exception cref="ArgumentException"></exception>
        private void SetForegroundGame(string lpClassName, string lpWindowName)
        {
            IntPtr gameHandle = FindWindow(lpClassName, lpWindowName);
            if (gameHandle == IntPtr.Zero)
            {
                throw new ArgumentException("DayZ is not running.");
            }
            SetForegroundWindow(gameHandle);
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}