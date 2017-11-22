using UnityEngine;
using Core.ViewManager;
using Core.Camera;
using Game.Map;
using System;
using Game.Map.Components;
using Game.Map.Commands;

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

        [SerializeField]
        private CharacterGroupWidget _characterGroupWidget;

        [SerializeField]
        private LayerMask _layerMask;

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
            if (Physics.Raycast(ray, out hit, _layerMask.value))
            {
                HandleMapClick(hit.point);
            }
        }

        private MoveToCommand _moveCommand;

        private void HandleMapClick(Vector3 worldPosition)
        {
            _camera.SetFocus(worldPosition);

            _clickWidget.RefreshAppearance(worldPosition);

            Vector3 forward = _camera.CachedTransform.TransformDirection(Vector3.left);
            Vector3 toOther = worldPosition - _camera.CachedTransform.position;

            if (Vector3.Dot(forward, toOther) > 0)
            {
                _characterGroupWidget.SetSide(CharacterSide.Left);
            }
            else
            {
                _characterGroupWidget.SetSide(CharacterSide.Right);
            }

            if(_moveCommand != null)
            {
                Destroy(_moveCommand);
            }

            _moveCommand = _characterGroupWidget.CachedTransform.gameObject.AddComponent<MoveToCommand>();
            _moveCommand.Init(worldPosition, 3);
        }

        protected override void OnReleaseResources()
        {
            base.OnReleaseResources();

            _mapInteraction.OnClick -= OnMapClick;
        }
    }
}
