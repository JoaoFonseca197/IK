using System.Collections.Generic;
using UnityEngine;

public class CCDIK : MonoBehaviour
{
    [SerializeField] private List<Transform> _listJoints;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _endEffectorTip;
    [Range(0,1)]
    [SerializeField] private float _errorDistance;

    private Vector3 _endEffectorPosition;

    private void Start()
    {
        _endEffectorPosition = _endEffectorTip.position;
    }

   
   

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 u1;
        Vector3 u2;
        if(Vector3.Distance(_target.position,_endEffectorTip.position) >= _errorDistance)
        {
            for (int jointNBR = _listJoints.Count - 1; jointNBR >= 0; jointNBR--)
            {
                u1 = (_endEffectorPosition - _listJoints[jointNBR].position);
                u2 = (_target.position - _listJoints[jointNBR].position);

                _listJoints[jointNBR].rotation = Quaternion.FromToRotation(u1, u2) * _listJoints[jointNBR].rotation;

                
                _endEffectorPosition = _endEffectorTip.position;
            }
        }

    }

}
