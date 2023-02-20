using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{   
    private int currentScore;

    public int getCurrentScore(){
        return currentScore;
    }

    public void setCurrentScore(int score){
        currentScore += score;
        Mathf.Clamp(currentScore,0,int.MaxValue); 
        Debug.Log(currentScore);
    }
    
    public void resetScore(){
        currentScore = 0;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
