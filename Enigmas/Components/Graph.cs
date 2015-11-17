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

            public int Distance(Node node)
            {
                string tagVisited = "__distance__visited__";
                string tagParent = "__distance__parent__";
                string tagDistance = "__distance__distance__";

                int distance = -1;

                List<Node> nodesToVisit = new List<Node>();
                List<Node> visitedNodes = new List<Node>();

                this.Tags.Add(tagParent, null);
                this.Tags.Add(tagDistance, 0);
                nodesToVisit.Add(this);

                while (nodesToVisit.Count > 0)
                {
                    Node current = nodesToVisit[0];
                    nodesToVisit.RemoveAt(0);

                    if (current.Tags.ContainsKey(tagVisited))
                    {
                        continue;
                    }

                    current.Tags.Add(tagVisited, true);

                    foreach (Connection connection in current.Connections)
                    {
                        Node neighbor = connection.Neighbor;
                        if (neighbor.Tags.ContainsKey(tagParent))
                        {
                            if ((int)neighbor.Tags[tagParent] - 1 > (int)current.Tags[tagParent])
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

        public class NotConnectedException : Exception
        {
            private Node origin;
            private Node destination;

            public string Message {
                get {
                    return "Les noeuds " + origin + " et " + destination + " ne sont pas connectés";
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
