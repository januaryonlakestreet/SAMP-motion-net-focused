using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class move_goal : MonoBehaviour
{
    public Vector3[] goals;
    public int target_goal_id;
    public float speed;
    public float swayAmplitude = 1f; // Amplitude of the sway
    public float swayFrequency = 1f; // Frequency of the sway

    private Vector3 direction;
    private float swayTimer;

    void Start()
    {
        if (goals.Length > 0)
        {
            target_goal_id = 0;
            direction = (goals[target_goal_id] - transform.position).normalized;
        }
    }
    Vector3 sway;
    void Update()
    {
        if (goals.Length == 0) return; // Ensure there are goals to move towards

        direction = (goals[target_goal_id] - transform.position).normalized;

        // Calculate the sway offset using sine wave
        float swayOffset = Mathf.Sin(swayTimer * swayFrequency) * swayAmplitude;

        // Apply the sway offset perpendicular to the forward direction
        sway = transform.right * swayOffset;

        // Move the object towards the goal with sway
        transform.position += (direction * speed * Time.deltaTime) + sway;

        // Update the sway timer
        swayTimer += Time.deltaTime;

        // Check if the object is close to the target goal
        if (Vector3.Distance(transform.position, goals[target_goal_id]) < 1f)
        {
            target_goal_id = (target_goal_id + 1) % goals.Length; // Move to the next goal, loop back to the start if at the end
            direction = (goals[target_goal_id] - transform.position).normalized;
        }

        // Optional: Make the object face the movement direction
        transform.forward = direction;

        if (!InBounds()){
            direction = direction * -1;
            transform.forward = direction;
            sway = Vector3.zero;
            swayTimer = 0;
        }
    }

    bool InBounds()
    {
        if (this.transform.position.x < -23f || this.transform.position.x > 23f || this.transform.position.z < -23f ||
            this.transform.position.z > 23f)
        {
            return false;
        }
        return true;
    }
}
