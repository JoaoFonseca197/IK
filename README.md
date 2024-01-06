# Inverse Kinematics

## Defenition

Inverse Kinematics, according with
[MathWorks](https://www.mathworks.com/discovery/inverse-kinematics.html),

> Inverse Kinematics is the calculation of the variables of the set of joints
and linkages connected to an end effector. Given the position and orientation
of the end effector, inverse kinematics can be used to calculate the variables
regarding those joints and linkages including position, angle, and orientation.

But there are many ways to solve Inverse Kinematics, the one that we will be
focus on is Cyclic Coordinate Descent Inverse Kinematics(CCDIK)

## Unity Project

This project will be based on this site,
[Cyclic Coordonate Descent Inverse Kynematic](http://rodolphe-vaillant.fr/entry/114/cyclic-coordonate-descent-inverse-kynematic-ccd-ik) and the video
[Unite Berlin 2018 - An Introduction to CCD IK and How to use it](https://www.youtube.com/watch?v=MA1nT9RAF3k).
As the site and video mentions we will need:

- A list with all joints
- The End Effector
- The target 
- A margin of error

![alt text](\ProjectImages\CCDIK_Variables.png)

In short what CCGIK does is making a loop throw all the joints and calculates
a vector from the current joint to the End Effector and another from the current
joint to the target,we calculate the angle made between this 2 vectors
and make a rotation from it.

The way that you should get the joints is going from the end factor and get the 
transform from the parent until this is null or met an condition. In my case I am
putting the joints that I want to use for demonstration.