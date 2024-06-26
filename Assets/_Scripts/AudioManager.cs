using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource menuMusic, levelSelectMusic;
    public AudioSource[] bgm;

    private int currentBGM;
    private bool playingBGM;

    public AudioSource[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playingBGM)
        {
            if (bgm[currentBGM].isPlaying ==  false )
            {
                currentBGM++;
                if(currentBGM >= bgm.Length)
                {
                    currentBGM = 0;
                }

                bgm[currentBGM].Play();
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                bgm[currentBGM].Stop();
            }
        }
    }

    public void StopMusic()
    {
        menuMusic.Stop();
        levelSelectMusic.Stop();

        foreach(AudioSource track in bgm)
        {
            track.Stop();
        }
        playingBGM = false;
    }

    public void PlayMenuMusic()
    {
        StopMusic();
        menuMusic.Play();
    }

    public void PlayLevelSelectMusic()
    {
        StopMusic();
        levelSelectMusic.Play();
    }

    public void PlayBGM()
    {
        StopMusic();

        currentBGM = Random.Range(0, bgm.Length);

        bgm[currentBGM].Play();
        playingBGM = true;
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
