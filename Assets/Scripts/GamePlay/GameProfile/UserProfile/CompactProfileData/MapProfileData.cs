using UnityEngine;
using System.Collections;

public class MapProfileData
{
	public int m;//mainMission
	public int f;//firstMission
	public int s;//secondMission

	public void saveDefaultValue ()
	{
		this.m = 0;
		this.f = 0;
		this.s = 0;
	}
}
