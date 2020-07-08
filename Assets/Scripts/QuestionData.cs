using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestionData")]
public class QuestionData : ScriptableObject
{
    public Sprite image;
    public string[] answer;
    public int rightAnswer;

}
