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

    public GameObject currentNPC;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(GameObject NPC, int statue)
    {
        mDialogue dlg;

        if(statue == 2)
        {
            dlg = NPC.GetComponent<interactible>().dialogue2;
        }else{
                  
            dlg = NPC.GetComponent<interactible>().dialogue1;
        }
        print("NPC" + NPC.name);

        name.text = dlg.name;
        sentences.Clear();

        foreach (string sentence in dlg.sentences)
        {
            sentences.Enqueue(sentence);
        }

    }

    public void DisplayNextSentence(GameObject NPC)
    {
        animator.SetBool("isOpen", true);

        if (sentences.Count == 0)
        {
            EndDialogue(NPC);

            return;
        }

        string sentence = sentences.Dequeue();
        // print(sentence);
        dlgText.text = sentence;
    }

    public void EndDialogue(GameObject NPC)
    {
        animator.SetBool("isOpen", false);

        int s = NPC.GetComponent<interactible>().statue;

        if(NPC.name == "Sheep" && s == 0){
            NPC.GetComponent<interactible>().statue = 1;

        }
        if (NPC.name == "STAG")
        {
            GameObject.Find("Sheep").GetComponent<interactible>().statue = 2;

        }


        print("end of conversation");
    }
}
