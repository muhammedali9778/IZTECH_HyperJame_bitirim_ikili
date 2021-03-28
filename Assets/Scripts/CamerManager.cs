using UnityEngine;

public class CamerManager : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed = 2.0f;
    private Vector3 offset;

  void Start()
    {
        offset = transform.position - target.position;    
    }

    // Update is called once per frame
   void LateUpdate()
    {
        //transform.position = Vector3.Slerp( new Vector3(transform.position.x, transform.position.y, transform.position.z),
        //                                    new Vector3(target.position.x, target.position.y, target.position.z),
        //                                   Time.deltaTime * cameraSpeed);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z+target.position.z);
        transform.position = Vector3.Lerp(transform.position,newPosition,10*Time.deltaTime);
    }
}
