using UnityEngine;
using System.Collections;

public class LevelDescription
{
	public static void configLevel (int level)
	{
		int map = level + 1;
		switch (map) {
		case 1:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 1;
			break;
		case 2:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 3:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 4:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 50;	
			GameData.durationSecond = 55;	
			GameData.durationThird = 60;	
			break;
		case 5:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 6:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 50;	
			GameData.durationSecond = 55;	
			GameData.durationThird = 60;	
			break;
		case 7:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;
			break;
		case 8:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 9:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 10:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 50;	
			GameData.durationSecond = 53;	
			GameData.durationThird = 58;		
			break;
		//--------------------------------------------------------------------------------
		case 11:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 100;	
			GameData.durationSecond = 105;	
			GameData.durationThird = 110;	
			break;
		case 12:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 13:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 6;
			break;
		case 14:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 50;	
			GameData.durationSecond = 55;	
			GameData.durationThird = 60;
			break;
		case 15:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 16:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 17:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 8;
			break;
		case 18:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 19:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			break;
		case 20:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 21:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 8;
			break;
		case 22:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 1;
			break;
		//--------------------------------------------------------------------------------
		case 23:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 7;
			break;
		case 24:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 25:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			GameData.numberCheckpoints = 8;
			break;
		case 26:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 45;	
			GameData.durationSecond = 50;	
			GameData.durationThird = 55;	
			break;
		case 27:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 28:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 48;	
			GameData.durationSecond = 53;	
			GameData.durationThird = 58;
			break;
		case 29:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;			
			break;
		case 30:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 31:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 48;	
			GameData.durationSecond = 53;	
			GameData.durationThird = 58;		
			break;
		case 32:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;
			GameData.numberCheckpoints = 8;
			break;
		case 33:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 34:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 35:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 48;	
			GameData.durationSecond = 53;	
			GameData.durationThird = 58;	
			break;
		case 36:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		//--------------------------------------------------------------------------------
		case 37:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 38:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			break;
		case 39:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 12;
			break;
		case 40:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 44;	
			GameData.durationSecond = 49;	
			GameData.durationThird = 54;
			break;
		case 41:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 42:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 44;	
			GameData.durationSecond = 49;	
			GameData.durationThird = 54;		
			break;
		case 43:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;		
			break;
		case 44:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 7;
			break;
		case 45:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;		
			break;
		case 46:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 47;	
			GameData.durationSecond = 52;	
			GameData.durationThird = 57;
			break;
		case 47:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 48:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;
			break;
		case 49:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 12;
			break;
		case 50:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 51:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 44;	
			GameData.durationSecond = 49;	
			GameData.durationThird = 54;		
			break;
		case 52:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 12;
			break;
		//--------------------------------------------------------------------------------		
		case 53:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 54:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 55:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;
			GameData.numberCheckpoints = 12;
			break;
		case 56:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 47;	
			GameData.durationSecond = 52;	
			GameData.durationThird = 57;
			break;
		case 57:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 58:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 43;	
			GameData.durationSecond = 47;	
			GameData.durationThird = 52;
			break;
		case 59:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;
			break;
		case 60:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;
			GameData.numberCheckpoints = 12;
			break;
		case 61:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;		
			break;
		case 62:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 46;	
			GameData.durationSecond = 51;	
			GameData.durationThird = 56;		
			break;
		case 63:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;		
			break;
		case 64:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;		
			break;
		case 65:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 4;	
			GameData.numberCheckpoints = 17;
			break;
		case 66:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 47;	
			GameData.durationSecond = 52;	
			GameData.durationThird = 57;
			break;
		case 67:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 10;
			break;
		case 68:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 69:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;		
			break;
		case 70:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 45;	
			GameData.durationSecond = 50;	
			GameData.durationThird = 57;
			break;
		//--------------------------------------------------------------------------------					
		case 71:
			GameData.selectedMap = GameData.MAP_NAME.PHILIPPINES;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 5;
			break;
		case 72:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			break;
		case 73:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 4;		
			GameData.numberCheckpoints = 18;
			break;
		case 74:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 45;	
			GameData.durationSecond = 50;	
			GameData.durationThird = 52;
			break;
		case 75:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 76:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 43;	
			GameData.durationSecond = 47;	
			GameData.durationThird = 52;		
			break;
		case 77:
			GameData.selectedMap = GameData.MAP_NAME.PHILIPPINES;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 13;
			break;
		case 78:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 79:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;		
			break;
		case 80:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 46;	
			GameData.durationSecond = 51;	
			GameData.durationThird = 55;
			break;
		case 81:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 82:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 10;
			break;
		case 83:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			break;
		case 84:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 45;	
			GameData.durationSecond = 47;	
			GameData.durationThird = 55;
			break;
		case 85:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 15;
			break;
		case 86:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;		
			break;
		case 87:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			break;
		case 88:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 40;	
			GameData.durationSecond = 45;	
			GameData.durationThird = 50;
			break;
		//--------------------------------------------------------------------------------					
		case 89:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;
			break;
		case 90:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 91:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;
			GameData.numberCheckpoints = 10;
			break;
		case 92:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 42;	
			GameData.durationSecond = 47;	
			GameData.durationThird = 50;
			break;
		case 93:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			GameData.numberCheckpoints = 10;
			break;
		case 94:
			GameData.selectedMap = GameData.MAP_NAME.PHILIPPINES;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 95:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 42;	
			GameData.durationSecond = 50;	
			GameData.durationThird = 53;
			break;
		case 96:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 3;
			GameData.numberCheckpoints = 15;
			break;
		case 97:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			break;
		case 98:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 99:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 36;	
			GameData.durationSecond = 40;	
			GameData.durationThird = 45;
			break;
		case 100:
			GameData.selectedMap = GameData.MAP_NAME.PHILIPPINES;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 12;
			break;
		case 101:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 42;	
			GameData.durationSecond = 46;	
			GameData.durationThird = 50;	
			break;
		case 102:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;
			break;
		case 103:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 15;
			break;
		case 104:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 105:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 42;	
			GameData.durationSecond = 46;	
			GameData.durationThird = 48;	
			break;
		case 106:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			break;
		//--------------------------------------------------------------------------------							
		case 107:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			break;
		case 108:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;		
			break;
		case 109:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 10;
			break;
		case 110:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 40;	
			GameData.durationSecond = 42;	
			GameData.durationThird = 46;
			break;
		case 111:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 112:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 10;
			break;
		case 113:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;		
			break;
		case 114:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 3;
			GameData.numberCheckpoints = 15;
			break;
		case 115:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;	
			break;
		case 116:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 32;	
			GameData.durationSecond = 42;	
			GameData.durationThird = 45;	
			break;
		case 117:
			GameData.selectedMap = GameData.MAP_NAME.PHILIPPINES;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 118:
			GameData.selectedMap = GameData.MAP_NAME.USA;
			GameData.selectedMode = GameData.GAME_MODE.CLASSIC;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 2;
			break;
		case 119:
			GameData.selectedMap = GameData.MAP_NAME.VIET_NAM;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 15;
			break;
		case 120:
			GameData.selectedMap = GameData.MAP_NAME.THAILAND;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;
			break;
		case 121:
			GameData.selectedMap = GameData.MAP_NAME.BRAZIL;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 6;
			GameData.numberRaces = 3;	
			GameData.numberCheckpoints = 15;
			break;
		case 122:
			GameData.selectedMap = GameData.MAP_NAME.EGYPT;
			GameData.selectedMode = GameData.GAME_MODE.ELIMINATION;

			GameData.numberPlayers = 6;	
			break;
		case 123:
			GameData.selectedMap = GameData.MAP_NAME.INDIA;
			GameData.selectedMode = GameData.GAME_MODE.CHECK_POINT;

			GameData.numberPlayers = 5;
			GameData.numberRaces = 2;	
			GameData.numberCheckpoints = 10;
			break;
		case 124:
			GameData.selectedMap = GameData.MAP_NAME.CHINA;
			GameData.selectedMode = GameData.GAME_MODE.TIME_TRIAL;

			GameData.numberPlayers = 1;
			GameData.numberRaces = 1;
			GameData.durationFirst = 32;	
			GameData.durationSecond = 36;	
			GameData.durationThird = 40;
			break;
		//--------------------------------------------------------------------------------							
		default:
			break;
		}
	}
}