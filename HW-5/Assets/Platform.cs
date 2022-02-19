using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float a = 0, b = 0;

    public Platform(float a, float b)
    {
        setA(a);
        setB(b);
    }

    public void setA(float a)
    {
        this.a = a;
    }
    public void setB(float b)
    {
        this.b = b;
    }

    public float getA()
    {
        return this.a;
    }
    public float getB()
    {
        return this.b;
    }
}
