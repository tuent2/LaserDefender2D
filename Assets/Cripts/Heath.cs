using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int heath = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    [SerializeField] bool applyCameraShake;
    void Awake (){
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null){
            TakeDame(damageDealer.GetDamage());
            playHitEffect();
            ShakeCamera();
            audioPlayer.PlayerGetDamageAudio();
            // heath -=damage.GetDamage();
            damageDealer.Hit();
        }
    }

     void TakeDame(int damageValue)
    {   
        heath -= damageValue;
        if(heath <= 0){
            if(!isPlayer){
                scoreKeeper.setCurrentScore(score);
            }
            Destroy(gameObject);

        }
    }

    void playHitEffect(){
        if(hitEffect !=null){
            ParticleSystem instance = Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera(){
        if(cameraShake !=null && applyCameraShake){
            cameraShake.PlayCameraShake();
        }
    }

    public int getHeath(){
        return heath;
    }
}
