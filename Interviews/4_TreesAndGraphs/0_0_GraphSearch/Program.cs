using System;
using System.Collections.Generic;
using System.Linq;

namespace _0_0_GraphSearch
{
	internal class Program
	{
		private static List<string> _nodeValues;
		private const int startingPoint = 5;

		private static Node _singlePathBalancedTree = CreateSinglePathBalancedTree();
		private static Node _perfectTree = CreatePerfectTree();

		private static void Main(string[] args)
		{
			_nodeValues = new List<string>();

			Console.WriteLine("DEPTH FIRST SEARCH");
			Console.WriteLine("===============================================================================================");

			Console.WriteLine($"Attempting to perform a recursive Depth First Search on a single path balanced tree with {_singlePathBalancedTree.Value} as the root value.");
			string outcome = DepthFirstSearchWithRecursion(_singlePathBalancedTree);
			Console.WriteLine(outcome);

			_nodeValues.Clear();

			Console.WriteLine($"Attempting to perform a recursive Depth First Search on a perfect tree with {_perfectTree.Value} as the root value.");
			outcome = DepthFirstSearchWithRecursion(_perfectTree);
			Console.WriteLine(outcome);

			_nodeValues.Clear();

			//Console.WriteLine($"Attempting to perform a Depth First Search using a stack on a perfect tree with {_perfectTree.Value} as the root value.");
			//outcome = DepthFirstSearchWithStack(_perfectTree.Value, _perfectTree);
			//Console.WriteLine(outcome);

			//_nodeValues.Clear();

			Console.WriteLine("");
			Console.WriteLine("BREADTH FIRST SEARCH");
			Console.WriteLine("===============================================================================================");

			Console.WriteLine($"Attempting to perform a Breadth First Search using a stack on a single path balanced tree with {_singlePathBalancedTree.Value} as the root value.");
			outcome = BreadthFirstSearchUsingQueue(_singlePathBalancedTree);
			Console.WriteLine(outcome);

			_nodeValues.Clear();

			Console.WriteLine($"Attempting to perform a Breadth First Search using a stack on a perfect tree with {_perfectTree.Value} as the root value.");
			outcome = BreadthFirstSearchUsingQueue(_perfectTree);
			Console.WriteLine(outcome);

			Console.ReadLine();
		}

		public static string DepthFirstSearchWithRecursion(Node root)
		{
			List<int> vistedNodes = new List<int>();

			Traverse(root.Value, vistedNodes, root);

			return string.Join(",", _nodeValues);
		}

		private static void Traverse(int vertex, List<int> vistedNodes, Node root)
		{
			vistedNodes.Add(vertex);

			_nodeValues.Add(vertex.ToString());

			if (root.AdjacentNodes.ContainsKey(vertex))
			{
				foreach (int neighbour in root.AdjacentNodes[vertex].Where(adjacentNode => !vistedNodes.Contains(adjacentNode)))
				{
					Traverse(neighbour, vistedNodes, root);
				}
			}
		}

		// TODO: FIXME
		//private static string DepthFirstSearchWithStack(int vertex, Node root)
		//{
		//	List<int> vistedNodes = new List<int>
		//	{
		//		vertex
		//	};

		//	Stack<int> stack = new Stack<int>();

		//	stack.Push(vertex);

		//	while (stack.Count > 0)
		//	{
		//		int current = stack.Pop();

		//		_nodeValues.Add(current.ToString());

		//		if (!vistedNodes.Contains(current))
		//		{
		//			vistedNodes.Add(current);
		//		}

		//		if (root.AdjacentNodes.ContainsKey(current))
		//		{
		//			foreach (int neighbour in root.AdjacentNodes[current].Where(adjacentNode => !visited.Contains(adjacentNode)))
		//			{
		//				vistedNodes.Add(neighbour);
		//				stack.Push(neighbour);
		//			}
		//		}
		//	}

		//	return string.Join(",", _nodeValues);
		//}

		private static string BreadthFirstSearchUsingQueue(Node root)
		{
			Queue<int> queue = new Queue<int>();
			List<int> vistedNodes = new List<int>();

			vistedNodes.Add(root.Value);

			queue.Enqueue(root.Value);

			while (queue.Any())
			{
				int current = queue.Dequeue();

				_nodeValues.Add(current.ToString());

				if (root.AdjacentNodes.ContainsKey(current))
				{
					foreach (int neighbour in root.AdjacentNodes[current].Where(adjacentNode => !vistedNodes.Contains(adjacentNode)))
					{
						vistedNodes.Add(neighbour);
						queue.Enqueue(neighbour);
					}
				}
			}

			return string.Join(",", _nodeValues);
		}

		private static Node CreateSinglePathBalancedTree()
		{
			Node root = new Node(startingPoint);

			Node rootLeftGreatGrandchild = new Node(2);
			Node rootLeftGrandchild = new Node(3);
			Node rootLeftChild = new Node(4);

			Node rootRightGreatGrandchild = new Node(8);
			Node rootRightGrandchild = new Node(7);
			Node rootRightChild = new Node(6);

			root.AddEdge(root, rootLeftChild);
			root.AddEdge(root, rootRightChild);

			root.AddEdge(rootLeftChild, rootLeftGrandchild);
			root.AddEdge(rootRightChild, rootRightGrandchild);

			root.AddEdge(rootLeftGrandchild, rootLeftGreatGrandchild);
			root.AddEdge(rootRightGrandchild, rootRightGreatGrandchild);

			return root;
		}

		private static Node CreatePerfectTree()
		{
			Node root = new Node(startingPoint);

			Node rootLeftLeftGrandchild = new Node(2);
			Node rootLeftRightGrandchild = new Node(4);
			Node rootLeftChild = new Node(3);

			Node rootRightLeftGrandchild = new Node(6);
			Node rootRightRightGrandchild = new Node(8);
			Node rootRightChild = new Node(7);

			root.AddEdge(root, rootLeftChild);
			root.AddEdge(root, rootRightChild);

			root.AddEdge(rootLeftChild, rootLeftLeftGrandchild);
			root.AddEdge(rootLeftChild, rootLeftRightGrandchild);

			root.AddEdge(rootRightChild, rootRightLeftGrandchild);
			root.AddEdge(rootRightChild, rootRightRightGrandchild);

			return root;
		}
	}

	internal class Node
	{
		public Dictionary<int, List<int>> AdjacentNodes;

		public int Value { get; private set; }

		public Node(int value)
		{
			AdjacentNodes = new Dictionary<int, List<int>>();
			Value = value;
		}

		public void AddEdge(Node source, Node target)
		{
			int sourceValue = source.Value;
			int targetValue = target.Value;

			if (AdjacentNodes.ContainsKey(sourceValue))
			{
				try
				{
					AdjacentNodes[sourceValue].Add(targetValue);
				}
				catch
				{
					Console.WriteLine($"The edge {sourceValue} to {targetValue} already exists!");
				}
			}
			else
			{
				List<int> targetNodes = new List<int>
				{
					targetValue
				};

				AdjacentNodes.Add(sourceValue, targetNodes);
			}
		}
	}
}