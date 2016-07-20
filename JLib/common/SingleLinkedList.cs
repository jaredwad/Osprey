using System;

namespace com.virtus.JLib.common {
	public class SingleLinkedList<T> {
		private Node<T> _head;
		private Node<T> _tail;

		private int _count = 0;

		public int Count => _count;
		public T Head => _head.Data;
		public T Tail => _tail.Data;

		public SingleLinkedList() { _head = _tail = null; }

		/// <param name="data">The data to insert at the end of the list</param>
		/// <summary>
		///   <para>This is identical to AddToBack</para>
		///   <para>O(1)</para>
		///   <see cref="AddToBack"/>
		/// </summary>
		public void Add(T data) { AddToBack(data); }

		/// <param name="data">The data to insert at the end of the list</param>
		/// <summary>
		///   <para>Adds data to the back of the list</para>
		///   <para>O(1)</para>
		/// </summary>
		public void AddToBack(T data) {
			var node = new Node<T>(data);

			if (_head == null) {
				_head = _tail = node;
				_count = 1;
				return;
			}

			_tail.Next = node;
			_tail = _tail.Next;

			_count++;
		}

		/// <param name="data">The data to insert at the begining of the list</param>
		/// <summary>
		///   <para>Adds data to the front of the list</para>
		///   <para>O(1)</para>
		/// </summary>
		public void AddToFront(T data) {
			var node = new Node<T>(data) { Next = _head };

			if (_head == null) {
				_head = _tail = node;
				_count = 1;
				return;
			}

			_head = node;
			_count++;
		}

		/// <param name="data">The data to remove from the list</param>
		/// <summary>
		///   <para>Removes the first instance of data in the list. If data does not exist it does nothing</para>
		///   <para>O(n)</para>
		/// </summary>
		public void Delete(T data) {
			if (_head == null) return;

			var node = _head;

			while (node.Next != null) {
				if (node.Next.Data.Equals(data)) {
					node.Next = node.Next.Next;
					_count--;
					return;
				}
				node = node.Next;
			}
		}

		/// <summary>
		///   <para>Removes the first item in the list. If the list is empty, it throws a Null Reference Exception</para>
		///   <para>O(1)</para>
		/// </summary>
		public T DeleteFront() {
			if (_head == null) throw new NullReferenceException("cannont delete from an empty list");

			T data = _head.Data;

			_head = _head.Next;
			_count--;

			return data;
		}

		/// <summary>
		///   <para>Removes the last item in the list. If the list is empty, it throws a Null Reference Exception</para>
		///   <para>O(n)</para>
		/// </summary>
		public T DeleteBack() {
			if (_head == null) throw new NullReferenceException("cannont delete from an empty list");

			T data = _tail.Data;

			if (_head == _tail) //if there is one elements in the list
			{
				_head = _tail = null;
				_count = 0;
				return data;
			}

			var node = _head;

			while (node?.Next != _tail) {
				node = node.Next;
			}

			node.Next = null;
			_tail = node;

			_count--;
			return data;
		}

		public T GetAt(int index) { return RetrieveNode(index).Data; }

		public T[] toArray() {
			var array = new T[_count];

			var node = _head;

			for (int i = 0; i < _count; ++i) {
				array[i] = node.Data;
				node = node.Next;
			}

			return array;
		}

		private Node<T> RetrieveNode(int index) {
			if (index >= _count) throw new IndexOutOfRangeException(string.Format("{0} is bigger than the size of the array", index));

			var node = _head;

			for (int i = 0; i < index; ++i) {
				node = node.Next;
			}
			return node;
		}

		internal class Node<T> {
			public T Data;
			public Node<T> Next;

			internal Node(T pData, Node<T> pNext = null) {
				Data = pData;
				Next = pNext;
			}
		}
	}
}

