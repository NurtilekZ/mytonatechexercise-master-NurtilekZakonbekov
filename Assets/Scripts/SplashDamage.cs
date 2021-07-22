using UnityEngine;

namespace Myproject
{
    public class SplashDamage : MonoBehaviour
    {
        [SerializeField] private float Damage;
        [SerializeField] private bool DamagePlayer;
        [SerializeField] private bool DamageMob;

        public void SetSettings(float damage)
        {
            Damage = damage;
        }

        private void OnTriggerEnter(Collider other)
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
    }
}