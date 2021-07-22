using UnityEngine;

namespace Myproject.Mob
{
    public class MeleeKamikaze : MobAttack
    {
        [SerializeField] private SplashDamage SplashDamage;

        protected override void ExecuteAttack()
        {
            Instantiate(SplashDamage, transform.position, Quaternion.identity).SetSettings(mob.Damage);
        }
    }
}