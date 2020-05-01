using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    void Start()
    {
        
    }

    void Update() {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement() {
        float forwardTranslation = Input.GetAxis("Vertical");
        float lateralTranslation = Input.GetAxis("Horizontal");

        forwardTranslation *= Time.deltaTime;
        lateralTranslation *= Time.deltaTime;

        transform.Translate(new Vector3(lateralTranslation, 0, forwardTranslation));
    }
}
