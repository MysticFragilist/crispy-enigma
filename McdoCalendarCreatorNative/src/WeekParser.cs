using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;

namespace McDoCalendarCreator
{
    public class WeekParser
    {
        public string EmpName { get; private set; }
        public List<WorkShift> weekShifts { get; set; }
        private string EntireMailBody;

        private Outlook.Application thisOutlookApp;
        private Thread threadParser;

        public WeekParser(Outlook.Application outlookApp, string mailBody)
        {
            thisOutlookApp = outlookApp;
            EntireMailBody = mailBody;

            threadParser = new Thread(this.Start);
            threadParser.Start();
        }

        /// <summary>
        /// Inside the thread
        /// </summary>
        public void Start()
        {
            weekShifts = new List<WorkShift>();
            InitializeOutlookCalendar();

            var work = FindWorkingShift(EntireMailBody);

            for (int i = 0; i < work.Count; i++)
            {
                var shift = new WorkShift(i + 1, work[i]);
                weekShifts.Add(shift);

                Console.WriteLine(shift);
            }

            weekShifts.ForEach(x => CreateAppointment(x));
            //ShowWeekDay();
        }

        private void InitializeOutlookCalendar()
        {

        }

        private List<string> FindWorkingShift(string mailBody)
        {
            List<string> lineWorkShift = new List<string>();

            var mailSplit = mailBody.Split('\n');
            for (int i = 0; i < mailSplit.Length; i++) mailSplit[i] = mailSplit[i].TrimEnd('\r');
            
            int indexStart = -1;
            int indexEnd = -1;

            for (int i = 0; i < mailSplit.Length; i++)
            {
                if (mailSplit[i].Contains("Cher/Chère "))
                {
                    EmpName = mailSplit[i].Split(' ')[1].ToLowerInvariant();
                }
                if (mailSplit[i].Contains("Here is your schedule for the week of "))
                {
                    indexStart = i + 2;
                }
                if (mailSplit[i].Contains("You have a total of "))
                {
                    indexEnd = i - 2;
                }
            }

            if (indexStart >= indexEnd) return lineWorkShift;

            for (int i = indexStart; i <= indexEnd; i++)
            {
                lineWorkShift.Add(mailSplit[i]);
            }
            return lineWorkShift;
        }

        private void CreateAppointment(WorkShift workShift)
        {
            if (!workShift.IsValidForCalendar)
            {
                Console.WriteLine("Des erreurs ont été trouvé lors du parsing des shifts. Impossible de créer un rendez-vous pour #" + workShift.ShiftPosition);
                return;
            }

            Outlook.MAPIFolder primaryCalendar = (Outlook.MAPIFolder)
                thisOutlookApp.ActiveExplorer().Session.GetDefaultFolder
                (OlDefaultFolders.olFolderCalendar);

            Outlook.MAPIFolder familialCalendar = null;
            foreach (Outlook.MAPIFolder personalCalendar in primaryCalendar.Folders)
            {
                if (personalCalendar.Name == "familial")
                {
                    familialCalendar = personalCalendar;
                    break;
                }
            }

            if (familialCalendar == null)
            {
                Console.WriteLine("Impossible de créer un rendez-vous pour le shift #" + workShift.ShiftPosition + " : Calendrier Familial non trouvé.");
                return;
            }

            Outlook.AppointmentItem newAppointment = (Outlook.AppointmentItem) familialCalendar.Items.Add(OlItemType.olAppointmentItem);

            newAppointment.Start = workShift.StartingShiftDate;
            newAppointment.End = workShift.FinishingShiftDate;
            newAppointment.Location = workShift.Location;
            newAppointment.Body = string.Empty;
            foreach (var type in workShift.typeOfShift) 
            {
                newAppointment.Body += "Shift de " + type.ShiftTitle + " : " + type.ShiftDescription + "\n";
            }

            newAppointment.AllDayEvent = false;
            newAppointment.Subject = "Travail McDonald's " + EmpName;

            Outlook.Items calendarItems = (Outlook.Items)familialCalendar.Items;
            
            newAppointment.Save();

            Console.WriteLine("Shift " + workShift.ShiftPosition + " enregistré avec succès!");
        }


        private void ShowWeekDay()
        {
            foreach (var item in weekShifts)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
