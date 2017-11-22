using Core;
using System;
using UnityEngine;

namespace Game.Map.Commands
{
    public class MoveToCommand : BaseMonoBehaviour
    {
        private Action<object> OnFinish;

        private Vector3 _destination;
        private float _speed;

        protected void Update()
        {
            Vector3 pos = Vector3.MoveTowards(CachedTransform.position, _destination, _speed * Time.deltaTime);
            CachedTransform.position = new Vector3(pos.x, CachedTransform.position.y, pos.z);

            if (Vector3.Distance(CachedTransform.position, _destination) < 0.01f)
            {
                CachedTransform.position = _destination;
                if (OnFinish != null)
                {
                    OnFinish(this);
                }

                Destroy(this);
            }
        }

        public void Init(Vector3 viewPosition, float moveSpeed, Action<object> onFinish = null)
        {
            _destination = viewPosition;
            _speed = moveSpeed;
            OnFinish = onFinish;
        }
    }
}
