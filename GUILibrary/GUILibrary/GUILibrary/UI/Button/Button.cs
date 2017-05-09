using GUILibrary.AssetLoading;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Visitor;
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
        public string Text { get; set; }
        public Texture2D CurrentTexture { get; private set; }

        private ButtonTextureWrapper textures;
        public Button(string text, Rectangle area)
        {
            this.Text = text;
            this.Position = new Vector2(area.X, area.Y);
            this.Size = new Vector2(area.Width, area.Height);

            // Temp
            this.Color = Color.White;

            // Flyweight pattern could be useful here, we don't need multiple instances of the textures
            this.textures = new ButtonTextureWrapper(
                AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonUp"),
                AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonOver"),
                AssetLibrary.Instance.RetrieveAsset<Texture2D>("DefaultButtonDown")
            );
            this.CurrentTexture = textures.ButtonUp;
        }
        public override void Update(IUpdateVisitor updateVisitor, float deltaTime)
        {
            updateVisitor.Update(this, deltaTime);
            base.Update(updateVisitor, deltaTime);
        }
        public override void Draw(IDrawVisitor drawVisitor)
        {
            drawVisitor.Draw(this);
        }

        protected override void OnMouseDown(MouseState mouseState)
        {
            this.CurrentTexture = textures.ButtonDown;
        }

        protected override void OnMouseRelease(MouseState mouseState)
        {
            // Quick hack to see if the mouse is still in the area
            var mouseIsInArea = Bounds.Contains(mouseState.Position);
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
