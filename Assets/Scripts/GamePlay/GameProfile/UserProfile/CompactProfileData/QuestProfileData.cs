using UnityEngine;
using System.Collections;

public class QuestProfileData
{
	public int id;
	public int progress;
	public int aim;
	public int money;
	public int cash;
	public bool receive;
	
	public void generateQuest (int questType)
	{
		id = Random.Range ((int)QuestMenu.QUEST_TYPE.FLY, ((int)QuestMenu.QUEST_TYPE.DESTROY_OBSTACLES) + 1);
		this.progress = 0;
		
		switch ((QuestMenu.QUEST_TYPE)id) {
		case QuestMenu.QUEST_TYPE.FLY:
			this.aim = Random.Range (30, 60);
			break;
			
		case QuestMenu.QUEST_TYPE.USE_NITRO:
			this.aim = Random.Range (120, 180);
			break;
			
		case QuestMenu.QUEST_TYPE.GO_SHORTCUT:
			this.aim = Random.Range (2, 7);
			break;
			
		case QuestMenu.QUEST_TYPE.DRIFT:
			this.aim = Random.Range (60, 120);
			break;
			
		case QuestMenu.QUEST_TYPE.EARN_COINS:
			this.aim = Random.Range (500, 5000);
			break;
			
		case QuestMenu.QUEST_TYPE.EARN_NITRO:
			this.aim = Random.Range (30, 80);
			break;
			
		case QuestMenu.QUEST_TYPE.MAX_SPEED:
			this.aim = Random.Range (300, 500);
			break;
			
		case QuestMenu.QUEST_TYPE.DESTROY_OBSTACLES:
			this.aim = Random.Range (50, 150);
			break;
			
		default:
			break;
		}
		
		switch (questType) {
		case 0:
			this.money = Random.Range (2000, 6000);
			this.cash = Random.Range (0, 2);
			break;
			
		case 1:
			this.money = Random.Range (4000, 10000);
			this.cash = Random.Range (4, 10);
			break;
			
		case 2:
			this.money = Random.Range (1000, 8000);
			this.cash = Random.Range (1, 4);
			break;
			
		default:
			break;
		}
	}
	
	public void updateQuest (Game game, int questType)
	{
		if (questType == 1) {
			if (ProfileManager.userProfile.VipLevel == 0) {
				return;
			}
		}
		
		switch ((QuestMenu.QUEST_TYPE)id) {
		case QuestMenu.QUEST_TYPE.FLY:
			this.progress += (int)game.carManager.MainPlayer.carData.TotalFlyTime;
			break;
			
		case QuestMenu.QUEST_TYPE.USE_NITRO:
			this.progress += (int)game.carManager.MainPlayer.carData.TotalNitroUsingDuration;
			break;
			
		case QuestMenu.QUEST_TYPE.GO_SHORTCUT:
			if (GameData.isGoShortCut == true) {
				this.progress += GameData.numberGoShortCut;
			}
			break;
			
		case QuestMenu.QUEST_TYPE.DRIFT:
			this.progress += (int)game.carManager.MainPlayer.carData.TotalDriftTime;
			break;
			
		case QuestMenu.QUEST_TYPE.EARN_COINS:			
			this.progress += game.carManager.MainPlayer.carData.TotalDollarEarned;
			break;
			
		case QuestMenu.QUEST_TYPE.EARN_NITRO:			
			this.progress += game.carManager.MainPlayer.carData.TotalNumberNitroEarned;
			break;
			
		case QuestMenu.QUEST_TYPE.MAX_SPEED:			
			if (this.progress < GameData.maxVelocityLimit * 3.6f) {
				this.progress = (int)(GameData.maxVelocityLimit * 3.6f);
			}
			break;
			
		case QuestMenu.QUEST_TYPE.DESTROY_OBSTACLES:			
			this.progress += game.carManager.MainPlayer.carData.TotalObstacleCollision;
			break;
			
		default:
			break;
		}
		
		if (this.progress > this.aim) {
			this.progress = this.aim;
		}
	}
}