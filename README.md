# Inverse Kinematics

## Defenition

Invenverse Kinematics, according with
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