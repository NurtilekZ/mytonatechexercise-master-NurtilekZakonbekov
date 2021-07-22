using UnityEngine;

namespace Myproject.EventBus.Handlers
{
	public class ActivateOnEvent : MonoBehaviour
	{
		[SerializeField] private int EventId = 0;
		[SerializeField] private GameObject Button;

		private void Awake()
		{
			EventBus.Sub(HandleMessage, EventId);
		}

		private void OnDestroy()
		{
			EventBus.Unsub(HandleMessage, EventId);
		}


		public void HandleMessage()
		{
			Button.SetActive(true);
		}
	}
}