using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RacingScript : MonoBehaviour
{
    public float laptime;
    private bool startTimer = false;

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
            startTimer = true;
        }
    }
}
