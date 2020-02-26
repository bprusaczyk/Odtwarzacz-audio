using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using System.Threading;

namespace OdtwarzaczAudio
{
    [Activity(Label = "OdtwarzanieActivity")]
    public class OdtwarzanieActivity : Activity
    {
        TextView tytul;
        Button odtworz;
        Button zatrzymaj;
        ProgressBar pb;
        MediaPlayer player;
        Timer timer;
        private string sciezka;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Odtwarzanie);
            tytul = FindViewById<TextView>(Resource.Id.odtwarzanieTytul);
            odtworz = FindViewById<Button>(Resource.Id.odtworz);
            odtworz.Click += Odtworz_Click;
            zatrzymaj = FindViewById<Button>(Resource.Id.zatrzymaj);
            zatrzymaj.Click += Zatrzymaj_Click;
            pb = FindViewById<ProgressBar>(Resource.Id.pasekPostepu);
            sciezka = Intent.GetStringExtra("bieżący utwór");
            MediaMetadataRetriever mmr = new MediaMetadataRetriever();
            mmr.SetDataSource(Application.Context, Android.Net.Uri.Parse(sciezka));
            string tytulUtowru = mmr.ExtractMetadata(MetadataKey.Title);
            tytul.Text = tytulUtowru;
            player = MediaPlayer.Create(this, Android.Net.Uri.Parse(sciezka));
            pb.Max = player.Duration;
            timer = new Timer(x => obsluzPasek(), null, 0, 1000);
        }

        private void Zatrzymaj_Click(object sender, EventArgs e)
        {
            player.Pause();
        }

        private void Odtworz_Click(object sender, EventArgs e)
        {
            player.Start();
        }

        void obsluzPasek()
        {
            pb.Progress = player.CurrentPosition;
        }
    }
}