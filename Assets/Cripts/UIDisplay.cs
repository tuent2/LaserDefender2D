using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Heath")]
    [SerializeField] Slider heathSilder;
    [SerializeField] Heath heath;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    private void Awake() {
        
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        heathSilder.maxValue = heath.getHeath();
    }

    
    void Update()
    {
        heathSilder.value = heath.getHeath();
        scoreText.text = scoreKeeper.getCurrentScore().ToString("0000000000000000000");
    }
}
