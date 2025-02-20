using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public float cameraMoveSpeed = 6.5f;//ī�޶� �̵��ӵ�
    private Vector3 cameraPosition = new Vector3 (0, 0, -10);

    private Transform playerTransform;
   
    private void Awake()
    {
            playerTransform = FindAnyObjectByType<PlayerController>().GetComponent<Transform>();
        }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition,
            Time.deltaTime * cameraMoveSpeed);//�ε巯�� ������
    }
}
