using System;
using System.Collections;
using UnityEngine;

namespace Haon.Utils
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Prints the name of the game object to the console.
        /// </summary>
        /// <param name="instance"></param>
        public static void PrintName(this GameObject instance)
        {
            Debug.Log(instance.name);
        }
        /// <summary>
        /// Smoothly moves the toMove transform towards the target so it reaches it after duration.
        /// </summary>
        /// <param name="toMove">The transform you want to manipulate</param>
        /// <param name="target">The target position the transform should end up.</param>
        /// <param name="duration">The amount of time the operation should take</param>
        /// <returns></returns>
        public static IEnumerator LerpTowards(this GameObject toMove, Vector3 target, float duration)
        {
            float time = 0.0f;
            Vector3 pos = toMove.transform.position;
            
            while (time < duration)
            {
                Vector3 newPos = new Vector3();
                newPos.x = Mathf.Lerp(pos.x, target.x, time/duration);
                newPos.y = Mathf.Lerp(pos.y, target.y, time/duration);
                newPos.z = Mathf.Lerp(pos.z, target.y, time/duration);
                
                toMove.transform.position = newPos;
                time += Time.deltaTime;
                yield return null;
            }

            toMove.transform.position = target;
        }
        
        /// <summary>
        /// Searches for a component on the target. If it exists returns it, otherwise creates and returns it. 
        /// </summary>
        /// <param name="target"> The game object in question.</param>
        /// <typeparam name="T"> The type of component which is wanted.</typeparam> 
        /// <returns>The component of type T</returns>
        public static T GetOrAddComponent<T>(this GameObject target) where T : Component
        {
            if (target.TryGetComponent<T>(out T component))
                return component;

            return target.AddComponent<T>();
        }
        /// <summary>
        /// Searches for a component on the target. If it exists returns it, otherwise creates and returns it. 
        /// </summary>
        /// <param name="target">The game object of the transform in question.</param>
        /// <typeparam name="T">The type of component which is wanted.</typeparam>
        /// <returns> The component of type T</returns>
        public static T GetOrAddComponent<T>(this Transform target) where T : Component
        {
            return target.TryGetComponent<T>(out T result) ? result : target.gameObject.AddComponent<T>();
        }
        
       /// <summary>
       ///  Searches for a component on the target. If it exists returns it, otherwise creates and returns it.
       /// </summary>
       /// <param name="target">The game object in question.</param>
       /// <param name="type">The type of component wanted.</param>
       /// <returns>A component of Type type</returns>
        public static Component GetOrAddComponent(this GameObject target, Type type)
            => target.GetComponent(type) ?? target.AddComponent(type);

       /// <summary>
       /// Sets the target to be not active. 
       /// </summary>
       /// <param name="target">The game object to be set inactive.</param>
        public static void SetInactive(this GameObject target)
        {
            target.SetActive(false);
        }
        /// <summary>
        /// Sets the target to be active. 
        /// </summary>
        /// <param name="target">The game object to be set active.</param>
        public static void SetActive(this GameObject target)
        {
            target.SetActive(true);
        }
        /// <summary>
        /// A shorthand for creating a new slerp drive and assigning it to a configurable joint. 
        /// </summary>
        /// <param name="joint">The configurable joint which value is to be changed. </param>
        /// <param name="value">The new value of the position spring of the slerp drive. </param>
        public static void SetSlerpDrivePositionSpring(this ConfigurableJoint joint, float value)
        {
            if (joint.rotationDriveMode != RotationDriveMode.Slerp)
                joint.rotationDriveMode = RotationDriveMode.Slerp;

            JointDrive jointDrive = new();
            jointDrive.positionSpring = value;
            joint.slerpDrive = jointDrive;
        }
        /// <summary>
        /// Looks at main camera.
        /// </summary>
        /// <param name="instance">The transform to rotate</param>
        public static void RotateToCamera(this Transform instance)
        {
            instance.LookAt(Camera.main.transform);
        }
    }
}