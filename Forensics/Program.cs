using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Forensics.Tools;
using Iyond.Utility;

namespace Forensics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            SQLiteHelper.SetConnectionString(System.Environment.CurrentDirectory + "\\DataBase.db", "", 3);
            /*LoginForm Log = new LoginForm();

            Log.ShowDialog();

            //if (Log.DialogResult == DialogResult.OK)
            {

                Application.Run(new MainForm());
            }*/
            //Application.Run(new AutoUpdate());
            AutoUpdater au = new AutoUpdater();
            au.Update();
            LoginForm Log = new LoginForm();
            Log.ShowDialog();
            if (StateInfo.IsLogin == true)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
