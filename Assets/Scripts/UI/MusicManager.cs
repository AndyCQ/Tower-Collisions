using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public static MusicManager instance;
    public static string currScene = "";
    public static AudioSource currBGM = null;

    void Awake()
    {
        if(instance == null){
            instance = this;
        } else{
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);

        print(sounds.Length);
        print(sounds[0].clip);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.group;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void FixedUpdate(){
        BGM();
    }

    void BGM(){
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName != currScene){
            if(currBGM != null){
                currBGM.Stop();
            }
            if(sceneName == "StartMenu"){
                currBGM = PlayBGM("StartMenu");
            }
            if(sceneName == "MainMenu"){
                currBGM = PlayBGM("MainMenu");
            }
            if(sceneName == "WinScreen"){
                currBGM = PlayBGM("WinScreen");
            }
            currScene = sceneName;
        }
    }
    public void PlaySoundEffects(string name){
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }
    public AudioSource PlayBGM(string name){
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
        return s.source;
    }
}
