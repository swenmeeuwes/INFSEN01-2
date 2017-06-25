using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILibrary.Application.Controller
{
    class MonoGameApplicationAdapter : IApplicationAdapter
    {
        private Game application;
        public MonoGameApplicationAdapter(Game application)
        {
            this.application = application;
        }
        public void Exit()
        {
            application.Exit();
        }
    }
}
