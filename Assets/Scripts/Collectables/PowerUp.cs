using UnityEngine;

namespace Myproject.Collectables
{
	public class PowerUp : Collectable
	{
		[SerializeField] private int Health;
		[SerializeField] private int Damage;
		[SerializeField] private float MoveSpeed;

		protected override void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<Player.Player>().Upgrade(Health, Damage, MoveSpeed);
				Destroy(gameObject);
			}
		}
	}
}