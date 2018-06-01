using UnityEngine;
using System.Collections;
using System;
namespace Novel{

	public enum MessageType {Error,Warning,Info};
	public enum AudioType{Bgm,Sound,Voice}
	public enum FirstAction{Start,Load}


	public class TextEnum{

		public static TextAnchor textAnchor(string key){
			switch(key){
			case "LowerCenter":
				return TextAnchor.LowerCenter;
			case "LowerLeft":
				return TextAnchor.LowerLeft;
			case "LowerRight":
				return TextAnchor.LowerRight;
			case "MiddleCenter":
				return TextAnchor.MiddleCenter;
			case "MiddleLeft":
				return TextAnchor.MiddleLeft;
			case "MiddleRight":
				return TextAnchor.MiddleRight;
			case "UpperCenter":
				return TextAnchor.UpperCenter;
			case "UpperLeft":
				return TextAnchor.UpperLeft;
			case "UpperRight":
				return TextAnchor.UpperRight;
			default:
				return TextAnchor.MiddleCenter;
			}
		}

		public static TextAlignment textAlignment(string key){
			switch (key) {
			case "Center":
				return TextAlignment.Center;
			case "Left":
				return TextAlignment.Left;
			case "Right":
				return TextAlignment.Right;
			default:
				return TextAlignment.Center;
			
			}
		}

	}

}
