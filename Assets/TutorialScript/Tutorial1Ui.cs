using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1Ui : MonoBehaviour
{
    [SerializeField]
    private Tutorial1 uiCont;
    void Start()
    {
        StartCoroutine("Title");
    }
    private IEnumerator Title()
    {
        yield return new WaitForSeconds(1.0f);
        uiCont.state = 1;
        yield return new WaitForSeconds(3.0f);
        uiCont.state = 2;
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("Title");
    }
}
