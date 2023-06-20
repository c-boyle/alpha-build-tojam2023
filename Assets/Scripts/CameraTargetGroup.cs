using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using MyBox;
using UnityEngine;

public class CameraTargetGroup : Singleton<CameraTargetGroup>
{
    [field: SerializeField] public CinemachineTargetGroup TargetGroup { get; set; }
}
