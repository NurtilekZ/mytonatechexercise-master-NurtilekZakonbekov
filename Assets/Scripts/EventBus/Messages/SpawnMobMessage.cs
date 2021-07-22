namespace Myproject.EventBus.Messages
{
	public class SpawnMobMessage : Message
	{
		private const int MELEE = 0;
		private const int RANGE = 1;

		public Mob.Mob Type { get; private set; }

		public SpawnMobMessage(Mob.Mob mobType)
		{
			Type = mobType;
		}
	}
}