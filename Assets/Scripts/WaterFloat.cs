using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ditzelgames;

public class WaterFloat : MonoBehaviour
{
    public float airDrag = 1;
    public float waterDrag = 10;
    public Transform[] floatPoints;
    public bool attachToSurface = false;
    public bool affectDirection = true;

    protected Rigidbody rigidbody;
    protected Waves waves;

    protected float waterLine;
    protected Vector3[] waterLinePoints;

    protected Vector3 smoothVectorRotation;
    protected Vector3 targetUp;
    protected Vector3 centerOffset;

    public Vector3 center { get { return transform.position + centerOffset; } }

    void Awake()
    {
        waves = FindObjectOfType<Waves>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        waterLinePoints = new Vector3[floatPoints.Length];
        for (int i = 0; i > floatPoints.Length; i++)
            waterLinePoints[i] = floatPoints[i].position;
        centerOffset = PhysicsHelper.GetCenter(waterLinePoints) - transform.position;
    }

    void FixedUpdate()
    {
        var newWaterLine = 0f;
        var pointUnderWater = false;

        for (int i = 0; i < floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
            waterLinePoints[i].y = waves.GetHeight(floatPoints[i].position);
            newWaterLine += waterLinePoints[i].y / floatPoints.Length;
            if (waterLinePoints[i].y > floatPoints[i].position.y)
                pointUnderWater = true;
        }

        var waterLineDelta = newWaterLine - waterLine;
        waterLine = newWaterLine;

        var gravity = Physics.gravity;
        rigidbody.drag = airDrag;
        if (waterLine > center.y)
        {
            rigidbody.drag = waterDrag;

            if (attachToSurface)
            {
                rigidbody.position = new Vector3(rigidbody.position.x, waterLine - centerOffset.y, rigidbody.position.z);
            }
            else
            {
                gravity = affectDirection ? targetUp * -Physics.gravity.y : -Physics.gravity;
                transform.Translate(Vector3.up * waterLineDelta * 0.9f);
            }
        }

        rigidbody.AddForce(gravity * Mathf.Clamp(Mathf.Abs(waterLine - center.y), 0, 1));

        targetUp = PhysicsHelper.GetNormal(waterLinePoints);

        if (pointUnderWater)
        {
            targetUp = Vector3.SmoothDamp(transform.up, targetUp, ref smoothVectorRotation, 0.2f);
            rigidbody.rotation = Quaternion.FromToRotation(transform.up, targetUp) * rigidbody.rotation;
        }
    }
}
