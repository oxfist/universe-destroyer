using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameplayConfigurationType gameplayConfiguration;
    public float movementSpeed;

    [SerializeField]
    private Transform weapon;

    void Update()
    {
        HandlePlayerMovement();
        HandlePlayerRotation();
    }

    private void HandlePlayerMovement()
    {
        float forwardTranslation = Input.GetAxis("Vertical");
        float lateralTranslation = Input.GetAxis("Horizontal");

        forwardTranslation *= Time.deltaTime * movementSpeed;
        lateralTranslation *= Time.deltaTime * movementSpeed;

        transform.Translate(new Vector3(lateralTranslation, 0, forwardTranslation));
    }

    private void HandlePlayerRotation() {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        horizontalRotation *= gameplayConfiguration.cameraRotationSpeed;
        verticalRotation *= gameplayConfiguration.cameraRotationSpeed;

        transform.Rotate(0, horizontalRotation, 0);
        weapon.Rotate(-verticalRotation, 0, 0);
    }

    
}
