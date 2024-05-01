using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextTutorial;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0F;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 3.0f){
            TextTutorial.text = string.Format("");
        }
    }
}
