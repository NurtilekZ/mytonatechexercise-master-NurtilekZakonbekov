using Myproject.Utils;
using UnityEngine;

namespace Myproject.Mob
{
	[RequireComponent(typeof(MobMover))]
	[RequireComponent(typeof(Mob))]
	public class MeleeAttack : MobAttack, IMobComponent
	{
		[SerializeField] protected float DamageDistance = 1f;

		protected override void ExecuteAttack()
		{
			var playerDistance = (transform.position - Player.Player.Instance.transform.position).Flat().magnitude;
			if (playerDistance <= DamageDistance)
			{
				Player.Player.Instance.TakeDamage(mob.Damage);
			}
		}
	}
}