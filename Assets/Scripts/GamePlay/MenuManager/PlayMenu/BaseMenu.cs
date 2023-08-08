using UnityEngine;
using System.Collections;

public abstract class BaseMenu
{
		protected MenuRenderer menuRenderer;
		protected Game game;

		public BaseMenu (MenuRenderer menuRenderer, Game game)
		{
				this.menuRenderer = menuRenderer;
				this.game = game;
		}

		public abstract void render ();
}
