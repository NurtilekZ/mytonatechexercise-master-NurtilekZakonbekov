using System.Collections;
using Myproject.EventBus.Messages;
using UnityEngine;

namespace Myproject.Player
{
    public class MeleeWeapon : PlayerWeapon
    {
        [SerializeField] private float Damage;
        [SerializeField] private float Speed;
        [SerializeField] private float Reload = 1f;
        [SerializeField] private bool DamagePlayer;
        [SerializeField] private bool DamageMob;
        private bool isCooldown;


        protected override void Awake()
        {
            base.Awake();
            Model.GetComponent<Melee>().SetSettings(Damage, Speed);
        }

        protected override async void Fire(PlayerInputMessage message)
        {
            if (!message.Fire) return;
            if (isCooldown) return;

            GetComponent<PlayerAnimator>().TriggerShoot();

            StartCoroutine(Cooldown());
        }
		
        private IEnumerator Cooldown()
        {
            isCooldown = true;
            yield return new WaitForSeconds(Reload);
            isCooldown = false;
        }
    }
}