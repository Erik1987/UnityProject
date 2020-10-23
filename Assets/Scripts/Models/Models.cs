using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Models
    {
        public class RandomModelVectors
        {
            public RandomModelVectors()
            {
                BigRockVectors = new List<Vector2>();
                SmallRock1Vectors = new List<Vector2>();
                SmallRock2Vectors = new List<Vector2>();
                EnemyMeleeVectors = new List<Vector2>();
                EnemyRangedVectors = new List<Vector2>();
            }

            public List<Vector2> BigRockVectors { get; set; }
            public List<Vector2> SmallRock1Vectors { get; set; }
            public List<Vector2> SmallRock2Vectors { get; set; }
            public List<Vector2> EnemyMeleeVectors { get; set; }
            public List<Vector2> EnemyRangedVectors { get; set; }
        }
    }
}