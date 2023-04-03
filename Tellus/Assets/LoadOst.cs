using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOst : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip music;
    void Start()
    {
        AudioManager.instance.changeMusic(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
