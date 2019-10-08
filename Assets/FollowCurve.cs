using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;


public class FollowCurve : MonoBehaviour
{
    public BGCcMath path;

    float sph_position = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = path.CalcPositionByDistanceRatio(sph_position);
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = path.CalcPositionByDistanceRatio(sph_position);
        sph_position += 0.1f * Time.deltaTime;
        if (sph_position >= 1) sph_position = 0.0f;
    }
}
