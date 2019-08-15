using System;
using System.Collections.Generic;
using System.Text;

using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;

namespace McDoCalendarCreator
{
    public class OutlookScraper
    {
        private const string SEARCH_MAIL_TEXT = "Ton horaire pour la semaine prochaine";

        private Queue<WeekParser> ParsingTaskExecuting;


        private Outlook.Application outlookApp;
        private Outlook._NameSpace outlookNS;
        private Outlook.MAPIFolder inboxFolder;
        private Outlook.Items items;

        public OutlookScraper()
        {
            ParsingTaskExecuting = new Queue<WeekParser>();
            Initialize();

            
        }

        private void Initialize()
        {
            outlookApp = new Outlook.Application();

            outlookNS = outlookApp.GetNamespace("MAPI");
            inboxFolder = outlookNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

            items = (Outlook.Items) inboxFolder.Items;
            items.ItemAddEvent +=
                new Outlook.Items_ItemAddEventHandler(items_ItemAdd);
        }

        /// <summary>
        /// Called when a new item has entered the stack
        /// </summary>
        /// <param name="Item"></param>
        private void items_ItemAdd(object Item)
        {
            Outlook.MailItem mail = (Outlook.MailItem)Item;
            if (Item != null)
            {
                if (mail.MessageClass == "IPM.Note" &&
                           mail.Subject.ToUpper().Contains(SEARCH_MAIL_TEXT.ToUpper()))
                {
                    ParsingTaskExecuting.Enqueue(new WeekParser(outlookApp, mail.Body));
                }
            }
        }
    }
}
