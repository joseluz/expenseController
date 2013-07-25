using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ExpenseController.UI
{
    public class TileControl
    {
        private static TileUpdater tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
        private static TileControl tileControl;

        private TileControl()
        {
            tileUpdater.EnableNotificationQueue(true);
        }

        public static TileControl GetInstance()
        {
            if (tileControl == null)
            {
                tileControl = new TileControl();
            }
            return tileControl;
        }



        public void AddTotalExpenseTile(string totalExpenseValue)
        {
            string totalExpenseTileXml = "<tile>"
                              + "<visual>"
                              + "<binding template='TileWideImageAndText02'>"
                              + "<image id='1' src='Images/WideSaveMoney.jpg'/>"
                              + "<text id='1'>Total Expenditure</text>"
                              + "<text id='2'>" + totalExpenseValue + "</text>"
                                + "</binding>"
                                + "<binding template='TileSquarePeekImageAndText04'>"
                                + "<image id='1' src='Images/SquareSaveMoney.jpg'/>"
                                + "<text id='1'>Total Expenditure</text>"
                                + "<text id='2'>" + totalExpenseValue + "</text>"
                                + "</binding>"
                                + "</visual>"
                                + "</tile>";

            XmlDocument tileDOM = new XmlDocument();

            tileDOM.LoadXml(totalExpenseTileXml.ToString());


            TileNotification tileNotification = new TileNotification(tileDOM);

            tileUpdater.Update(tileNotification);
        }

        public void AddExpense(string wideTileTemplate, string[] wideTileText, string wideImagePath, string squareTileTemplate, string[] squareTileText, string squareImagePath)
        {


            StringBuilder tileXmlString = new StringBuilder();
            tileXmlString.Append("<tile>");
            tileXmlString.Append("<visual>");
            tileXmlString.Append("<binding template='");
            tileXmlString.Append(wideTileTemplate);
            tileXmlString.Append("'>");
            tileXmlString.Append("<image id='1' src='");
            tileXmlString.Append(wideImagePath);
            tileXmlString.Append("'/>");
            for (int i = 0; i < wideTileText.Count(); i++)
            {
                tileXmlString.Append("<text id='" + (i + 1) + "'>");
                tileXmlString.Append(wideTileText[i]);
                tileXmlString.Append("</text>");
            }
            tileXmlString.Append("</binding>");
            tileXmlString.Append("<binding template='");
            tileXmlString.Append(squareTileTemplate);
            tileXmlString.Append("'>");
            tileXmlString.Append("<image id='1' src='");
            tileXmlString.Append(squareImagePath);
            tileXmlString.Append("'/>");
            for (int i = 0; i < squareTileText.Count(); i++)
            {
                tileXmlString.Append("<text id='" + (i + 1) + "'>");
                tileXmlString.Append(squareTileText[i]);
                tileXmlString.Append("</text>");
            }
            tileXmlString.Append("</binding>");
            tileXmlString.Append("</visual>");
            tileXmlString.Append("</tile>");


            XmlDocument tileDOM = new XmlDocument();

            tileDOM.LoadXml(tileXmlString.ToString());


            TileNotification tileNotification = new TileNotification(tileDOM);

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }


        public void ClearTiles()
        {
            tileUpdater.Clear();
            tileUpdater.EnableNotificationQueue(true);
        }
    }
}
