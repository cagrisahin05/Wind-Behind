using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]  float controlSpeed = 10f;
    [SerializeField]  float zClampRange = 10f;
    [SerializeField]  float yClampRange = 10f;
    [SerializeField]  float controlRollFactor = 20f;
    [SerializeField]  float controlPitchFactor = 20f;
    [SerializeField]  float rotationSpeed = 0f;
    Vector2 movement; 
     void Update()
    {
        ProcessTranslation(); 
        ProcessRotation(); 
    }


    public void OnMove(InputValue value) // Input System ile hareket
    {
        movement = value.Get<Vector2>(); // hareket değerini al
    }
    void ProcessTranslation()
    {
       
        float zOffset = -movement.x * controlSpeed * Time.deltaTime; // A ve D düzgün çalışmayınca - verdim ve z ekseni üzerinde hareket etmesini sağladım
        float rawZPos = transform.localPosition.z + zOffset; // z ekseninde hareket
        float clampedZPos = Mathf.Clamp(rawZPos, -zClampRange, zClampRange); // x ekseninde hareket sınırlaması
        
        float yOffset = movement.y * controlSpeed * Time.deltaTime; // W and S keys for forward and backward
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange); // y ekseninde hareket sınırlaması

        transform.localPosition = new Vector3(transform.localPosition.x  , clampedYPos  , clampedZPos ); // A and D keys for left and right 
    }
    
    void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(controlRollFactor * -movement.x , 0f, 0f); // A and D keys for rotation  
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed); // rotation speed

        Quaternion targetRotation2 = Quaternion.Euler(0f, 0f, controlPitchFactor * movement.y); // W and S keys for rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, Time.deltaTime * rotationSpeed); // rotation speed
    }


}
