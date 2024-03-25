using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuButton : MonoBehaviour
{
    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
