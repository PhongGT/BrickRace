using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected TMP_Text score;
   

    // Update is called once per frame
    void Update()
    {
        UpdateScore(GameManager.Instance.score);
    }
    protected void UpdateScore(int newScore)
    {
        score.text = "Score: " + newScore.ToString();
    }
}
