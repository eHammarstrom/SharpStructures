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

        void IDisposable.Dispose() => list.Clear();

        [Fact]
        public void ShouldGiveSize() 
        {
            Assert.Equal(4, list.Count);
            Assert.Equal(4, list.Count());
        }

        [Fact]
        public void ShouldIterate() {
            int i = 0;
            foreach (string s in list) {
                i++;
            }
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

        [Fact]
        public void ShouldCopyToArray() {
            string[] asd = new string[100];
            asd[0] = "asd";
            asd[1] = "das";
            asd[2] = "sda";
            asd[3] = "sad";

            list.CopyTo(asd, 0);

            Assert.Equal(true, asd.Contains("Goodbye"));
        }
    }
}
