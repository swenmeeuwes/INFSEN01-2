using GUILibrary.AssetLoading.Model;
using Microsoft.Xna.Framework.Content;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.AssetLoading
{
    class AssetLoadService
    {
        private static AssetLoadService instance = null;
        public static AssetLoadService Instance
        {
            get
            {
                if (instance == null)
                    instance = new AssetLoadService();
                return instance;
            }
        }

        // Make the constructor private and thus uninstantiateable
        private AssetLoadService() { }

        public void LoadAssets(ContentManager contentManager)
        {
            try
            {
                var jsonString = File.ReadAllText(@"Content/Assets/asset-manifest.json");
                var manifest = JsonConvert.DeserializeObject<ManifestModel>(jsonString);

                LoadAssetGroups(contentManager, manifest.Images);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadAssetGroups(ContentManager contentManager, params AssetModel[][] groups)
        {       
            foreach (var group in groups)
            {
                LoadAssetGroup(contentManager, group);
            }
        }

        private void LoadAssetGroup(ContentManager contentManager, AssetModel[] group)
        {
            foreach (var assetModel in group)
            {
                var asset = contentManager.Load<object>(assetModel.Src);
                AssetLibrary.Instance.StoreAsset(assetModel.Id, asset);
            }
        }
    }
}
