using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject nextLevelGame;

    public Text text;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Collectibles.iconYoutube == 7){
            AudioManager.Instance.PlaySFX("level-pass");
            StartCoroutine(WaitForSecondMethod());
            print("sonraki level");
            
        }else{
            StartCoroutine(WaitForSecondMethod2());
            print("sonraki level");

        }
    }

    IEnumerator WaitForSecondMethod(){
        text.text = "Tebrikler Videoyu Çektin, Sisteme yükleniyor...";
        nextLevelGame.SetActive(true);
        yield return new WaitForSeconds(1f);
        nextLevelGame.SetActive(false);
        
    }

    IEnumerator WaitForSecondMethod2(){
        text.text = "Hepsini toplamadan bir sonraki bölüme geçemezsin !!";
        nextLevelGame.SetActive(true);
        yield return new WaitForSeconds(1f);
        nextLevelGame.SetActive(false);
        
    }
}
