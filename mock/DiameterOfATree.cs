using System;
using System.Linq;

namespace Problems 
{
public class Tree<T>
{

	public Tree(Node root) =>Root = root;

	public Node Root {get;}
		
	public class Node
	{
		public Node(T value, int cost, IReadOnlyCollection<Node> children)
		{
			// TODO:
			this.Value = value;
			this.Cost = cost;
			this.Children = children; // Consider copy
		}

		public T Value {get;}
		// cost of getting from parent to this node
		public int Cost {get;}
		public IReadOnlyCollection<Node> Children {get;}

		public int Diameter() // Diameter does NOT always involve going "UP" (not sum)
		{
			if (Children.Count == 0) return Cost;
			if (Children.Count == 1) return Children.First().Diameter();
			if (Children.Count == 2)
			{
				var first= Children.First():
				var second = Children.Last();
				var firstDiameter = first.Diameter();
				var secondDiameter = second.Diameter();

				// take maximum
				var max = Max.Max(firstDiameter, secondDiameter);
				var min = Math.Min(firstDiameter, secondDiameter);

				if (min>Cost) // stay "inside" - do not go up
				{
					return min+max; // info about "stay inside" is gone	
				}
				return cost+max;
			} 
		}

	}

	// Length of a longest path in the tree 
	public int Diameter()
	{
		if (Root is null) return 0;
		return Root.Diameter();	
	}


}










}