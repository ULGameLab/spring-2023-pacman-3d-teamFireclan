using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Count_Collectibles : MonoBehaviour
{
    public static int finalScore;
    public Text countText;
    private float timeLeft;
    private float count;
    public bool Mega = false;
    private float timeRemaining;


    // Start is called before the first frame update
    void Start()
    {
        countText.text = "Score = " + finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= 1f;
        }

        if (timeRemaining <= 0)
        {
            Mega = false;
        }
        if (finalScore >= 100 || finalScore <= -100)
        {
            EndGame();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.CompareTag("Mega Fruit"))
        {
            Mega = true;
            timeRemaining = 1000f;
        }
        
        


        if (Mega)
        {
            allBonus(other);

        }

        if (!Mega)
        {
            normalScore(other);


        }

        



    }

    private void normalScore(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            finalScore += 25;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Banana"))
        {
            finalScore += 10;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Burger"))
        {
            finalScore -= 25;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Ice Cream"))
        {
            finalScore -= 10;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Onion"))
        {
            finalScore -= 5;
            countText.text = "Score = " + finalScore.ToString();
        }
    }

    private void allBonus(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            finalScore += 25;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Banana"))
        {
            finalScore += 10;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Burger"))
        {
            finalScore += 25;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Ice Cream"))
        {
            finalScore += 10;
            countText.text = "Score = " + finalScore.ToString();
        }

        if (other.gameObject.CompareTag("Onion"))
        {
            finalScore += 5;
            countText.text = "Score = " + finalScore.ToString();
        }
    }

    void EndGame()
    {
        Count_Collectibles.finalScore = 0;
        SceneManager.LoadScene("GameEnd");
    }
}