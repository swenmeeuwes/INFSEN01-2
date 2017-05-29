using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Input
{
    class InputManager : IInputManager
    {
        private static InputManager instance = null;
        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager(new MonoGameInputStrategy());
                return instance;
            }
        }

        private IInputStrategy inputStrategy;

        private InputManager(IInputStrategy inputStrategy)
        {
            this.inputStrategy = inputStrategy;
        }

        public void SetStrategy(IInputStrategy newStrategy)
        {
            inputStrategy = newStrategy;
        }


        public MouseState Mouse {
            get {
                return inputStrategy.GetMouseState();
            }
        }
    }
}
