using UnityEngine;

namespace Myproject.Collectables
{
	public class HealthPack : Collectable
	{
		[SerializeField] private int Health;

		protected override void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<Player.Player>().Heal(Health);
				Destroy(gameObject);
			}
		}
	}
}