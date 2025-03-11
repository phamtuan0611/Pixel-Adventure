using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform targetPosition; 
    public float moveSpeed = 2f;

    private Camera mainCamera;
    private bool isMoving = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(MoveCamera());
        }
    }

    IEnumerator MoveCamera()
    {
        isMoving = true;
        Vector3 startPosition = mainCamera.transform.position;
        //Vector3 endPosition = new Vector3(targetPosition.position.x, targetPosition.position.y, mainCamera.transform.position.z);
        Vector3 endPosition = new Vector3(startPosition.x + 32f, startPosition.y, mainCamera.transform.position.z);


        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        mainCamera.transform.position = endPosition;
        isMoving = false;
    }
}
