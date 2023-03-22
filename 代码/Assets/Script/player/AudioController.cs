using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioController instance { get; private set; }
    public AudioSource _audioSource;
    public AudioClip[] Clips;
    void Start()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is callled once per frame
    public void PlayAudio(int id,Transform transform)
    {
        //AudioSource.PlayClipAtPoint(Clips[id],transform.position,1);
        _audioSource.PlayOneShot(Clips[id]);
    }
}
