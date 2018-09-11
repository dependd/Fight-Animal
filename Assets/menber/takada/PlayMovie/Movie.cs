using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movie : MonoBehaviour {

    enum Mode
    {
        Plane,
        RawImage
    }

    // PlaneとRawImageで切り替え
    [SerializeField]
    private Mode mode;
    // 再生する動画
    [SerializeField]
    private MovieTexture[] movies;
    // 音声再生コンポーネント
    private AudioSource audioSource;
    // 再生する音声
    [SerializeField]
    private AudioClip[] audioClip;
    // 動画番号
    private int num;

	// Use this for initialization
	void Start () {
        // 最初の動画を設定
        num = 0;
        if(mode == Mode.Plane)
        {
            GetComponent<MeshRenderer>().material.mainTexture = movies[num];
        } else {
            GetComponent<RawImage>().texture = movies[num];
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip[num];

        movies[num].Play();
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
