using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;

    // Takes the initial position of the camera,
    // Then applies it to player's position as offset
    // Gives a nice no-frills follow effect
    public Vector3 offset;

    void Start()
    {
        offset = this.transform.localPosition;
        player = FindObjectOfType<Player>().gameObject;
    }
    void Update()
    {
        transform.position = player.transform.position + offset;

    }
}
