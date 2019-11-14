using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform : MonoBehaviour
{
    public GameObject p1;
    public Avatar p1_avatar;
    public GameObject p2;
    public Avatar p2_avatar;

    public GameObject player;
    private GameObject model;

    public int flag = 0;




    // Start is called before the first frame update
    void Start()
    {
        model = Instantiate(p2);
        gameObject.GetComponent<Animator>().avatar=p2_avatar;
    
        // player.GetComponent<Animator>().avatar = p2_avatar;
        model.transform.SetParent (player.transform);
        model.transform.localPosition = new Vector3 (0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position=model.transform.position;
        //Debug.Log(player.transform.position);
        if (Input.GetKeyDown(KeyCode.X)){
            flag++;
            
            if (flag % 2 == 0){
                Destroy(model);
                model = Instantiate(p2);
                gameObject.GetComponent<Animator>().avatar=p2_avatar;
                // Destroy(p1_avatar);

                //player.GetComponent<Animator>().avatar = p2_avatar;
              
            }else{
                Destroy(model);

                model = Instantiate(p1);
                gameObject.GetComponent<Animator>().avatar=p1_avatar;
                // Destroy(p2);
                // Destroy(p2_avatar);
                // p2.SetActiveRecursively(false);
                // p1.SetActiveRecursively(true);

                // player.GetComponent<Animator>().avatar = p1_avatar;             
            }
            model.transform.SetParent (player.transform);
            model.transform.localPosition = new Vector3 (0, 0, 0);


             gameObject.GetComponent<Animator>().Rebind();


        }
        
    }
}
