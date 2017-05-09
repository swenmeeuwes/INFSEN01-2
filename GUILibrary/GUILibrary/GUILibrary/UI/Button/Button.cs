using GUILibrary.AssetLoading;
using GUILibrary.UI.View.State;
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
        private ButtonTextureWrapper textures;
        public Button(Rectangle area)
        {
            this.Area = area;

            // Flyweight pattern could be useful here, we don't need multiple instances of the textures
            this.textures = new ButtonTextureWrapper(
                AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonUp"),
                AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonOver"),
                AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonDown")
            );
            this.CurrentTexture = textures.ButtonUp;
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
            this.CurrentTexture = textures.ButtonDown;
        }

        protected override void OnMouseRelease(MouseState mouseState)
        {
            // Quick hack to see if the mouse is still in the area
            var mouseIsInArea = Area.Contains(mouseState.Position);
            if (mouseIsInArea)
                this.CurrentTexture = textures.ButtonOver;
            else
                this.CurrentTexture = textures.ButtonUp;
        }

        protected override void OnMouseEnter(MouseState mouseState)
        {
            this.CurrentTexture = textures.ButtonOver;
        }

        protected override void OnMouseExit(MouseState mouseState)
        {
            this.CurrentTexture = textures.ButtonUp;
        }
    }
}
