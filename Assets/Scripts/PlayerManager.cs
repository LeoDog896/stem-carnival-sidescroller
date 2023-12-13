using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;

    void Start()
    {
        PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardWASD", pairWithDevice: Keyboard.current);
        PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardArrows", pairWithDevice: Keyboard.current);
    }
}
