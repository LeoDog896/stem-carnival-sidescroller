using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweening : MonoBehaviour
{
    /*
     * Ease in out quint easing function
     */
    public static float EaseInOutQuint(float x)
    {
        if (x < 0.5f)
        {
            return 16 * Mathf.Pow(x, 5);
        }
        else
        {
            return 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
        }
    }

    /**
     * Lerps a value from start to end
     * 
     * @param start The start value
     * @param end The end value
     * @param t The time passed
     * @param time The time to lerp for
     * @param ease The easing function to use
     * 
     * @return The lerped value
     */

    public static float Lerp(float start, float end, float t, float time = 1f, System.Func<float, float> ease = null)
    {
        var easeFunction = ease ?? EaseInOutQuint;
        return Mathf.Lerp(start, end, Mathf.Clamp(easeFunction(t / time), 0, 1));
    }
}
