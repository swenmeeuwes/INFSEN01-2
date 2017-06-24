using GUILibrary.Input;
using GUILibrary.UI.Drawing;
using GUILibrary.UI.View.State;
using GUILibrary.Util.Observable;
using GUILibrary.Util.Structures;
using GUILibrary.Util.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.UI.View
{
    abstract class AbstractView : IDrawable, IObservable, IUpdatable
    {
        public abstract bool Visible { get; set; }
        public abstract float Opacity { get; set; }        
        public abstract Point2D<int> Position { get; set; }
        public abstract Vector2<int> Size { get; set; }
        //public abstract Vector2 Origin { get; set; }
        public abstract Rectangle<int> Bounds { get; }
        public abstract ViewState State { get; set; }

        private List<IObserver> observers = new List<IObserver>();

        public abstract void Draw(IDrawVisitor drawVisitor);

        public abstract void Update(IUpdateVisitor updateVisitor, float deltaTime);
        public abstract void HandleClick(IOnClickVisitor onClickVisitor);

        public virtual void Notify(Event eventObject) {
            observers.ForEach(observer => observer.OnNotify(eventObject));
        }

        public virtual void RegisterObserver(IObserver observer) {
            observers.Add(observer);
        }

        public virtual void DeregisterObserver(IObserver observer) {
            observers.Remove(observer);
        }
    }
}
