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

namespace OdtwarzaczAudio
{
    class AudioInfo
    {
        public string Tytul { get; set; }

        public TimeSpan Dlugosc { get; set; }

        public string Sciezka { get; set; }
    }
}