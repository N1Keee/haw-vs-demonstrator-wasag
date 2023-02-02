using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadphoneAnimation : MonoBehaviour
{
    [SerializeField] private float mSpeed;
    [SerializeField] private float rSpeed;
    [SerializeField] private GameObject cam;
    private Vector3 _startPos;
    private Vector3 _targetPos;
    private Quaternion _startRotation;
    private Quaternion _targetRotation;
    
    void Start()
    {
        Debug.Log(transform.rotation);
        _targetPos = cam.transform.position;
        _targetPos.y += 0.25f; 
        _targetRotation = cam.transform.rotation;
        //_targetPos = new Vector3(-24.82f, 1.94f, 6.52f);
        //_targetRotation = new Quaternion(0.39678f, 0.71435f, 0.27990f, 0.50392f);
        _targetRotation = new Quaternion(0.00000f, 0.92388f, 0.00000f, 0.38268f);
        _startPos = transform.position;
        _startRotation = transform.rotation;
    }

    public void EquipHp()
    {
        var mStep = mSpeed * Time.deltaTime;
        var rStep = rSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, mStep);
        //transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, rotSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, rStep);
    }
    public void UnequipHp(){
        var mStep = mSpeed * Time.deltaTime;
        var rStep = rSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,_startPos, mStep);
        //transform.rotation = Quaternion.Lerp(transform.rotation, _startRotation, rotSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _startRotation, rStep);
    }
}
