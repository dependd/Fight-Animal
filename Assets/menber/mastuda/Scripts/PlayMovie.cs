using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayMovie : MonoBehaviour {
    
    public VideoPlayer mPlayer;

    public RawImage image;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator PlayOnMovie()
    {
        image.color = new Color(255, 255, 255, 255);
        mPlayer.Play();
        yield return new WaitForSeconds(0.5f);
        image.color = new Color(255, 255, 255, 0);
    }
    public void CharaMovies()
    {

    }
}
