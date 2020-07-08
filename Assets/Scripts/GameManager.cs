using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Question")]
    [SerializeField] Image questionImage;
    [SerializeField] Button[] buttons;
    [SerializeField] Button help;

    [Header("Data")]
    public List<QuestionData> allQuestions;

    [Header("Score")]
    [SerializeField] Text trueScore;
    [SerializeField] Text falseScore;
    [SerializeField] Image[] lives;

    QuestionData currentQuestion;
    SceneLoader sceneLoader;

    public int trueAnswer;
    public int falseAnswer;

    private int health = 3;
    private int hintCount;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        SetQuestion();
        DontDestroyOnLoad(this);
        hintCount = 2;
    }

    public void CheckAnswer(int answer)
    {

        if (answer == currentQuestion.rightAnswer)
        {
            trueAnswer++;
        }
        else if (answer != currentQuestion.rightAnswer)
        {
            falseAnswer++;
            health--;
            if (health == 0)
            {
                sceneLoader.LoadLastScene();
            }
        }

        allQuestions.Remove(currentQuestion);
        SetQuestion();
        CheckLives();
        RestartButtons();

        trueScore.text = "RIGHT : " + trueAnswer;
        falseScore.text = "FALSE : " + falseAnswer;

    }
    public void HelpButton()
    {
        if (hintCount != 0)
        {
            hintCount--;
            int counter = 0;

            for (int i = 0; i < buttons.Length; i++)
            {
                if (counter == 2)
                {
                    break;
                }
                Button button = buttons[i];
                if (i != currentQuestion.rightAnswer)
                {
                    button.interactable = false;
                    counter++;


                }

            }
        }
        
    }
    private void RestartButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button button = buttons[i];

            button.interactable = true;



        }
    }

    private void SetQuestion()
    {
        if (allQuestions.Count <= 0)
        {
            sceneLoader.LoadNextLevel();
        }
        else
        {
            int questionIndex = Random.Range(0, allQuestions.Count - 1);
            currentQuestion = allQuestions[questionIndex];
            questionImage.sprite = currentQuestion.image;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = currentQuestion.answer[i].ToUpper();
            }
        }
    }
    private void CheckLives()
    {
        if (health < lives.Length)
        {
            lives[health].enabled = false;
        }

    }


}
