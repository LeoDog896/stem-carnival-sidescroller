using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    public float startCountdownTime = 60f;
    public float countdownTime;

    public bool noticedByCamera = false;

    void Start()
    {
        countdownTime = startCountdownTime;
    }

    void Update()
    {
        countdownTime -= Time.deltaTime * (noticedByCamera ? 5 : 1);
        countdownTime = Mathf.Max(0, countdownTime);

        // M:SS:MSS
        countdownText.text = $"{Mathf.Floor(countdownTime / 60):00}:{Mathf.Floor(countdownTime % 60):00}:{Mathf.Floor((countdownTime * 100) % 100):00}";

        if (countdownTime <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
