using System;

namespace NodeMachine2
{
    public partial class NodeLogic
    {
        static public string nodeSequence(string sequence, Nodal.Node initialNode)
        {
            Nodal.Node currentNode = initialNode;

            string pad = "";

            foreach (char letter in sequence)
            {
                pad += currentNode.getName() + ",";
                currentNode = currentNode.advanceNode(letter);
            }
            pad += currentNode.getName();
            return pad;
        }
    }
    public class Nodal
    {
        public class Node
        {
            private string nodeName;
            private Node APointTo;
            private Node BPointTo;
            private Node Empty;
            private string currentState;

            private enum nodeState
            {
                Unlocked,Locked
            }

            public Node(string nm, string st)
            {
                nodeName = nm;
                currentState = st;
            }

            public Node advanceNode(char nodeCode)
            {
                if(nodeCode == 'A')
                {
                    return APointTo;
                }
                else if(nodeCode == 'B')
                {
                    return BPointTo;
                }
                else
                {
                    return Empty;
                }
            }

            public void setA(Node nodePoint)
            {
                APointTo = nodePoint;
            }
            public void setB(Node nodePoint)
            {
                BPointTo = nodePoint;
            }

            public Node getA()
            {
                return APointTo;
            }
            public string getName()
            {
                return nodeName;
            }

            public string getState()
            {
                return currentState; 
            }

            public string getString()
            {
                string verhaal = "For node " + nodeName + " A points to node(s) " + APointTo + " B points to node(s) " + BPointTo;
                return verhaal;
            }
            public string getStateString()
            {
                string verhaal = "This node is currently " + currentState;
                return verhaal;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Nodal.Node s0 = new Nodal.Node("s0", "Unlocked");
            Nodal.Node s1 = new Nodal.Node("s1", "Unlocked");
            Nodal.Node s2 = new Nodal.Node("s2", "Unlocked");
            Nodal.Node s3 = new Nodal.Node("s3", "Unlocked");

            s0.setA(s2);
            s0.setB(s1);
            s1.setA(s1);
            s1.setB(s2);
            s2.setB(s3);
            s3.setA(s3);
            s3.setB(s0);

            Console.WriteLine("Tests0:"+s0.getA());

            string text;
            string sequence = "BAAB";
            text = NodeLogic.nodeSequence(sequence, s0);
            Console.WriteLine(text);
        }
    }
}
