using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MoviePlayer : MonoBehaviour {

    // VideoPlayerのコンポーネント
    private VideoPlayer moviePlayer;
    // AudioSourceのコンポーネント
    private AudioSource audioSource;
    // 内部に保存したテクスチャを表示する
    public RawImage rawImage;

	// Use this for initialization
	void Start () {

        moviePlayer = GetComponent<VideoPlayer>();
        // スクリプトでAudioOutputModeをAudioSourceに変更
        moviePlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        audioSource = GetComponent<AudioSource>();
        //
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
