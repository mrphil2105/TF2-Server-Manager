using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ServerManager.Core
{
    public class ServerRunner : IDisposable
    {
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA = 0x2;
        private const int SW_RESTORE = 9;

        private readonly Server _server;
        private Process _process;

        public event EventHandler<EventArgs> Stopped;

        public ServerRunner(Server server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            _server = server;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        // We want to recover the process if the program was closed when the server was running.
        public bool TryRecoverProcess(out bool consoleVisible)
        {
            ThrowIfDisposed();
            var processes = Process.GetProcessesByName("srcds");

            foreach (var process in processes)
            {
                // Make sure we are finding SRCDS of this server only.
                if (process.MainModule.FileName == _server.SRCDSPath)
                {
                    _process = process;
                    _process.EnableRaisingEvents = true;
                    _process.Exited += OnProcessExited;

                    consoleVisible = GetConsoleVisible();
                    return true;
                }
            }

            consoleVisible = false;
            return false;
        }

        public void StartProcess()
        {
            ThrowIfDisposed();

            _process?.Dispose();
            _process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = _server.SRCDSPath,
                    Arguments = $"-console -game tf -strictportbind -nohltv -ip {_server.Address} -port {_server.Port} +clientport {_server.ClientPort} +map {_server.Map} +maxplayers {_server.MaxPlayers} +hostname \"{_server.Name}\"",
                    WindowStyle = Program.Settings.General.HideConsole ? ProcessWindowStyle.Minimized : ProcessWindowStyle.Normal
                },
                EnableRaisingEvents = true
            };
            _process.Exited += OnProcessExited;
            _process.Start();

            if (Program.Settings.General.HideConsole)
            {
                // Hiding the window when the process has just been started does not work, so we try hiding it every 50 ms until it is hidden, as a dirty fix.
                while (_process.MainWindowHandle == IntPtr.Zero || GetConsoleVisible())
                {
                    Thread.Sleep(50);
                    _process.Refresh();
                    HideConsole();
                }
            }
        }

        public void KillProcess()
        {
            ThrowIfDisposed();
            _process.Kill();
        }

        // Actually hiding the window makes the handle unavailable, so we set the transparency instead.
        public void HideConsole()
        {
            ThrowIfDisposed();

            // Get the window style and apply the layered style, to support transparency.
            int windowStyle = GetWindowLong(_process.MainWindowHandle, GWL_EXSTYLE) | WS_EX_LAYERED;
            SetWindowLong(_process.MainWindowHandle, GWL_EXSTYLE, windowStyle);
            // Set the transparency to 0, fully transparent.
            SetLayeredWindowAttributes(_process.MainWindowHandle, 0, 0, LWA_ALPHA);
        }

        public void ShowConsole()
        {
            ThrowIfDisposed();

            // Set the transparency to 255, fully visible.
            SetLayeredWindowAttributes(_process.MainWindowHandle, 0, 255, LWA_ALPHA);
            // Get the window style and remove the layered style, to disable transparency.
            int windowStyle = GetWindowLong(_process.MainWindowHandle, GWL_EXSTYLE) & ~WS_EX_LAYERED;
            SetWindowLong(_process.MainWindowHandle, GWL_EXSTYLE, windowStyle);

            ShowWindow(_process.MainWindowHandle, SW_RESTORE);
            SetForegroundWindow(_process.MainWindowHandle);
        }

        private bool GetConsoleVisible()
        {
            // To determine if the console is visible, we check if the layered style is applied.
            return (GetWindowLong(_process.MainWindowHandle, GWL_EXSTYLE) & WS_EX_LAYERED) == 0;
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            Stopped?.Invoke(this, EventArgs.Empty);
        }

        private void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _process?.Dispose();
            _isDisposed = true;
        }
    }
}
