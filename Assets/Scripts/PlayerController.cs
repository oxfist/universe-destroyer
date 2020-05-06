using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameplayConfigurationType gameplayConfiguration;
    public float movementSpeed;

    [SerializeField]
    private Transform weapon;

    [SerializeField]
    private Transform bullet;

    [SerializeField]
    private Transform spawnPoint;


    void Update()
    {
        HandlePlayerMovement();
        HandlePlayerRotation();
        ShootBullet();
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

    private void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Transform bulletTransform = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bulletTransform.gameObject.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(weapon.forward * gameplayConfiguration.bulletSpeed, ForceMode.Impulse);
        }
    }

    
}
