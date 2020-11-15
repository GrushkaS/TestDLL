using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Runtime.InteropServices;
//

using Zulu;
using ZuluLib;
using ZuluCharts;
using ZB;
using ZuluComNetOcx;
using ZuluOcx;
using zulurep;
using zuluui;
using stdole;

namespace TestDLL
{
    //Set ProgID and ComVisible
    [Guid("CFE59D63-6073-43CF-B0A3-CDD755F9BA39")]
    [ComVisible(true)]
    [ProgId("TestDLL.PluginControl")]
    public partial class PluginControl : UserControl
    {
        public PluginControl(){
            InitializeComponent();
        }

        
  
        public void ShowForm() {
        }

        //Some variables     
        //Main 
        IPluginConnector pluginConnector;

        Document aDoc;
        MapDoc Map;

        Layer ActiveLayer;

        ChangedElementKeys elementKeys;

        int currentKey;


        //IZuluEvents EvSink;


        public bool ConnectZuluPlugin(IPluginConnector connector)
        {
            try
            {
                #region test
                //LayerBox.Text = $"Guess func ConnectZuluPlugin works";
                #endregion
                //Take object??
                //this.IPluginConnector = Connector;
                pluginConnector = connector;
                //which object??
                //pluginConnector.SetEventSink(EvSink);
                aDoc = pluginConnector?.Zulu?.ActiveDocument;
                Map = aDoc?.NativeDoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //connector.SetEventSink();

            return true;

        }


        public void DisconnectZuluPlugin()
        {
            //delete IpluginConnector?
            //pluginConnector.SetEventSink(null);

            pluginConnector.Unlock();
            pluginConnector = null;
            Map = null;
            aDoc = null;
        }


        private void SelectLayer()
        {
            ActiveLayer = Map.Layers.Active;
            SetCRSProjection("EPSG:32601");
            #region ActiveLayer
            /*List<string> layers = new List<string>();          

            for (int i = 0; i < Map.Layers.Count; i++)
            {
                //How to get all layers from zulu?
                //layers.Add(Map.Layers.);
            }
           
            try
            {
                if (!LayersBox.Items.Contains(ActiveLayer.UserName))
                {
                    LayersBox.Items.Add(ActiveLayer.UserName);
                    if (LayersBox.Items.Contains(empty)) LayersBox.Items.Remove(empty);
                }
            }
            catch 
            { 
                if (!LayersBox.Items.Contains(empty)) LayersBox.Items.Add(empty);
            }*/
            #endregion
        }

        private void SetCRSProjection(string input) {
            ActiveLayer.SetInputCRSProjection(input);
        }

      
        private void Draw(double[] Xcoord, double[] Ycoord)
        {
            ElemStyle eStyle;
            Contour Cell;

            Cell = new Contour();
            eStyle = new ElemStyle
            {
                PatColor = 255,
                BorderStyle = 0,
                BorderWidth = 1
            };


            Cell.Fill(4, ref Xcoord[0], ref Ycoord[0]);

            //Element.SetContour(Cell);
            //Element.ElemStyle = eStyle;



             ActiveLayer.AddContour(Cell, eStyle, 0, 0);
    

            //ActiveLayer.AddElementEx(Element,-1,1);

            //ElementId = Element.Key;

            //ElementKeys elementKeys
            //elementKeys = ActiveLayer.ElementKeys;


        }

        /*public void Draw()
        {
            ElemStyle eStyle;
            Contour Cell;
            //Example coordinates
            //cell = new MyContour();
            //cell = new ContourClass();
            Cell = new Contour();
            //eStyle = new MyStyle();
            eStyle = new ElemStyle();

            
            
            double[] Xcoord = new double[] {1000, 1000, 990, 990 };
            double[] Ycoord = new double[] {50100, 50200, 50200, 50100 };
            
            
            for (int i = 0; i < Xcoord.Length; i++)
            {
                cell.AddPoint(Xcoord[i], Ycoord[i]);
            }

            Cell.Fill(4, ref Xcoord[0], ref Ycoord[0]);



            eStyle.PatColor = 255;
            eStyle.BorderStyle = 0;
            eStyle.BorderWidth = 1;


            ActiveLayer.AddContour(Cell, eStyle, 0, 0);
        }*/


        /*public bool OnZuluEvent() {
        
        }*/


        private int GetCurentKeys()
        {
            elementKeys = ActiveLayer?.ChangedElements;
            if (elementKeys.Count != 0)
            {         
                return elementKeys[1];
            }
            else return -1;
        }

        private void DeleteOldElement(int key)
        {
            ActiveLayer.DeleteElement(key);
        }


        private void GetValues(string input, out double[] Xcoord, out double[] Ycoord) 
        {
           string[] split_text =  input.Split(new char[] {' ', ',', ';'});
            if (split_text.Length >= 8)
            {
                try
                {
                    int n = split_text.Length / 2;
                    Xcoord = new double[n];
                    Ycoord = new double[n];
                    int x = 0;
                    for (int i = 0; i < n; i++)
                    {
                        Xcoord[i] = double.Parse(split_text[x]);
                        Ycoord[i] = double.Parse(split_text[x + 1]);
                        x += 2;
                    }


                    #region debugging
                    /*
                    string what = null;
                    string what2 = null;
                    for(int i = 0; i < split_text.Length; i++)
                    {
                        what2 += split_text[i] + " ";
                    }

                    for (int i = 0; i < Xcoord.Length; i++)
                    {                 
                        what += Xcoord[i].ToString() + ";" + Ycoord[i].ToString() + ". "; 
                    }

                    MessageBox.Show(what2, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(what, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                    #endregion
                }
                catch
                {
                    Xcoord = null;
                    Ycoord = null;
                }
            }else
            {
                Xcoord = null;
                Ycoord = null;
            }
            
        }

        


        private void DrawButton_Click(object sender, EventArgs e)
        {
            try
            {                 
                double[] Xcoord, Ycoord;
                GetValues(Coordinates1.Text, out Xcoord, out Ycoord);

                currentKey = GetCurentKeys();
                if (currentKey != -1)
                {
                DeleteOldElement(currentKey);
                }

                if(Xcoord != null)
                {
                    Draw(Xcoord, Ycoord);
                    MessageBox.Show("Painted", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Wrong input data", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease add layer to the map and press update", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LayerButton_Click(object sender, EventArgs e)
        {         
            try
            {
                SelectLayer();
                LayerTextBox.Text = ActiveLayer.UserName;
            }
            catch
            { 
                MessageBox.Show("Please add layer to the map", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }      
        }


        //Make redraw element+?
        //Make coord in WGS84+?
        //Make exceptions handler? or just exceptions+?
        //Make eventhandler-
        //Make main logic in other files-?
        //Make appconfig for constants-?
        //Create OnZuluEvent?
        //GetCoord remake!
        //Exceptions!

    }


}
