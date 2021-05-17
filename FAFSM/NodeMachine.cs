using System;
using System.Collections.Generic;

namespace NodeMachine
{
    public class NodeMachine
    {

        //Node Object.
        public class Node
        {
            private string NodeName;
            private List<Node> NodeConnections = new List<Node>();

            public Node(string nm)
            {
                NodeName = nm;
            }

            public void setNodeName(string naam)
            {
                NodeName = naam;
            }
            public string getNodeName()
            {
                return NodeName;
            }

            public void setNodeConnections(List<Node> lijst)
            {
                NodeConnections = lijst;
            }

            public List<Node> getNodeconnections()
            {
                return NodeConnections;
            }
        }

        public class NodeList
        {
            private List<Node> nodeList = new List<Node>();

            public void NodeToList(string noodle) //Makes a node with identifier noodle.
            {
                nodeList.Add(new Node(noodle));
            }
            
            public List<Node> getNodeList()
            {
                return nodeList;
            }

            public void GenerateNodeList(int size)
            {
                string nodeName;
                for (int i = 0; i < size; i++)
                {
                    nodeName = "s" + i;
                    NodeToList(nodeName);
                }
            }
        }

        //Node machine initializer.
        public NodeMachine(int MachineSize)
        {
            List<Node> t1;
            NodeList.GenerateNodeList(MachineSize);
            t1 = NodeList.getNodeList();
            //Node s0 = new Node("s0");
        }
    }
}