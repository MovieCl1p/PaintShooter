using Core;
using Game.Enemy;

namespace Game.Map.Components
{
    public class BulletCollider : BaseMonoBehaviour
    {
        public void OnTriggerEnter(UnityEngine.Collider other)
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
