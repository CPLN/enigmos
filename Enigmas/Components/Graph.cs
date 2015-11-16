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
            private T element;
            private List<Connection> connections = new List<Connection>();
        }

        private class Connection
        {
            private Node neighbor;
            private Dictionary<string, object> tags = new Dictionary<string, object>();
        }
    }
}
