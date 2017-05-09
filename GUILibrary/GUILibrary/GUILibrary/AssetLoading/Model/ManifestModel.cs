using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.AssetLoading.Model
{
    class ManifestModel
    {
        public AssetModel[] Fonts { get; set; }
        public AssetModel[] Images { get; set; }
    }
}
