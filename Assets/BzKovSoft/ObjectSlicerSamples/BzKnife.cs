using System;
using System.Collections.Generic;
using UnityEngine;
namespace BzKovSoft.ObjectSlicerSamples
{
	/// <summary>
	/// The script must be attached to a GameObject that have collider marked as a "IsTrigger".
	/// </summary>
	public class BzKnife : MonoBehaviour
	{
		public int SliceID { get; private set; }
		Vector3 _prevPos;
		Vector3 _pos;

        private Rigidbody rb;

		[SerializeField]
		private Vector3 _origin = Vector3.down;

		[SerializeField]
		private Vector3 _direction = Vector3.up;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


        public Vector3 getVelocity()
        {
            if(rb == null) UnityEngine.Debug.Log("Pas de rb!!");
            return rb.velocity;
        }

        public float getDif()
        {
            return _prevPos.magnitude - _pos.magnitude;
        }

		private void Update()
		{
			_prevPos = _pos;
			_pos = transform.position;
          //  UnityEngine.Debug.Log(_pos.magnitude);
          //  UnityEngine.Debug.Log(_prevPos.magnitude);

        }



        public Vector3 Origin
		{
			get
			{
				Vector3 localShifted = transform.InverseTransformPoint(transform.position) + _origin;
				return transform.TransformPoint(localShifted);
			}
		}

		public Vector3 BladeDirection { get { return transform.rotation * _direction.normalized; } }
		public Vector3 MoveDirection { get { return (_pos - _prevPos).normalized; } }

		public void BeginNewSlice()
		{
			SliceID = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
		}
	}
}
