using GUILibrary.AssetLoading;
using GUILibrary.Input;
using GUILibrary.UI.Label;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.Button
{
    class Button : View.View
    {
        public Label.Label Label { get; set; }
        public Texture2D CurrentTexture { get; private set; }

        private ButtonTextureWrapper textures;
        public Button(string text, Point2D<int> position)
        {
            this.Position = position;            
            this.Label = new Label.Label(text, Position);

            var measuredSize = Label.Font.MeasureString(text);
            this.Size = new Vector2<int>((int)measuredSize.X, (int)measuredSize.Y);

            // Temp
            Color = Color.White;

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
            drawVisitor.Draw(this.Label);
        }

        protected override void OnMouseDown(MouseState mouseState)
        {
            base.OnMouseDown(mouseState);
            this.CurrentTexture = textures.ButtonDown;
        }

        protected override void OnMouseRelease(MouseState mouseState)
        {
            base.OnMouseRelease(mouseState);
        }

        protected override void OnMouseEnter(MouseState mouseState)
        {
            base.OnMouseEnter(mouseState);
            this.CurrentTexture = textures.ButtonOver;
        }

        protected override void OnMouseOver(MouseState mouseState)
        {
            base.OnMouseOver(mouseState);
            this.CurrentTexture = textures.ButtonOver;
        }

        protected override void OnMouseExit(MouseState mouseState)
        {
            base.OnMouseExit(mouseState);
            this.CurrentTexture = textures.ButtonUp;
        }
    }
}
