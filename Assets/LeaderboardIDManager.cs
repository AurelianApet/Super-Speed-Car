using UnityEngine;
using System.Collections;

public class LeaderboardIDManager
{
	public static string getLeaderboardID (GameData.GAME_MODE selectedMode, GameData.MAP_NAME selectedMap)
	{
		switch (selectedMode) {
		case GameData.GAME_MODE.CLASSIC:
			{
				switch (selectedMap) {
				case GameData.MAP_NAME.EGYPT:
					return "CgkI1qW1kZAKEAIQBg";

				case GameData.MAP_NAME.INDIA:
					return "CgkI1qW1kZAKEAIQBw";

				case GameData.MAP_NAME.BRAZIL:
					return "CgkI1qW1kZAKEAIQCA";

				case GameData.MAP_NAME.CHINA:
					return "CgkI1qW1kZAKEAIQCQ";

				case GameData.MAP_NAME.VIET_NAM:
					return "CgkI1qW1kZAKEAIQCg";

				case GameData.MAP_NAME.PHILIPPINES:
					return "CgkI1qW1kZAKEAIQCw";

				case GameData.MAP_NAME.THAILAND:
					return "CgkI1qW1kZAKEAIQDA";

				case GameData.MAP_NAME.USA:
					return "CgkI1qW1kZAKEAIQDQ";

				default:				
					return "";
				}
			}

		case GameData.GAME_MODE.ELIMINATION:
			{
				switch (selectedMap) {
				case GameData.MAP_NAME.EGYPT:
					return "CgkI1qW1kZAKEAIQDg";
				
				case GameData.MAP_NAME.INDIA:
					return "CgkI1qW1kZAKEAIQDw";
				
				case GameData.MAP_NAME.BRAZIL:
					return "CgkI1qW1kZAKEAIQEA";
				
				case GameData.MAP_NAME.CHINA:
					return "CgkI1qW1kZAKEAIQEQ";
				
				case GameData.MAP_NAME.VIET_NAM:
					return "CgkI1qW1kZAKEAIQEg";
				
				case GameData.MAP_NAME.PHILIPPINES:
					return "CgkI1qW1kZAKEAIQEw";
				
				case GameData.MAP_NAME.THAILAND:
					return "CgkI1qW1kZAKEAIQFA";
				
				case GameData.MAP_NAME.USA:
					return "CgkI1qW1kZAKEAIQFQ";
				
				default:				
					return "";
				}
			}

		case GameData.GAME_MODE.CHECK_POINT:
			{
				switch (selectedMap) {
				case GameData.MAP_NAME.EGYPT:
					return "CgkI1qW1kZAKEAIQFg";
				
				case GameData.MAP_NAME.INDIA:
					return "CgkI1qW1kZAKEAIQFw";
				
				case GameData.MAP_NAME.BRAZIL:
					return "CgkI1qW1kZAKEAIQGA";
				
				case GameData.MAP_NAME.CHINA:
					return "CgkI1qW1kZAKEAIQGQ";
				
				case GameData.MAP_NAME.VIET_NAM:
					return "CgkI1qW1kZAKEAIQGg";
				
				case GameData.MAP_NAME.PHILIPPINES:
					return "CgkI1qW1kZAKEAIQGw";
				
				case GameData.MAP_NAME.THAILAND:
					return "CgkI1qW1kZAKEAIQHA";
				
				case GameData.MAP_NAME.USA:
					return "CgkI1qW1kZAKEAIQHQ";
				
				default:				
					return "";
				}
			}

		case GameData.GAME_MODE.TIME_TRIAL:
			{
				switch (selectedMap) {
				case GameData.MAP_NAME.EGYPT:
					return "CgkI1qW1kZAKEAIQHg";
				
				case GameData.MAP_NAME.INDIA:
					return "CgkI1qW1kZAKEAIQHw";
				
				case GameData.MAP_NAME.BRAZIL:
					return "CgkI1qW1kZAKEAIQIA";
				
				case GameData.MAP_NAME.CHINA:
					return "CgkI1qW1kZAKEAIQIQ";
				
				case GameData.MAP_NAME.VIET_NAM:
					return "CgkI1qW1kZAKEAIQIg";
				
				case GameData.MAP_NAME.PHILIPPINES:
					return "CgkI1qW1kZAKEAIQIw";
				
				case GameData.MAP_NAME.THAILAND:
					return "CgkI1qW1kZAKEAIQJA";
				
				case GameData.MAP_NAME.USA:
					return "CgkI1qW1kZAKEAIQJQ";
				
				default:				
					return "";
				}
			}

		default:
			return "";
		}
	}
}