using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils;

namespace CustomContextMenu {
    public partial class Form1 : Form {
        const string aptDataFileName = @"..\..\Data\appointments.xml";
        const string resDataFileName = @"..\..\Data\resources.xml";
        
        public Form1() {
            InitializeComponent();
            schedulerControl1.Start = new DateTime(2010, 7, 05);
            schedulerControl1.DayView.TopRowTime = new TimeSpan(16, 0, 0);
            FillData();
        }

        #region FillData
        void FillData() {
            AppointmentCustomFieldMapping customNameMapping = new AppointmentCustomFieldMapping("CustomName", "CustomName");
            AppointmentCustomFieldMapping customStatusMapping = new AppointmentCustomFieldMapping("CustomStatus", "CustomStatus");
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customNameMapping);
            schedulerStorage1.Appointments.CustomFieldMappings.Add(customStatusMapping);
            FillResourceStorage(schedulerStorage1.Resources.Items, resDataFileName);
            FillAppointmentStorage(schedulerStorage1.Appointments.Items, aptDataFileName);
        }

        static Stream GetFileStream(string fileName) {
            return new StreamReader(fileName).BaseStream;
        }

        static void FillResourceStorage(ResourceCollection c, string fileName) {
            using (Stream stream = GetFileStream(fileName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }
        static void FillAppointmentStorage(AppointmentCollection c, string fileName) {
            using (Stream stream = GetFileStream(fileName)) {
                c.ReadXml(stream);
                stream.Close();
            }
        }
        #endregion

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            schedulerStorage1.Appointments.Items.WriteXml(aptDataFileName);
        }

        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            // Check if it's the default menu of a Scheduler.
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {

                // Disable the "New Recurring Appointment" menu item.
                e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringAppointment);

                // Hide the "New Recurring Event" menu item.
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);

                // Enable the "Go To Today" menu item.
                e.Menu.EnableMenuItem(SchedulerMenuItemId.GotoToday);

                // Find the "New Appointment" menu item and rename it.
                SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment, false);
                if (item != null) item.Caption = "&Rent a Car";

                // Find the "New All Day Event" menu item and rename it.
                item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent, false);
                if (item != null) item.Caption = "&Perform a Maintenance";

                SchedulerMenuItem myMenu = new SchedulerMenuItem("Click!", new EventHandler(MyMenuItemClick));
                myMenu.Image = imageList1.Images[0];
                e.Menu.Items.Add(myMenu);
            }
        }

        private void MyMenuItemClick(object sender, EventArgs e) {
            Appointment apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
            apt.Start = schedulerControl1.SelectedInterval.Start;
            apt.End = schedulerControl1.SelectedInterval.End;
            apt.Subject = "Fly to Iceland!";
            schedulerStorage1.Appointments.Add(apt);
            System.Diagnostics.Process.Start("http://www.icelandtouristboard.com/");            
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e) {
            // Fill in the Subject field for the newly created appointment.
            if (((SchedulerControl)sender).Storage.Appointments.IsNewAppointment(e.Appointment)) {
               if (e.Appointment.AllDay) {
                   e.Appointment.Subject = "Perform a maintenance";
               }
               else {
                   e.Appointment.Subject="Rent a car";
               };
           }
       }
   }
}