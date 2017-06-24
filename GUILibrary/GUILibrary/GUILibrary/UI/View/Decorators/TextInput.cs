using GUILibrary.AssetLoading;
using GUILibrary.Input.Model;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View.Decorators
{
    class TextInput : ViewDecorator
    {
        public bool Selected { get; set; }
        public string Content { get; set; }
        public string Placeholder { get; set; }
        public SpriteFont Font { get; set; }
        public Color FontColor { get; set; }

        private DateTime lastInput = DateTime.Now;
        public TextInput(AbstractView view, string placeholder) : base(view)
        {
            Placeholder = placeholder;

            // Use a font as "default" label font
            Font = AssetLibrary.Instance.RetrieveAsset<SpriteFont>("Arial");
            FontColor = Color.Black;

            Selected = false;
            Content = "";
        }
        public override void Draw(IDrawVisitor visitor)
        {
            visitor.Draw(this);
            view.Draw(visitor);
        }
        public override void Update(IUpdateVisitor visitor, float deltaTime)
        {
            visitor.Update(this, deltaTime);
            view.Update(visitor, deltaTime);
        }
        public override void HandleClick(IOnClickVisitor visitor)
        {
            visitor.HandleClick(this);
            view.HandleClick(visitor);
        }

        public void HandleInput(Key[] pressedKeys)
        {
            var now = DateTime.Now;
            var backspace = pressedKeys.Count(k => k.KeyCode == 8) > 0;
            if(backspace && Content.Length > 0 && lastInput.AddSeconds(0.05) < now)
            {
                Content = Content.Substring(0, Content.Length - 1);
                lastInput = now;
                return; // Stop checking for other keys
            }

            // Modifier key checks
            var shift = pressedKeys.Count(k => k.KeyCode == 160 || k.KeyCode == 161) > 0;
            
            // 0-9 keycodes range from [48-57]
            // A-Z keycodes range from [65-90]
            var validPressedKeys = pressedKeys.Where(k => (k.KeyCode >= 48 && k.KeyCode <= 57) || (k.KeyCode >= 65 && k.KeyCode <= 90)).ToArray();

            if(validPressedKeys.Length > 0)
            {
                var key = validPressedKeys[0];
                if (lastInput.AddSeconds(0.1) < now)
                {
                    Content += shift ? key.KeyName.ToUpper() : key.KeyName.ToLower();
                    lastInput = now;
                }
            }
        }
    }
}
