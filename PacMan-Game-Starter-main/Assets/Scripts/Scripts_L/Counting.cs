using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counting : MonoBehaviour
{
    private int score = 0;
    private double health = 3;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;
    public float megaTimer = 20;
    public float invulnTimer = 2;
    float elapsedTime = 0;
    float elapsedInvulnTime = 0;
    bool powerup = false;
    bool invuln= false;

    // Start is called before the first frame update
    void Start()
    {
        countText.text = "Score = " + score.ToString();
        healthText.text = "Health = " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerup == true)
        {
            gameObject.tag = "MegaPac";
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= megaTimer)
            {
                gameObject.tag = "Player";
                elapsedTime = 0;
                powerup = false;
            }
        }
        if (invuln == true)
        {
            elapsedInvulnTime += Time.deltaTime;
            if(elapsedInvulnTime >= invulnTimer)
            {
                elapsedInvulnTime = 0;
                invuln = false;
            }
        }
        if(health == 0)
        {
            EndGame();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MegaPellet"))
        {
            score += 10;
            health += 3;
            if (health > 3) health = 3; 
            countText.text = "Score = " + score.ToString();
            healthText.text = "Health = " + health.ToString();
            powerup = true;
        }
        Collision(other);
    }
    void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
    void Collision(Collider other)
    {
        if (powerup == true)
        {
            if (other.gameObject.CompareTag("Pellet"))
            {
                score += 5;
                countText.text = "Score = " + score.ToString();
                healthText.text = "Health = " + health.ToString();
            }
        }
        else if (invuln == true)
        {
            if (other.gameObject.CompareTag("Pellet"))
            {
                score += 5;
                countText.text = "Score = " + score.ToString();
                healthText.text = "Health = " + health.ToString();
            }
            if (other.gameObject.CompareTag("Junk"))
            {
                score -= 1;
                health -= 1;
                if (health < 0) health = 0;
                countText.text = "Score = " + score.ToString();
                healthText.text = "Health = " + health.ToString();
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Pellet"))
            {
                score += 5;
                countText.text = "Score = " + score.ToString();
            }
            if (other.gameObject.CompareTag("Junk"))
            {
                score -= 1;
                health -= 1;
                if (health < 0) health = 0;
                countText.text = "Score = " + score.ToString();
                healthText.text = "Health = " + health.ToString();
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                health -= 1;
                if (health < 0) health = 0;

                healthText.text = "Health = " + health.ToString();
                invuln = true;
            }
        }
    }
}
