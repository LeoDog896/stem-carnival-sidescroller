using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject gameObject = collider.gameObject;
        Carry carry = gameObject.GetComponent<Carry>();

        if (carry != null)
        {
            GameObject carriedObject = carry.carriedObject;
            if (carriedObject != null)
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
        
    }
}
