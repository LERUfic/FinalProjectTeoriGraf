using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Nodes : MonoBehaviour
{

    [SerializeField]
    protected List<Nodes> m_Connections = new List<Nodes>();

    public virtual List<Nodes> connections
    {
        get
        {
            return m_Connections;
        }
    }

    public Nodes this[int index]
    {
        get
        {
            return m_Connections[index];
        }
    }

    void OnValidate()
    {

        m_Connections = m_Connections.Distinct().ToList();
    }
}