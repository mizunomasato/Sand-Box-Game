using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject itemImage;
    public bool haveItem = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (haveItem)
        {
            itemImage.SetActive(true); //haveItem�̂Ƃ��\������
        }
        else
        {
            itemImage.SetActive(false);//haveItem����Ȃ��Ƃ��\�����Ȃ�
        }
    }
}
