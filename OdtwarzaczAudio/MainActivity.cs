using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;

namespace OdtwarzaczAudio
{
    [Activity(Label = "OdtwarzaczAudio", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button dodajUtwor;
        ListView lv;
        List<AudioInfo> lista = new List<AudioInfo>();
        AudioAdapter aa;

        public static readonly int PickImageId = 1000;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            lv = FindViewById<ListView>(Resource.Id.lista);
            dodajUtwor = FindViewById<Button>(Resource.Id.dodajUtwor);
            dodajUtwor.Click += DodajUtwor_Click;
            aa = new AudioAdapter(this, lista);
            lv.Adapter = aa;
            lv.ItemClick += Lv_ItemClick;
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(OdtwarzanieActivity));
            i.PutExtra("bieżący utwór", lista[e.Position].Sciezka);
            StartActivity(i);
        }

        private  void DodajUtwor_Click(object sender, System.EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("audio/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                lista.Add(new AudioInfo { Sciezka = uri.ToString() });
                aa.NotifyDataSetChanged();
            }
        }
    }
}

