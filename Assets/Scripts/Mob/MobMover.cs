using Myproject.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Myproject.Mob
{
	public class MobMover : MonoBehaviour, IMobComponent
	{
		[SerializeField] private float SightDistance = 5f;
		[SerializeField] private float MoveSpeed;
		private Vector3 targetPosition = Vector3.zero;
		public bool Active = true;

		private void Awake()
		{
			PickRandomPosition();
			EventBus.EventBus.Sub(OnDeath, EventBus.EventBus.PLAYER_DEATH);
		}

		private void OnDestroy()
		{
			EventBus.EventBus.Unsub(OnDeath, EventBus.EventBus.PLAYER_DEATH);
		}

		private void Update()
		{
			if (Active)
			{
				var playerDistance = (transform.position - Player.Player.Instance.transform.position).Flat().magnitude;
				var targetDistance = (transform.position - targetPosition).Flat().magnitude;
				if (SightDistance >= playerDistance)
				{
					targetPosition = Player.Player.Instance.transform.position;
				}
				else if (targetDistance < 0.2f)
				{
					PickRandomPosition();
				}

				var direction = (targetPosition - transform.position).Flat().normalized;

				transform.SetPositionAndRotation(transform.position + direction * Time.deltaTime * MoveSpeed,
					Quaternion.LookRotation(direction, Vector3.up));
			}

			GetComponent<MobAnimator>().SetIsRun(Active);
		}


		private void PickRandomPosition()
		{
			targetPosition.x = Random.value * 11 - 6;
			targetPosition.z = Random.value * 11 - 6;
		}

		public void OnDeath()
		{
			enabled = false;
		}
	}
}