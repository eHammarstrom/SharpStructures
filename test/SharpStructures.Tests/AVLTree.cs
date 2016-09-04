﻿using System;
using Xunit;
using SharpStructures;

namespace Tests
{
    public class AVLTree : IDisposable {
        AVLTree<int> smallTree;
        AVLTree<int> mediumTree;
        AVLTree<int> largeTree;

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
            largeTree.Add(2);
            largeTree.Add(7);
            largeTree.Add(11);
            largeTree.Add(21);
            largeTree.Add(30);
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

        /*
        [Fact]
        public void ShouldDeleteElements() {
            Assert.Equal(7, tree.Delete(7));
            Assert.Equal(2, tree.Delete(2));
            Console.WriteLine("After removing 7 and 2: ");
            Assert.Equal(false, tree.Contains(7));
            Assert.Equal(false, tree.Contains(2));
        }
        */

        [Fact]
        public void ShouldCountHeight() {
            Assert.Equal(2, smallTree.Height());
            Assert.Equal(3, mediumTree.Height());
            Assert.Equal(4, largeTree.Height());
        }
    }
}
