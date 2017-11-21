using System.Collections;
using Core;
using UnityEngine;

namespace Game.Map.Components
{
    public class MapClickWidget : MonoScheduledBehaviour
    {
        [SerializeField]
        private GameObject _view;
        
        public void RefreshAppearance(Vector3 worldPosition)
        {
            CachedTransform.position = worldPosition;
            _view.SetActive(true);

            UnscheduleUpdate();
            ScheduleUpdate(1);
        }

        protected override void OnScheduledUpdate()
        {
            base.OnScheduledUpdate();
            _view.SetActive(false);
        }
    }
}
