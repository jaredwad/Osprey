using System;
namespace com.virtus.JLib.tree {
	public class BinaryNode<T> where T : IComparable {
		public delegate void processItem(T item);

		public T Data;

		public BinaryNode<T> Parent;
		public BinaryNode<T> Left;
		public BinaryNode<T> Right;

		public BinaryNode(
			T pData
			, BinaryNode<T> pParent = null
			, BinaryNode<T> pLeft   = null
			, BinaryNode<T> pRight  = null)
		{
			Data = pData;

			Parent = pParent;
			Left   = pLeft;
			Right  = pRight;
		}

		public bool isLeaf() { return Right == null && Left == null; }

		public BinaryNode<T> insert(BinaryNode<T> pNode, T pData, BinaryNode<T> pParent = null){
			if(pNode == null){
				pNode = new BinaryNode<T>(pData, pParent);
				return pNode;
			}

			return insert(pData.CompareTo(pNode.Data) > 0 ? pNode.Right : pNode.Left, pData, pNode);
		}

		public BinaryNode<T> search(BinaryNode<T> pNode, T pData){
			if (pNode == null)
				return null;

			int pos = pData.CompareTo(pNode.Data);

			if (pos == 0)
				return pNode;
			else if (pos > 0)
				return search(pNode.Right, pData);
			else
				return search(pNode.Left , pData);
		}

		public BinaryNode<T> minimum(BinaryNode<T> pNode){
			if (pNode == null) return null;

			var min = pNode;

			while (min.Left != null)
				min = min.Left;

			return min;
		}

		public BinaryNode<T> Maximum(BinaryNode<T> pNode) {
			if (pNode == null) return null;

			var min = pNode;

			while (min.Right != null)
				min = min.Right;

			return min;
		}


		public void DFS(BinaryNode<T> node, processItem process){
			preOrder(node, process);
		}

		public void inOrder(BinaryNode<T> node, processItem process){
			if (node != null) {
				inOrder(node.Left, process);
				process(node.Data);
				inOrder(node.Right, process);
			}
		}

		public void preOrder(BinaryNode<T> node, processItem process){
			if(node != null){
				process(node.Data);
				postOrder(node.Left, process);
				postOrder(node.Right, process);
			}
		}

		public void postOrder(BinaryNode<T> node, processItem process) {
			if (node != null) {
				postOrder(node.Left, process);
				postOrder(node.Right, process);
				process(node.Data);
			}
		}

		public override string ToString() {
			string result = string.Empty;

			if (Left != null)
				result += Left.ToString();

			result += Data.ToString();

			if (Right != null)
				result += Right.ToString();

			return result;
		}
	}
}

