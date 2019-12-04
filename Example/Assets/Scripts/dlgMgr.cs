using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dlgMgr : MonoBehaviour
{

  public Text name;
  public Text dlgText;
  public Animator animator;

  public Queue<string> sentences;
  // Start is called before the first frame update
  void Start()
  {
    sentences = new Queue<string>();

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void StartDialogue(mDialogue dlg)
  {
    name.text = dlg.name;
    sentences.Clear();

    foreach (string sentence in dlg.sentences)
    {
      sentences.Enqueue(sentence);
    }

    // DisplayNextSentence();
  }

  public void DisplayNextSentence()
  {
    animator.SetBool("isOpen",true);
    if (sentences.Count == 0)
    {
      EndDialogue();
      return;
    }

    string sentence = sentences.Dequeue();
    // print(sentence);
    dlgText.text = sentence;
  }

  public void EndDialogue()
  {
    print("end of conversation");
    animator.SetBool("isOpen",false);
  }
  
}
