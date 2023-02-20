using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    [SerializeField] GameObject projectTileFrefab;
    [SerializeField] float projectTileSpeed = 10f;
    [SerializeField] float projectTileLifeTime = 5f;
    [SerializeField] float firingRate =  0.2f;
    public bool isFiring;
    Coroutine firingCoroutine;
    void Start()
    {
        
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
            GameObject instance = Instantiate(projectTileFrefab, transform.position,Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb!=null){
                rb.velocity=transform.up * projectTileSpeed;
            }
            Destroy(instance,projectTileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
