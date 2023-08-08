using UnityEngine;
using System.Collections;

public class RankingRow : MonoBehaviour
{
	public RankingMenu rankingMenu;

	//
	public dfLabel posLabel;
	public dfLabel nameLabel;
	public dfLabel starLabel;
	public dfLabel scoreLabel;
	public dfPanel background;

	//
	public dfLabel titleLabel;
	public dfTextureSprite titleIcon;
	public dfSprite starIcon;
	public dfTextureSprite flagIcon;

	public void setVisible (bool value)
	{
		posLabel.IsVisible = value;
		nameLabel.IsVisible = value;
		starLabel.IsVisible = value;
		scoreLabel.IsVisible = value;

		titleLabel.IsVisible = value;
		titleIcon.IsVisible = value;

		background.IsVisible = value;

		starIcon.IsVisible = value;
		starIcon.IsVisible = value;
	}

	public void updateMyPositionScore (HighScoreUserInfo highScoreUserInfo)
	{
		this.posLabel.Text = highScoreUserInfo.rank;
		this.nameLabel.Text = highScoreUserInfo.username;		
		this.starLabel.Text = highScoreUserInfo.level;
		this.scoreLabel.Text = highScoreUserInfo.score;

		this.titleLabel.Text = RewardData.getTitleText (RewardData.getTitleID (int.Parse (highScoreUserInfo.score)));
		this.titleIcon.Texture = rankingMenu.titleImage [RewardData.getTitleID (int.Parse (highScoreUserInfo.score))];

		int flag = 84;
		try {
			flag = int.Parse (highScoreUserInfo.nation);
		} catch {
			flag = 84;
		}
		this.flagIcon.Texture = rankingMenu.flagImage [flag];
	}

	public void updateMyPositionScore (UserScore userScore, int pos)
	{
		this.posLabel.Text = (pos + 1).ToString ();
		this.nameLabel.Text = userScore.username;		
		this.starLabel.Text = userScore.level;
		this.scoreLabel.Text = userScore.score;

		this.titleLabel.Text = RewardData.getTitleText (RewardData.getTitleID (int.Parse (userScore.score)));
		this.titleIcon.Texture = rankingMenu.titleImage [RewardData.getTitleID (int.Parse (userScore.score))];

		int flag = 0;
		try {
			flag = int.Parse (userScore.nation);
		} catch {
			flag = 84;
		}
		this.flagIcon.Texture = rankingMenu.flagImage [flag];
	}
}