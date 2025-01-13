using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] protected Color color;

    public static GameManager Instance;
    void Start()
    {
        color = new Color();
        
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int RandomColor()
    {
        int count = color.Total();
        int random = Random.Range(0, count+1);
        Debug.Log(color.Debug());
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

