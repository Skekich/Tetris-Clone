using System.Runtime.InteropServices;
using UnityEngine;

public class Rotation : MonoBehaviour
{
   [SerializeField] private Vector3 rotationPoint;
   private Boundries boundries;

   private void Start()
   {
      boundries = GetComponent<Boundries>();
   }

   private void Update()
   {
      if (!Input.GetKeyDown(KeyCode.UpArrow)) return;
      transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, 90);
      if (boundries.ValidMove()) return;
      transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, -90);
   }
}
