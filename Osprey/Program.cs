using System;
using System.Diagnostics;
using com.virtus.MLL.search;
using com.virtus.JLib.common;
using System.Collections.Generic;
using System.Linq;

namespace Osprey {
	class MainClass {
		public delegate int zeroTest();
		public delegate void oneTest(int item);
		public delegate int oneIntTest(int item);

		public static void Main(string[] args) {
			var singleList = new SingleLinkedList<int>();
			var doubleList = new DoubleLinkedList<int>();
			var list = new LinkedList<int>();

			int size = 100000;

			var arr = new int[size];

			Random rand = new Random();

			for (int i = 0; i < size; ++i) {
				arr[i] = rand.Next();
			}

			int[] randArr = arr.OrderBy(x => rand.Next()).ToArray();

			Debug.Assert(arr != randArr);

			//////Single Linked List

			Console.WriteLine("Single Linked List");

			timeOne(singleList.AddToFront, arr, "\tAdd Front");

			timeZero(singleList.DeleteFront, arr.Length, "\tDelete Front");

			timeOne(singleList.AddToBack, arr, "\tAdd Back");

			timeZero(singleList.DeleteFront, arr.Length, "\tDelete Front");

			timeZero(singleList.DeleteBack, arr.Length, "\tDelete Front");

			timeOne(singleList.Delete, randArr, "\tRandom Delete");

			//////Double Linked List

			Console.WriteLine("Single Linked List");

			timeOne(doubleList.AddToFront, arr, "\tAdd Front");

			timeZero(doubleList.DeleteFront, arr.Length, "\tDelete Front");

			timeOne(doubleList.AddToBack, arr, "\tAdd Back");

			timeZero(doubleList.DeleteFront, arr.Length, "\tDelete Front");

			timeZero(doubleList.DeleteBack, arr.Length, "\tDelete Front");

			timeOne(doubleList.Delete, randArr, "\tRandom Delete");

		}

		public static void timeZero(zeroTest test, int numItter, string name){
			var sw = new Stopwatch();

			sw.Start();

			for (int i = 0; i < numItter; ++i) {
				test();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\t{0}: {1}", name, sw.Elapsed));
		}

		public static void timeOne(oneTest test, int[] arr, string name) {
			var sw = new Stopwatch();

			int size = arr.Length;

			sw.Start();

			for (int i = 0; i < size; ++i) {
				test(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\t{0}: {1}", name, sw.Elapsed));
		}

		public static void timeOneInt(oneIntTest test, int[] arr, string name) {
			var sw = new Stopwatch();

			int size = arr.Length;

			sw.Start();

			for (int i = 0; i < size; ++i) {
				test(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\t{0}: {1}", name, sw.Elapsed));
		}

		public static void testLists(){
			var sw = new Stopwatch();

			var singleList = new SingleLinkedList<int>();
			var doubleList = new DoubleLinkedList<int>();
			var list = new LinkedList<int>();

			int size = 100000;

			var arr = new int[size];

			Random rand = new Random();

			for (int i = 0; i < size; ++i) {
				arr[i] = rand.Next();
			}

			int[] randArr = arr.OrderBy(x => rand.Next()).ToArray();

			Debug.Assert(arr != randArr);

			//////Single Linked List

			Console.WriteLine("Single Linked List");

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				singleList.AddToFront(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tAdd Front {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				singleList.DeleteFront();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tDelete Front {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				singleList.AddToBack(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tAdd Back {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				singleList.DeleteBack();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tDelete Back {0}", sw.Elapsed));

			for (int i = 0; i < size; ++i) {
				singleList.AddToBack(arr[i]);
			}

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				singleList.Delete(randArr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tRandom Delete {0}", sw.Elapsed));

			singleList = null;

			//////Double Linked List

			Console.WriteLine("Double Linked List");

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				doubleList.AddToFront(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tAdd Front {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				doubleList.DeleteFront();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tDelete Front {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				doubleList.AddToBack(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tAdd Back {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				doubleList.DeleteBack();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tDelete Back {0}", sw.Elapsed));

			for (int i = 0; i < size; ++i) {
				doubleList.AddToBack(arr[i]);
			}

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				doubleList.Delete(randArr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tRandom Delete {0}", sw.Elapsed));

			doubleList = null;

			//////Standard Linked List

			Console.WriteLine("Linked List");

			sw.Start();

			for (int i = 0; i < size; ++i) {
				list.AddFirst(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tAdd Front {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				list.RemoveFirst();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tDelete Front {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				list.AddLast(arr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tAdd Back {0}", sw.Elapsed));

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				list.RemoveLast();
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tDelete Back {0}", sw.Elapsed));

			for (int i = 0; i < size; ++i) {
				list.AddLast(arr[i]);
			}

			sw.Restart();

			for (int i = 0; i < size; ++i) {
				list.Remove(randArr[i]);
			}

			sw.Stop();

			Console.WriteLine(string.Format("\tRandom Delete {0}", sw.Elapsed));
		}
	}
}
