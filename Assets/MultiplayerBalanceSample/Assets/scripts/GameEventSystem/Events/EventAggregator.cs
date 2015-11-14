using UnityEngine;
using System.Collections;

public class EventAggregator : MonoBehaviour {
    public static PlayerDetectedEvent PlayerDetected = new PlayerDetectedEvent();
}
