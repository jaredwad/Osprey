using System;
namespace com.virtus.JLib.common {
	public class Queue<T> {
		DoubleLinkedList<T> _list;

		public Queue() {
			_list = new DoubleLinkedList<T>();
		}

		public void Enqueue(T item) {
			_list.AddToFront(item);
		}

		public T Dequeue() {
			return _list.DeleteBack();
		}

		public T Peek() {
			return _list.Back();
		}
	}
}

