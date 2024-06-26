﻿namespace HyperX;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class NotificationAttribute(object key) : Attribute
{
    public object Key => key;
}