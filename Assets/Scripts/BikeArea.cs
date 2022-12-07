using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeArea : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Bike bike1;
    public Bike bike2;

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveSpeed * Time.deltaTime));
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bike"))
        {
            other.GetComponent<Bike>().TeleportToSpawn();
        }
    }
}
