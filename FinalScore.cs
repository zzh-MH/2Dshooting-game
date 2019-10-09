using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public static int scorevalue;
    Text Finalscore;
    // Start is called before the first frame update
    void Start()
    {
        Finalscore = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Finalscore.text = "Final Score: " + scorecounter.scorevalue;
    }
}
