using System;
using System.Collections.Generic;

namespace _0_0_Scratchpad
{
	internal class Program
	{
		private static List<string> _treeValues;

		private static TreeNode _singlePathBalancedTree = CreateSinglePathBalancedTree();
		private static TreeNode _perfectTree = CreatePerfectTree();

		private static void Main(string[] args)
		{
			_treeValues = new List<string>();

			Console.WriteLine("IN ORDER TRAVERSAL");
			Console.WriteLine("===============================================================================================");

			Console.WriteLine($"Attempting to perform an In Order Traversal on a single path balanced tree with {_singlePathBalancedTree.Value} as the root value.");
			string outcome = InOrderTraversal(_singlePathBalancedTree);
			Console.WriteLine(outcome);

			_treeValues.Clear();

			Console.WriteLine($"Attempting to perform an In Order Traversal on a perfect tree with {_perfectTree.Value} as the root value.");
			outcome = InOrderTraversal(_perfectTree);
			Console.WriteLine(outcome);

			_treeValues.Clear();

			Console.WriteLine("");
			Console.WriteLine("PRE-ORDER TRAVERSAL");
			Console.WriteLine("===============================================================================================");

			Console.WriteLine($"Attempting to perform a Pre-Order Traversal on a single path balanced tree with {_singlePathBalancedTree.Value} as the root value.");
			outcome = PreOrderTraversal(_singlePathBalancedTree);
			Console.WriteLine(outcome);

			_treeValues.Clear();

			Console.WriteLine($"Attempting to perform an Pre-Order Traversal on a perfect tree with {_perfectTree.Value} as the root value.");
			outcome = PreOrderTraversal(_perfectTree);
			Console.WriteLine(outcome);

			_treeValues.Clear();

			Console.WriteLine("");
			Console.WriteLine("POST-ORDER TRAVERSAL");
			Console.WriteLine("===============================================================================================");

			Console.WriteLine($"Attempting to perform a Post-Order Traversal on a single path balanced tree with {_singlePathBalancedTree.Value} as the root value.");
			outcome = PostOrderTraversal(_singlePathBalancedTree);
			Console.WriteLine(outcome);

			_treeValues.Clear();

			Console.WriteLine($"Attempting to perform an Post-Order Traversal on a perfect tree with {_perfectTree.Value} as the root value.");
			outcome = PostOrderTraversal(_perfectTree);
			Console.WriteLine(outcome);

			Console.ReadLine();
		}

		/// <summary>
		/// Left branch --> Current node --> Right branch
		/// </summary>
		/// <param name="node">Root node</param>
		private static string InOrderTraversal(TreeNode node)
		{
			if (node != null)
			{
				InOrderTraversal(node.Left);
				Visit(node);
				InOrderTraversal(node.Right);
			}

			return string.Join(",", _treeValues);
		}

		/// <summary>
		/// Current node --> Left branch --> Right branch
		/// </summary>
		/// <param name="node">Root node</param>
		private static string PreOrderTraversal(TreeNode node)
		{
			if (node != null)
			{
				Visit(node);
				PreOrderTraversal(node.Left);
				PreOrderTraversal(node.Right);
			}

			return string.Join(",", _treeValues);
		}

		/// <summary>
		/// Left branch --> Right branch --> Current node
		/// </summary>
		/// <param name="node">Root node</param>
		private static string PostOrderTraversal(TreeNode node)
		{
			if (node != null)
			{
				PostOrderTraversal(node.Left);
				PostOrderTraversal(node.Right);
				Visit(node);
			}

			return string.Join(",", _treeValues);
		}

		private static void Visit(TreeNode node)
		{
			_treeValues.Add(node.Value);
		}

		private static TreeNode CreateSinglePathBalancedTree()
		{
			TreeNode rootLeftGreatGrandchild = new TreeNode("2", null, null);
			TreeNode rootLeftGrandchild = new TreeNode("3", rootLeftGreatGrandchild, null);
			TreeNode rootLeftChild = new TreeNode("4", rootLeftGrandchild, null);

			TreeNode rootRightGreatGrandchild = new TreeNode("8", null, null);
			TreeNode rootRightGrandchild = new TreeNode("7", null, rootRightGreatGrandchild);
			TreeNode rootRightChild = new TreeNode("6", null, rootRightGrandchild);

			TreeNode root = new TreeNode("5", rootLeftChild, rootRightChild);

			return root;
		}

		private static TreeNode CreatePerfectTree()
		{
			TreeNode rootLeftLeftGrandchild = new TreeNode("2", null, null);
			TreeNode rootLeftRightGrandchild = new TreeNode("4", null, null);
			TreeNode rootLeftChild = new TreeNode("3", rootLeftLeftGrandchild, rootLeftRightGrandchild);

			TreeNode rootRightLeftGrandchild = new TreeNode("6", null, null);
			TreeNode rootRightRightGrandchild = new TreeNode("8", null, null);
			TreeNode rootRightChild = new TreeNode("7", rootRightLeftGrandchild, rootRightRightGrandchild);

			TreeNode root = new TreeNode("5", rootLeftChild, rootRightChild);

			return root;
		}
	}

	internal class TreeNode
	{
		public string Value { get; private set; }
		public TreeNode Left { get; private set; }
		public TreeNode Right { get; private set; }

		public TreeNode(string value, TreeNode left, TreeNode right)
		{
			Value = value;
			Left = left;
			Right = right;
		}
	}
}