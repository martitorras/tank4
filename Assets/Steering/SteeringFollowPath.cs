using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : MonoBehaviour {

	Move move;
	SteeringSeek seek;
   public BGCcMath path;

    public float ratio_increment = 0.1f;
    public float min_distance = 10.0f;
    float current_ratio = 0.0f;
    Vector3 current_distance;
    Vector3 current_point;
    float current_obj = 0.0f;
	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringSeek>();
    //    path = GetComponent<FollowCurve>().path;

        // TODO 1: Calculate the closest point from the tank to the curve
        current_point = path.CalcPositionByClosestPoint(transform.position,out current_ratio);
        current_ratio /= path.GetDistance();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 2: Check if the tank is close enough to the desired point
        // If so, create a new point further ahead in the path
        current_point = path.CalcPositionByDistanceRatio(current_ratio);
        current_distance = current_point - transform.position ;

        if (current_distance.magnitude < min_distance)
        {
            current_ratio += ratio_increment;
            if ((current_ratio) > 1.0f) current_ratio = 0.0f;
        }

        seek.Steer(current_point);
    }

	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere were on the closest point to the path
		}

	}
}