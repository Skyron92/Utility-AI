using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassengerEntity : MonoBehaviour {
    public MeshRenderer MeshRenderer;
    private NavMeshAgent _agent;
    public List<PassengerEntity> PassengerEntities = new List<PassengerEntity>();
    public bool IsControlled;
    public float TravelDuration;

    void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        PassengerEntities.Add(this);
    }

    private void Update() {
        TravelDuration += Time.deltaTime;
    }
}