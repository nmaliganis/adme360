using System;
using System.Drawing;
using System.Windows.Forms;
using adme360.presenter.Utilities;
using adme360.suite.ui;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;

namespace adme360.suite.ui
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      SkinManager.EnableFormSkins();
      BonusSkins.Register();
      AppearanceObject.DefaultFont = new Font("Segoe UI", 8.25f);
      UserLookAndFeel.Default.SetSkinStyle("Metropolis Dark");
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue = "localhost";
      //ClientSettingsSingleton.InstanceSettings().IpAddressConfigValue = "137.116.232.108";
      Application.Run(new Main());
    }
  }
}
