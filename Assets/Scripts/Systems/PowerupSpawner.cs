using System.Collections.Generic;
using Myproject.Collectables;
using Myproject.Data;
using UnityEngine;
using Random = UnityEngine.Random;

// Bad class
// Rewrite it
namespace Myproject.Systems
{
	public class PowerupSpawner : MonoBehaviour
	{
		[SerializeField] private List<CollectableData> Collectables = new List<CollectableData>();

		private float[] weights;
		private void Awake()
		{
			List<float> weightsList = new List<float>();
			Collectables.ForEach((collectable) => weightsList.Add(collectable.Weight));
			weights = weightsList.ToArray();
			
			EventBus.EventBus.Sub(Handle, EventBus.EventBus.MOB_KILLED);
		}

		private void Handle()
		{
			Spawn(PickRandomPosition());
		}

		private Vector3 PickRandomPosition()
		{
			var vector3 = new Vector3();
			vector3.x = Random.value * 11 - 6;
			vector3.z = Random.value * 11 - 6;
			return vector3;
		}

		private void Spawn(Vector3 position)
		{
			CollectableData selected = Collectables[Choose(weights)]; 
			if (selected.Collectable.TryGetComponent<WeaponPowerUp>(out var weaponPowerUp))
			{
				if (Player.Player.Instance.CurrentWeaponType == weaponPowerUp.Type)
				{
					Spawn(PickRandomPosition());
					return;
				}
			}
			Instantiate(selected.Collectable, position, Quaternion.identity);
		}

		int Choose (float[] weightsArray) {

			float total = 0;
			foreach (float weight in weightsArray) 
			{
				total += weight;
			}

			float randomPoint = Random.value * total;
			for (int i= 0; i < weightsArray.Length; i++)
			{
				if (randomPoint < weightsArray[i]) 
				{
					return i;
				}

				randomPoint -= weightsArray[i];
			}
			return weightsArray.Length - 1;
		}
	}
}