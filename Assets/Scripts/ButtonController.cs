using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Sprite newSprite;
    private Image buttonImage;
    private Sprite originalSprite;

    public int index;

    private bool isMuted;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalSprite = buttonImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSprite(){
        
        if(!isMuted){
            buttonImage.sprite = newSprite;
            isMuted = true;
            if(index == 0){
                UIController.Instance._musicSlider.value = 0;
            }else if(index == 1){
                UIController.Instance._sfxSlider.value = 0;
            }
        }else{
            buttonImage.sprite = originalSprite;
            isMuted = false;
        }

    }
}
