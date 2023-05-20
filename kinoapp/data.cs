using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kinoapp
{
    public class data
    {
        public string uuid { get; set; }
        public int row { get; set; }
        public int col { get; set; }

        public data(string _uuid, int _row, int _col)
        {
            uuid = _uuid;
            row = _row;
            col = _col;
        }
    }
}
