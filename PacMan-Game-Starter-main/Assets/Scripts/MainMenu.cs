using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI countText;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (countText)
        {
            countText.text = "Points Collected = " + Count_Collectibles.finalScore;
        }
    }

        public void QuitGameButton()
{
    #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
}
public void StartGameButton()
{
    
    SceneManager.LoadScene(1);
    Count_Collectibles.finalScore = 0;
    }
    public void FirstGameButton()
    {
        SceneManager.LoadScene(2);
    }
    public void ThirdGameButton()
    {
        SceneManager.LoadScene(3);
    }
}