using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToStart : MonoBehaviour
{
    private bool pressed = false;
    private float passedTime = 0;

    [SerializeField] private RectTransform mainTransform;
    [SerializeField] private RectTransform levelSelect;

    void Start()
    {
        levelSelect.anchoredPosition = new Vector2(
            levelSelect.anchoredPosition.x,
            Screen.height
        );
    }

    void Update()
    {
        var height = Screen.height;
        if (Input.GetKeyDown("space"))
        {
            pressed = true;
        }

        if (pressed)
        {
            passedTime += Time.deltaTime;
            mainTransform.anchoredPosition = new Vector2(
                mainTransform.anchoredPosition.x,
                Tweening.Lerp(
                    0,
                    -Screen.height,
                    passedTime,
                    1f,
                    Tweening.EaseInOutQuint
                )
            );

            levelSelect.anchoredPosition = new Vector2(
                levelSelect.anchoredPosition.x,
                Tweening.Lerp(
                    Screen.height,
                    0,
                    passedTime,
                    1f,
                    Tweening.EaseInOutQuint
                )
            );
        }
    }
}
