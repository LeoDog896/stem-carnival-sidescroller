using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CameraHandler cameraHandler;

    void Start()
    {
        var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardWASD", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "KeyboardArrows", pairWithDevice: Keyboard.current);

        cameraHandler.players = new PlayerInput[2] { player1, player2 };
    }
}
