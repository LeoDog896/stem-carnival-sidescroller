using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private CameraHandler cameraHandler;

    void Start()
    {
        var player1 = PlayerInput.Instantiate(player1Prefab, controlScheme: "KeyboardWASD", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(player2Prefab, controlScheme: "KeyboardArrows", pairWithDevice: Keyboard.current);

        cameraHandler.players = new PlayerInput[2] { player1, player2 };
    }
}
