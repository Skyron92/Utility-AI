using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditor {
    public abstract class Node : ScriptableObject {
        public enum ConnectionType {
            Any, 
            Strict, 
            InParent, 
            InChild,
        }
    }
}
