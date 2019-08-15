using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace McDoCalendarCreator
{
    public class WorkShift
    {
        public int ShiftPosition { get; private set; }

        public DateTime StartingShiftDate { get; private set; }
        public DateTime FinishingShiftDate { get; private set; }

        public string Location { get; private set; }

        public List<ShiftType> typeOfShift { get; private set; }

        public bool IsValidForCalendar { get; private set; } = true;
        

        public WorkShift(int IndexShift, string lineInMail)
        {
            ShiftPosition = IndexShift;
            typeOfShift = new List<ShiftType>();

            InitializeLineToData(lineInMail);
        }

        private void InitializeLineToData(string lineInMail)
        {
            Console.WriteLine("Converting shift #" + ShiftPosition + " of this week");
            //Tuesday       0
            //May           1
            //22            2
            //2018          3
            //5:00          4
            //PM            5
            //-             6
            //9:00          7
            //PM            8
            //lachenaie     9
            ///             10
            //BASE          11
            string[] differ = lineInMail.Split(' ');

            //Not removing in last
            for (int i = 0; i < differ.Length - 1; i++)
            {
                differ[i] = differ[i].Replace(",", string.Empty);
            }

            string dateTimeFormatStart  = differ[0] + " " + differ[1] + " " + differ[2] + " " + differ[3] + " " + differ[4] + " " + differ[5];
            string dateTimeFormatEnd    = differ[0] + " " + differ[1] + " " + differ[2] + " " + differ[3] + " " + differ[7] + " " + differ[8];
            

            string formatDate = "dddd' 'MMMM' 'd' 'yyyy' 'h:mm' 'tt";
            DateTime parsed;

            if (!DateTime.TryParseExact(dateTimeFormatStart, formatDate, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsed))
            {
                IsValidForCalendar = false;
                Console.WriteLine("Error while parsing StartingDateTime");
            }
            else StartingShiftDate = parsed;

            if (!DateTime.TryParseExact(dateTimeFormatEnd, formatDate, CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsed))
            {
                IsValidForCalendar = false;
                Console.WriteLine("Error while parsing FinishedDateTime");
            }
            else FinishingShiftDate = parsed;

            if (String.IsNullOrEmpty(differ[9])) IsValidForCalendar = false;
            Location = differ[9];

            string[] types = differ[11].Split(',');
            foreach (var type in types)
            {
                typeOfShift.Add(new ShiftType(type));
            }
        }

        public override string ToString()
        {
            string types = string.Empty;

            for (int i = 0; i < typeOfShift.Count; i++)
            {
                if (i > 0)
                    types += ";";

                types += typeOfShift[i];
            }

            return ShiftPosition + " - "
                + StartingShiftDate.ToString()
                + " - "
                + FinishingShiftDate.TimeOfDay.ToString("t")
                + " -> "
                + Location
                + " (" + types + ")";
        }
    }
}
