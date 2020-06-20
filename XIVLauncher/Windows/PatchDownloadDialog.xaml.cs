﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Serilog;
using XIVLauncher.Http;
using XIVLauncher.Windows.ViewModel;

namespace XIVLauncher.Windows
{
    /// <summary>
    /// Interaction logic for PatchDownloadDialog.xaml
    /// </summary>
    public partial class PatchDownloadDialog : Window
    {
        public PatchDownloadDialogViewModel ViewModel => DataContext as PatchDownloadDialogViewModel;

        public PatchDownloadDialog(bool isBoot)
        {
            InitializeComponent();
            this.DataContext = new PatchDownloadDialogViewModel();
        }

        public void SetGeneralProgress(int curr, int final)
        {
            PatchProgressText.Text = string.Format(ViewModel.PatchGeneralStatusLoc,
                $"{curr}/{final}");

            InstallingText.Text = string.Format(ViewModel.PatchInstallingFormattedLoc, curr);
        }

        public void SetLeft(long left, long rate)
        {
            BytesLeftText.Text = string.Format(ViewModel.PatchEtaLoc, Util.BytesToString(left), Util.BytesToString(rate));
        }

        public void SetPatchProgress(int index, string patchName, double pct)
        {
            switch (index)
            {
                case 0:
                    SetProgressBar1Progress(patchName, pct);
                    break;
                case 1:
                    SetProgressBar2Progress(patchName, pct);
                    break;
                case 2:
                    SetProgressBar3Progress(patchName, pct);
                    break;
                case 3:
                    SetProgressBar4Progress(patchName, pct);
                    break;
            }
        }

        public void SetProgressBar1Progress(string patchName, double percentage)
        {
            Progress1.Value = percentage;
            Progress1Text.Text = patchName;
        }

        public void SetProgressBar2Progress(string patchName, double percentage)
        {
            Progress2.Value = percentage;
            Progress2Text.Text = patchName;
        }

        public void SetProgressBar3Progress(string patchName, double percentage)
        {
            Progress3.Value = percentage;
            Progress3Text.Text = patchName;
        }

        public void SetProgressBar4Progress(string patchName, double percentage)
        {
            Progress4.Value = percentage;
            Progress4Text.Text = patchName;
        }

        public void SetDownloadDone()
        {
            Progress1.Visibility = Visibility.Collapsed;
            Progress1Text.Visibility = Visibility.Collapsed;

            Progress2.Visibility = Visibility.Collapsed;
            Progress2Text.Visibility = Visibility.Collapsed;

            Progress3.Visibility = Visibility.Collapsed;
            Progress3Text.Visibility = Visibility.Collapsed;

            Progress4.Visibility = Visibility.Collapsed;
            Progress4Text.Visibility = Visibility.Collapsed;
        }
    }
}
