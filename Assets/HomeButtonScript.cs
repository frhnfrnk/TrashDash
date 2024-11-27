using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonScript : MonoBehaviour
{
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
