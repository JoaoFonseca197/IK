using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Constraints", menuName = "ScriptableObjects/Constraints", order = 1)]
public class Constraint : ScriptableObject
{
    [SerializeField] public float minX;
    [SerializeField] public float maxX;
    [SerializeField] public float minY;
    [SerializeField] public float maxY;
    [SerializeField] public float minZ;
    [SerializeField] public float maxZ;
}
