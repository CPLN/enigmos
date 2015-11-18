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

        public Node Root
        {
            get
            {
                return root;
            }
            set
            {
                root = value;
            }
        }

        public Graph(T element)
        {
            this.root = new Node(element);
        }

        public Node Contains(T element)
        {
            string tagVisited = "__contains__visited__";
            List<Node> visited = new List<Node>();
            List<Node> toBeVisited = new List<Node>();

            Node containingNode = null;
            toBeVisited.Add(Root);
            while (toBeVisited.Count > 0)
            {
                Node active = toBeVisited[0];
                toBeVisited.RemoveAt(0);
                if (active.Element.Equals(element))
                {
                    containingNode = active;
                    break;
                }
                if (!active.Tags.ContainsKey(tagVisited))
                {
                    active.Tags[tagVisited] = true;
                    visited.Add(active);
                    foreach (Connection connection in active.Connections)
                    {
                        toBeVisited.Add(connection.Neighbor);
                    }
                }
            }

            foreach (Node node in visited)
            {
                node.Tags.Remove(tagVisited);
            }

            return containingNode;
        }

        public class Node
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

            public void AddNeighbor(Node neighbor)
            {
                this.Connections.Add(new Connection(neighbor));
                neighbor.Connections.Add(new Connection(this));
            }

            public void AddNeighbor(T element)
            {
                AddNeighbor(new Node(element));
            }

            public Node FindNeighbor(T element)
            {
                foreach (Connection connection in Connections)
                {
                    if (connection.Neighbor.Element.Equals(element))
                    {
                        return connection.Neighbor;
                    }
                }
                return null;
            }

            public int Distance(Node node)
            {
                string tagVisited = "__distance__visited__";
                string tagParent = "__distance__parent__";
                string tagDistance = "__distance__distance__";

                int distance = -1;

                List<Node> nodesToVisit = new List<Node>();
                List<Node> visitedNodes = new List<Node>();

                this.Tags[tagParent] = null;
                this.Tags[tagDistance] = 0;
                nodesToVisit.Add(this);

                while (nodesToVisit.Count > 0)
                {
                    Node current = nodesToVisit[0];
                    nodesToVisit.RemoveAt(0);

                    if (current.Tags.ContainsKey(tagVisited))
                    {
                        continue;
                    }

                    current.Tags[tagVisited] = true;

                    foreach (Connection connection in current.Connections)
                    {
                        Node neighbor = connection.Neighbor;
                        if (neighbor.Tags.ContainsKey(tagParent))
                        {
                            if (neighbor.Tags[tagParent] != null && (int)neighbor.Tags[tagDistance] - 1 > (int)current.Tags[tagDistance])
                            {
                                neighbor.Tags.Add(tagParent, current);
                                neighbor.Tags.Add(tagDistance, (int)current.Tags[tagDistance] + 1);
                            }
                        }
                        else
                        {
                            neighbor.Tags.Add(tagParent, current);
                            neighbor.Tags.Add(tagDistance, (int)current.Tags[tagDistance] + 1);
                            nodesToVisit.Add(neighbor);
                        }
                    }
                }

                if (node.Tags.ContainsKey(tagVisited))
                {
                    distance = (int)node.Tags[tagDistance];
                }

                foreach (Node visitedNode in visitedNodes)
                {
                    visitedNode.Tags.Remove(tagVisited);
                    visitedNode.Tags.Remove(tagParent);
                    visitedNode.Tags.Remove(tagDistance);
                }

                if (distance < 0)
                {
                    throw new NotConnectedException(this, node);
                }

                return distance;
            }
        }

        public class Connection
        {
            public Node Neighbor { get; set; }
            public Dictionary<string, object> Tags { get; private set; }

            public Connection(Node neighbor)
            {
                this.Neighbor = neighbor;
                this.Tags = new Dictionary<string, object>();
            }

            public Connection(T element)
                : this(new Node(element))
            {

            }
        }

        public class NotConnectedException : Exception
        {
            private Node origin;
            private Node destination;

            override public string Message {
                get {
                    return "Les noeuds contenant " + origin.Element + " et " + destination.Element + " ne sont pas connectés";
                }
            }

            public NotConnectedException(Node origin, Node destiation)
            {
                this.origin = origin;
                this.destination = destiation;
            }
        }
    }
}
