using UnityEngine;

namespace Myproject.EventBus.Messages
{
	public class PlayerInputMessage : Message
	{
		public Vector2 MovementDirection { get; private set; }
		public Vector2 AimDirection { get; private set; }
		public bool Fire { get; private set; } = false;

		public PlayerInputMessage(Vector2 move, Vector2 aim, bool fire)
		{
			MovementDirection = move;
			AimDirection = aim;
			Fire = fire;
		}
	}
}