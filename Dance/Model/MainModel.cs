using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance.Model
{
    public class MainModel
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<string> SongList { get; set; }
    }
}
