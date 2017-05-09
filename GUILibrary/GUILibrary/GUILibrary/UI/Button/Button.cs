using GUILibrary.AssetLoading;
using GUILibrary.Util.Observable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.Button
{
    class Button : View.View
    {
        public Texture2D CurrentTexture { get; private set; }
        public Button(Rectangle area)
        {
            this.Area = area;

            // TEST
            this.CurrentTexture = AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonUp");
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CurrentTexture, Area, Color.White);
        }

        protected override void OnMouseDown(MouseState mouseState)
        {
            
        }

        protected override void OnMouseEnter(MouseState mouseState)
        {
            // TEST
            this.CurrentTexture = AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonDown");
        }

        protected override void OnMouseExit(MouseState mouseState)
        {
            // TEXT
            this.CurrentTexture = AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonUp");
        }
    }
}
