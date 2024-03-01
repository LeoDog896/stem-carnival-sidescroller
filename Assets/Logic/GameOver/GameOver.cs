using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Image panel;
    [SerializeField] private TMP_Text text;

    [SerializeField] private CountdownManager countdownManager;
    private bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (countdownManager.countdownTime <= 0.0f)
        {
            if (!triggered)
            {
                StartGameOver();
            }
            triggered = true;
        }
    }

    void StartGameOver()
    {

    }
}
