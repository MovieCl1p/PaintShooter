using Core;
using Game.Enemy;
using UnityEngine;

namespace Game.Map.Components
{
    public class CharacterCollider : BaseMonoBehaviour
    {
        [SerializeField]
        private CharacterController _controller;

        public void OnTriggerStay(Collider other)
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            if(enemy != null)
            {
                _controller.TryFire(CachedTransform.position, enemy.CachedTransform.position);
            }
        }
    }
}
