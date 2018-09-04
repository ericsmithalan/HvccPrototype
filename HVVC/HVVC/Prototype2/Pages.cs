using System.Collections.Generic;
using System.Windows.Controls;

namespace HVCC.Prototype2
{
    internal class Pages
    {
        public List<ControlBase> Windows;
        public List<ControlBase> Dialogs;
        public List<Control> Setup;
        public List<ControlBase> InfoPaneErrorPages;
        public List<UserControl> AllPages;

        private void GetPagesFullyRendered()
        {
            AllPages = new List<UserControl>();
            foreach (ControlBase ctl in Windows)
            {
                Prototype2.WindowMaster wm = new WindowMaster();
                wm.WindowContentControl = ctl;
                wm.IsDialog = ctl.IsDialog;
                wm.IsDevicesMenusShown = ctl.IsMenusVisible;
                wm.ToolTip = ctl.WindowName;
                AllPages.Add(wm);
            }

            foreach (ControlBase ctl in Dialogs)
            {
                Prototype2.WindowMaster wm = new WindowMaster();
                wm.WindowContentControl = ctl;
                wm.IsDialog = ctl.IsDialog;
                wm.IsDevicesMenusShown = ctl.IsMenusVisible;
                wm.ToolTip = ctl.WindowName;
                AllPages.Add(wm);
            }
            foreach (ControlBase ctl in InfoPaneErrorPages)
            {
                Prototype2.WindowMaster wm = new WindowMaster();
                wm.WindowContentControl = ctl;
                wm.IsDialog = ctl.IsDialog;
                wm.IsDevicesMenusShown = ctl.IsMenusVisible;
                wm.ToolTip = ctl.WindowName;
                AllPages.Add(wm);
            }
        }

        public Pages()
        {
            //CollectionContainer
            //ContainerVisual

            //Dictionary
            Windows = new List<ControlBase>();
            Windows.Add(new HVCC.Prototype2.AddDevice());
            Windows.Add(new HVCC.Prototype2.DevicesDetected());
            Windows.Add(new HVCC.Prototype2.SelectFromList());
            Windows.Add(new HVCC.Prototype2.InstallingDevice());
            Windows.Add(new HVCC.Prototype2.DownloadingXML());
            Windows.Add(new HVCC.Prototype2.Upgrade());
            Windows.Add(new HVCC.Prototype2.ErrorDeviceDriverDownload());
            Windows.Add(new HVCC.Prototype2.ErrorDeviceInstallation());
            Windows.Add(new HVCC.Prototype2.ErrorDeviceListDownload());

            InfoPaneErrorPages = new List<ControlBase>();
            InfoPaneErrorPages.Add(new HVCC.Prototype2.Upload());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.MultipleRecordPicker());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.Uploading());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.UploadingAlreadyInProgress());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.UploadComplete());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.NoAccount());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.NoPermission());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.DeviceInstalledNoNewData());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.DeviceInstalledNotConnected());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.SelectPersonForUpload());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.UploadCompleteError());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.UploadCompleteMultipleErrors());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.UploadingError());
            InfoPaneErrorPages.Add(new HVCC.Prototype2.UploadMultiple());

            Setup = new List<Control>();
            Setup.Add(new HVCC.Setup.ULA());
            Setup.Add(new HVCC.Setup.Installing());

            Dialogs = new List<ControlBase>();
            Dialogs.Add(new HVCC.Prototype2.UploadSettings());
            Dialogs.Add(new HVCC.Prototype2.Options());
            Dialogs.Add(new HVCC.Prototype2.DeviceInfo());
            Dialogs.Add(new HVCC.Prototype2.RemoveAccount());
            Dialogs.Add(new HVCC.Prototype2.RemovedAccount());
            Dialogs.Add(new HVCC.Prototype2.RemovingAccount());
            Dialogs.Add(new HVCC.Prototype2.Waiting());
            Dialogs.Add(new HVCC.Prototype2.RefreshingData());
            Dialogs.Add(new HVCC.Prototype2.Updates());
            Dialogs.Add(new HVCC.Prototype2.UpdatesFound());
            Dialogs.Add(new HVCC.Prototype2.About());
            Dialogs.Add(new HVCC.Prototype2.ConfirmQuit());
            Dialogs.Add(new HVCC.Prototype2.CIPDialog());
            Dialogs.Add(new HVCC.Prototype2.AddGadget());
            Dialogs.Add(new HVCC.Prototype2.SetupDevicePagePrompt());

            Dialogs.Add(new HVCC.Prototype2.FormatComplete());
            Dialogs.Add(new HVCC.Prototype2.FormatDevicePrompt());
            Dialogs.Add(new HVCC.Prototype2.FormatIncomplete());

            Dialogs.Add(new HVCC.Prototype2.DataMigrationPromtDialog());
            Dialogs.Add(new HVCC.Prototype2.DataMigrationSingleLiveIDialog());
            Dialogs.Add(new HVCC.Prototype2.DataMigrationLiveIdSelectionDialog());
            Dialogs.Add(new HVCC.Prototype2.DataMigrationStatusDialog());
            Dialogs.Add(new HVCC.Prototype2.ForcedExpirationWarning());
            Dialogs.Add(new HVCC.Prototype2.LanguageSwitchConfirmation());
            Dialogs.Add(new HVCC.Prototype2.VersionConflict());
            Dialogs.Add(new HVCC.Prototype2.RemoveAccountError());

            GetPagesFullyRendered();
        }
    }
}