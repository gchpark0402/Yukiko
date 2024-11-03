using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static BGMController Instance
    {
        get
        {
            if (instance == null) return null;
            return instance;
        }
    }

    [SerializeField]
    private AudioClip audio1;
    [SerializeField]
    private AudioClip audio2;
    [SerializeField]
    private AudioClip audio3;
    [SerializeField]
    private AudioClip audio4;

    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = this.gameObject.AddComponent<AudioSource>();
        ChangeBGM(audio1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBGM1()
    {
        ChangeBGM(audio1, 1);
    }

    public void ChangeBGM2()
    {
        ChangeBGM(audio2, 0.5f);
    }

    public void ChangeBGM3()
    {
        ChangeBGM(audio3, 0.5f);
    }

    void ChangeBGM(AudioClip audio, float volume)
    {
        audiosource.clip = audio;
        audiosource.Play();
        audiosource.volume = volume;
    }
}
