using UnityEngine;
using Core.ViewManager;
using Core.Camera;
using Game.Map;
using System;
using Game.Map.Components;

namespace Game.Gui.Map
{
    public class GameView : BaseView
    {
        [SerializeField]
        private CameraSmoothFollow _camera;

        [SerializeField]
        private InteractionHandler _mapInteraction;

        [SerializeField]
        private MapClickWidget _clickWidget;

        protected override void Awake()
        {
            base.Awake();

            _mapInteraction.OnClick += OnMapClick;
        }

        protected override void Start()
        {
            base.Start();

            _camera.SetFocus(new Vector3(0, 12, -1));
        }

        private void OnMapClick()
        {
            Ray ray = _camera.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                HandleMapClick(hit.point);
            }
        }

        private void HandleMapClick(Vector3 worldPosition)
        {
            _camera.SetFocus(worldPosition);

            _clickWidget.RefreshAppearance(worldPosition);
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _mapInteraction.OnClick -= OnMapClick;
        }
    }
}
