using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public static Quiz index;

    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI congratulationsText;
    [SerializeField] private AudioSource congratulationsAudio;

   
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    [SerializeField] List<QuestionSO> Mathquestions = new List<QuestionSO>();
    [SerializeField] List<QuestionSO> CSquestions = new List<QuestionSO>();
    [SerializeField] TextMeshProUGUI levelText; // Add a reference to the level text UI element
    QuestionSO currentQuestion;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Button nextQuestionButton;
    // Add a Level structure and define levels with their properties
    [System.Serializable]
    public struct Level
    {
        public string levelName;
        public int correctAnswersRequired;
        public int correctAnswerReward;
    }
    
    [SerializeField] List<Level> levels;
    
    int correctAnswerReward = 50;
    int wrongAnswerPenalty = 20;

    public static int curQuestionIndex = -1; // We increment 1 before displaying

    void Start()
    {
        string quizType = PlayerPrefs.GetString("QuizType", "Computer Science");
        if (quizType == "Math")
        {
            questions = Mathquestions;
        }
        else
        {
            questions = CSquestions;
        }


        
        GetNextQuestion();
        
        UpdateLevelText();
    }




    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        

        if(index == currentQuestion.getCorrectAnswerIndex())
        {
            GameManager.Instance.correctAnswers++; // Increment the correct answers count
            CheckLevelUp();
            questionText.text = "Correct!";
            GameManager.Instance.AddBalance(correctAnswerReward);
            GameManager.Instance.AddBalance(levels[GameManager.Instance.levelIndex].correctAnswerReward); // Update to use the reward from the levels list
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;;
        }
        else
        {
            int correctAnswerIndex = currentQuestion.getCorrectAnswerIndex();
            string correctAnswer = currentQuestion.getAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;
            //GameManager.Instance.AddBalance(-wrongAnswerPenalty);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
        nextQuestionButton.gameObject.SetActive(true);
    }

    public void OnNextQuestionButtonPressed()
    {
        nextQuestionButton.gameObject.SetActive(false);
        GetNextQuestion();
    }

    void GetNextQuestion()
    {

        if(curQuestionIndex < questions.Count - 1)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            curQuestionIndex++;
            PlayerPrefs.SetInt("Question", curQuestionIndex);
            currentQuestion = questions[curQuestionIndex];
            DisplayQuestion();
        }
        else
        {
            string quizType = PlayerPrefs.GetString("QuizType", "Computer Science");
            if (quizType == "Math")
            {
                questionText.text = "You completed your job! Try Computer Science!";
            }
            else {
                questionText.text = "You completed your job! Try Math!";
            }
                
            SetButtonState(false);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.getQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    void CheckLevelUp()
{
    if (GameManager.Instance.levelIndex < levels.Count - 1 && 
        GameManager.Instance.correctAnswers >= levels[GameManager.Instance.levelIndex + 1].correctAnswersRequired)
    {
        GameManager.Instance.levelIndex++;
        // Remove the line below
        // GameManager.Instance.correctAnswers = 0;
        UpdateLevelText();
         StartCoroutine(DisplayCongratulationsText("Congratulations! You have been promoted to " + levels[GameManager.Instance.levelIndex].levelName + "!"));
        

    }
}


    void UpdateLevelText()
    {

        if (levelText != null)
        {
            levelText.text = "Level: " + levels[GameManager.Instance.levelIndex].levelName;
        }
    }
    IEnumerator DisplayCongratulationsText(string message)
{
    congratulationsAudio.Play();
    congratulationsText.text = message;
    yield return new WaitForSeconds(3);
    congratulationsText.text = "";
     
}

}


