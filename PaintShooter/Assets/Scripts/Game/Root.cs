﻿using Core;
using Core.ViewManager;
using Game.Commands;
using Game.Config;
using Game.Data;

namespace Game
{
    public class Root : BaseMonoBehaviour
    {
        protected override void Start()
        {
            base.Start();

            AppConfig config = new AppConfig();
            config.AddBindings();

            StartCommand start = new StartCommand();
            start.Execute();

            ViewManager.Instance.SetView(ViewNames.SplashScreen);
        }
    }
}
