using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] protected Color color;

    public static GameManager Instance;

    public int[] characterBrickCount;

    public int score = 0;
    void Start()
    {
        color = new Color();
        characterBrickCount = new int[3];
        if(PlayerPrefs.HasKey("score"))
        score = PlayerPrefs.GetInt("score");
        // 0: Red, 1: Green, 2: Blue, 3:Yellow
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame

    public int RandomColor()
    {
        int count = color.Total();
        int random = Random.Range(0, count+1);
        //Debug.Log(random);
        if (random >= 0 && random < color.numbRed && color.numbRed != 0)
        {
            color.Lost(0);
            return 0;
        }
        else if (random >= color.numbRed && random < (color.numbRed + color.numbGreen) && color.numbGreen != 0 )
        {
            color.Lost(1);
            return 1;
        }
        else if (random >= (color.numbRed + color.numbGreen) && random < (color.Total()-color.numbYellow) && color.numbBlue!= 0)
        {

            color.Lost(2);
            return 2;
        }
        else 
        {
            color.Lost(3);
            return 3;
        }
        
            
     
    }
    private void OnApplicationQuit()
    {

        PlayerPrefs.SetInt("score", score);
        
    }

    [System.Serializable] protected class Color
    {
        public int numbRed;
        public int numbGreen;
        public int numbBlue;
        public int numbYellow;

        public Color() 
        {
            numbRed = 25; 
            numbGreen = 25; 
            numbBlue = 25;
            numbYellow = 25;
        }
        public int Total()
            { return numbRed + numbBlue + numbGreen + numbGreen+ numbYellow; }

        public void Lost(int i)
        {
            if (i == 0) {
                
                    numbRed--;
                }
            else if (i == 1) {
                    numbGreen--;
                }
                else if (i == 2) {
                    numbBlue--;

                }
                else if (i == 3) {
                    numbYellow--;

                }
            }
        public void Gain(int i)
        {
            if (i == 0) {
                
                    numbRed++;
                }
            else if (i == 1) {
                    numbGreen++;
                }
            else if (i == 2) {
                numbBlue++;

            }
            else if (i == 3) {
                numbYellow++;

            }
        }
        public string  Debug()
        {
            string a = "R" + ": " + numbRed.ToString() + ": " + numbGreen.ToString() + ": " + numbBlue.ToString() + ": " + numbYellow.ToString() + "\n";
            return a;
        }
   
    }
}    

