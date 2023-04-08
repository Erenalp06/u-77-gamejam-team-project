using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int letterPerSecond;

    [SerializeField] Dialog dialog1;

    [SerializeField] GameObject selectMenu;

    [SerializeField] GameObject spaceKeyImage;
    
    public static DialogManager Instance {get; private set;}

    private int currentLine = 0;

    private bool isTyping;
    
    void Awake()
    {
        Instance = this;
        StartCoroutine(Instance.ShowDialog(dialog1));
        spaceKeyImage.SetActive(true);
        
    }

    public IEnumerator ShowDialog(Dialog dialog){
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1f);
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
        

    }
    

    public IEnumerator TypeDialog(string line){
        isTyping = true;
        dialogText.text = "";
        foreach(var letter in line.ToCharArray()){
            dialogText.text += letter;
            yield return new  WaitForSeconds(1f / letterPerSecond);
        }
        isTyping = false;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isTyping){
            currentLine++;
            if(currentLine < dialog1.Lines.Count){
                StartCoroutine(TypeDialog(dialog1.Lines[currentLine]));
            }else if(currentLine == 6){
                selectMenu.SetActive(true);
                spaceKeyImage.SetActive(false);
            }            
            else{
                dialogBox.SetActive(false);
                currentLine = 0;
                
            }
            print("space");
            
        }
    }
}
