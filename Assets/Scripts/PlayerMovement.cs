using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationSpeed = 720f;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveVertical  = new InputAction(type: InputActionType.Button);
    void OnEnable()  {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()  {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    void Update() {
        float horizontal = moveHorizontal.ReadValue<float>();
        float vertical = moveVertical.ReadValue<float>();
        Vector2 movementDirection = new Vector2(horizontal, vertical);
        Vector3 movementVector = new Vector3(horizontal, vertical, 0) * movementSpeed * Time.deltaTime;

        movementDirection.Normalize();
        
        transform.position += movementVector;
        
        if (movementDirection != Vector2.zero)
        {
            // transform.forward = movementDirection;
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        //transform.Translate(movementVector);
        // NOTE: "Translate(movementVector)" uses relative coordinates - 
        //       it moves the object in the coordinate system of the object itself.
        // In contrast, "transform.position += movementVector" would use absolute coordinates -
        //       it moves the object in the coordinate system of the world.
        // It makes a difference only if the object is rotated.
    }
}
