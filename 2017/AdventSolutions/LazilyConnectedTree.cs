using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventSolutions
{
    class LazilyConnectedTree<DataType>
    {
        private class Node
        {
            public DataType Data { get; set; }
            public int Weight { get; set; }
            public List<Node> Children { get; set; } = new List<Node>();
            public Node Parent { get; set; } = null;

            public bool IsBalanced => Children.Distinct(new WeightComparer()).Count() == 1;
            public int TotalWeight => Weight + Children.Sum(child => child.TotalWeight);

            public Node FindItem(DataType data)
            {
                if (Data.Equals(data))
                    return this;
                foreach (Node child in Children)
                {
                    Node result = child.FindItem(data);
                    if (result != null)
                        return result;
                }
                return null;
            }

            public (DataType Source, int NewWeight) FindImbalance()
            {
                if (IsBalanced)
                    throw new InvalidOperationException("Tree is balanced.");
                int badWeight = Children.GroupBy(child => child.TotalWeight).Where(group => group.Count() == 1).Select(group => group.Key).Single();
                return Children.Find(child => child.TotalWeight == badWeight).FindImbalance(Children.Find(child => child.TotalWeight != badWeight).TotalWeight);
            }

            private (DataType Source, int NewWeight) FindImbalance(int weightNeeded)
            {
                if (Children.Count() == 0)
                    return (Data, weightNeeded - TotalWeight + Weight);
                try
                {
                    int badWeight = Children.GroupBy(child => child.TotalWeight).Where(group => group.Count() == 1).Select(group => group.Key).Single();
                    return Children.Find(child => child.TotalWeight == badWeight).FindImbalance(Children.Find(child => child.TotalWeight != badWeight).TotalWeight);
                }
                catch (InvalidOperationException)
                {
                    return (Data, weightNeeded - TotalWeight + Weight);
                }
            }

            private class WeightComparer : IEqualityComparer<Node>
            {
                public bool Equals(Node x, Node y)
                {
                    return x.TotalWeight.Equals(y.TotalWeight);
                }

                public int GetHashCode(Node obj)
                {
                    return obj.Weight.GetHashCode();
                }
            }
        }

        public DataType Root => head.Data;

        private Node head;
        private readonly List<Node> unconnected = new List<Node>();

        public void UpdateItem(DataType data, int weight, List<DataType> childData)
        {
            Node toUpdate = FindConnectedItem(data) ?? unconnected.Find(Node => Node.Data.Equals(data));
            if (toUpdate == null)
            {
                unconnected.ForEach(node =>
                {
                    Node childNode = node.FindItem(data);
                    if (childNode != null)
                    {
                        toUpdate = childNode;
                        return;
                    }
                });
            }
            if (toUpdate == null)
                toUpdate = new Node { Data = data };

            // Update the weight and add children
            toUpdate.Weight = weight;
            toUpdate.Children = new List<Node>();
            childData.ForEach(child => toUpdate.Children.Add(new Node { Data = child, Parent = toUpdate }));
            if (toUpdate.Parent == null)
            {
                if (head == null)
                    head = toUpdate;
                else
                    unconnected.Add(toUpdate);
            }

            UpdateConnections();
        }

        private Node FindConnectedItem(DataType data)
        {
            if (head == null)
                return null;
            return head.FindItem(data);
        }

        private void UpdateConnections()
        {
            // Connect unconnected as new children in tree
            List<Node> newlyConnected = new List<Node>();
            unconnected.ForEach(unconnectedNode =>
            {
                Node childToReplace = FindConnectedItem(unconnectedNode.Data);
                if (childToReplace == null)
                {
                    unconnected.ForEach(otherUnconnected =>
                    {
                        if (otherUnconnected == unconnectedNode)
                            return;
                        Node found = otherUnconnected.FindItem(unconnectedNode.Data);
                        if (found != null)
                            childToReplace = found;
                    });
                }
                if (childToReplace != null)
                {
                    Node parent = childToReplace.Parent;
                    parent.Children.Remove(childToReplace);
                    parent.Children.Add(unconnectedNode);
                    newlyConnected.Add(unconnectedNode);
                    unconnectedNode.Parent = parent;
                }
            });
            newlyConnected.ForEach(node => unconnected.Remove(node));
            // Connect head as child of unconnected
            if (head != null)
            {
                Node childToReplace = null;
                unconnected.ForEach(node =>
                {
                    Node found = node.FindItem(head.Data);
                    if (found != null)
                        childToReplace = found;
                });
                if (childToReplace != null)
                {
                    Node parent = childToReplace.Parent;
                    parent.Children.Remove(childToReplace);
                    parent.Children.Add(head);
                    head.Parent = parent;
                }
            }
            while (head.Parent != null)
                head = head.Parent;
            unconnected.RemoveAll(node => node.Data.Equals(head.Data));
        }

        public (DataType Source, int NewWeight) FindImbalance()
        {
            return head.FindImbalance();
        }
    }
}
