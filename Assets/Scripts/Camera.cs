using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    public Vector2 limitX;
    public Vector2 limitY;
    public float interpolationRatio;
    public float desiredZ = -10;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Mario").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
        Vector3 desiredPosition = target.position + offset;
        float clampX = desiredPosition.x;
        float clampY = desiredPosition.y;

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredZ);

        transform.position = clampedPosition;

        
    }
}
