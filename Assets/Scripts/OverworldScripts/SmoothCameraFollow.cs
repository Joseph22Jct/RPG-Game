using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed;
    // Start is called before the first frame update
    
    private void Start() {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position+offset;
        Vector3 smoothedPosition= Vector3.Lerp(transform.position, desiredPosition, speed);
        smoothedPosition.z = transform.position.z;
        //Vector3 newPosition = new Vector3(smoothedPosition.x - (smoothedPosition.x%0.03125f ),smoothedPosition.y - (smoothedPosition.x%0.03125f ), transform.position.z );
        transform.position = smoothedPosition;
    }
}
