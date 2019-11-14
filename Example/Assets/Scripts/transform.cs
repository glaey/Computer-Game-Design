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
    model = Instantiate(p1);
    gameObject.GetComponent<Animator>().avatar = p1_avatar;

    // player.GetComponent<Animator>().avatar = p2_avatar;
    model.transform.SetParent(player.transform);
    model.transform.localPosition = new Vector3(0, 0, 0);

  }

  // Update is called once per frame
  void Update()
  {
    player.transform.position = model.transform.position;
    if (Input.GetKeyDown(KeyCode.X))
    {
      flag++;
      if (flag % 2 == 1)
      {
        Destroy(model);
        model = Instantiate(p2);
        gameObject.GetComponent<Animator>().avatar = p2_avatar;
        model.transform.SetParent(player.transform);
        model.transform.localPosition = new Vector3(0, 0, 0);
      }
      else
      {
        Destroy(model);
        model = Instantiate(p1);
        gameObject.GetComponent<Animator>().avatar = p1_avatar;
              model.transform.SetParent(player.transform);
      model.transform.localPosition = new Vector3(0, 0, 0);

      }



      gameObject.GetComponent<Animator>().Rebind();


    }

  }
}
