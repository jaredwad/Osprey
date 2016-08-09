using System;
namespace com.virtus.JLib.tree {
	public class SimpleBinaryTree<T> where T : IComparable {
		private BinaryNode<T> _root;
		private int _count;

		public int Count{ get { return _count;} }

		public SimpleBinaryTree() {
			_root = null;
		}

		public bool Contains(T item) {
			var node = _root.search(_root, item);

			return node != null;
		}

		public void insert(T item){
			if(_root == null)
				_root = new BinaryNode<T>(item);
			else
				_root.insert(_root, item);

			_count++;
		}

		public T Delete(T item){
			if (_root == null) throw new NullReferenceException("cannont delete from an empty tree");

			BinaryNode<T> node = _root;
			BinaryNode<T> next = null;

			T ret = default(T);

			int order = 0;

			while (node != null) {
				int pos = item.CompareTo(node.Data);

				if (pos == 0) {
					ret = node.Data;

					if (node.Right == null && node.Left == null){
						if (order == 0)
							_root = null;
						else if (order == 1)
							node.Parent.Left = null;
						else
							node.Parent.Right = null;
					} else if(node.Right == null){
						if (order == 1)
							node.Parent.Left = node.Left;
						else
							node.Parent.Right = node.Left;
					} else if(node.Left == null){
						if (order == 1)
							node.Parent.Left = node.Right;
						else
							node.Parent.Right = node.Right;
					} else {
						next = node.Left;
						while(next != null){
							if(next.Left != null){
								next = next.Left;
								continue;
							} else {
								node.Data = next.Data;
								next.Parent.Left = null;
								break;
							}
						}
					}
					break;
				}

				if(pos > 0){
					node = node.Right;
					order = 2;
				} else {
					node = node.Left;
					order = 1;
				}

			}

			if(node == null){
				throw new IndexOutOfRangeException(string.Format("Cannot delete {0} from the tree", item.ToString()));
			}

			return ret;
		}
	}
}

