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

    [SerializeField]
    public Dictionary<string,AudioClip> SoundTrack;
    void Awake(){
        if(instance!=null){
            Destroy(this.gameObject);
        }else{
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        music=GetComponent<AudioSource>();
    }
    public void playSoundAtPoint(AudioClip audio,Vector3 pos){
        Sounds.transform.position=pos;
        Sounds.PlayOneShot(audio);
    }
    public void playDialogueAtPoint(AudioClip audio,Vector3 pos){
      Dialogue.transform.position=pos;
        Dialogue.PlayOneShot(audio);
    }
    public void changeMusic(AudioClip audio)
    {
        music.clip=audio;
        music.Play();
        music.loop=true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
