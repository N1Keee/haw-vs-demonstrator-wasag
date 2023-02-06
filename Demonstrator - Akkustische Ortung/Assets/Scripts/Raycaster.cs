using UnityEditor;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public Camera cam;
    private RaycastHit _hitInfo;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ExecuteRaycast();
        }
    }

    void ExecuteRaycast()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hitInfo, 100))
        {
            //Debug.DrawLine(ray.origin, _hitInfo.point, Color.red);
            //Debug.Log(_hitInfo.transform.name);
        }
        else
        {
            //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }

    public RaycastHit GetRaycastHit()
    {
        return _hitInfo;
    }
}
