using UnityEngine;
using System.Collections;

public class ObstacleInfo
{
		public enum ObstacleAvoidance
		{
				LEFT,
				RIGHT,
				STRAIGHT
		}
	
		float[] obstacles;
	
		public ObstacleInfo ()
		{
				this.obstacles = new float[3];
		}
	
		public ObstacleAvoidance getAvoidanceDirection ()
		{
				int i;
				int avoidCase = 0;
		
				for (i=0; i<obstacles.Length; i++) {
						if (obstacles [i] > 0) {
								avoidCase = 1;
								break;
						}
				}

				int index;
				float min;
				if (avoidCase == 0) {
						index = -1;
						min = -1;
			
						for (i=0; i<obstacles.Length; i++) {
								if (obstacles [i] < min) {
										min = obstacles [i];
										index = i;
								}
						}
				} else {
						index = 0;
						min = obstacles [0];

						for (i=1; i<obstacles.Length; i++) {
								if (obstacles [i] < min) {
										min = obstacles [i];
										index = i;
								}
						}
				}		

				switch (index) {
				case 0:
						return ObstacleAvoidance.LEFT;
			
				case 1:
						return ObstacleAvoidance.STRAIGHT;
			
				case 2:
						return ObstacleAvoidance.RIGHT;
			
				default:
						return ObstacleAvoidance.STRAIGHT;
				}
		}
	
		public void calculateAvoidancePriority (int layer, float distance, ObstacleAvoidance obstacleAvoidance)
		{
				float value;
				switch (layer) {
				case LayerDefinition.OBSTACLE:
						value = 0;
						break;
			
				case LayerDefinition.MAP:
						value = 0;
						break;
			
				case LayerDefinition.BOUND:
						value = 0;
						break;
			
				case LayerDefinition.PLAYER:
						value = distance;
						break;
			
				case LayerDefinition.ENEMY:
						value = distance;
						break;
			
				default:
						value = 0;
						break;
				}
		
				switch (obstacleAvoidance) {
				case ObstacleAvoidance.LEFT:
						obstacles [0] = value;
						break;			
			
				case ObstacleAvoidance.STRAIGHT:
						obstacles [1] = value;
						break;
			
				case ObstacleAvoidance.RIGHT:
						obstacles [2] = value;
						break;
			
				default:
						break;
				}
		}
}
