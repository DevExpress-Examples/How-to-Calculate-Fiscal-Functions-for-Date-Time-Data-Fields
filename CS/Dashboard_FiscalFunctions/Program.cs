using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Data.Filtering;
using System.Globalization;

namespace Dashboard_FiscalFunctions {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            CriteriaOperator.RegisterCustomFunction(new GetFiscalYearFunction(1, 10));
            CriteriaOperator.RegisterCustomFunction(new GetFiscalQuarterFunction(1, 10));
            CriteriaOperator.RegisterCustomFunction(new GetFiscalWeekOfYearFunction(1, 10, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
            Application.Run(new Form1());
            
        }
    }
}
