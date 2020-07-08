using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text rightScore;
    [SerializeField] Text badScore;

    GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        SetScore(gm.trueAnswer, gm.falseAnswer);
    }

    private void SetScore(int right,int bad)
    {
        rightScore.text = "RIGHT : " + right;
        badScore.text = "FALSE : " + bad;
    }
}
