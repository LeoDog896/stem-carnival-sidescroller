using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if (countdownManager.noticedByCamera)
        {
            countdownBar.GetComponent<Image>().color = new Color(1, 0, 0, countdownBar.GetComponent<Image>().color.a);
        } else
        {
            countdownBar.GetComponent<Image>().color = new Color(1, 1, 1, countdownBar.GetComponent<Image>().color.a);
        }
    }
}
