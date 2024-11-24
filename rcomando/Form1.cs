using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace rcomando
{
    public partial class Form1 : Form
    {

        private static IntPtr _hookID = IntPtr.Zero;
        private static int savedX = 0;
        private static int savedY = 0;
        private static bool isCapturingPosition = true;
        private static bool isCapturingRotation = true;

        public Form1()
        {
            InitializeComponent();
            _hookID = SetHook(HookCallback);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            base.OnFormClosing(e);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (var process = Process.GetCurrentProcess())
            using (var module = process.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(module.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Método de callback del hook
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && isCapturingPosition)
            {
                MSLLHOOKSTRUCT hookStruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
                if (IsMouseOverControl(hookStruct.pt.x, hookStruct.pt.y))
                {
                    return CallNextHookEx(_hookID, nCode, wParam, lParam);
                }
                // Detectar clic izquierdo para guardar posición
                if (wParam == (IntPtr)WM_LBUTTONDOWN)
                {
                    savedX = hookStruct.pt.x;
                    savedY = hookStruct.pt.y;

                    UpdateLabels(savedX, savedY);
                }
            }
            if (nCode >= 0 && isCapturingRotation)
            {
                // Detectar clic de la rueda del mouse para regresar a la posición guardada
                if (wParam == (IntPtr)WM_MBUTTONDOWN)
                {
                    SetCursorPos(savedX, savedY);

                    // Doble click papi :hot:
                    SimulateMouseClick();
                    SimulateMouseClick();

                    // Mover el cursor al centro de la pantalla
                    MoveCursorToCenter();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static bool IsMouseOverControl(int x, int y)
        {
            if (Application.OpenForms["Form1"] is Form1 form)
            {
                // Convertir coordenadas globales a coordenadas del formulario
                var clientPoint = form.PointToClient(new System.Drawing.Point(x, y));

                // Comprobar si el punto está sobre un control
                Control control = form.GetChildAtPoint(clientPoint);
                return control != null;
            }
            return false;
        }

        private static void SimulateMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private static void MoveCursorToCenter()
        {
            // Obtener las dimensiones de la pantalla principal
            int centerX = Screen.PrimaryScreen.Bounds.Width / 2;
            int centerY = Screen.PrimaryScreen.Bounds.Height / 2;

            // Mover el cursor al centro
            SetCursorPos(centerX, centerY);
        }

        // Método para actualizar los Labels (invocado desde el hook)
        private static void UpdateLabels(int x, int y)
        {
            if (Application.OpenForms["Form1"] is Form1 form)
            {
                form.Invoke((MethodInvoker)(() =>
                {
                    form.lbl_posX.Text = x.ToString();
                    form.lbl_poxY.Text = y.ToString();
                }));
            }
        }

        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_MBUTTONDOWN = 0x0207;

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private void btnAccion_Click(object sender, EventArgs e)
        {
            isCapturingRotation = !isCapturingRotation;
            this.btnAccion.Text = isCapturingRotation ? "Desactivar Accion" : "Activar Accion";
        }

        private void btnDefinir_Click(object sender, EventArgs e)
        {
            isCapturingPosition = !isCapturingPosition;
            this.btnDefinir.Text = isCapturingPosition ? "Desactivar Captura" : "Activar Captura";
        }

    }
}
