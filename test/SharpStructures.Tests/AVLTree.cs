using System;
using Xunit;
using SharpStructures;

namespace Tests
{
    public class AVLTree : IDisposable {
        AVLTree<int> smallTree;
        AVLTree<int> mediumTree;
        AVLTree<int> largeTree;

        // Small      Medium          Large
        //  20+        20+           __20+__
        //  /         /  \          /       \
        // 4         4    26       4         26
        //          / \           / \       /  \
        //         3   9         3+  9    21    30
        //                      /   / \
        //                     2   7   11

        public AVLTree() {
            smallTree = new AVLTree<int>();
            mediumTree = new AVLTree<int>();
            largeTree = new AVLTree<int>();

            smallTree.Add(20);
            smallTree.Add(4);

            mediumTree.Add(20);
            mediumTree.Add(4);
            mediumTree.Add(26);
            mediumTree.Add(3);
            mediumTree.Add(9);

            largeTree.Add(20);
            largeTree.Add(4);
            largeTree.Add(26);
            largeTree.Add(3);
            largeTree.Add(9);
            largeTree.Add(21);
            largeTree.Add(30);
            largeTree.Add(2);
            largeTree.Add(7);
            largeTree.Add(11);
        }

        void IDisposable.Dispose() {
            smallTree.Clear();
            mediumTree.Clear();
            largeTree.Clear();
        }

        void PrintTrees() {
            Console.WriteLine("Small: ");
            smallTree.Print();
            Console.WriteLine("Medium: ");
            mediumTree.Print();
            Console.WriteLine("Large: ");
            largeTree.Print();
        }

        /*
        [Fact]
        public void ShouldSetupBaseTrees() {
            PrintTrees(); // Check terminal, compare with top comment
        }
        */

        /*
        [Fact]
        public void ShouldLeftRightBalanceWith15() { // Confirm in terminal
            Console.WriteLine("Before inserting 15.");
            PrintTrees();
            Console.WriteLine("Inserting 15. After L-R balancing: ");
            smallTree.Add(15);
            mediumTree.Add(15);
            largeTree.Add(15);
            PrintTrees();
        }

        [Fact]
        public void ShouldLeftRightBalanceWith8() { // Confirm in terminal
            Console.WriteLine("Before inserting 8.");
            PrintTrees();
            Console.WriteLine("Inserting 8. After L-R balancing: ");
            smallTree.Add(8);
            mediumTree.Add(8);
            largeTree.Add(8);
            PrintTrees();
        }

        [Fact]
        public void ShouldContainElements() {
            Assert.Equal(true, largeTree.Contains(3));
            Assert.Equal(true, largeTree.Contains(2));
            Assert.Equal(true, largeTree.Contains(26));
            Assert.Equal(true, largeTree.Contains(20));
            Assert.Equal(true, largeTree.Contains(21));
            Assert.Equal(false, largeTree.Contains(999));
            Assert.Equal(false, largeTree.Contains(-1));
        }

        [Fact]
        public void ShouldGetElements() {
            Assert.Equal(21, largeTree.Get(21));
            Assert.Equal(0, largeTree.Get(999));
        }
        */

        [Fact]
        public void ShouldRemoveLeafNode() {
            Console.WriteLine("Before leaf node removal: ");
            smallTree.Print();
            Assert.Equal(4, smallTree.Remove(4));
            Console.WriteLine("After leaf node removal: ");
            smallTree.Print();
        }

        [Fact]
        public void ShouldRemoveRootOfBalancedAVLSubtree4() {
            Console.WriteLine("Before root removal of subtree 4: ");
            largeTree.Print();
            Assert.Equal(4, largeTree.Remove(4));
            Console.WriteLine("After root removal of subtree 4: ");
            largeTree.Print();
        }

        [Fact]
        public void ShouldRemoveRootOfBalancedAVLSubtree26() {
            Console.WriteLine("Before root removal of subtree 26: ");
            largeTree.Print();
            Assert.Equal(26, largeTree.Remove(26));
            Console.WriteLine("After root removal of subtree 26: ");
            largeTree.Print();
        }

        [Fact]
        public void ShouldRemoveRootOfBalancedAVLSubtree20() {
            Console.WriteLine("Before root removal of subtree 20: ");
            largeTree.Print();
            Assert.Equal(20, largeTree.Remove(20));
            Console.WriteLine("After root removal of subtree 20: ");
            largeTree.Print();
        }

        /*
        [Fact]
        public void ShouldCountHeight() {
            Assert.Equal(2, smallTree.Height());
            Assert.Equal(3, mediumTree.Height());
            Assert.Equal(4, largeTree.Height());
        }
        */
    }
}
