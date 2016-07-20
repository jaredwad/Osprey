using System;
namespace com.virtus.JLib.common {
	public class DoubleLinkedList<T> {
		private Node<T> _head = null;
		private Node<T> _tail = null;

		private int _len = 0;

		public int Length => _len;

		/// <param name="data">The data to insert at the end of the list</param>
		/// <summary>
		///   <para>This is identical to AddToBack</para>
		///   <para>O(1)</para>
		///   <seealso cref="DataStructures.com.virtus.common.DoubleLinkedList.AddToBack"/>
		/// </summary>
		public void Add(T data) { AddToBack(data); }

		/// <param name="data">The data to insert at the end of the list</param>
		/// <summary>
		///   <para>Adds data to the back of the list</para>
		///   <para>O(1)</para>
		/// </summary>
		public void AddToBack(T data) {
			var node = new Node<T>(data, _tail);

			if (_head == null) {
				_head = _tail = node;
				_len = 1;
				return;
			}

			_tail.Child = node;
			_tail = node;
			_len++;
		}

		/// <param name="data">The data to insert at the beginning of the list</param>
		/// <summary>
		///   <para>Adds data to the front of the list</para>
		///   <para>O(1)</para>
		/// </summary>
		public void AddToFront(T data) {
			var node = new Node<T>(data);

			if (_head == null) {
				_head = _tail = node;
				_len = 1;
				return;
			}

			node.Child = _head;
			_head.Parant = node;
			_head = node;
			_len++;
		}

		/// <param name="data">The data to remove from the list</param>
		/// <summary>
		///   <para>Removes the first instance of data from the list</para>
		///   <para>O(n)</para>
		/// </summary>
		public void Delete(T data) {
			if (_head == null) return;

			var node = _head;

			while (node.Child != null) {
				if (node.Child.Data.Equals(data)) {
					var temp = node.Child;
					node.Child = temp.Child;
					temp.Child.Parant = node;
					temp = null;
					return;
				}
				node = node.Child;
			}

		}

		/// <summary>
		///   <para>Removes and returns the first item in the list</para>
		///   <para>O(1)</para>
		/// </summary>
		public T DeleteFront() {
			if (_head == null) throw new NullReferenceException("Cannont delete from an empty list");

			var data = _head.Data;

			_head = _head.Child;

			if (_head != null)
				_head.Parant = null;

			_len--;
			return data;
		}

		/// <summary>
		///   <para>Removes and returns the last item in the list</para>
		///   <para>O(1)</para>
		/// </summary>
		public T DeleteBack() {
			if (_tail == null) throw new NullReferenceException("Cannont delete from an empty list");

			var data = _tail.Data;

			_tail = _tail.Parant;

			if (_tail != null)
				_tail.Child = null;

			_len--;
			return data;
		}

		/// <summary>
		///   <para>Returns the item at the specified location in the list without removing it</para>
		///   <para>O(n)</para>
		/// </summary>
		public T GetItemAt(int index) {
			if (index >= _len) throw new ArgumentOutOfRangeException(string.Format("{0} is larger than the size of the list", index));

			return index >= (_len / 2) ? RetrieveFromBack(_len - 1 - index) : RetrieveFromFront(index);
		}

		public T Front() {
			return RetrieveFromFront(0);
		}

		public T Back() {
			return RetrieveFromBack(0);
		}

		public T[] toArray() {
			var array = new T[_len];

			var node = _head;

			for (int i = 0; i < _len; ++i) {
				array[i] = node.Data;
				node = node.Child;
			}

			return array;
		}

		private T RetrieveFromBack(int index) { return RetrieveNodeFromBack(index).Data; }
		private T RetrieveFromFront(int index) { return RetrieveNodeFromFront(index).Data; }

		private Node<T> RetrieveNodeFromFront(int index) {
			var node = _head;

			for (int i = 0; i < index; ++i) {
				node = node.Child;
			}
			return node;
		}

		private Node<T> RetrieveNodeFromBack(int index) {
			var node = _tail;

			for (int i = 0; i < index; ++i) {
				node = node.Parant;
			}
			return node;
		}

		internal class Node<T> {
			public T Data;
			public Node<T> Child;
			public Node<T> Parant;

			internal Node(T pData, Node<T> pParant = null, Node<T> pChild = null) {
				Data = pData;
				Child = pChild;
				Parant = pParant;
			}
		}
	}
}

