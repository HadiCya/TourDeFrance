using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingScript : MonoBehaviour
{
    public float laptime;
    private bool startTimer = false;
    private bool checkpoint = false;

    public TextMeshProUGUI laptimeText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true) {
            laptime = laptime + Time.deltaTime;

            laptimeText.text = "Time: " + laptime.ToString("F2");
        }
        
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedLine")) {
            if (checkpoint == true)
            {
                startTimer = false;
                Debug.Log("Stopped timer");
            }
            else {
                startTimer = true;
                checkpoint = false;
                Debug.Log("Started timer");
            }
        }

        if (other.gameObject.name == "Checkpoint") {
            Debug.Log("Hit Checkpoint");
            checkpoint = true;
        }
    }
}
