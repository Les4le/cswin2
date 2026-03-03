using System.Runtime.InteropServices;

namespace ConsoleApp15
{
    internal class Program
    {
        // # 1

        //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        //static void Main()
        //{
        //    MessageBox(IntPtr.Zero, "Прізвище: Nekit", "Інформація", 0);
        //    MessageBox(IntPtr.Zero, "Ім'я: Nikita", "Інформація", 0);
        //    MessageBox(IntPtr.Zero, "Місто: Odesa", "Інформація", 0);
        //    MessageBox(IntPtr.Zero, "Спеціальність: Програміст 😎", "Інформація", 0);
        //}

        // # 2

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        const uint WM_SETTEXT = 0x000C;
        const uint WM_CLOSE = 0x0010;

        static void Main()
        {
            IntPtr hWnd = FindWindow(null, "MyTestWindow");

            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("Вікно не знайдено.");
                return;
            }

            Console.WriteLine("1 - Змінити заголовок");
            Console.WriteLine("2 - Закрити вікно");
            Console.WriteLine("3 - Ваш варіант (мінімізувати)");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть новий заголовок: ");
                    string newTitle = Console.ReadLine();
                    SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, newTitle);
                    break;

                case "2":
                    SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    break;

                case "3":
                    const uint WM_SYSCOMMAND = 0x0112;
                    const int SC_MINIMIZE = 0xF020;
                    SendMessage(hWnd, WM_SYSCOMMAND, (IntPtr)SC_MINIMIZE, IntPtr.Zero);
                    break;
            }
        }

        // # 3

        //[DllImport("kernel32.dll")]
        //public static extern bool Beep(int frequency, int duration);

        //[DllImport("user32.dll")]
        //public static extern bool MessageBeep(uint type);

        //static void Main()
        //{
        //    // Простий "ритм"
        //    Beep(800, 300);
        //    Thread.Sleep(200);

        //    Beep(1000, 300);
        //    Thread.Sleep(200);

        //    Beep(1200, 500);
        //    Thread.Sleep(500);

        //    MessageBeep(0); // стандартний системний звук
        //}

        // # 4

        //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childAfter, string className, string windowName);

        //[DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        //const uint WM_SETTEXT = 0x000C;

        //static void Main()
        //{
        //    IntPtr mainWindow = FindWindow(null, "StyleWindow");

        //    if (mainWindow == IntPtr.Zero)
        //    {
        //        Console.WriteLine("Вікно не знайдено.");
        //        return;
        //    }

        //    // Знайдемо TextBox (клас Edit)
        //    IntPtr textBox = FindWindowEx(mainWindow, IntPtr.Zero, "Edit", null);

        //    if (textBox != IntPtr.Zero)
        //    {
        //        SendMessage(textBox, WM_SETTEXT, IntPtr.Zero, "Текст змінено через API!");
        //    }

        //    Console.WriteLine("Стиль змінено.");
        //}
    }
}
