using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
     private static SoundManager _instance;
    public static SoundManager Instance{
        get{
            if (_instance == null){
                GameObject go = new GameObject("GAMEPLAY MANAGER");
                go.AddComponent<GameplayPartyManager>();
            }
            
            return _instance;
        }
    }
    

    void Awake(){
        if(_instance == null){
            _instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (SoundContainer s in Sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }
    /*

    bool playmusic = true;
    private void Update() {
        if(Input.GetButtonUp("Debug_Button")){
            if(playmusic){
                playmusic = !playmusic;
                Play("Music-Test");
            }
            else{
                playmusic = !playmusic;
                Stop("Music-Test");
            }
        }
    }
    */

    public SoundContainer[] Sounds;

    public void Play(string name){
        SoundContainer s = Array.Find(Sounds, Sounds => Sounds.name == name);
        s.source.Play();
    }

    public void Stop(string name){
        SoundContainer s = Array.Find(Sounds, Sounds => Sounds.name == name);
        s.source.Stop();

    }



}
