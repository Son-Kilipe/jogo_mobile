using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;


public class Perguntas : MonoBehaviour
{
    //PEGA O API
    private string apiURL = "https://opentdb.com/api.php?amount=15&category=15&difficulty=hard&type=boolean";
    //EXEMPLO DE URL PARA OBTER PERGUNTAS DE MULTIPLA ESCOLHA

    //CRIA A LISTA
    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] options;
        public int correctOptionIndex;

    }

    //CONTROLA A PONTUAÇÃO
    private int point = 0;
    public Text pointText; //Referencia ao elemento texto que exibira a pontuação
    public GameObject ObjQuestion;


    public List<Question> triviaQuestions = new List<Question>();
    public Text questionText; //referencia ao elemento Text onde exibira a pergunta
    public Text[] optionTexts; //Referencia aos elementos Text onde exibira as opcoes

    private int currentQuestionIndex = 0; //indice atual da questao


    void Start()
    {
        ObjQuestion.SetActive(false);
        StartCoroutine(GetTriviaQuestions());
        pointText.text = point.ToString();
        
    }

    IEnumerator GetTriviaQuestions()
    {
        using(UnityWebRequest webRequest = UnityWebRequest.Get(apiURL)) // Se comunica com a API atraves da URL
        {
            yield return webRequest.SendWebRequest(); //Faz a requisicao para AP1

            if (webRequest.result == UnityWebRequest.Result.ConnectionError) //exibe o erro, em casa de erro
            {
                Debug.LogError("Erro de conexão: " + webRequest.error);
            }
            else if (webRequest.result == UnityWebRequest.Result.Success) //Realiza o tratamento das perguntas
            {
                string jsonText = webRequest.downloadHandler.text;

                //Parse JSON
                JSONNode jsonData = JSON.Parse(jsonText);
                JSONArray questionsArray = jsonData["results"].AsArray;

                //Limpa a lista de perguntas
                triviaQuestions.Clear();


                foreach(JSONNode questionData in questionsArray)
                {
                    Question newQuestion = new Question();
                    newQuestion.question = questionData["question"];
                    newQuestion.correctOptionIndex = Random.Range(0, 1); //Escolhe uma opção correta aleatoria
                    
                    newQuestion.options = new string[2];
                    newQuestion.options[newQuestion.correctOptionIndex] = questionData["correct_answer"];
                   
                    for (int i=0, j = 0; i < 2; i++)
                    {
                        if (i != newQuestion.correctOptionIndex)
                        {
                            newQuestion.options[i] = questionData["incorrect_answers"][j];
                            j++;
                        }


                    }
             
                    triviaQuestions.Add(newQuestion);

                }

                NextQuestion();

            }

        }


    }

    void DisplayQuestion(Question question)
    {
        questionText.text = question.question;
        for (int i = 0; i < question.options.Length; i++)
        {
            optionTexts[i].text = question.options[i];
        }

    }

    public void NextQuestion()
    {
        if (currentQuestionIndex < triviaQuestions.Count)
        {
            DisplayQuestion(triviaQuestions[currentQuestionIndex]);
        }
        currentQuestionIndex++;
    }

    public void CheckAnswer(int selectedOptionIndex)
    {
        if (currentQuestionIndex < triviaQuestions.Count)
        {
            if (selectedOptionIndex == triviaQuestions[currentQuestionIndex].correctOptionIndex)
            {
                point++;
                pointText.text = point.ToString();
            }

            if (currentQuestionIndex < triviaQuestions.Count)
            {
                NextQuestion();

            }

        }
        else
        {
            questionText.text = "FIM DAS PERGUNTAS";
            ObjQuestion.SetActive(false);
        }

    }


}
