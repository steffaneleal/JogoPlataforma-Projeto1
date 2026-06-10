using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject woody;
    public float offSetY;

    // Start is called before the first frame update
    void Start()
    {
        offSetY = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(woody.transform.position.x, woody.transform.position.y + offSetY, -10);
    }
}
