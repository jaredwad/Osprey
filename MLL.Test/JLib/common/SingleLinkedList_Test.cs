using System;
using NUnit.Framework;
using com.virtus.JLib.common;

namespace com.virtus.test.JLib.common {

	[TestFixture]
	public class SingleLinkedList_Test {

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { 3, 5, 2, 4 })]
		[TestCase(new int[] { 7, 6, 8, 1 })]
		public void Add(int[] a){

			var list = new SingleLinkedList<int>();

			foreach(int i in a){
				list.Add(i);
			}

			Assert.AreEqual(a, list.toArray());

			list = new SingleLinkedList<int>();

			foreach (int i in a) {
				list.AddToFront(i);
			}

			Array.Reverse(a);

			Assert.AreEqual(a, list.toArray());
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { 3, 5, 2, 4, 9 })]
		[TestCase(new int[] { 7, 6, 8, 2, 1 })]
		public void Delete(int[] a) {

			var list = new SingleLinkedList<int>();

			foreach (int i in a) {
				list.Add(i);
			}

			list.DeleteFront();
			list.DeleteBack();

			int len = a.Length;

			int[] b = new int[len-2];

			for (int i = 1; i < len-1; ++i){
				b[i - 1] = a[i];
			}

			Assert.AreEqual(b, list.toArray());
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4, 5 })]
		[TestCase(new int[] { 3, 5, 2, 4, 9 })]
		[TestCase(new int[] { 7, 6, 8, 2, 1 })]
		public void GetAt(int[] a) {

			var list = new SingleLinkedList<int>();

			foreach (int i in a) {
				list.Add(i);
			}

			for (int i = 0; i < a.Length; ++i) {
				Assert.AreEqual(a[i], list.GetAt(i));
			}
		}
	}
}

