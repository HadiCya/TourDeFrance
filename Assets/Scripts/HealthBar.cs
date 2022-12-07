using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    Player player;
    [SerializeField]
    TMPro.TextMeshProUGUI curHealthText;

    // Start is called before the first frame update
    void Start()
    {
        if (slider == null || player == null) return;

        slider.minValue = 0;
        slider.maxValue = player.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider == null || player == null) return;

        slider.value = player.GetCurHealth();
        curHealthText.text = player.GetCurHealth().ToString();
    }
}
