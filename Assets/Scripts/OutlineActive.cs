using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineActive : MonoBehaviour
{
    // Start is called before the first frame update
    public cakeslice.Outline obj;
    public Transform grab;
    public GameObject objpos;
    public float hit_distance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        raycast();
    }

    void raycast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.tag == "Outline")
            {
                Debug.Log("Hit " + hit.collider.name);
                obj = hit.collider.GetComponent<cakeslice.Outline>();
                grab= hit.collider.transform;
                if (hit.distance < hit_distance)
            {
                if (obj != null)
                {
                    obj.eraseRenderer = false;
                }
                if(Input.GetMouseButton(0))
            {
                //set raycast hit object as child of player
                grab.parent = objpos.transform;
                obj.enabled = false;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //set raycast hit object out as child of player
                grab.parent = null;
                obj.enabled = true;
            }
            }
            }
            else

            {
                if (obj != null)
                {
                    obj.eraseRenderer = true;
                }
            }
        }
        else
        {
            if (obj != null)
            {
                obj.eraseRenderer = true;
            }
        }
        
    }
}

