using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used by non-monobehaviour inheriting classes to start a coroutine.
/// </summary>

public class CoroutineManager : Singleton<CoroutineManager> {
  public new Coroutine StartCoroutine(IEnumerator routine) {
    return base.StartCoroutine(routine);
  }
}