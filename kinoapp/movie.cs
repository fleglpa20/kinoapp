using System;
using System.Collections.Generic;
using System.Text;

namespace kinoapp
{
    public class movie
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public cinema cinema { get; set; }
    }
}
