using Myproject.Player;
using UnityEngine;

namespace Myproject.Collectables
{
	public class WeaponPowerUp : Collectable
	{
		[SerializeField] public WeaponType Type;

		protected override void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<Player.Player>().ChangeWeapon(Type);
				Destroy(gameObject);
			}
		}
	}
}