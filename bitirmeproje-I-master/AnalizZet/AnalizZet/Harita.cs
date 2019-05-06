using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
namespace AnalizZet
{
    public partial class Harita : Form
    {
        List<PointLatLng> pointLatLngs;
        public static string konumlar { get; set; }
        double ilkLat, ilkLong, sonLat, sonLong;
        string bolucu, bolucu2;
        string[] bol, bol2;
        public Harita()
        {
            InitializeComponent();
            pointLatLngs = new List<PointLatLng>();
        }
        private void Harita_FormClosing(object sender, FormClosingEventArgs e)
        {
            pointLatLngs.Clear();
        }
   
        private void Harita_Load(object sender, EventArgs e)
        {
            StreamReader konumSR = new StreamReader(konumlar);
            if(konumSR.ReadLine() == "Lat;Long;Hız;Time")
            {

            }
            else
            {
                bolucu = konumSR.ReadLine();
                bol = bolucu.Split(';');
                ilkLat = double.Parse(bol[0], CultureInfo.InvariantCulture);
                ilkLong = double.Parse(bol[1], CultureInfo.InvariantCulture);
                pointLatLngs.Add(new PointLatLng(ilkLat, ilkLong));
                konumSR.Close();
                
            }
            bolucu2 = File.ReadLines(konumlar).Last();
            bol2 = bolucu2.Split(';');
            sonLat = double.Parse(bol2[0], CultureInfo.InvariantCulture);
            sonLong = double.Parse(bol2[1], CultureInfo.InvariantCulture);
            pointLatLngs.Add(new PointLatLng(sonLat, sonLong));
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyCd8-jxB4Riq4wkmFHmWoyJFwi-gmDdw4w";
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.ShowCenter = false;
            map.Position = pointLatLngs[0];
            GMapMarker marker = new GMarkerGoogle(pointLatLngs[0],GMarkerGoogleType.red_pushpin);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);

            var rota = GoogleMapProvider.Instance.GetRoute(pointLatLngs[0], pointLatLngs[1], false, false, 14);
            var r = new GMapRoute(rota.Points, "Güzergah");
            var rotalar = new GMapOverlay("routes");
            rotalar.Routes.Add(r);
            map.Overlays.Add(rotalar);
        }
    }
}
