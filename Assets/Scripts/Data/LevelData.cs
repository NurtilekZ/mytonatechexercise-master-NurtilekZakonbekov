using System.Collections.Generic;
using UnityEngine;

// Bonus!
// Create and use namespace Myproject in whole solution with appropriate subspaces 
namespace Myproject.Data
{
	[CreateAssetMenu(menuName = "Data/LevelData")]
	public class LevelData : ScriptableObject
	{
		public int Index;

		public bool[,] GetMap()
		{
			bool[,] map = new bool[12, 12];
			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					map[i, j] = CharMap[i*12+j] == '1';
				}
			}

			return map;
		}

		[HideInInspector] public string CharMap;

		public List<WaveData> WaveDatas;
		public float WaveInterval = 5f;
	}
}