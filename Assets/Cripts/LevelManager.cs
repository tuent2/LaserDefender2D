using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
   [SerializeField] float sceneLoadDelay =2f;
   ScoreKeeper scoreKeeper;
   void Awake(){
      scoreKeeper = FindObjectOfType<ScoreKeeper>();
   }
   public void LoadGame(){
      scoreKeeper.resetScore();
      SceneManager.LoadScene(0);
   }
   public void LoadMainMenu(){
      SceneManager.LoadScene(2);
   }

   public void LoadGameOver(){
      StartCoroutine(WaitAndLoad(1,sceneLoadDelay));

   }

   IEnumerator WaitAndLoad(int sceneIndex,float delay){
      yield return new WaitForSeconds(delay);
      SceneManager.LoadScene(sceneIndex);
   }

   public void QuitGame(){
      Application.Quit();
   }
}
