using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectTileFrefab;
    [SerializeField] float projectTileSpeed = 10f;
    [SerializeField] float projectTileLifeTime = 5f;
    [SerializeField] float basefiringRate =  0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake() {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }
    void Start()
    {
        if(useAI){
            isFiring = true;
        }
    }

    
    void Update()
    {
        Fire();
    }

    void Fire(){
        if (isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously(){
        while(true) {
            GameObject instance = Instantiate(projectTileFrefab
            ,transform.position
            ,Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb!=null){
                rb.velocity=transform.up * projectTileSpeed;
            }

            Destroy(instance,projectTileLifeTime);
            float TimeToNextProjectTile = Random.Range(basefiringRate- firingRateVariance, basefiringRate+firingRateVariance);
            TimeToNextProjectTile = Mathf.Clamp(TimeToNextProjectTile,minimumFiringRate,float.MaxValue);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(TimeToNextProjectTile);
        }
    }
}
