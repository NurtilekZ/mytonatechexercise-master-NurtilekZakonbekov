using UnityEngine;

// Bonus!
// Refactor Rifle, AutomaticRifle and Shotgun classes as you want
namespace Myproject.Player
{
	public class Shotgun : RangeWeapon
	{
		protected override void Attack()
		{
			var directions = SpreadDirections(transform.rotation.eulerAngles, 3, 20);
			foreach (var direction in directions)
			{
				var bullet = Instantiate(BulletPrefab, FirePoint.position, Quaternion.Euler(direction));
				bullet.Damage = GetDamage();
			}
		}

		private Vector3[] SpreadDirections(Vector3 direction, int num, int spreadAngle)
		{
			Vector3[] result = new Vector3[num];
			result[0] = new Vector3(0, direction.y - (num - 1) * spreadAngle / 2, 0);
			for (int i = 1; i < num; i++)
			{
				result[i] = result[i - 1] + new Vector3(0, spreadAngle, 0);
			}

			return result;
		}
	}
}