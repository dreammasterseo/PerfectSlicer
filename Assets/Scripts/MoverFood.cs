using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFood : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Food food))
        {
            food.transform.position = Vector3.MoveTowards(other.transform.position, _endPoint.position, _speed * Time.deltaTime);
        }
       
    }
}
