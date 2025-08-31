using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ajuda_MC : MonoBehaviour
{
    //public GameObject myObject;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //myObject.GetComponent<DataBaseManager_MC>().Start();
        Panel.SetActive(true);
    }
}
