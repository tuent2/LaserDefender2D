using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{   
    private int currentScore =0;
    static ScoreKeeper scoreKeeperInstance;
    void Awake() {
        ManagerScoreKeeperSingleToon();
    }
    void ManagerScoreKeeperSingleToon(){
        if(scoreKeeperInstance !=null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            scoreKeeperInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
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
    
}
