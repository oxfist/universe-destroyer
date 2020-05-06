using UnityEngine;

[CreateAssetMenu]
public class GameplayConfigurationType : ScriptableObject {
    public float cameraMoveSpeed = 1;                      // How fast the rig will move to keep up with the target's position.
    public float cameraRotationSpeed;
    public float bulletSpeed = 5f;

}
