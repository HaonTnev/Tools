using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class TransformExtension : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private void Start()
    {
        gameObject.GetOrAddComponent<MeshFilter>();
        transform.GetOrAddComponent<MeshRenderer>();
        
        gameObject.SetInactive();
        gameObject.SetActive();

        ConfigurableJoint configurableJoint = gameObject.GetOrAddComponent<ConfigurableJoint>();
        configurableJoint.SetSlerpDrivePositionSpring(10);
        gameObject.InitializeComponents();
        
        
    }
    
    
}


public static class Extension
{
    
    public static T GetOrAddComponent<T>(this GameObject target) where T : Component
    {
        if (target.TryGetComponent<T>(out  T component))
            return component;
        
        return target.AddComponent<T>();
    }

    public static T GetOrAddComponent<T>(this Transform target) where T : Component
    {
        return target.TryGetComponent<T>(out T result) ? result : target.AddComponent<T>();
    }

    public static Component GetOrAddComponent(this GameObject target, Type type) 
        =>  target.GetComponent(type) ?? target.AddComponent(type);
    
    public static void SetInactive(this GameObject target)
    {
        target.SetActive(false);
    }

    public static void SetActive(this GameObject target)
    {
        target.SetActive(true);
    }

    public static void SetSlerpDrivePositionSpring(this ConfigurableJoint joint, float value)
    {
        if (joint.rotationDriveMode != RotationDriveMode.Slerp)
            joint.rotationDriveMode = RotationDriveMode.Slerp;
        
        JointDrive jointDrive = new();
        jointDrive.positionSpring = value;
        joint.slerpDrive = jointDrive;
    }
    
    public static void InitializeComponents(this GameObject instance)
    {
        FieldInfo[] fields = instance.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo field in fields)
        {
            if (typeof(Component).IsAssignableFrom(field.FieldType))
            {
                Component component = instance.GetComponent(field.FieldType);
                if (!component)
                {
                    instance.AddComponent(field.FieldType);
                    component = instance.GetComponent(field.FieldType);
                    Debug.LogWarning($"Component {field.FieldType} was missing and dynamically added on {instance.name}, check its configuration!");
                }

                Debug.Log($"{field.FieldType} was initialized in {instance}");
                field.SetValue(instance, component);
            }
        }
    }
}