using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     AudioMixer audioMixer;
    public AudioSource music;
        public AudioSource Sounds;
            public AudioSource Dialogue;
    public static AudioManager instance;
    public Dictionary<string,AudioClip> SoundTrack;
    void Awake(){
        if(instance!=null){
            Destroy(this.gameObject);
        }else{
            instance=this;
        }
    }
    void Start()
    {
        music=GetComponent<AudioSource>();
    }
    public void playSoundAtPoint(AudioClip audio,Vector3 pos){
        float volume;
               Sounds.transform.position=pos;
        audioMixer.GetFloat("Sounds",out volume);
        Debug.Log(volume);
        Sounds.PlayOneShot(audio,Mathf.Pow(10, (volume/20)));
    }
    public void playDialogueAtPoint(AudioClip audio,Vector3 pos){
        Dialogue.transform.position=pos;
        Dialogue.clip=audio;
        Dialogue.Play();
    }
    public void changeMusic(string key){
        music.clip=SoundTrack[key];
        float tempvolume;
        audioMixer.GetFloat("Music",out tempvolume);
        music.volume=tempvolume;
        music.Play();
        music.loop=true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
