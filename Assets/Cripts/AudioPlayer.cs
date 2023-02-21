using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shotting")]
    [SerializeField] AudioClip shottingClip;
    [SerializeField][Range(0f, 1f)] float shottingVolume = 1f;
    [Header("PlayerGetDamage")]
    [SerializeField] AudioClip playerGetDamageClip;
    [SerializeField][Range(0f, 1f)] float playerGetDamageVolume = 1f;
    static AudioPlayer instance;
    void Awake()
    {
        ManageSingleton();
    }
    // void ManageSingleton()
    // {
    //     int instanceCount = FindObjectsOfType(GetType()).Length;
    //     if (instanceCount > 1)
    //     {
    //         gameObject.SetActive(false);
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    void ManageSingleton()
    {
        if(instance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
  
    public void PlayShootingClip()
    {
        // if(shottingClip != null){
        //     AudioSource.PlayClipAtPoint(shottingClip,Camera.main.transform.position,shottingVolume);
        // }
        playClip(shottingClip, shottingVolume);
    }

    public void PlayerGetDamageAudio()
    {
        playClip(playerGetDamageClip, playerGetDamageVolume);
    }
    void playClip(AudioClip clip, float valume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, valume);
        }
    }
}
