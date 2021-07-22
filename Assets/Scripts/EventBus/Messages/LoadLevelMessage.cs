namespace Myproject.EventBus.Messages
{
	public class LoadLevelMessage : Message
	{
		public int LevelIndex { get; private set; }

		public LoadLevelMessage(int levelIndex)
		{
			LevelIndex = levelIndex;
		}
	}
}