using System.Collections.Generic;
using UnityEngine;

public class CCDIK : MonoBehaviour
{
    [SerializeField] private List<Transform> _listJoints;
    [SerializeField] private Constraint _armConstraint;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _endEffectorTip;
    [Range(0,1)]
    [SerializeField] private float _errorDistance;

    private Vector3 _endEffectorPosition;
    private List<Vector3> _jointsOriginalRotation;

    private void Start()
    {
        _endEffectorPosition = _endEffectorTip.position;


    }

   

    private Vector3 CheckMaxRotation( Vector3 rotation)
    {
        rotation.x = Mathf.Clamp(rotation.x, _armConstraint.minX, _armConstraint.maxX);
        rotation.y = Mathf.Clamp(rotation.y, _armConstraint.minY, _armConstraint.maxY);
        rotation.z = Mathf.Clamp(rotation.z, _armConstraint.minZ, _armConstraint.maxZ);
        return new Vector3(Mathf.Clamp(rotation.x, _armConstraint.minX, _armConstraint.maxX), Mathf.Clamp(rotation.y, _armConstraint.minY, _armConstraint.maxY), Mathf.Clamp(rotation.z, _armConstraint.minZ, _armConstraint.maxZ));
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

                if(jointNBR == 0)
                    _listJoints[jointNBR].localEulerAngles =  CheckMaxRotation( _listJoints[jointNBR].localEulerAngles);

                
                _endEffectorPosition = _endEffectorTip.position;
            }
        }

        print("Joint 5 rotation = " + _listJoints[_listJoints.Count-1].localEulerAngles);
    }

}
