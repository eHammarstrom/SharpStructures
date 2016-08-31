using System;
using Xunit;
using SharpStructures;
using System.Linq;

namespace Tests
{
    public class AVLTree : IDisposable {
        AVLTree<int> tree;

        public AVLTree() {
            tree = new AVLTree<int>();
            tree.Add(10);
            tree.Add(2);
            tree.Add(7);
            tree.Add(1);
            tree.Add(8);
            tree.Add(6);
            tree.Add(9);
            tree.Add(23);
            tree.Add(20);
            tree.Add(12);
            tree.Add(15);
            tree.Add(13);
            tree.Add(14);
            tree.Add(19);
            tree.Add(18);
        }

        void IDisposable.Dispose() => tree.Clear();

        [Fact]
        public void ShouldPrintTree() => tree.Print(); // Check console

        [Fact]
        public void ShouldContainElements() {
            Assert.Equal(true, tree.Contains(8));
            Assert.Equal(true, tree.Contains(7));
            Assert.Equal(true, tree.Contains(1));
            Assert.Equal(false, tree.Contains(999));
            Assert.Equal(false, tree.Contains(-1));
        }

        [Fact]
        public void ShouldFindElements() {
            Assert.Equal(6, tree.Find(6));
            Assert.Equal(0, tree.Find(999));
        }

        [Fact]
        public void ShouldDeleteElements() {
            Assert.Equal(7, tree.Delete(7));
            Assert.Equal(2, tree.Delete(2));
            Console.WriteLine("After removing 7 and 2: ");
            Assert.Equal(false, tree.Contains(7));
            Assert.Equal(false, tree.Contains(2));
        }

        [Fact]
        public void ShouldCountHeightCorrectly() {
        }
    }
}
