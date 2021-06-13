using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject musicPrefab;
    AudioSource musicSource;
    // Start is called before the first frame update
    void Awake()
    {
        musicSource = FindObjectOfType<AudioSource>();
		if (!musicSource)
		{
            musicSource = Instantiate(musicPrefab).GetComponent<AudioSource>();
            DontDestroyOnLoad(musicSource);
		}


    }
}
