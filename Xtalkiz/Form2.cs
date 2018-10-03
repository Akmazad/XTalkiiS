using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using SHDocVw;
using System.Net;
using System.Collections;
using System.Threading;

namespace Xtalkiz
{
    public partial class SplashForm : Form
    {
        //Delegate for cross thread call to close
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static SplashForm splashForm;

        public static BindingList<KeyValuePair<String, String>> allOrganisms = new BindingList<KeyValuePair<string, string>>();
        static RestImpl ri = new RestImpl();
        
        public SplashForm()
        {
            InitializeComponent();
        }

        private void InitialLoadingForm_Load(object sender, EventArgs e)
        {

        }
        public static BindingList<KeyValuePair<string, string>> GetAllOrganisms()
        {
            BindingList<KeyValuePair<string, string>> retDic = new BindingList<KeyValuePair<string, string>>();
            IDictionary<String, String> paramList = new Dictionary<String, String>();
            string target_url = "http://rest.kegg.jp/list/organism";
            HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);

            string response = ri.GetResponse(webRequest);

            #region parse the response
            string[] lines = response.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (String line in lines)
            {
                string[] parts = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string organismPrefixID = parts[0].Trim();
                string organismPrefix = parts[1].Trim();
                string organismName = parts[2].Trim();
                retDic.Add(new KeyValuePair<string, string>(organismPrefix, organismName));
            }
            #endregion

            return retDic;
        }

        public static void ShowSplashScreen()
        {
            // Make sure it is only launched once.

            if (splashForm != null)
                return;

            //this.Close();
            Thread thread = new Thread(new ThreadStart(SplashForm.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        static public void loadAllorganism()
        {
            try
            {
                #region Get all the organism names
                allOrganisms = GetAllOrganisms();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Organism loading failed", "Error loading data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        static private void ShowForm()
        {
            splashForm = new SplashForm();
            Application.Run(splashForm);
        }
        static public void CloseForm()
        {
            splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            splashForm.Close();
            splashForm = null;
        }
    }
}
