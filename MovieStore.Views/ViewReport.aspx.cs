using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class ViewReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ReportName = Request.QueryString["rpt"];
                string Orientation = Request.QueryString["o"];
                string strReportOutput = Request.QueryString["f"];
                string isNative = Request.QueryString["isNative"];
                string tabTitle = Request.QueryString["title"];
                string reportServerUrl = ConfigurationManager.AppSettings["ReportServerUrl"]; // Get report server URL from Web.config

                List<ReportParameter> paramList = new List<ReportParameter>();
                List<string> reportParameters = new List<string>();

                if (Request.QueryString["p"] != null)
                {
                    // Decode parameters
                    string encodedString = Request.QueryString["p"];

                    byte[] data = Convert.FromBase64String(encodedString);
                    string decodedString = Encoding.UTF8.GetString(data);

                    string[] c = decodedString.Split('|');

                    for (Int32 x = 0; x < c.Length; x++)
                    {
                        reportParameters.Add(c[x]);
                    }

                }

                foreach (string i in reportParameters)
                {
                    string[] sParam = i.Split('=');

                    ReportParameter prm = new ReportParameter(sParam[0], sParam[1]);
                    paramList.Add(prm);
                }

                rptViewer.ShowParameterPrompts = false;
                rptViewer.ServerReport.ReportServerUrl = new Uri(reportServerUrl);
                rptViewer.ServerReport.ReportPath = "/Reports/" + ReportName;
                rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                rptViewer.ServerReport.SetParameters(paramList);
                rptViewer.SizeToReportContent = true;
                rptViewer.ServerReport.Refresh();
                Response.ClearContent();
            }
        }
    }
}