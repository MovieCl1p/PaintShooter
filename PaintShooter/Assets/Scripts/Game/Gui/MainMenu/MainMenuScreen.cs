using UnityEngine;
using Core.ViewManager;
using UnityEngine.UI;
using System;
using Game.Data;

namespace Game.Gui.MainMenu
{
    public class MainMenuScreen : BaseView
    {
        [SerializeField]
        private Button _attackBtn;

        protected override void Awake()
        {
            base.Awake();

            _attackBtn.onClick.AddListener(OnAttackClick);
        }

        private void OnAttackClick()
        {
            ViewManager.Instance.SetView(ViewNames.GameHudScreen);
            ViewManager.Instance.SetView(ViewNames.GameView);
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _attackBtn.onClick.RemoveListener(OnAttackClick);
        }
    }
}
