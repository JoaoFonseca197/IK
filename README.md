# Inverse Kinematics

## Defenition

Inverse Kinematics, according with
[MathWorks](https://www.mathworks.com/discovery/inverse-kinematics.html),

> Inverse Kinematics is the calculation of the variables of the set of joints
and linkages connected to an end effector. Given the position and orientation
of the end effector, inverse kinematics can be used to calculate the variables
regarding those joints and linkages including position, angle, and orientation.

But there are many ways to solve Inverse Kinematics, the one that we will be
focus on is Cyclic Coordinate Descent Inverse Kinematics(CCDIK).

## Unity Project

This project will be based on this site,
[Cyclic Coordonate Descent Inverse Kynematic](http://rodolphe-vaillant.fr/entry/114/cyclic-coordonate-descent-inverse-kynematic-ccd-ik) and the video
[Unite Berlin 2018 - An Introduction to CCD IK and How to use it](https://www.youtube.com/watch?v=MA1nT9RAF3k).
As the site and video mentions we will need:

- A list with all joints transforms;
- The End Effector;
- The target;
- A margin of error;

![variables](/ProjectImages/CCDIK_Variables.png)

In short what CCGIK does is making a loop throw all the joints and calculates
a vector from the current joint to the End Effector and another from the current
joint to the target,we calculate the angle made between this 2 vectors
and make a rotation from it.

The way that you should get the joints is going from the end factor and get the 
transform from the parent until this is null or met an condition. In my case I am
putting the joints that I want, to use for demonstration.

After getting all the joints transforms, on the `FixedUpdate()` we do a condition to
check if the distance between the end effector and the target are smaller than the
error margin. Create 2 `Vector3` variables, to be used later. Now, do a for loop
that iterates through all the transform joints. Inside the loop calculate the
vector that goes from the current joint to the end factor (`u1`), calculate another vector
that goes from the current joint to the target(`u2`) and perform an rotation with an angle 
calculated from the vectors `u1`, `u2`.

The code should look like this:
```
void FixedUpdate()
{
       
    if(Vector3.Distance(_target.position,_endEffectorTip.position) >= _errorDistance)
    {
        Vector3 u1;
        Vector3 u2;
        for (int jointNBR = _listJoints.Count - 1; jointNBR >= 0; jointNBR--)
        {
            u1 = (_endEffectorTip.position - _listJoints[jointNBR].position);
            u2 = (_target.position - _listJoints[jointNBR].position);

            _listJoints[jointNBR].rotation = Quaternion.FromToRotation(u1, u2) * _listJoints[jointNBR].rotation;

        }
    }

}
```

In the end should look something like this:

![Arm_Gif](/ProjectImages/ArmMovement.gif)

As you can see the arm clips throw the body. To resolver this we need to make
some constraints.

In my project I created a ScriptableObject called `Constraints` with the
solo objective of constraining the rotation of the transform reminding that
all the movement of the arm is just rotations. For this project I will only
constrain the left arm. What I think is the best to do this is when getting
all the joint transforms, it should show options in the unity editor, instead
of creating this script `Constraint`.

As for the code what I did was clamp the rotation of the of the arm according
with the restrictions that we made.
```
private Vector3 CheckMaxRotation(Vector3 rotation)
{
    float x = Mathf.Clamp(rotation.x, _armConstraint.minX, _armConstraint.maxX);
    float y = Mathf.Clamp(rotation.y, _armConstraint.minY, _armConstraint.maxY);
    float z = Mathf.Clamp(rotation.z, _armConstraint.minZ, _armConstraint.maxZ);
    return new Vector3(x, y, z);
}
```
```
void FixedUpdate()
{
        
    if (Vector3.Distance(_target.position, _endEffectorTip.position) >= _errorDistance)
    {
        Vector3 u1;
        Vector3 u2;
        for (int jointNBR = _listJoints.Count - 1; jointNBR >= 0; jointNBR--)
        {
            u1 = (_endEffectorTip.position - _listJoints[jointNBR].position);
            u2 = (_target.position - _listJoints[jointNBR].position);

            _listJoints[jointNBR].rotation = Quaternion.FromToRotation(u1, u2) * _listJoints[jointNBR].rotation;
            //Just the left arm for test
            if (jointNBR == 0)
                _listJoints[jointNBR].localEulerAngles = CheckMaxRotation(_listJoints[jointNBR].localEulerAngles);
        }
    }

}
```

This is the end result:

![Arm_Gif2](/ProjectImages/ArmMovementConstrained.gif)
