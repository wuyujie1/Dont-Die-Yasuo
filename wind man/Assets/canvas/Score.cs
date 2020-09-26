using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Text txt;
    private static float score = 0f;

    public static void incrementScore()
    {
        score++;
    }

    public static void decrementScore()
    {
        score--;
    }

    public static void resetScore()
    {
        score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("Text").GetComponent<Text>();
        txt.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        Score.txt.text = "Score : " + score.ToString();
    }
}
