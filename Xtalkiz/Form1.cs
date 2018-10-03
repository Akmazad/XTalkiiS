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

namespace Xtalkiz
{
    public partial class Form1 : Form
    {
        #region Global variables
        //Dictionary<String, String> allOrganisms = new Dictionary<string, string>();
        //Dictionary<String, String> allPathways = new Dictionary<string, string>();

        BindingList<KeyValuePair<String, String>> allPathwaysA = new BindingList<KeyValuePair<string, string>>();
        BindingList<KeyValuePair<String, String>> allPathwaysB = new BindingList<KeyValuePair<string, string>>();


        BindingList<KeyValuePair<String, String>> lb1_list = new BindingList<KeyValuePair<string, string>>();
        BindingList<KeyValuePair<String, String>> lb2_list = new BindingList<KeyValuePair<string, string>>();

        RestImpl ri = new RestImpl();

        string outputDirectory = "";
        string outputText_PathwayGenes = "";
        string outputText_XTtalks = "";

        string organism_A_ID = "";
        string organism_B_ID = "";

        NameValueCollection gsPair = new NameValueCollection();
        NameValueCollection KEGGpathways = new NameValueCollection();

        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                #region fill the combo box with all the organisms

                comBoxOrganismA.DataSource = new BindingSource(SplashForm.allOrganisms, null);
                comBoxOrganismA.DisplayMember = "Value";
                comBoxOrganismA.ValueMember = "Key";

                comBoxOrganismB.DataSource = new BindingSource(SplashForm.allOrganisms, null);
                comBoxOrganismB.DisplayMember = "Value";
                comBoxOrganismB.ValueMember = "Key";

