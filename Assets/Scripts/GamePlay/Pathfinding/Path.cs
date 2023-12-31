﻿using UnityEngine;
using System.Collections;

namespace com.dev.util.lib.Pathfinding
{
		public class Path: MonoBehaviour
		{
				public bool isDebug = true;
				public bool isShowWaypoint = true;
				//
				public Color color = Color.white;
				public float defaultRadius = 1;
				public Waypoint[] waypointList = new Waypoint[0];
				float[] distanceList;
				//
				private int selectedWaypoint = 0;
	
				public int SelectedWaypoint {
						get {
								if (isValidWaypointIndex (selectedWaypoint)) {
										return selectedWaypoint;
								} else {
										selectedWaypoint = 0;
										return selectedWaypoint;
								}
						}
						set {
								selectedWaypoint = value;
						}
				}
				//
				Color sphereColor;
				Gizmos gizmo;
				int i;

				void Start ()
				{
						this.distanceList = new float[waypointList.Length];
						for (i=0; i<this.waypointList.Length-1; i++) {
								this.distanceList [i] = Vector3.Distance (waypointList [i].waypointPos, waypointList [i + 1].waypointPos);
						}
						this.distanceList [this.waypointList.Length - 1] = Vector3.Distance (waypointList [0].waypointPos,
			                                                                waypointList [this.waypointList.Length - 1].waypointPos);
				}
	
				void OnDrawGizmos ()
				{			
						if (this.isShowWaypoint == true) {
								sphereColor = color;
								sphereColor.a = 0.5f;
								Gizmos.color = sphereColor;

								for (i = 0; i <waypointList.Length-1; i++) {
										if (waypointList [i].useDefault == false) {
												Gizmos.DrawWireSphere (waypointList [i].waypointPos, waypointList [i].radius);
										} else {
												Gizmos.DrawWireSphere (waypointList [i].waypointPos, defaultRadius);
										}
										Debug.DrawLine (waypointList [i].waypointPos, waypointList [i + 1].waypointPos, color);
								}
		
								if (waypointList.Length > 0) {
										if (waypointList [waypointList.Length - 1].useDefault == false) {
												Gizmos.DrawWireSphere (waypointList [waypointList.Length - 1].waypointPos, 
				                       		waypointList [waypointList.Length - 1].radius);
										} else {
												Gizmos.DrawWireSphere (waypointList [waypointList.Length - 1].waypointPos, defaultRadius);
										}
								}
								Gizmos.color = Color.white;
						}
				}
	
				public bool isValidWaypointIndex (int index)
				{
						if (index > -1 && index < waypointList.Length) {
								return true;
						} else {
								return false;
						}
				}
	
				public bool isReachWaypoint (Vector3 position, int waypointIndex)
				{
						if (isValidWaypointIndex (waypointIndex)) {
								if (waypointList [waypointIndex].useDefault == false) {
										return waypointList [waypointIndex].isReachWaypoint (position);
								} else {
										return waypointList [waypointIndex].isReachWaypoint (position, defaultRadius);
								}
						} else {
								return false;
						}
				}
		
				public bool isReachAnyWaypointExcept (Vector3 position, int nextWaypoint, int currentWaypoint)
				{
						for (int i = 0; i <waypointList.Length; i++) {
								if (i != nextWaypoint && i != currentWaypoint) {
										if (waypointList [i].isReachWaypoint (position)) {
												return true;
										}
								}
						}

						return false;
				}
		
				public bool isReachWaypoint (Vector3 position, int waypointIndex, float customRadius)
				{
						if (isValidWaypointIndex (waypointIndex)) {
								return waypointList [waypointIndex].isReachWaypoint (position, customRadius);
						} else {
								return false;
						}
				}
	
