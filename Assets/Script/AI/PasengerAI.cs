using System.Collections.Generic;
using UnityEngine;

public class PasengerAI : MonoBehaviour{
    [HideInInspector] public PassengerEntity PassengerEntity;
    [HideInInspector] public List<PassengerEntity> PassengerEntities => PassengerEntity.PassengerEntities;

    private void Awake() {
        PassengerEntity = GetComponent<PassengerEntity>();
    }
}