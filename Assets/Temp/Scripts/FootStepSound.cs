using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Step()
    {
        AudioClip clip = clips[UnityEngine.Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip);
    }


    public void FootprintSound()
    {
        Step();
    }
}
