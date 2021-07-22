using System;
using Myproject.Collectables;
using UnityEngine;

namespace Myproject.Data
{
    [Serializable]
    public class CollectableData
    {
        public Collectable Collectable;
        [Range(0, 100)] public float Weight;
    }
}