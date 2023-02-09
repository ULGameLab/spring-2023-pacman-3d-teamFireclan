using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FirstPerson()
    {
        SceneManager.LoadScene("FooFighter");
    }
    public void ThirdPerson()
    {
        SceneManager.LoadScene("FooFighter 3P");
    }
}
