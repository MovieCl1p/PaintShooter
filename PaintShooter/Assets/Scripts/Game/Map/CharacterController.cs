using System;
using Core;
using UnityEngine;
using Game.Map.Commands;

namespace Game.Map
{
    public class CharacterController : MonoScheduledBehaviour
    {
        [SerializeField]
        private GameObject _bullet;

        private bool _reloading;

        public void TryFire(Vector3 characterPosition, Vector3 targetPosition)
        {
            if (!_reloading)
            {
                ScheduleUpdate(0.1f, false);
                _reloading = true;
                Fire(characterPosition, targetPosition);
            }
        }

        private void Fire(Vector3 characterPosition, Vector3 targetPosition)
        {
            GameObject go = GameObject.Instantiate(_bullet, characterPosition, Quaternion.Euler(90, 0, 0));
            MoveToCommand command = go.AddComponent<MoveToCommand>();
            command.Init(targetPosition, 6);
        }

        protected override void OnScheduledUpdate()
        {
            base.OnScheduledUpdate();

            _reloading = false;
        }
    }
}
