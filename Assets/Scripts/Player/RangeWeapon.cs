using System.Collections;
using Myproject.EventBus.Messages;
using UnityEngine;

namespace Myproject.Player
{
	public class RangeWeapon : PlayerWeapon
	{
		[SerializeField] protected float Reload = 1f;
		[SerializeField] private Projectile _bulletPrefab;
		[SerializeField] private Transform _firePoint;
		[SerializeField] protected ParticleSystem VFX;
		protected bool isCooldown;

		protected Projectile BulletPrefab
		{
			get => _bulletPrefab;
			private set => _bulletPrefab = value;
		}

		protected Transform FirePoint
		{
			get => _firePoint;
			private set => _firePoint = value;
		}
		
		protected virtual float GetDamage()
		{
			return Player.Instance.Damage;
		}

		protected override void Fire(PlayerInputMessage message)
		{
			if (!message.Fire) return;
			if (isCooldown) return;

			GetComponent<PlayerAnimator>().TriggerShoot();
			
			Attack();

			VFX?.Play();

			StartCoroutine(Cooldown());
		}

		protected virtual void Attack()
		{
			var bullet = Instantiate(BulletPrefab, FirePoint.position, transform.rotation);
			bullet.Damage = GetDamage();
		}

		protected IEnumerator Cooldown()
		{
			isCooldown = true;
			yield return new WaitForSeconds(Reload);
			isCooldown = false;
		}
	}
}