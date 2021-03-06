﻿using Core.ViewManager;
using Game.Data;

namespace Game.Gui.Splash
{
    public class SplashScreen : BaseView
    {
        protected override void Start()
        {
            base.Start();

            ViewManager.Instance.SetView(ViewNames.MainMenuScreen);
        }
    }
}

