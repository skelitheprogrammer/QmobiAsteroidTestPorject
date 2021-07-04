using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//could use new Input system but think its overkill for this project
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _keycodeMove = KeyCode.W;
    public KeyCode KeycodeMove => _keycodeMove;

    [SerializeField] private KeyCode _keycodeRotateLeft = KeyCode.A;
    public KeyCode KeycodeRotateLeft => _keycodeRotateLeft;

    [SerializeField] private KeyCode _keycodeRotateRight = KeyCode.D;
    public KeyCode KeycodeRotateRight => _keycodeRotateRight;

    [SerializeField] private KeyCode _keycodeShoot = KeyCode.LeftControl;
    public KeyCode KeycodeShoot => _keycodeShoot;

    [SerializeField] private KeyCode _keycodeWarp = KeyCode.Space;
    public KeyCode KeycodeWarp => _keycodeWarp;

}
