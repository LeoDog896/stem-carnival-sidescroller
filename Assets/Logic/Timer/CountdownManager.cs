using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

        // M:SS:MSS
        countdownText.text = $"{Mathf.Floor(countdownTime / 60):00}:{Mathf.Floor(countdownTime % 60):00}:{Mathf.Floor((countdownTime * 100) % 100):00}";
    }
}
