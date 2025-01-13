using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class MoveTask : ActionTask 
	{

		private Blackboard agentBlackboard;
		private Transform robotTransform;

		private float stoppingDistance;

		public BBParameter<float> moveSpeed;
		public BBParameter<float> turnSpeed;

		public Transform destination;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() 
		{
			agentBlackboard = agent.GetComponent<Blackboard>();
			robotTransform = agentBlackboard.GetVariableValue<Transform>("robotTransform");
			stoppingDistance = agentBlackboard.GetVariableValue<float>("stoppingDistance");

			return null;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			Vector3 direcrtion = destination.position - robotTransform.position;
			Turn(direcrtion);
			Move(direcrtion);
		}

        private void Turn(Vector3 direction)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction);
            if (robotTransform.rotation == desiredRotation) return;

            float step = turnSpeed.value * Time.deltaTime;
            robotTransform.rotation = desiredRotation = Quaternion.RotateTowards(robotTransform.rotation, desiredRotation, step);
        }


        private void Move(Vector3 direction)
        {
            if (direction.magnitude <= stoppingDistance) EndAction(true);
            robotTransform.Translate(moveSpeed.value * Time.deltaTime * robotTransform.forward, Space.World);
        }
    }
}