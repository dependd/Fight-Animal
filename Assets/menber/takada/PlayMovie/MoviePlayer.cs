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
    // 内部スクリプトを出力するUIにTextureをセットしたかどうか
    private bool check = false;

	// Use this for initialization
	void Start () {

        moviePlayer = GetComponent<VideoPlayer>();
        // スクリプトでAudioOutputModeをAudioSourceに変更
        moviePlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        audioSource = GetComponent<AudioSource>();
        // オーディオトラックを有効にする
        moviePlayer.EnableAudioTrack(0, true);
        // AudioputがAudioSourceの時にスクリプトからAudioSourceを設定する
        moviePlayer.SetTargetAudioSource(0, audioSource);
        // スタートしたら再生
        moviePlayer.Play();
	}
	
	// Update is called once per frame
	void Update () {
        //内部保存しているテクスチャを設定
        if(moviePlayer.texture != null && !check)
        {
            rawImage.texture = moviePlayer.texture;
            check = true;
        }
	}
}
