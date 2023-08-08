using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ID_Pool
{
		public const int EMPTY = -1;
		private List<UniqueID> idList;

		public ID_Pool ()
		{
		}

		public ID_Pool (int size)
		{
				idList = new List<UniqueID> (size);

				for (int i=0; i<idList.Capacity; i++) {
						idList.Add (new UniqueID (i));
				}
		}

		public void customInit (int size)
		{
				idList = new List<UniqueID> (size);
		}

		public void customAdd (int id)
		{
				idList.Add (new UniqueID (id));
		}

		public void removeID (int id)
		{
				UniqueID needRemoved = null;
				for (int i=0; i<idList.Count; i++) {
						if (id == idList [i].id) {
								needRemoved = idList [i];
								break;
						}
				}

				idList.Remove (needRemoved);
		}

		public int allocateID ()
		{
				if (idList.Count > 0) {
						UniqueID uniqueID = idList [Random.Range (0, idList.Count)];
						idList.Remove (uniqueID);
			
						return uniqueID.id;
				} else {
						return EMPTY;
				}
		}
	
		public int getLength ()
		{
				return idList.Count;
		}

		public class UniqueID
		{
				public int id;

				public UniqueID (int id)
				{
						this.id = id;
				}
		}
}