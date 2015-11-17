using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Graph<T>
    {
        private Node root;

        private class Node
        {
            public T Element { get; set; }
            public List<Connection> Connections { get; private set; }
            public Dictionary<string, object> Tags { get; private set; }

            public Node(T element)
            {
                this.Element = element;
                Connections = new List<Connection>();
                Tags = new Dictionary<string, object>();
            }
        }

        private class Connection
        {
            public Node Neighbor { get; set; }
            public Dictionary<string, object> Tags { get; private set; }

            public Connection(Node neighbor)
            {
                this.Neighbor = neighbor;
                this.Tags = new Dictionary<string, object>();
            }
        }
    }
}
