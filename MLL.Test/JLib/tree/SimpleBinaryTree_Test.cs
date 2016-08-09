using System;
using NUnit.Framework;
using com.virtus.JLib.tree;
using System.Collections.Generic;

namespace com.virtus.test.JLib.tree {
	[TestFixture]
	public class SimpleBinaryTree_Test {

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { 3, 5, 2, 4 })]
		[TestCase(new int[] { 7, 6, 8, 1 })]
		public void insert(int[] a){
			var bTree = new SimpleBinaryTree<int>();

			foreach (int i in a) {
				bTree.insert(i);
			}

			foreach (int i in a) {
				Assert.True(bTree.Contains(i));
			}
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { 3, 5, 2, 4 })]
		[TestCase(new int[] { 7, 6, 8, 1 })]
		public void delete(int[] a) {
			var bTree = new SimpleBinaryTree<int>();
			var list = new List<int>(a);
			var rand = new Random();
			int numDel = list.Count / 2;

			foreach (int i in a) {
				bTree.insert(i);
			}

			for (int i = 0; i < numDel; ++i) {
				int item = list[rand.Next(list.Count)];

				list.Remove(item);
				bTree.Delete(item);
			}

			foreach (int i in list) {
				Assert.True(bTree.Contains(i));
			}
		}

	}
}

