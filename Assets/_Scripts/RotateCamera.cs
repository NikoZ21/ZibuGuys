using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;
    [SerializeField] private float smoothTime = 0.3f;

    private Transform parentTransform;
    private Vector3 currentPosition;
    private Quaternion currentRotation;

    void Start()
    {
        parentTransform = transform.parent;
        currentPosition = transform.position;
        currentRotation = transform.rotation;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Mouse X");

        Quaternion rotationDelta = Quaternion.AngleAxis(horizontalInput * rotationSpeed, rotationAxis);

        Vector3 rotatedPosition = rotationDelta * (currentPosition - parentTransform.position);

        currentPosition = Vector3.Lerp(currentPosition, parentTransform.position + rotatedPosition, 2f);
        currentRotation = Quaternion.Lerp(currentRotation, rotationDelta * currentRotation, 2f);

        var verticalInput = Input.GetAxis("Mouse Y");

        float newRotationAngle = transform.eulerAngles.x - verticalInput * rotationSpeed;

        newRotationAngle = Mathf.Clamp(newRotationAngle, 30, 60f);


        transform.position = currentPosition;
        transform.rotation = currentRotation;


        transform.eulerAngles = new Vector3(newRotationAngle, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
