using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    private float levelLimitXMin,levelLimitXMax;

    [SerializeField]
    private float defaultOffsetX, defaultOffsetY;


    private Camera cam;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        float camSize = cam.orthographicSize;
        float camAspect = cam.aspect;
        transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x+defaultOffsetX,levelLimitXMin+camSize*camAspect,levelLimitXMax+ camSize * camAspect), defaultOffsetY, -10);
    }
}
