using System.Web.UI;

namespace UI_Gestion.Code
{
    public class MasterBasePage : MasterPage
    {
        public string GetStringConnection
        {
            get
            {
                return (Session["GetStringConnection"] == null) ? string.Empty : Session["GetStringConnection"].ToString();
            }
            set
            {
                Session["GetStringConnection"] = value;
            }
        }

        public string GetUserName
        {
            get
            {
                return (Session["GetUserName"] == null) ? string.Empty : Session["GetUserName"].ToString();
            }
            set
            {
                Session["GetUserName"] = value;
            }
        }

        public void CleanSessionVariable()
        {
            Session.Remove("GetStringConnection");
            Session.Remove("GetUserName");
        }
    }
}