using System;
using UnityEngine;

namespace Myproject.Mob
{
	public class Mob : MonoBehaviour
	{
		public float Damage = 1;
		[SerializeField] private float MoveSpeed = 3.5f;
		[SerializeField] private float Health = 3;
		public float MaxHealth = 3;

		public event Action<float, float> OnHPChange = null;

		public void TakeDamage(float amount)
		{
			if (Health <= 0)
				return;
			Health -= amount;
			OnHPChange?.Invoke(Health, -amount);
			if (Health <= 0)
			{
				Death();
			}
		}

		public void Heal(float amount)
		{
			if (Health <= 0)
				return;
			Health += amount;
			if (Health > MaxHealth)
			{
				Health = MaxHealth;
			}

			OnHPChange?.Invoke(Health, amount);
		}

		public void Death()
		{
			EventBus.EventBus.Pub(EventBus.EventBus.MOB_KILLED);
			var components = GetComponents<IMobComponent>();
			foreach (var component in components)
			{
				component.OnDeath();
			}

			GetComponent<Collider>().enabled = false;
			GetComponent<Rigidbody>().isKinematic = true;

		
			Destroy(gameObject, 2f);
		}
	}
}