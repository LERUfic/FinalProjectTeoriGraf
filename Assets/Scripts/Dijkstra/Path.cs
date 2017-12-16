using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The Path.
/// </summary>
public class Path
{
    protected List<Nodes> m_Nodes = new List<Nodes>();
    protected float m_Length = 0f;
    public virtual List<Nodes> nodes
    {
        get
        {
            return m_Nodes;
        }
    }

    public virtual float length
    {
        get
        {
            return m_Length;
        }
    }

    public virtual void Bake()
    {
        List<Nodes> calculated = new List<Nodes>();
        m_Length = 0f;
        for (int i = 0; i < m_Nodes.Count; i++)
        {
            Nodes node = m_Nodes[i];
            for (int j = 0; j < node.connections.Count; j++)
            {
                Nodes connection = node.connections[j];
                
                if (m_Nodes.Contains(connection) && !calculated.Contains(connection))
                {
                    m_Length += Vector3.Distance(node.transform.position, connection.transform.position);
                }
            }
            calculated.Add(node);
        }
    }
    
    public override string ToString()
    {
        return string.Format(
            "Nodes: {0}\nLength: {1}",
            string.Join(
                ", ",
                nodes.Select(node => node.name).ToArray()),
            length);
    }

}