                toolStripStatusLabel1.Text = "Organisms have been Loaded Successfully!";
                #endregion
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Organism loading failed: " + ex.Message;
            }
        }
        private void comBoxOrganism_A_SelectionChangeCommitted(object sender, EventArgs e)
        {
            resetAll();

            String organism_A_Name = ((ComboBox)sender).SelectedText.ToString();
            String organism_A_Prefix = ((ComboBox)sender).SelectedValue.ToString();

            try
            {
                #region get all the pathways of the selected organism and pathway ID
                organism_A_ID = organism_A_Prefix;
                allPathwaysA = GetAllPathways4anOrganism(organism_A_Prefix);
                lblChosePathwayFrom_A.Text = "Choose from " + allPathwaysA.Count + " pathway(s)";
                lblSelectedPathways_A.Text = "Selected Pathway(s): 0";
                dataGridView1.DataSource = null;
                dataGridView1.Visible = false;
                #endregion

                #region initialize and populate pathway listboxes
                lbxAllA.DataSource = null;
                lboxSelected_A.DataSource = null;
                lbxAllA.Items.Clear();
                lboxSelected_A.Items.Clear();

                lbxAllA.DataSource = new BindingSource(allPathwaysA, null);
                lbxAllA.DisplayMember = "Value";
                lbxAllA.ValueMember = "Key";
                toolStripStatusLabel1.Text = "Pathways have been Loaded Successfully!";
                #endregion
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Pathway loading failed: " + ex.Message;
            }

            //MessageBox.Show(organismPrefix);
        }

        private void resetAll()
        {
            this.Lbl_KeggPathwayGenes.Visible = false;
            this.Lbl_KeggPathwayCrosstalks.Visible = false;
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Visible = false;
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Visible = false;
        }

        private void comBoxOrganism_B_SelectionChangeCommitted(object sender, EventArgs e)
        {
            resetAll();

            String organism_B_Name = ((ComboBox)sender).SelectedText.ToString();
            String organism_B_Prefix = ((ComboBox)sender).SelectedValue.ToString();

            try
            {
                #region get all the pathways of the selected organism and pathway ID
                organism_B_ID = organism_B_Prefix;
                allPathwaysB = GetAllPathways4anOrganism(organism_B_Prefix);
                lblChosePathwayFrom_B.Text = "Choose from " + allPathwaysB.Count + " pathway(s)";
                lblSelectedPathways_B.Text = "Selected Pathway(s): 0";
                dataGridView1.DataSource = null;
                dataGridView1.Visible = false;
                #endregion

                #region initialize and populate pathway listboxes
                lbxAllB.DataSource = null;
                lboxSelected_B.DataSource = null;
                lbxAllB.Items.Clear();
                lboxSelected_B.Items.Clear();

                lbxAllB.DataSource = new BindingSource(allPathwaysB, null);
                lbxAllB.DisplayMember = "Value";
                lbxAllB.ValueMember = "Key";
                toolStripStatusLabel1.Text = "Pathways have been Loaded Successfully!";
                #endregion
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Pathway loading failed: " + ex.Message;
            }
        }
        private BindingList<KeyValuePair<string, string>> GetAllPathways4anOrganism(string organismPrefix)
        {

            BindingList<KeyValuePair<string, string>> retDic = new BindingList<KeyValuePair<string, string>>();
            IDictionary<String, String> paramList = new Dictionary<String, String>();
            string target_url = "http://rest.kegg.jp/list/pathway/" + organismPrefix;
            HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);

            string response = ri.GetResponse(webRequest);

            #region parse the response
            string[] lines = response.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (String line in lines)
            {
                string[] parts = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string pathwayID = parts[0].Trim().Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                string pathwayName = parts[1].Trim().Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0].Trim();

                retDic.Add(new KeyValuePair<string, string>(pathwayID, pathwayName));
            }
            #endregion

            return retDic;
        }
        private void btnGetGenes_Click(object sender, EventArgs e)
        {
            #region retrieve kegg pathway genes [same as KPGminer]
            
            outputText_PathwayGenes = "";
            outputText_XTtalks = "";

            DataTable dTable = new DataTable();
            dTable.Columns.Add("Pathway Name", typeof(string));
            dTable.Columns.Add("KEGG ID", typeof(string));
            dTable.Columns.Add("Constituent Genes", typeof(string));

            if (lboxSelected_A.Items.Count > 0 || lboxSelected_B.Items.Count > 0)
                toolStripStatusLabel1.Text = "XTalkiis is retrieving Pathway genes from KEGG and finding pathway Cross-talks. This might take a few minutes. Please wait.!!";

            #region for A
            if (lboxSelected_A.Items.Count > 0)
            {
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                #region get Pathway ids to make REST queries
                BindingSource bsRight = (BindingSource)lboxSelected_A.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                IEnumerator<KeyValuePair<string, string>> enumElem = bsRList.GetEnumerator();
                #endregion

                while (enumElem.MoveNext())
                {
                    KeyValuePair<string, string> hsa = enumElem.Current;
                    /* make web-request and get response*/
                    string target_url = "http://rest.kegg.jp/get/" + hsa.Key;
                    HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);

                    string response = ri.GetResponse(webRequest);

                    #region parse it and save it
                    string line = "";


                    /* parse the pathway name */
                    string[] stall = response.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    //string stt = stall[1].Replace("NAME        ", "").Replace(" - Homo sapiens (human)", "").Replace(" ", "_").ToUpper();
                    string pathwayName = hsa.Value;
                    //string dummyText = "dummytext";
                    string KEGG_ID = hsa.Key;
                    line += pathwayName + "\t" + KEGG_ID + "\t";

                    /* parse gene names */
                    bool start = false;
                    string geneNames = "";
                    List<LinkLabel> lLinkLabels = new List<LinkLabel>();

                    for (int i = 2; i < stall.Count(); i++)
                    {
                        if (!start && stall[i].StartsWith("GENE"))
                        {
                            string temp = stall[i].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string[] tempAll = temp.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            string geneName = tempAll[tempAll.Count() - 1];
                            LinkLabel tempLLabel = new LinkLabel();
                            tempLLabel.Text = geneName;
                            tempLLabel.LinkClicked += TempLLabel_LinkClicked;
                            lLinkLabels.Add(tempLLabel);

                            geneNames += geneName + ", ";
                            line += geneName + "\t";
                            start = true;
                        }
                        if (start && stall[i].StartsWith("            "))
                        {
                            string temp = stall[i].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string[] tempAll = temp.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            string geneName = tempAll[tempAll.Count() - 1];
                            geneNames += geneName + ", ";

                            LinkLabel tempLLabel = new LinkLabel();
                            tempLLabel.Text = geneName;
                            tempLLabel.LinkClicked += TempLLabel_LinkClicked;
                            lLinkLabels.Add(tempLLabel);

                            line += geneName + "\t";
                        }
                        else if (start && !stall[i].StartsWith("GENE"))
                            break;
                    }
                    // put in keeg pathway dictionary [for crosstalk analysis]
                    KEGGpathways.Add(hsa.Value + "++" + KEGG_ID, geneNames);
                    // put in the datagrid [for display]
                    dTable.Rows.Add(hsa.Value, KEGG_ID, geneNames);
                    outputText_PathwayGenes += line + "\n";
                    #endregion
                }
                #region output texts               
                #endregion
            }
            #endregion

            #region for B
            if (lboxSelected_B.Items.Count > 0)
            {
                IDictionary<String, String> paramList = new Dictionary<String, String>();

                #region get Pathway ids to make REST queries
                //List<KeyValuePair<string, string>> qPathways = new List<KeyValuePair<string, string>>();
                //foreach (var elem in lboxSelected.SelectedItems)
                //    qPathways.Add(((KeyValuePair<string, string>)elem));
                BindingSource bsRight = (BindingSource)lboxSelected_B.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                IEnumerator<KeyValuePair<string, string>> enumElem = bsRList.GetEnumerator();
                #endregion


                while (enumElem.MoveNext())
                {
                    KeyValuePair<string, string> hsa = enumElem.Current;
                    /* make web-request and get response*/
                    string target_url = "http://rest.kegg.jp/get/" + hsa.Key;
                    HttpWebRequest webRequest = ri.CreateRequest(target_url, paramList);

                    string response = ri.GetResponse(webRequest);

                    #region parse it and save it
                    string line = "";


                    /* parse the pathway name */
                    string[] stall = response.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    //string stt = stall[1].Replace("NAME        ", "").Replace(" - Homo sapiens (human)", "").Replace(" ", "_").ToUpper();
                    string pathwayName = hsa.Value;
                    //string dummyText = "dummytext";
                    string KEGG_ID = hsa.Key;
                    line += pathwayName + "\t" + KEGG_ID + "\t";

                    /* parse gene names */
                    bool start = false;
                    string geneNames = "";
                    List<LinkLabel> lLinkLabels = new List<LinkLabel>();

                    for (int i = 2; i < stall.Count(); i++)
                    {
                        if (!start && stall[i].StartsWith("GENE"))
                        {
                            string temp = stall[i].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string[] tempAll = temp.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            string geneName = tempAll[tempAll.Count() - 1];
                            LinkLabel tempLLabel = new LinkLabel();
                            tempLLabel.Text = geneName;
                            tempLLabel.LinkClicked += TempLLabel_LinkClicked;
                            lLinkLabels.Add(tempLLabel);

                            geneNames += geneName + ", ";
                            line += geneName + "\t";
                            start = true;
                        }
                        if (start && stall[i].StartsWith("            "))
                        {
                            string temp = stall[i].Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string[] tempAll = temp.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            string geneName = tempAll[tempAll.Count() - 1];
                            geneNames += geneName + ", ";

                            LinkLabel tempLLabel = new LinkLabel();
                            tempLLabel.Text = geneName;
                            tempLLabel.LinkClicked += TempLLabel_LinkClicked;
                            lLinkLabels.Add(tempLLabel);

                            line += geneName + "\t";
                        }
                        else if (start && !stall[i].StartsWith("GENE"))
                            break;
                    }
                    // put in keeg pathway dictionary [for crosstalk analysis]
                    KEGGpathways.Add(hsa.Value + "++" + KEGG_ID, geneNames);
                    // put in the datagrid [for display]
                    dTable.Rows.Add(hsa.Value, KEGG_ID, geneNames);
                    outputText_PathwayGenes += line + "\n";
                    #endregion


                }
                #region output texts                
                #endregion
            }
            #endregion

            if (lboxSelected_A.Items.Count > 0 || lboxSelected_B.Items.Count > 0)
            {
                this.Lbl_KeggPathwayGenes.Visible = true;
                dataGridView1.DataSource = new BindingSource(dTable, null);
                dataGridView1.Visible = Enabled;
                toolStripStatusLabel1.Text = "Pathway genes are downloaded successfully !!";
            }
            #endregion

            #region 1.2 [in KEGG]
            DataTable dTable_Xtalks = new DataTable();
            dTable_Xtalks.Columns.Add("Pathway 1", typeof(string));
            dTable_Xtalks.Columns.Add("KEGG_ID 1", typeof(string));
            dTable_Xtalks.Columns.Add("Pathway 2", typeof(string));
            dTable_Xtalks.Columns.Add("KEGG_ID 2", typeof(string));
            dTable_Xtalks.Columns.Add("Cross-talk info", typeof(string));
            dTable_Xtalks.Columns.Add("Cross-talk Type", typeof(string));

            //TextWriter tw = new StreamWriter(generalFilePath + study + "_KEGG_CrossTalks_Pathway_pairs_new_2.csv");
            //TextWriter twww = new StreamWriter(generalFilePath + study + "_KEGG_CrossTalks_gs_pairs_new_2.csv");
            //TextWriter tw_1stV_type_I = new StreamWriter(generalFilePath + study + "_KEGG_EnrichmentType_I_1stOrder_V_structures_new_2.csv");
            //TextWriter tw_1stV_type_II = new StreamWriter(generalFilePath + study + "_KEGG_EnrichmentType_II_1stOrder_V_structures_PathPairs_new_2.csv");
            //TextWriter tw_1stV_type_III = new StreamWriter(generalFilePath + study + "_KEGG_EnrichmentType_III_1stOrder_V_structures_EnrichedPathway_new_2.csv");

            NameValueCollection kegg_result = new NameValueCollection();
            NameValueCollection kegg_gsPairinSamePathway = new NameValueCollection();

            foreach (string pair in gsPair.AllKeys)
            {
                string[] gs = pair.Split("::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < KEGGpathways.AllKeys.Count(); i++)
                {
                    string key1 = KEGGpathways.AllKeys[i];
                    string p1 = key1.Split("++".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)[0];
                    string p1_ID = key1.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];

                    string[] p1GS = KEGGpathways[key1].Replace(" ", "").Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    if (_isGeneExists(p1GS, gs[0]) && _isGeneExists(p1GS, gs[1]))
                    {
                        if ((kegg_gsPairinSamePathway[gs[0] + "::" + gs[1]] == null)
                            && (kegg_gsPairinSamePathway[gs[1] + "::" + gs[0]] == null))
                            kegg_gsPairinSamePathway.Add(gs[0] + "::" + gs[1], "");

                        continue;
                    }
                    else
                    {
                        for (int j = i + 1; j < KEGGpathways.AllKeys.Count(); j++)
                        {
                            string key2 = KEGGpathways.AllKeys[j];
                            string p2 = key2.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string p2_ID = key2.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];

                            string[] p2GS = KEGGpathways[key2].Replace(" ", "").Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                            if (_isGeneExists(p2GS, gs[0]) && _isGeneExists(p2GS, gs[1]))
                            {
                                if ((kegg_gsPairinSamePathway[gs[0] + "::" + gs[1]] == null)
                                    && (kegg_gsPairinSamePathway[gs[1] + "::" + gs[0]] == null))
                                    kegg_gsPairinSamePathway.Add(gs[0] + "::" + gs[1], "");

                                continue;
                            }
                            else if (_isGeneExists(p1GS, gs[0]) && _isGeneExists(p2GS, gs[1]))
                            {
                                if (kegg_result[gs[0] + "::" + gs[1]] == null && kegg_result[gs[1] + "::" + gs[0]] == null)
                                    kegg_result.Add(gs[0] + "::" + gs[1], gsPair[pair]);

                                //save Type-I cross-talk
                                dTable_Xtalks.Rows.Add(p1, p1_ID, p2, p2_ID, gs[0] + "::" + gs[1], "Type-I");
                                outputText_XTtalks += p1 + ", " + p1_ID + ", " + p2 + ", " + p2_ID + ", " + gs[0] + "::" + gs[1] + ", " + "Type-I" + "\n";

                            }
                            else if (_isGeneExists(p2GS, gs[0]) && _isGeneExists(p1GS, gs[1]))
                            {
                                if (kegg_result[gs[0] + "::" + gs[1]] == null && kegg_result[gs[1] + "::" + gs[0]] == null)
                                    kegg_result.Add(gs[0] + "::" + gs[1], gsPair[pair]);

                                //save Type-I cross-talk
                                dTable_Xtalks.Rows.Add(p1, p1_ID, p2, p2_ID, gs[0] + "::" + gs[1], "Type-I");
                                outputText_XTtalks += p1 + ", " + p1_ID + ", " + p2 + ", " + p2_ID + ", " + gs[0] + "::" + gs[1] + ", " + "Type-I" + "\n";

                            }
                        }
                    }
                }

            }
          
            

            #region Find and Print Type II and III
            NameValueCollection _1stV_type_II = new NameValueCollection();
            //NameValueCollection _1stV_type_III = new NameValueCollection();

            for (int i = 0; i < kegg_gsPairinSamePathway.AllKeys.Count(); i++)
            {
                string __pair1 = kegg_gsPairinSamePathway.AllKeys[i];
                for (int j = i + 1; j < kegg_gsPairinSamePathway.AllKeys.Count(); j++)
                {
                    string __pair2 = kegg_gsPairinSamePathway.AllKeys[j];

                    /* one of (__pair1,__pair2) pair is 'UpInParental' or 'UpInResistant', and other is the opposite, not the same*/
                    if (!gsPair[__pair1].Equals(gsPair[__pair2]))
                    {
                        for (int i1 = 0; i1 < KEGGpathways.AllKeys.Count(); i1++)
                        {
                            string key1 = KEGGpathways.AllKeys[i1];
                            string __p1 = key1.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                            string __p1_D = key1.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];

                            if (hasBothGenesInPathway(__pair1, KEGGpathways[key1]) && hasBothGenesInPathway(__pair2, KEGGpathways[key1]))
                            {
                                //string _comnGene = CommonGeneinVstructure(__pair1, __pair2);
                                //if (!_comnGene.Equals(""))
                                //{
                                //    if (_1stV_type_III[__pair1 + "," + gsPair[__pair1] + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p1] == null)
                                //        _1stV_type_III.Add(__pair1 + "," + gsPair[__pair1] + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p1, "");
                                //    //tw_1stV_type_III.WriteLine(__pair1 + "," + gsPair[__pair1] + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p1);
                                //}
                                continue;
                            }
                            else
                            {
                                for (int j1 = i1 + 1; j1 < KEGGpathways.AllKeys.Count(); j1++)
                                {
                                    string key2 = KEGGpathways.AllKeys[j1];
                                    string __p2 = key2.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                                    string __p2_D = key2.Split("++".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];

                                    if (hasBothGenesInPathway(__pair1, KEGGpathways[key2]) && hasBothGenesInPathway(__pair2, KEGGpathways[key2]))
                                    {
                                        //string _comnGene = CommonGeneinVstructure(__pair1, __pair2);
                                        //if (!_comnGene.Equals(""))
                                        //{
                                        //    if (_1stV_type_III[__pair1 + "," + gsPair[__pair1] + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p2] == null)
                                        //        _1stV_type_III.Add(__pair1 + "," + gsPair[__pair1] + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p2, "");
                                        //    //tw_1stV_type_III.WriteLine(__pair1 + "," + gsPair[__pair1] + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p2);
                                        //}
                                        continue;
                                    }
                                    else if (hasBothGenesInPathway(__pair1, KEGGpathways[key1]) && hasBothGenesInPathway(__pair2, KEGGpathways[key2]))
                                    {
                                        string _comnGene = CommonGeneinVstructure(__pair1, __pair2);
                                        if (!_comnGene.Equals(""))
                                        {
                                            if (_1stV_type_II[__pair1 + "," + gsPair[__pair1] + "," + __p1 + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p2] == null)
                                                _1stV_type_II.Add(__pair1 + "," + gsPair[__pair1] + "," + __p1 + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p2, "");
                                            //tw_1stV_type_II.WriteLine(__pair1 + "," + gsPair[__pair1] + "," + __p1 + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p2);

                                            // save Type-II cross-talk
                                            dTable_Xtalks.Rows.Add(__p1, __p1_D, __p2, __p2_D, __pair1 + "&&" + __pair2, "Type-II");
                                            outputText_XTtalks += __p1 + ", " + __p1_D + ", " + __p2 + ", " + __p2_D + ", " + __pair1 + "&&" + __pair2 + ", " + "Type-II" + "\n";
                                        }
                                    }
                                    else if (hasBothGenesInPathway(__pair1, KEGGpathways[key2]) && hasBothGenesInPathway(__pair2, KEGGpathways[key1]))
                                    {
                                        string _comnGene = CommonGeneinVstructure(__pair1, __pair2);
                                        if (!_comnGene.Equals(""))
                                        {
                                            if (_1stV_type_II[__pair1 + "," + gsPair[__pair1] + "," + __p2 + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p1] == null)
                                                _1stV_type_II.Add(__pair1 + "," + gsPair[__pair1] + "," + __p2 + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p1, "");
                                            //tw_1stV_type_II.WriteLine(__pair1 + "," + gsPair[__pair1] + "," + __p2 + "&&" + __pair2 + "," + gsPair[__pair2] + "," + __p1);

                                            // save Type-II cross-talk
                                            dTable_Xtalks.Rows.Add(__p2, __p2_D, __p1, __p1_D, __pair1 + "&&" + __pair2, "Type-II");
                                            outputText_XTtalks += __p2 + ", " + __p2_D + ", " + __p1 + ", " + __p1_D + ", " + __pair1 + "&&" + __pair2 + ", " + "Type-II" +"\n";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (lboxSelected_A.Items.Count > 0 || lboxSelected_B.Items.Count > 0)
            {
                this.Lbl_KeggPathwayCrosstalks.Visible = true;
                dataGridView2.DataSource = new BindingSource(dTable_Xtalks, null);
                dataGridView2.Visible = Enabled;
                toolStripStatusLabel1.Text = "Pathway Cross-talks are generated successfully and they are now ready to be exported !!";
            }
            #endregion

            #endregion
        }

        private void TempLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                MessageBox.Show("Select Pathway and Get genes first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = folderBrowserDialog_OutputDir.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputDirectory = folderBrowserDialog_OutputDir.SelectedPath;
                if (!outputText_PathwayGenes.Equals(""))
                {
                    TextWriter tw = new StreamWriter(outputDirectory + @"\KEGG_Pathway_genes_.gmt");
                    tw.WriteLine(outputText_PathwayGenes);
                    tw.Close();
                    toolStripStatusLabel1.Text = "Output file exported successfully !!";
                }
                if (!outputText_XTtalks.Equals(""))
                {
                    TextWriter tw = new StreamWriter(outputDirectory + @"\Cross-talks_among_Selected_KEGG_Pathway_genes.csv");
                    tw.WriteLine(outputText_XTtalks);
                    tw.Close();
                    toolStripStatusLabel1.Text = "Output file exported successfully !!";
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KPGminer v1.0.0\nDeveloped by A. K. M. Azad @UNSW");
        }


        #region A-Click
        private void btnSingleInclusion_A_Click(object sender, EventArgs e)
        {
            #region Single inclusion button: A
            if (lbxAllA.SelectedItems.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();

                #region update (add to) right listbox
                lboxSelected_A.BeginUpdate();
                BindingSource bsRight = (BindingSource)lboxSelected_A.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = new BindingList<KeyValuePair<string, string>>();
                if (bsRight != null)
                    bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                foreach (var elem in lbxAllA.SelectedItems)
                {
                    bsRList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));

                }

                lboxSelected_A.DataSource = null;
                lboxSelected_A.DataSource = new BindingSource(bsRList, null);
                lboxSelected_A.DisplayMember = "Value";
                lboxSelected_A.ValueMember = "Key";
                lboxSelected_A.EndUpdate();
                #endregion

                #region update (remove from) left listbox
                BindingSource bsLeft = (BindingSource)lbxAllA.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;

                lbxAllA.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsLList.Remove(elem);
                }
                lbxAllA.EndUpdate();
                lblChosePathwayFrom_A.Text = "Choose from " + lbxAllA.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_A.Text = "Selected Pathway(s): " + lboxSelected_A.Items.Count.ToString();
                #endregion
            }
            #endregion
        }

        private void btnBatchInclusion_A_Click(object sender, EventArgs e)
        {
            #region Batch inclusion button: A
            if (lbxAllA.Items.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();

                #region update (add to) right listbox
                lboxSelected_A.BeginUpdate();

                BindingSource bsRight = (BindingSource)lboxSelected_A.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = new BindingList<KeyValuePair<string, string>>();
                BindingSource bsLeft = (BindingSource)lbxAllA.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;
                IEnumerator<KeyValuePair<string, string>> tempElem = bsLList.GetEnumerator();

                if (bsRight != null)
                    bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                while (tempElem.MoveNext())
                {
                    KeyValuePair<string, string> elem = tempElem.Current;
                    bsRList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));
                }

                lboxSelected_A.DataSource = null;
                lboxSelected_A.DataSource = new BindingSource(bsRList, null);
                lboxSelected_A.DisplayMember = "Value";
                lboxSelected_A.ValueMember = "Key";
                lboxSelected_A.EndUpdate();
                #endregion

                #region update (remove from) left listbox

                lbxAllA.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsLList.Remove(elem);
                }
                lbxAllA.EndUpdate();
                lblChosePathwayFrom_A.Text = "Choose from " + lbxAllA.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_A.Text = "Selected Pathway(s): " + lboxSelected_A.Items.Count.ToString();
                #endregion
            }
            #endregion

        }

        private void btnSingleExclusion_A_Click(object sender, EventArgs e)
        {
            #region single Exclusion button: A
            if (lboxSelected_A.SelectedItems.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();

                #region update (i.e. add to) left listbox
                lbxAllA.BeginUpdate();
                BindingSource bsLeft = (BindingSource)lbxAllA.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = new BindingList<KeyValuePair<string, string>>();
                if (bsLeft != null)
                    bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;
                foreach (var elem in lboxSelected_A.SelectedItems)
                {
                    bsLList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));

                }

                lbxAllA.DataSource = null;
                lbxAllA.DataSource = new BindingSource(bsLList, null);
                lbxAllA.DisplayMember = "Value";
                lbxAllA.ValueMember = "Key";
                lbxAllA.EndUpdate();
                #endregion

                #region update (i.e. remove from) right listbox
                BindingSource bsRight = (BindingSource)lboxSelected_A.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;

                lboxSelected_A.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsRList.Remove(elem);
                }
                lboxSelected_A.EndUpdate();
                lblChosePathwayFrom_A.Text = "Choose from " + lbxAllA.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_A.Text = "Selected Pathway(s): " + lboxSelected_A.Items.Count.ToString();
                #endregion
            }
            #endregion
        }

        private void btnBatchExclusion_A_Click(object sender, EventArgs e)
        {
            #region Batch Exclusion button: A
            if (lboxSelected_A.Items.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();
                BindingSource bsLeft = (BindingSource)lbxAllA.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = new BindingList<KeyValuePair<string, string>>();
                BindingSource bsRight = (BindingSource)lboxSelected_A.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                IEnumerator<KeyValuePair<string, string>> enumElem = bsRList.GetEnumerator();

                #region update (i.e. add to) left listbox
                lbxAllA.BeginUpdate();
                if (bsLeft != null)
                    bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;
                while (enumElem.MoveNext())
                {
                    KeyValuePair<string, string> elem = enumElem.Current;
                    bsLList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));
                }

                lbxAllA.DataSource = null;
                lbxAllA.DataSource = new BindingSource(bsLList, null);
                lbxAllA.DisplayMember = "Value";
                lbxAllA.ValueMember = "Key";
                lbxAllA.EndUpdate();
                #endregion

                #region update (i.e. remove from) right listbox

                lboxSelected_A.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsRList.Remove(elem);
                }
                lboxSelected_A.EndUpdate();
                lblChosePathwayFrom_A.Text = "Choose from " + lbxAllA.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_A.Text = "Selected Pathway(s): " + lboxSelected_A.Items.Count.ToString();
                #endregion
            }
            #endregion
        }
        #endregion

        #region B-Click
        private void btnSingleInclusion_B_Click(object sender, EventArgs e)
        {
            #region Single inclusion button: B
            if (lbxAllB.SelectedItems.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();

                #region update (add to) right listbox
                lboxSelected_B.BeginUpdate();
                BindingSource bsRight = (BindingSource)lboxSelected_B.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = new BindingList<KeyValuePair<string, string>>();
                if (bsRight != null)
                    bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                foreach (var elem in lbxAllB.SelectedItems)
                {
                    bsRList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));

                }

                lboxSelected_B.DataSource = null;
                lboxSelected_B.DataSource = new BindingSource(bsRList, null);
                lboxSelected_B.DisplayMember = "Value";
                lboxSelected_B.ValueMember = "Key";
                lboxSelected_B.EndUpdate();
                #endregion

                #region update (remove from) left listbox
                BindingSource bsLeft = (BindingSource)lbxAllB.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;

                lbxAllB.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsLList.Remove(elem);
                }
                lbxAllB.EndUpdate();
                lblChosePathwayFrom_B.Text = "Choose from " + lbxAllB.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_B.Text = "Selected Pathway(s): " + lboxSelected_B.Items.Count.ToString();
                #endregion
            }
            #endregion
        }

        private void btnBatchInclusion_B_Click(object sender, EventArgs e)
        {
            #region Batch inclusion button: B
            if (lbxAllB.Items.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();

                #region update (add to) right listbox
                lboxSelected_B.BeginUpdate();

                BindingSource bsRight = (BindingSource)lboxSelected_B.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = new BindingList<KeyValuePair<string, string>>();
                BindingSource bsLeft = (BindingSource)lbxAllB.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;
                IEnumerator<KeyValuePair<string, string>> tempElem = bsLList.GetEnumerator();

                if (bsRight != null)
                    bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                while (tempElem.MoveNext())
                {
                    KeyValuePair<string, string> elem = tempElem.Current;
                    bsRList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));
                }

                lboxSelected_B.DataSource = null;
                lboxSelected_B.DataSource = new BindingSource(bsRList, null);
                lboxSelected_B.DisplayMember = "Value";
                lboxSelected_B.ValueMember = "Key";
                lboxSelected_B.EndUpdate();
                #endregion

                #region update (remove from) left listbox

                lbxAllA.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsLList.Remove(elem);
                }
                lbxAllB.EndUpdate();
                lblChosePathwayFrom_B.Text = "Choose from " + lbxAllB.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_B.Text = "Selected Pathway(s): " + lboxSelected_B.Items.Count.ToString();
                #endregion
            }
            #endregion
        }
        private void btnSingleExclusion_B_Click(object sender, EventArgs e)
        {
            #region single Exclusion button: B
            if (lboxSelected_B.SelectedItems.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();

                #region update (i.e. add to) left listbox
                lbxAllB.BeginUpdate();
                BindingSource bsLeft = (BindingSource)lbxAllB.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = new BindingList<KeyValuePair<string, string>>();
                if (bsLeft != null)
                    bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;
                foreach (var elem in lboxSelected_B.SelectedItems)
                {
                    bsLList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));

                }

                lbxAllB.DataSource = null;
                lbxAllB.DataSource = new BindingSource(bsLList, null);
                lbxAllB.DisplayMember = "Value";
                lbxAllB.ValueMember = "Key";
                lbxAllB.EndUpdate();
                #endregion

                #region update (i.e. remove from) right listbox
                BindingSource bsRight = (BindingSource)lboxSelected_B.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;

                lboxSelected_B.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsRList.Remove(elem);
                }
                lboxSelected_B.EndUpdate();
                lblChosePathwayFrom_B.Text = "Choose from " + lbxAllB.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_B.Text = "Selected Pathway(s): " + lboxSelected_B.Items.Count.ToString();
                #endregion
            }
            #endregion
        }

        private void btnBatchExclusion_B_Click(object sender, EventArgs e)
        {
            #region Batch Exclusion button: B
            if (lboxSelected_B.Items.Count > 0)
            {
                List<KeyValuePair<string, string>> itemsToRemove = new List<KeyValuePair<string, string>>();
                BindingSource bsLeft = (BindingSource)lbxAllB.DataSource;
                BindingList<KeyValuePair<string, string>> bsLList = new BindingList<KeyValuePair<string, string>>();
                BindingSource bsRight = (BindingSource)lboxSelected_B.DataSource;
                BindingList<KeyValuePair<string, string>> bsRList = (BindingList<KeyValuePair<string, string>>)bsRight.List;
                IEnumerator<KeyValuePair<string, string>> enumElem = bsRList.GetEnumerator();

                #region update (i.e. add to) left listbox
                lbxAllB.BeginUpdate();
                if (bsLeft != null)
                    bsLList = (BindingList<KeyValuePair<string, string>>)bsLeft.List;
                while (enumElem.MoveNext())
                {
                    KeyValuePair<string, string> elem = enumElem.Current;
                    bsLList.Add((KeyValuePair<string, string>)elem);
                    itemsToRemove.Add(((KeyValuePair<string, string>)elem));
                }

                lbxAllB.DataSource = null;
                lbxAllB.DataSource = new BindingSource(bsLList, null);
                lbxAllB.DisplayMember = "Value";
                lbxAllB.ValueMember = "Key";
                lbxAllB.EndUpdate();
                #endregion

                #region update (i.e. remove from) right listbox

                lboxSelected_B.BeginUpdate();
                foreach (KeyValuePair<string, string> elem in itemsToRemove)
                {
                    bsRList.Remove(elem);
                }
                lboxSelected_B.EndUpdate();
                lblChosePathwayFrom_B.Text = "Choose from " + lbxAllB.Items.Count.ToString() + " pathway(s)";
                lblSelectedPathways_B.Text = "Selected Pathway(s): " + lboxSelected_B.Items.Count.ToString();
                #endregion
            }
            #endregion
        }

        #endregion

        #region A-Paint
        private void btnSingleInclusion_A_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(">", myfont, mybrush, 0, 0);
        }

        private void btnBatchInclusion_A_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(">>", myfont, mybrush, 0, 0);
        }

        private void btnSingleExclusion_A_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("<", myfont, mybrush, 0, 0);
        }

        private void btnBatchExclusion_A_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("<<", myfont, mybrush, 0, 0);
        }
        #endregion

        #region B-Paint
        private void btnSingleInclusion_B_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(">", myfont, mybrush, 0, 0);
        }

        private void btnBatchInclusion_B_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(">>", myfont, mybrush, 0, 0);
        }

        private void btnSingleExclusion_B_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("<", myfont, mybrush, 0, 0);
        }


        private void btnBatchExclusion_B_Paint(object sender, PaintEventArgs e)
        {
            Font myfont = new Font("Arial", 14);
            Brush mybrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            e.Graphics.TranslateTransform(20, 5);
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString("<<", myfont, mybrush, 0, 0);
        }
        #endregion

        private void Btn_loadData_Click(object sender, EventArgs e)
        {
            #region Load gene-dependency data
            try
            {
                toolStripStatusLabel1.Text = "Gene dependency data is being loaded: Please wait";

                /* open file choserbox */
                OpenFileDialog filechoser = new OpenFileDialog();
                filechoser.Filter = "Comma Separeted Files|*.csv|Text Documents|*.txt";
                DialogResult result = filechoser.ShowDialog();

                /* if cancel button is pressed in chosing file just dispose it */
                if (result == DialogResult.Cancel)
                    return;

                /* otherwise pick the file name */
                String filename = filechoser.FileName;

                /* check for a valid file name */
                if (filename == "" || filename == null)
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    #region Read GS-Pair
                    TextReader tr = new StreamReader(filename);
                    while (true)
                    {
                        string st = tr.ReadLine();
                        if (st == null)
                            break;
                        string[] stall = st.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        string metaData = stall[1];
                        if (gsPair[stall[0]] == null)
                            gsPair.Add(stall[0], metaData);
                    }
                    tr.Close();
                    toolStripStatusLabel1.Text = "Gene dependency data has been loaded successfully: Total " + gsPair.Count.ToString() + " pairs";
                    #endregion
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Data loading failed: " + ex.Message;
            }
            #endregion
        }

        private bool _isGeneExists(string[] arry, string p)
        {
            foreach (string s in arry)
            {
                if (s.Equals(p))
                    return true;
            }
            return false;
        }

        private bool _isKeyExist(string _pair2, NameValueCollection kegg_1stOrder_Vs)
        {
            foreach (string key in kegg_1stOrder_Vs.AllKeys)
                if (key.Contains(_pair2))
                    return true;
            return false;
        }

        private bool hasBothGenesInPathway(string _pair1, string p1)
        {
            string[] pathwayGenes = p1.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] _genesinPair = _pair1.Split("::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (_isGeneExists(pathwayGenes, _genesinPair[0]) && _isGeneExists(pathwayGenes, _genesinPair[1]))
                return true;
            else
                return false;
        }

        private string CommonGeneinVstructure(string k1, string k2)
        {
            string[] s1 = k1.Split("::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] s2 = k2.Split("::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (_isGeneExists(s2, s1[0]))
                return s1[0];
            else if (_isGeneExists(s2, s1[1]))
                return s1[1];
            else
                return "";
        }
    }
}
