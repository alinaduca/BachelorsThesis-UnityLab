//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//public class OpenTheBook : MonoBehaviour
//{
//    public UnityEvent clickEvent = new UnityEvent();
//    public GameObject button;
//    // Start is called before the first frame update
//    void Start()
//    {
//        button = this.gameObject;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//        if (Input.GetMouseButtonDown(0))
//        {
//            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
//            {
//                clickEvent.Invoke();
//            }
//        }
//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenTheBook : MonoBehaviour
{
    //private void Start()
    //{
    //    GetComponent<Collider>().isTrigger = true;
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Controller"))
    //    {
    //        ButtonPressed();
    //    }
    //}

    //private void ButtonPressed()
    //{
    //    Debug.Log("Butonul a fost apasat!");
    //}
}