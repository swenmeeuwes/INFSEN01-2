using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.AssetLoading
{
    class AssetLibrary
    {
        private static AssetLibrary instance = null;
        public static AssetLibrary Instance
        {
            get
            {
                if (instance == null)
                    instance = new AssetLibrary();
                return instance;
            }
        }

        private Dictionary<string, object> assets;

        // Make the constructor private and thus uninstantiateable
        private AssetLibrary() {
            assets = new Dictionary<string, object>();
        }

        public void StoreAsset(string key, object asset)
        {
            assets.Add(key, asset);
        }

        public T RetrieveAsset<T>(string key)
        {
            return (T)assets[key];
        }
    }
}
