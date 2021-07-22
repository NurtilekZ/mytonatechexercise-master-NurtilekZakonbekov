using UnityEngine;

namespace Myproject
{
    public class Melee : MonoBehaviour
    {
        public float Damage;
        public float Speed;
        [SerializeField] private bool DamagePlayer;
        [SerializeField] private bool DamageMob;
        [SerializeField] private Collider Collider;

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (DamagePlayer && other.CompareTag("Player"))
            {
                other.GetComponent<Player.Player>().TakeDamage(Damage);
            }

            if (DamageMob && other.CompareTag("Mob"))
            {
                var mob = other.GetComponent<Mob.Mob>();
                mob.TakeDamage(Damage);
            }
        }

        public void SetColliderActive(bool value)
        {
            if (Collider != null)
            {
                Collider.enabled = value;
            }
        }

        public void SetSettings(float damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }
    }
}