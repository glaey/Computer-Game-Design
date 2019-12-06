using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
   // [SerializeField] AnimatorFutions animatorFutions;
    [SerializeField] int thisIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menuButtonController.index==thisIndex)
        {
            animator.SetBool("selected",true);
            if(Input.GetAxis("Submit")==1){
                animator.SetBool("pressed",true);
                if(thisIndex==0)
                {SceneManager.LoadScene("Presentation2");}
                else if(thisIndex==1)
                {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;//用于退出运行
                #else
                Application.Quit();
                #endif
                }
            }else if(animator.GetBool("pressed")){
                animator.SetBool("pressed",false);
                //animatorFutions.disableOnce=true;
            }
        }
        else
        {
            animator.SetBool("selected",false);
        }
    }
}
