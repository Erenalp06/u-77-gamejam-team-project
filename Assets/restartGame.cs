using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
    
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            characterController.Instance.hurted = true;
            Collectibles.lives--;
            Collectibles.iconYoutube = 0;
            print("hurted : " + characterController.Instance.hurted);
            AudioManager.Instance.PlaySFX("character-dead");
            AudioManager.Instance.musicSource.mute = true;
            StartCoroutine(WaitForSecondMethod());

        }

        IEnumerator WaitForSecondMethod(){
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    }
}
