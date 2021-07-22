using Myproject.EventBus;
using Myproject.EventBus.Messages;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Myproject.Systems
{
	public class MobSpawner : Handler<SpawnMobMessage>
	{
		protected override void Awake()
		{
			base.Awake();
			EventBus.EventBus.Sub(Unsub, EventBus.EventBus.PLAYER_DEATH);
		}

		public override void HandleMessage(SpawnMobMessage message)
		{
			var position = new Vector3(Random.value * 11 - 6, 1, Random.value * 11 - 6);
			Instantiate(message.Type, position, Quaternion.identity);
		}
	}
}