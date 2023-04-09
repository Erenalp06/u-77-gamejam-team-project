using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSlider : MonoBehaviour
{

    public GameObject recScreenPanel, startRecordingText;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            SliderMovement.Instance.isMoving = true;
            recScreenPanel.SetActive(true);
            StartCoroutine(showRecordingText());
        }

    }

    IEnumerator showRecordingText(){
        startRecordingText.SetActive(true);
        print("kayıt başladı");
        yield return new WaitForSeconds(1.5f);
        startRecordingText.SetActive(false);
    }
}