				public void insert ()
				{
						if (isValidWaypointIndex (selectedWaypoint)) {
								Waypoint[] tempWaypoint = new Waypoint[waypointList.Length + 1];
			
								int j = 0;
								for (int i = 0; i <tempWaypoint.Length; i++) {
										if (i == selectedWaypoint) {
												tempWaypoint [i] = new Waypoint ();
												tempWaypoint [i].waypointPos = waypointList [selectedWaypoint].waypointPos;
					
												tempWaypoint [i].waypointPos.x -= 1f;
												tempWaypoint [i].waypointPos.z -= 1f;
					
										} else {
												tempWaypoint [i] = waypointList [j];
												j++;
										}
								}
								waypointList = tempWaypoint;
						} else {
								selectedWaypoint = 0;
								if (waypointList.Length == 0) {
										waypointList = new Waypoint[1];
										waypointList [0] = new Waypoint ();
										waypointList [0].waypointPos = transform.position;
								}
						}
				}
	
				public void delete ()
				{
						if (isValidWaypointIndex (selectedWaypoint)) {
								Waypoint[] tempWaypoint = new Waypoint[waypointList.Length - 1];
			
								int j = 0;
								for (int i = 0; i <waypointList.Length; i++) {
										if (i != selectedWaypoint) {
												tempWaypoint [j] = waypointList [i];
												j++;
										}
								}
								waypointList = tempWaypoint;
						} else {
								selectedWaypoint = 0;
						}
				}
	
				public float getDistance (int start, int destination, int numberRace)
				{
						if (isValidWaypointIndex (start) == true && isValidWaypointIndex (destination) == true) {
								float distance = 0;
			
								if (start <= destination) {
										for (int i=start; i<destination; i++) {
												distance += Vector3.Distance (waypointList [i].waypointPos,
					                              waypointList [i + 1].waypointPos);
										}
										distance += numberRace * getPathLength ();
								} else {
										int i;
										for (i=0; i<destination; i++) {
												distance += Vector3.Distance (waypointList [i].waypointPos,
					                              waypointList [i + 1].waypointPos);
										}
				
										for (i=start; i<waypointList.Length-1; i++) {
												distance += Vector3.Distance (waypointList [i].waypointPos,
					                              waypointList [i + 1].waypointPos);
										}
										distance += Vector3.Distance (waypointList [0].waypointPos, 
				                              waypointList [waypointList.Length - 1].waypointPos);
										distance += numberRace * getPathLength ();
								}
			
								return distance;
						} else {
								Debug.Log ("Invalid waypoint index");
								return 0;
						}
				}

				public float fastGetDistance (int start, int destination, int numberRace)
				{
						if (isValidWaypointIndex (start) == true && isValidWaypointIndex (destination) == true) {
								float distance = 0;
				
								if (start <= destination) {
										for (int i=start; i<destination; i++) {
												distance += distanceList [i];
										}
										distance += numberRace * getPathLength ();
								} else {
										int i;
										for (i=0; i<destination; i++) {
												distance += distanceList [i];
										}
					
										for (i=start; i<waypointList.Length-1; i++) {
												distance += distanceList [i];
										}

										distance += distanceList [waypointList.Length - 1];
										distance += numberRace * getPathLength ();
								}
				
								return distance;
						} else {
								Debug.Log ("Invalid waypoint index");
								return 0;
						}
				}

				public void moveAllWaypoints (float deltaX, float deltaY, float deltaZ)
				{
						Vector3 delta = new Vector3 (deltaX, deltaY, deltaZ);
						for (int i=0; i<waypointList.Length; i++) {
								waypointList [i].waypointPos += delta;
						}
				}
	
				public float getPathLength ()
				{
						float distance = 0;
						for (int i=0; i<waypointList.Length-1; i++) {
								distance += Vector3.Distance (waypointList [i].waypointPos,
			                              waypointList [i + 1].waypointPos);
						}
						distance += Vector3.Distance (waypointList [0].waypointPos,
		                              waypointList [waypointList.Length - 1].waypointPos);
		
						return distance;
				}
	
				public int getPreviousWaypoint (int index)
				{
						if (index == 0) {
								return waypointList.Length - 1;
						} else {
								return index - 1;
						}
				}

				public int getPreviousWaypoint (int index, int offset)
				{
						if (index < offset) {
								return waypointList.Length - 1 - (offset - index - 1);
						} else {
								return index - offset;
						}
				}
	
				public int getNextWaypoint (int index)
				{
						return (index + 1) % waypointList.Length;
				}
		}
}