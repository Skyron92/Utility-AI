using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerEntity : MonoBehaviour{

    public MeshRenderer MeshRenderer;
    private NavMeshAgent _agent;
    public List<PassengerEntity> PassengerEntities = new List<PassengerEntity>();
    public int PassengerToControl;
    public PassengerEntity Target;
    public int Speed;
    public GameObject Controlling;
    public GameObject FillArea;
    public bool IsControlling;
    public float Sight;
    public float rangeX, rangeZ;
    private Vector3 _target;
    public AnimationCurve PatroilCurve;
    private float _controllWeight;
    private bool IsSmuggled;

    void Awake() {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        PassengerToControl = PassengerEntities.Count;
    }

    private void Update() {
        if (Target) {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, Target.transform.position - transform.position, Speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            _agent.SetDestination(Target.transform.position);
        }
        if(IsControlling && HasReachedTarget()) Control(Target);
    }

    private void ChooseAction() {
        float value = Mathf.NegativeInfinity;
        if (PatroilValue() > value) {
            value = PatroilValue();
        }
    }

    private float ControlValue() {
        _controllWeight = PassengerEntities.Count;
        return _controllWeight;
    }

    private float AttackValue() {
        if (IsSmuggled) return 1000;
        return 0;
    }

    private float PatroilValue() {
        return 1;
    }

    private void Patroil() {
        rangeX = Random.Range(5, 10);
        rangeZ = Random.Range(5, 10);
        _target = new Vector3(rangeX, transform.position.y, rangeZ);
        _agent.SetDestination(_target);
    }
    
    [ContextMenu("Control")]
    private void Control(PassengerEntity passenger) {
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
        PassengerEntities.Remove(passenger);
    }

    private bool HasReachedTarget() {
        return Vector3.Distance(transform.position, Target.transform.position) <= 1;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Sight);
    }
}