using UnityEngine;
using System.Collections;

namespace Novel{

	public class Validate  {

		public static string  checkStorage(string storage){

			Sprite g = Resources.Load<Sprite> (storage);

			Debug.Log (g);

			if (g == null) {
				return "ファイル「"+storage+"」が存在しません\n";
			}

			return "";
			
		}



	}

}
