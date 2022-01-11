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
            SelectNext();

            Selecting();
        }

        /// <summary>
        /// Перебор единиц
        /// </summary>
        private void Selecting()
        {
            Thread.Sleep(200);
            inputSimulator.Mouse.RightButtonDown();
            Thread.Sleep(4200);
            inputSimulator.Mouse.RightButtonUp();
        }

        /// <summary>
        /// Переход на другой порядок
        /// </summary>
        private void SelectNext()
        {
            for (int i = 0; i < 2; i++)
            {
                inputSimulator.Mouse.RightButtonDown();
                Thread.Sleep(100);
                inputSimulator.Mouse.RightButtonUp();
                Thread.Sleep(200);
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