using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float cameraMoveSpeed = 6.5f;//카메라 이동속도
    private Vector3 cameraPosition = new Vector3 (0, 0, -10);

    private Transform playerTransform;
   
    private void Awake()
    {
            playerTransform = FindAnyObjectByType<PlayerController>().GetComponent<Transform>();
        }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition,
            Time.deltaTime * cameraMoveSpeed);//부드러운 움직임
    }
}
