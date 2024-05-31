using UnityEngine;
using TMPro;

public class MathQuestionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TMP_InputField answerInput;
    [SerializeField] TextMeshProUGUI resultText;

    int correctAnswer;
    public static bool correctAnswerGiven = false;

    void Start()
    {
        GenerateQuestion();
        resultText.text = "";
        correctAnswerGiven = false;
    }

    void GenerateQuestion()
    {
        int num1 = Random.Range(1, 10);
        int num2 = Random.Range(1, 10);
        int num3 = Random.Range(1, 10);
        int operation1 = Random.Range(0, 2); // Sadece 0 ve 1 se�enekleri (toplama ve �arpma)

        string operation1Symbol = "";
        string operation2Symbol = "";
        float intermediateResult = 0f;

        switch (operation1)
        {
            case 0:
                intermediateResult = num1 + num2;
                operation1Symbol = "+";
                break;
            case 1:
                intermediateResult = num1 * num2;
                operation1Symbol = "*";
                break;
        }

        correctAnswer = Mathf.RoundToInt(intermediateResult) + num3;
        operation2Symbol = "+"; // Toplama i�lemi yapaca��z

        questionText.text = $"{num1} {operation1Symbol} {num2} {operation2Symbol} {num3} = ?";
    }

    public void CheckAnswer()
    {
        int userAnswer;
        if (int.TryParse(answerInput.text, out userAnswer))
        {
            if (userAnswer == correctAnswer)
            {
                resultText.text = "Do�ru!";
                correctAnswerGiven = true;
                answerInput.text = "";
            }
            else
            {
                resultText.text = "Yanl��. Tekrar deneyin.";
            }
        }
        else
        {
            resultText.text = "L�tfen ge�erli bir say� girin.";
        }
    }
}
