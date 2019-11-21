using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dlgTrigger : MonoBehaviour
{
  public mDialogue dialogue;

  public void TriggerDialogue()
  {
    FindObjectOfType<dlgMgr>().StartDialogue(dialogue);
  }

}
