using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blockset: MonoBehaviour
{
    Vector2 displayCenter;
    private Vector3 pos;
   

    [SerializeField]
    private GameObject blockPrefab;
    item itemScript;

    // Start is called before the first frame update
    void Start()
    {
        displayCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Cursor.lockState = CursorLockMode.Locked;

        itemScript = gameObject.GetComponent<item>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(displayCenter);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            pos = hit.normal + hit.collider.transform.position;

        }
    if (Input.GetMouseButtonDown(1))
        {
            Instantiate(blockPrefab, pos, Quaternion.identity);

        }
        if (Input.GetMouseButtonDown(0) && itemScript.haveItem)//ç∂ÉNÉäÉbÉNÇâüÇ∑Ç©Ç¬itemScriptÇÃÇ∆Ç´îjâÛÇ∑ÇÈ
        {
            if (!gameObject.CompareTag("wall")) {
                Destroy(this.gameObject);
            }
               
            
            
        }
    }
}
