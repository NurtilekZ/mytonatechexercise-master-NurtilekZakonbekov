using UnityEngine;

namespace Myproject.Utils
{
	public class WeaponAnimationMock : MonoBehaviour
	{
		[SerializeField] public Melee MeleeWeapon;
		
		public void WeaponAttack()
		{
			MeleeWeapon?.SetColliderActive(true);
		}

		public void WeaponEndAttack()
		{
			MeleeWeapon?.SetColliderActive(false);
		}
	}
}