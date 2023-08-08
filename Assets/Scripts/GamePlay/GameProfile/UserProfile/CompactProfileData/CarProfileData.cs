using UnityEngine;
using System.Collections;

public class CarProfileData
{
		public int b;//isBought
		public int a;//acceleration
		public int s;//speed
		public int h;//handling
		public int n;//nitro
		public int c;//color
		public int bc;//bought color

		//
//		public string u1;
//		public string u2;
//		public string u3;
//		public string u4;

		public void saveDefaultValue (int id)
		{
				if (id == 0) {
						this.b = 1;
				} else {
						this.b = 0;
				}

				this.a = 0;
				this.s = 0;
				this.h = 0;
				this.n = 0;
		
				this.c = 0;
				this.bc = 0;

//				this.u1 = string.Empty;
//				this.u2 = string.Empty;
//				this.u3 = string.Empty;
//				this.u4 = string.Empty;
		}
}