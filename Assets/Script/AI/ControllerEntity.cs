using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerEntity : MonoBehaviour{

    public MeshRenderer MeshRenderer;
    private NavMeshAgent _agent;
    public List<PassengerEntity> PassengerEntities = new List<PassengerEntity>();
    public int PassengerToControll;
    public PassengerEntity Target;
    public int Speed;
    public GameObject Controlling;
    public GameObject FillArea;
    public bool IsControlling;

    void Awake() {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        PassengerToControll = PassengerEntities.Count;
    }

    private void Update() {
        if (Target) {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, Target.transform.position - transform.position, Speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            _agent.SetDestination(Target.transform.position);
        }
        if(IsControlling && HasReachedTarget()) Controll(Target);
    }
    
    [ContextMenu("Controll")]
    private void Controll(PassengerEntity passenger) {
        if(passenger.IsControlled) return;
        Controlling.SetActive(true);
        Vector3 scale = FillArea.transform.localScale;
        scale.x += Time.deltaTime;
        if (scale.x >= 1) {
            scale.x = 0;
            Controlling.SetActive(false);
            IsControlling = false;
            passenger.IsControlled = true;
        }
        FillArea.transform.localScale = scale;
    }

    private bool HasReachedTarget() {
        return Vector3.Distance(transform.position, Target.transform.position) <= 1;
    }
}