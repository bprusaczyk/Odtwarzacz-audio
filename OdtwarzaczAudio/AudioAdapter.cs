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

namespace OdtwarzaczAudio
{
    class AudioAdapter : BaseAdapter<AudioInfo>
    {
        List<AudioInfo> lista = new List<AudioInfo>();
        Activity context;

        public AudioAdapter(Activity context, List<AudioInfo> items)   : base()
        {
            this.context = context;
            lista = items;
        }

        public override AudioInfo this[int position]
        {
            get
            {
                return lista.ElementAt<AudioInfo>(position);
            }
        }

        public override int Count
        {
            get
            {
                return lista.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = lista[position];
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.poleListy, null);
            }
            MediaMetadataRetriever mmr = new MediaMetadataRetriever();
            mmr.SetDataSource(context, Android.Net.Uri.Parse(item.Sciezka));
            string tytul = mmr.ExtractMetadata(MetadataKey.Title);
            string wykonawca = mmr.ExtractMetadata(MetadataKey.Artist);
            string czas = mmr.ExtractMetadata(MetadataKey.Duration);
            view.FindViewById<TextView>(Resource.Id.tytul).Text = tytul;
            view.FindViewById<TextView>(Resource.Id.wykonawca).Text = wykonawca;
            view.FindViewById<TextView>(Resource.Id.czas).Text = new TimeSpan(0,0,0,0,Int32.Parse(czas)).ToString();
            return view;
        }
    }
}