using UnityEngine;

namespace Myproject
{
	public class Projectile : MonoBehaviour
	{
		public float Damage;
		[SerializeField] protected float Speed = 8;
		[SerializeField] protected bool DamagePlayer = false;
		[SerializeField] protected bool DamageMob;
		[SerializeField] protected float TimeToLive = 5f;
		[SerializeField] protected bool haveSplashDamage = false;
		[SerializeField] protected SplashDamage SplashDamage;
		protected float timer = 0f;
		protected bool destroyed = false;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (destroyed)
			{
				return;
			}

			if (DamagePlayer && other.CompareTag("Player"))
			{
				if (haveSplashDamage)
					DoSplashDamage();
				else
					other.GetComponent<Player.Player>().TakeDamage(Damage);

				destroyed = true;
			}

			if (DamageMob && other.CompareTag("Mob"))
			{
				if (haveSplashDamage)
					DoSplashDamage();
				else
					other.GetComponent<Mob.Mob>().TakeDamage(Damage);
				destroyed = true;
			}
		}

		private void DoSplashDamage()
		{
			Instantiate(SplashDamage, transform.position, Quaternion.identity).SetSettings(Damage);
		}

		protected virtual void Update()
		{
			if (!destroyed)
			{
				transform.position += transform.forward * Speed * Time.deltaTime;
			}

			timer += Time.deltaTime;
			if (timer > TimeToLive || destroyed)
			{
				Destroy(gameObject);
			}
		}
	}
}