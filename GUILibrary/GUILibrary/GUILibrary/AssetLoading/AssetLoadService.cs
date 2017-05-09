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
                var jsonObject = JsonConvert.DeserializeObject<ManifestModel>(jsonString);

                var imageGroup = jsonObject.Images;
                foreach (JObject jObject in imageGroup.Children<JObject>())
                {
                    foreach (JProperty jProperty in jObject.Properties())
                    {
                        var asset = contentManager.Load<object>((string)jProperty.Value);
                        AssetLibrary.Instance.StoreAsset(jProperty.Name, asset);
                    }
                }

                // Would be nice to get a stream working
                //using (StreamReader streamReader = new StreamReader(@"Content/Assets/asset-manifest.json"))
                //{
                //    JsonTextReader reader = new JsonTextReader(streamReader);
                //    while (reader.Read())
                //    {
                //        if (reader.Value != null)
                //        {
                //            Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                //        }
                //        else
                //        {
                //            Console.WriteLine("Token: {0}", reader.TokenType);
                //        }
                //    }
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
