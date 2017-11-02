﻿using DriverMon.ViewModels;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Zodiacon.WPF;

namespace DriverMon {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        internal static MainViewModel MainViewModel;

        public const string Title = "DriverMon";

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var ui = new UIServicesDefaults();
            MainViewModel = new MainViewModel(ui);
            var win = new MainWindow { DataContext = MainViewModel };
            win.Show();
            ui.MessageBoxService.SetOwner(win);

            //SfSkinManager.ApplyStylesOnApplication = true;
            //SfSkinManager.SetVisualStyle(win, VisualStyles.Metro);
        }

        protected override void OnExit(ExitEventArgs e) {
            base.OnExit(e);

            MainViewModel.Save();
            MainViewModel.Dispose();
        }
    }
}
