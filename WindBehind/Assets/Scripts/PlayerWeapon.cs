using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour 
{   
    [SerializeField] RectTransform crosshair; // crosshair tanımlaması
    [SerializeField] GameObject[] lasers; // lazer array tanımlaması
    [SerializeField] Transform targetPoint; // hedef nokta tanımlaması
    [SerializeField] float targetDistance = 10f; // hedef mesafesi tanımlaması
    bool isFiring = false;  // ateş etme durumu

    void Update()
    {
        ProcessFiring(); 
        MoveCrosshair();
        MoveToTarget();
        AimLasers();
    }

    public void OnFire(InputValue value) // ateş etme
    {                               
        isFiring = value.isPressed; // ateş etme durumu
       
    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers) // lazer array içinde dön
        {
            
            var emissionModule = laser.GetComponent<ParticleSystem>().emission; // particle system emission module
            emissionModule.enabled = isFiring; // emission module enabled
        }
    }
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition; // mouse takip
    }
    void MoveToTarget()
    {
        Vector3 targetpointPosition =   new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance); // hedef nokta pozisyonu    
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetpointPosition); // hedef nokta ekranın içinde
    }
    void AimLasers()
    {
        foreach (GameObject laser in lasers) // lazer array içinde dön
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; // hedef nokta ve lazer arasındaki mesafe
            Quaternion lookRotation = Quaternion.LookRotation(fireDirection); // hedef noktaya bakma    
            laser.transform.rotation = lookRotation; // lazerin rotasyonu
        }
    }

}
