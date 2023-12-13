using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownViewer : MonoBehaviour
{

    [SerializeField] private CountdownManager countdownManager;
    [SerializeField] private RectTransform countdownBar;

    // Update is called once per frame
    void Update()
    {
        var ratio = countdownManager.countdownTime / countdownManager.startCountdownTime;
        var screenWidth = Screen.width;
        countdownBar.offsetMax = new Vector2(-screenWidth * (1 - ratio), countdownBar.offsetMax.y);
    }
}
