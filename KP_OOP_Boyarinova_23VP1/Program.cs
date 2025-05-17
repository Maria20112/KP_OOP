namespace KP_OOP_Boyarinova_23VP1
{
    internal static class Program
    {
        /// <summary>
        ///  Точка входа
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}