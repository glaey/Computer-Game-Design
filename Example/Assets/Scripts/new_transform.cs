using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_transform : MonoBehaviour
{
  public GameObject lp;
  public GameObject sheep;


  public int flag = 0;


  // Start is called before the first frame update
  void Start()
  {
    lp = GameObject.Find("lp_guy");
    lp.SetActive(true);
    
    sheep = GameObject.Find("Sheep");
    sheep.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if(lp.activeSelf == true){
      transform.position = lp.transform.position;

    }else{
      transform.position = sheep.transform.position;
    }
    if (Input.GetKeyDown(KeyCode.X))
    {
      flag++;
      if (flag % 2 == 1)
      {
        sheep.transform.position = lp.transform.position;
        lp.SetActive(false);
        sheep.SetActive(true);
        print("transform to sheep");




      }
      else
      {

        lp.transform.position = sheep.transform.position;
        lp.SetActive(true);
        sheep.SetActive(false);


      }
    }

  }
}
