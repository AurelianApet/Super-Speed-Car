using UnityEngine;
using System.Collections;

public class Effect2DRenderer : BaseMenu
{
	Rect leftNitroFlareEffect;
	Rect rightNitroFlareEffect;
	float tempWidth;
	float tempHeight;

	//
	Rect brokenEffect;
	bool isBroken;
	float lastBroken;
	Color tintColor;
	
	public Effect2DRenderer (MenuRenderer menuRenderer, Game game):base(menuRenderer,game)
	{	
		leftNitroFlareEffect = new Rect (0, 0, menuRenderer.flareEffect.width, menuRenderer.flareEffect.height);
		rightNitroFlareEffect = new Rect (0, 0, menuRenderer.flareEffect.width, menuRenderer.flareEffect.height);
				
		tempWidth = leftNitroFlareEffect.width / 2;
		tempHeight = Screen.height - leftNitroFlareEffect.height / 2;

		brokenEffect = new Rect ((800 - menuRenderer.brokenGlass.width) / 2, (480 - menuRenderer.brokenGlass.height) / 2,
		                         menuRenderer.brokenGlass.width, menuRenderer.brokenGlass.height);
		isBroken = false;
		tintColor = Color.white;
	}

	public override void render ()
	{
		if (game.carManager.MainPlayer.isNitroUsing () == true) {
			GUI.DrawTexture (leftNitroFlareEffect, menuRenderer.flareEffect);
			GUI.DrawTexture (rightNitroFlareEffect, menuRenderer.flareEffect);
		}

		if (this.isBroken == true) {
			if (Time.timeSinceLevelLoad - lastBroken < 3) {	
				if (tintColor.a > 0) {
					tintColor.a -= Time.deltaTime / 3;
				} else {
					tintColor.a = 0;
				}

				GUI.color = tintColor;
				GUI.DrawTexture (brokenEffect, menuRenderer.brokenGlass);
				GUI.color = Color.white;
			} else {							
				this.isBroken = false;
			}
		}
	}

	public void setNitroFlareEffect (float leftX, float leftY, float rightX, float rightY)
	{
		this.leftNitroFlareEffect.x = leftX - tempWidth;
		this.leftNitroFlareEffect.y = tempHeight - leftY;

		this.rightNitroFlareEffect.x = rightX - tempWidth;
		this.rightNitroFlareEffect.y = tempHeight - rightY;
	}

	public void activateBrokenGlassEffect ()
	{
		if (this.isBroken == false) {
			tintColor = Color.white;
			this.lastBroken = Time.timeSinceLevelLoad;
			this.isBroken = true;
		}
	}
}