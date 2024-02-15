using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRedirect : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void Click()
    {
        SceneManager.LoadScene(sceneName);
    }
}
