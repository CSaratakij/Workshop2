using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("General Setting")]
    [SerializeField]
    float moveSpeed = 8.0f;

    [SerializeField]
    float jumpSpeed = 10.0f;

    [SerializeField]
    float gravity = -9.8f;

    [SerializeField]
    float gravityMultipiler = 1.0f;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float rotationRate = 0.25f;

    [Header("UI")]
    [SerializeField]
    InGameUIController ingameUI;

    Vector3 inputVector;
    Vector3 nonZeroInputVector;
    Vector3 velocity;

    CharacterController characterController;

    void Awake()
    {
        Initialize();
    }

    void Update()
    {
        InputHandler();
        MoveHandler();
    }

    void LateUpdate()
    {
        RotateHandler();
    }

    // Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) {
            // TODO
            Debug.Log("Found a coin...");
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Enemy")) {
            //TODO
            // Show UI here
            ingameUI.Show();

            // Game Over
            gameObject.SetActive(false);
        }
    }

    /*
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Coin")) {
            Debug.Log("Stay on a coin...");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin")) {
            Debug.Log("Exit on a coin...");
        }
    }
    */

    // Collision
    /* void OnCollisionEnter(Collision other) */
    /* void OnCollisionStay(Collision other) */
    /* void OnCollisionExit(Collision other) */

    void Initialize()
    {
        characterController = GetComponent<CharacterController>();
    }

    void InputHandler()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.z = Input.GetAxisRaw("Vertical");

        inputVector = Vector3.ClampMagnitude(inputVector, 1.0f);

        if (inputVector.sqrMagnitude > 0.1f) {
            nonZeroInputVector = inputVector;
        }
    }

    void MoveHandler()
    {
        if (characterController.isGrounded && velocity.y < 0) {
            velocity.y = 0;
        }

        velocity.x = inputVector.x * moveSpeed;
        velocity.z = inputVector.z * moveSpeed;

        if (Input.GetButtonDown("Jump") && characterController.isGrounded) {
            velocity.y = jumpSpeed;
        }

        velocity.y += (gravity * gravityMultipiler) * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void RotateHandler()
    {
        Quaternion lookDirection = Quaternion.LookRotation(nonZeroInputVector);
        Quaternion result = Quaternion.Slerp(transform.rotation, lookDirection, rotationRate);
        transform.rotation = result;
    }
}

