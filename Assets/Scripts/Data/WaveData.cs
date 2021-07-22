using System.Collections.Generic;

namespace Myproject.Data
{
	[System.Serializable]
	public class WaveData
	{
		public List<MobData> WaveMobNCount;
	}

	[System.Serializable]
	public class MobData
	{
		public Mob.Mob Mob;
		public int Count;
	}
}