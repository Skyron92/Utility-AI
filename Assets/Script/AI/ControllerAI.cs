using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAI : MonoBehaviour
{
    [HideInInspector] public ControllerEntity ControllerEntity;
    [HideInInspector] public List<PassengerEntity> PassengerEntities => ControllerEntity.PassengerEntities;

    private void Awake() {
        ControllerEntity = GetComponent<ControllerEntity>();
    }
}