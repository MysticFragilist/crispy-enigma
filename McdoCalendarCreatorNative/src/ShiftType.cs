using System;
using System.Collections.Generic;
using System.Text;

namespace McDoCalendarCreator
{
    public class ShiftType
    {
        public string ShiftCode { get; private set; }

        public string ShiftTitle { get; private set; }
        public string ShiftDescription { get; private set; }

        public ShiftType(string shiftCode)
        {
            ShiftCode = shiftCode;

            InitializeDescription();
        }

        public void InitializeDescription()
        {
            switch (ShiftCode)
            {
                case "BASE":
                case "BAS2":
                    ShiftTitle = "Close Cuisine";
                    ShiftDescription = "L'employé du close de soir qui s'occupe de la fermeture du restaurant en cuisine.";
                    break;
                case "CU":
                case "CU1":
                case "CU2":
                case "CU3":
                case "CU4":
                    ShiftTitle = "Cuisine";
                    ShiftDescription = "Un shift en cuisine, le chiffre indique la position sur la carte de la cuisine.";
                    break;
                case "ECU":
                case "ECU1":
                case "ECU2":
                case "ECU3":
                case "ECU4":
                    ShiftTitle = "Formation Cuisine";
                    ShiftDescription = "Un shift de formation en cuisine. Le donner ou le recevoir.";
                    break;
                case "CA":
                case "CA1":
                case "CA2":
                case "CA3":
                case "CA4":
                    ShiftTitle = "Caisse";
                    ShiftDescription = "Un shift au caisse, le chiffre indique la position sur la carte de l'avant.";
                    break;
                case "ECA":
                case "ECA1":
                case "ECA2":
                case "ECA3":
                case "ECA4":
                    ShiftTitle = "Formation Caisse";
                    ShiftDescription = "Un shift de formation au caisse. Le donner ou le recevoir.";
                    break;
                case "SV":
                case "SV1":
                case "SV2":
                    ShiftTitle = "Service au volant";
                    ShiftDescription = "Un shift au comptoir du service au volant.";
                    break;
                default:
                    ShiftTitle = ShiftCode;
                    ShiftDescription = "Inconnu";
                    break;
            }
        }

        public override string ToString()
        {
            return ShiftCode + "/" + ShiftTitle;
        }
    }
}
