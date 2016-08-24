using System;
using Xunit;
using SharpStructures;
using System.Linq;

namespace Tests
{
    public class LinkedList : IDisposable
    {
        LinkedList<string> list;

        public LinkedList() {
            list = new LinkedList<string>();
            list.Add("Hello");
            list.Add("World");
            list.Add("Goodbye");
            list.Add("World");
        }

        void IDisposable.Dispose() {
            list.Dispose();
        }

        [Fact]
        public void ShouldGiveSize() 
        {
            Assert.Equal(4, list.Count);
            Assert.Equal(4, list.Count());
        }

        [Fact]
        public void ShouldIterate() {
            int i = list.Count(); // iterates because our LinkedList does not implement ICollection
            Assert.Equal(4, i);
        }

        [Fact]
        public void ShouldRemoveElements() {
            list.Remove("Goodbye");
            Assert.Equal(true, (list.Count() == 3) ? true : false);
        }

        [Fact]
        public void ShouldContainElement() {
            Assert.Equal(true, list.Contains("Goodbye"));
        }
    }
}
