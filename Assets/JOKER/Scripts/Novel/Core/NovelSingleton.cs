using UnityEngine;
using System.Collections;
using Novel;

namespace Novel{

	// Singletonクラスです。
	public class NovelSingleton
	{
		private static GameManager gameManager;
		private static GameView gameView;
		private static ImageManager imageManager;
		private static ScenarioManager scenarioManager;
		private static StatusManager statusManager;
		private static AudioManager audioManager;
		private static EventManager eventManager;
		private static SaveManager saveManager;


		// コンストラクタです。(外部からのアクセス不可)
		private NovelSingleton()
		{
			//Debug.Log ("console start ");
		}

		public static void clearSingleton(){
			gameManager = null;
			gameView = null;
			imageManager = null;
			scenarioManager = null;
			statusManager = null;
			audioManager= null;
			eventManager= null;
			saveManager= null;
		}

		// 唯一のインスタンスを取得します。
		public static GameManager GameManager
		{
			get{

				if(gameManager == null) gameManager = new GameManager();
				
				return gameManager;
				
			}
		}
		
		
		// 唯一のインスタンスを取得します。
		public static GameView GameView
		{
			get{
				
				if(gameView == null) gameView = new GameView();
				
				return gameView;
				
			}
		} 

		public static ImageManager ImageManager
		{
			get{
				
				if(imageManager == null) imageManager = new ImageManager();
				
				return imageManager;
				
			}
		} 

		public static ScenarioManager ScenarioManager
		{
			get{

				if(scenarioManager == null) scenarioManager = new ScenarioManager();

				return scenarioManager;

			}
		} 

		public static StatusManager StatusManager
		{
			get{

				if(statusManager == null) statusManager = new StatusManager();

				return statusManager;

			}
		} 

		public static AudioManager AudioManager
		{
			get{

				if(audioManager == null) audioManager = new AudioManager();

				return audioManager;

			}
		} 

		public static EventManager EventManager
		{
			get{

				if(eventManager == null) eventManager = new EventManager();

				return eventManager;

			}
		} 

		public static SaveManager SaveManager
		{
			get{

				if(saveManager == null) saveManager = new SaveManager();

				return saveManager;

			}
		} 

		
	}

}

