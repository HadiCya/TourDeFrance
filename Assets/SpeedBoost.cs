using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // make sure object is a bike
        if (!other.CompareTag("Bike")) return;

        other.GetComponent<Rigidbody>().AddForce(other.transform.forward * 1000, ForceMode.Acceleration);
        Debug.Log("Hit a speed boost");
    }
}
