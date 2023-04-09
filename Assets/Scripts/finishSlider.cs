using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishSlider : MonoBehaviour
{
    public GameObject recScreenPanel, finishSliderText;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            recScreenPanel.SetActive(false);
            SliderMovement.Instance.isMoving = false;
            StartCoroutine(showFinishText());
        }
    }

    IEnumerator showFinishText(){
        finishSliderText.SetActive(true);
        print("kayıt başladı");
        yield return new WaitForSeconds(1f);
        finishSliderText.SetActive(false);
    }
}
