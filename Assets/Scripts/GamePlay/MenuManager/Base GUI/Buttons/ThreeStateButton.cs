using UnityEngine;
using System.Collections;

public class ThreeStateButton
{
		public delegate void ChangeListener (int state);

		private Texture state_0;
		private Texture state_1;
		private Texture state_2;
		//
		private Rect bound;
		private GUIStyle style = new GUIStyle ();
		//
		public ChangeListener changeStateListener;
		private int state;
	
		public ThreeStateButton (Texture state_0, Texture state_1, Texture state_2, Rect bound)
		{
				this.state_0 = state_0;
				this.state_1 = state_1;
				this.state_2 = state_2;
				this.bound = bound;
				this.changeStateListener = defaultChangeState;
		}
	
		public void setState (int state)
		{
				this.state = state;
		}
	
		public void draw ()
		{
				switch (state) {
				case 0:
						if (state_0 != null) {
								if (GUI.Button (bound, state_0, style)) {
										this.state = (this.state + 1) % 3;
					
										if (changeStateListener != null) {
												changeStateListener (this.state);
										}
								}
						}
						break;

				case 1:
						if (state_1 != null) {
								if (GUI.Button (bound, state_1, style)) {
										this.state = (this.state + 1) % 3;
					
										if (changeStateListener != null) {
												changeStateListener (this.state);
										}
								}
						}
						break;

				case 2:
						if (state_2 != null) {
								if (GUI.Button (bound, state_2, style)) {
										this.state = (this.state + 1) % 3;
					
										if (changeStateListener != null) {
												changeStateListener (this.state);
										}
								}
						}
						break;

				default:
						break;
				}
		}
	
		public void defaultChangeState (int state)
		{
				Debug.Log ("Change State");
		}
}
