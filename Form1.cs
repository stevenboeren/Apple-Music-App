using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace Apple_Music
{

    public partial class Form1 : Form
    {


    public ChromiumWebBrowser browser;

        public void InitBrowser()
        {
            CefSettings settings = new CefSettings();

            settings.CachePath = System.IO.Path.Combine(Application.StartupPath, "Cache");
            settings.CefCommandLineArgs.Add("persist_session_cookies", "1");
            settings.CefCommandLineArgs.Add("enable-automatic-password-saving", "enable-automatic-password-saving");
            settings.CefCommandLineArgs.Add("enable-password-save-in-page-navigation", "enable-password-save-in-page-navigation");
            settings.CefCommandLineArgs.Add("enable-widevine-cdm", "1");
            settings.CefCommandLineArgs.Add("enable-npapi", "1");
            settings.CefCommandLineArgs.Add("allow-running-insecure-content", "1");
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.CefCommandLineArgs.Add("flag-switches-begin");
            settings.CefCommandLineArgs.Add("flag-switches-end");
            settings.CefCommandLineArgs.Add("origin-trial-disabled-features=SecurePaymentConfirmation");

            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

            //WebLink: chrome://version/ music.apple.com google.com
            browser = new ChromiumWebBrowser("music.apple.com");


            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill; 
            //browser.LoadingStateChanged += OnLoadingStateChanged;
        }

        public Form1()

        {
            InitializeComponent();

            InitBrowser();

        }
        private void browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                browser.ExecuteScriptAsync("alert('All Resources Have Loaded');");
            }
        }


       
        //private async void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        //{
        //    if (!args.IsLoading)
        //    {
        //        var response = await args.Browser.MainFrame.EvaluateScriptAsync("cefSharp.renderProcessId");
        //        if (response.Success)
        //        {
        //            var renderProcessId = (int)response.Result;
        //            var process = Process.GetProcessById(renderProcessId);
        //            var processName = process.ProcessName;
        //        }
        //    }
        //}
    }
}
