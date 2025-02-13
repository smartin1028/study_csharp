using System;
using NUnit.Framework;
using WebApplication5.Services;

namespace TestProject1.Services
{
    [TestFixture]
    [TestOf(typeof(MyFileWatcher))]
    public class MyFileWatcherTest
    {

        [Test]
        public void FileSystemWatcherTest()
        {
            var myFileWatcher = new MyFileWatcher();
            myFileWatcher.RunFileWatcher();
            Console.WriteLine("asdasd");
            
        }
    }
}