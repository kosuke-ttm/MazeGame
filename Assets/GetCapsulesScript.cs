using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetCapsulesScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextCapsuleCount;
    [SerializeField] private int allCapsule = 5;
    private int capsuleCount = 0;

    public AudioClip getSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.gameObject.name == "Capsules")
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(getSound);
            capsuleCount += 1;
            TextCapsuleCount.text = string.Format("Capsule {0}/{1}", capsuleCount, allCapsule);
        }
    }
}
