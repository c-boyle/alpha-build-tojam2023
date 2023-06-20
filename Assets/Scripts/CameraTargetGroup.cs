using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MyBox;
using UnityEngine;

/// <summary>
/// Offers access to Cinemachine's target group.
/// </summary>

public class CameraTargetGroup : Singleton<CameraTargetGroup> {
  [field: SerializeField] public CinemachineTargetGroup TargetGroup { get; set; }
}
