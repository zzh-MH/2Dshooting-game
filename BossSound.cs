using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;

    public float timeBetweenSoundEffect;
    private float nextSoundEffect;
    // Start is called before the first frame update

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.time >= nextSoundEffect)
        {
            int randomNumber = Random.Range(0, clips.Length);
            source.clip = clips[randomNumber];
            source.Play();
            nextSoundEffect = Time.time + timeBetweenSoundEffect;

        }

       
    }
}
