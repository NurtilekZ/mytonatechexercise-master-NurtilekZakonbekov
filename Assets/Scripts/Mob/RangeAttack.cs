using Myproject.Utils;
using UnityEngine;

namespace Myproject.Mob
{
	[RequireComponent(typeof(MobMover))]
	[RequireComponent(typeof(Mob))]
	public class RangeAttack : MobAttack, IMobComponent
	{
		[SerializeField] private Projectile Bullet;
		
		protected override void ExecuteAttack()
		{
			var bullet = Instantiate(Bullet, transform.position + transform.forward,
				Quaternion.LookRotation((Player.Player.Instance.transform.position - transform.position).Flat().normalized,
					Vector3.up));
			bullet.Damage = mob.Damage;
		}
	}
}