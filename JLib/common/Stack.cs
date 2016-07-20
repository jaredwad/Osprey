using System;

namespace com.virtus.JLib.common {
	public class Stack<T> {
		private SingleLinkedList<T> _list;

		public Stack() {
			_list = new SingleLinkedList<T>();
		}

		public void Push(T item) {
			_list.AddToFront(item);
		}

		public T Pop() {
			return _list.DeleteFront();
		}

		public T Peek() {
			return _list.GetAt(0);
		}
	}
}

