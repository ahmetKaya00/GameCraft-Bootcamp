using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Hareket ve Fizik")]
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _Xspeed = 6f;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _jump = 1f;

    [Header("Zemin Kontrol")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    [Header("UI Elemanlarý")]
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Button jumpButton;

    [Header("Yön ve Yer Çekimi")]
    Vector3 _velocity;
    bool isGround;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        jumpButton.onClick.AddListener(Jump);
    }
    private void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGround && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = movementJoystick.Horizontal;
        float z = movementJoystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        if (z > 0.8f)
        {
            characterController.Move(move * _Xspeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(move * _speed * Time.deltaTime);
        }

        _velocity.y += _gravity * Time.deltaTime;
        characterController.Move(_velocity * Time.deltaTime);
    }
    private void Jump()
    {
        if (isGround)
        {
            _velocity.y = Mathf.Sqrt(_jump * -2f * _gravity);
        }
    }
}
